using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;

namespace crowl
{
    public partial class Form1 : Form
    {
        ChromeDriver driver = new ChromeDriver();
        ChromeDriverService driverService = null;
        ChromeOptions options = new ChromeOptions();
        List<string> Lsrc = new List<string>();//이미지 url 저장변수
        int i = 0; //배열 인덱스 값 설정 변수
            
        public Form1()
        {

            
            driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            options.AddArgument("disable-gpu"); //드라이버설정값

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string pw = txtPW.Text;

            driver = new ChromeDriver(driverService, options);
            driver.Navigate().GoToUrl("https://www.naver.com"); //웹사이트링크

            var element = driver.FindElement(By.XPath("//*[@id=\"account\"]/a")); //""를''로바꿔도됨 혹은 따음표 앞에 \표시로바꾸면됨
            element.Click();                                                      //버튼 클릭

            element = driver.FindElement(By.XPath("//*[@id='id']"));  //id 입력 
            element.SendKeys(id); // sendkey= 값을 넣고 보낼수 있는 메서드 텍스트말고 특정 키도 됨

            element = driver.FindElement(By.XPath("//*[@id='pw']"));
            element.SendKeys(pw);

            element = driver.FindElement(By.XPath("//*[@id='log.login']"));
            element.Click();
        }

        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strUrl = "https://www.google.com/search?q=" +txtSearch.Text+ "&source=lnms&tbm=isch";

            driver = new ChromeDriver(driverService, options);
            driver.Navigate().GoToUrl(strUrl);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

           // driver.ExecuteAsyncScript("windows.crollBy(0,10000)");

            foreach (IWebElement item in driver.FindElements(By.ClassName("rg_i")))
            {
                if (item.GetAttribute("src") != null)
                    Lsrc.Add(item.GetAttribute("src"));
               
            }

            lblTotal.Text = "/" + Lsrc.Count.ToString();
            this.Invoke(new Action(delegate ()
            {
                foreach (string strsrc in Lsrc)
                {
                    try
                    {
                        i++;

                        ChangeImage(Lsrc[i]);
                        txtNow.Text = i.ToString();
                        Refresh();
                        Thread.Sleep(50);
                    }
                    catch (Exception) { }
                }
                
            }));
            
            
        }
        private void ChangeImage(string base64)
        {
            var base64data = Regex.Match(base64, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            var binData = Convert.FromBase64String(base64data);

            using (var stream = new MemoryStream(binData))
            {
                if (stream.Length == 0)
                {
                    pictureBox1.Load(base64);
                    txtNow.Text = i.ToString();
                    textBox4.Text = base64;
                }
                else
                {
                    var img = Image.FromStream(stream);
                    pictureBox1.Image = img;
                    textBox4.Text = base64;
                }
            }
              
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {

            this.Invoke(new Action(delegate ()
            {
                i--;
                ChangeImage(Lsrc[i]);
                txtNow.Text = i.ToString();
            }));
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(delegate ()
            {
                i++;
                ChangeImage(Lsrc[i]);
                txtNow.Text = i.ToString();

            }            
            ));

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(delegate ()
            {
                i = int.Parse(txtNow.Text);

                ChangeImage(Lsrc[i]);
                txtNow.Text = i.ToString();

            }
           ));
        }
    }
}
