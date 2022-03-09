using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Threading;
using Tulpep.NotificationWindow;

namespace crowl
{
    public partial class Form2 : Form 
    {
        ChromeDriver driver = null;
        ChromeDriverService driverService = null;
        ChromeOptions option = new ChromeOptions();
        GetTable gettable = new GetTable();

        public Form2()
        {
            driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            option.AddArgument("disable-gpu");
            // option.AddArgument("headless");

            driver = new ChromeDriver(driverService, option);
            InitializeComponent();


        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string id = "22009";
            string pw = "22009";

            driver.Navigate().GoToUrl("https://lineusadmin.cwit.co.kr/ad/login/form.do"); //url설정

            var element = driver.FindElement(By.XPath("//*[@id='emp_no']")); //아이디입력 변수
            element.SendKeys(id);

            element = driver.FindElement(By.XPath("//*[@id='pass']")); //비밀번호입력 변수
            element.SendKeys(pw);

            element = driver.FindElement(By.XPath("/html/body/div/div/div[1]/button"));// 로그인버튼클릭 변수
            element.Click();

            driver.SwitchTo().Alert().Accept(); //웹페이지 alret창 확인 버튼                       

            var jub = driver.FindElement(By.XPath("//*[@id='top3_1']")); //접수 클릭변수                     
            var close = driver.FindElement(By.ClassName("btn_close"));//닫기버튼 클릭 변수설정
            var dam = driver.FindElement(By.XPath("//*[@id='top3_2']")); //담당자배정 클릭 변수

            jub.Click();  
            gettable.Jubsu(jub);
            driver.ExecuteScript("arguments[0].click();", close); //클릭버튼 사용불가시 자바 스크립트 명령어로 사용대체

            dam.Click();
            gettable.Jubsu(dam);
            driver.ExecuteScript("arguments[0].click();", close);

            //element = driver.FindElement(By.XPath("//*[@id='asListLayer']/div[1]/button"));
            //element.Click();
            //gettable.Jubsu(dam, element);

           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

    
   

        //public void table()
        //{
        //    int Count = 0;
        //    try
        //    {  
        //        var element = driver.FindElement(By.XPath("//*[@id='top3_1']"));
        //        element.Click();

        //        List<IWebElement> list = driver.FindElements(By.CssSelector("body div div div div table tbody tr ")).ToList(); //cssselect 활용 table값 불러오기
        //        //var table = driver.FindElement(By.XPath("//*[@id='asListLayer]/div[1]/div/table"));
        //        //var tbody = table.FindElement(By.TagName("tbody"));
        //        //var trs = tbody.FindElements(By.TagName("tr"));
        //        foreach (IWebElement lt in list)
        //        {
        //            Trace.WriteLine(lt.Text);

        //            if (lt.Text.Contains("챠트") || lt.Text.Contains("원무") || lt.Text.Contains("김우준"))
        //            {
        //                 Count =+ 1;   
        //            }                    
        //            //dataGridView1.Rows.Add(lt.Text);
        //        }
        //        MessageBox.Show("챠트" + Count + " 건 접수");


        //    }
        //    catch { }            
        //}
        //    public void HtmlTable()
        //    {
        //        int Count = 0;
        //        try
        //        {

        //            element.Click();


        //            var tbody = driver.FindElement(By.XPath("//*[@id='asListBody']")); //담당자배정 xpath
        //            var rows = tbody.FindElements(By.TagName("tr"));


        //            foreach (IWebElement row in rows)
        //            {
        //                Trace.WriteLine(row.Text);
        //                dataGridView1.Rows.Add(row.Text);
        //                if (row.Text.Contains("이태현")||row.Text.Contains("김우준"))
        //                {
        //                   Count = Count+1;
        //                }
        //            }
        //            MessageBox.Show("emr담당자배정" + Count + "건 있습니다!");
        //        }
        //        catch { }
        //    }

    }

}

