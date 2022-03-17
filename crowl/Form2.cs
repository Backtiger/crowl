using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Windows.Forms;

using System.Threading;


namespace crowl
{
    public partial class Form2 : Form
    {
        ChromeDriver driver = null;
        ChromeDriverService driverService = null;
        ChromeOptions option = new ChromeOptions();
        GetTable gettable = new GetTable();
        
        string id = "22004";
        string pw = "22004";
        int min = 0; 

        public Form2()
        {


            driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            option.AddArgument("disable-gpu"); //그래픽 카드 사용 안함
            //option.AddArgument("headless"); //웹페이지 창 안뜨게 설정

            driver = new ChromeDriver(driverService, option);
            InitializeComponent();


        }


        public void Run()
        {
       
            // int min = Convert.ToInt32(txtminute.Text);                                 //타이머세팅
           
            Login();

            var jub = driver.FindElement(By.XPath("//*[@id='top3_1']"));                  //접수 클릭변수                     
            var close = driver.FindElement(By.ClassName("btn_close"));                    //닫기버튼 클릭 변수설정
            var dam = driver.FindElement(By.XPath("//*[@id='top3_2']"));                  //담당자배정 클릭 변수         

            dam.Click();
            gettable.Jubsu(dam);
            driver.ExecuteScript("arguments[0].click();", close);                         // 담당자배정 창 닫기 버튼 클릭


        }

        private void timer1_Tick(object sender, EventArgs e) //타이머 시간이 돌아오면 해당 메서드 실행
        {
            Run();
        }

        private void timerstart() //타이머 시작값 설정 및 시작
        {
          
            try
            {
                min = Convert.ToInt32(txtminute.Text);

                if (min > 2)
                {
                    timer1.Start();
                    timer1.Interval = 60000 * min;
                    timer1.Enabled = true;
                }
             
            }
            catch (Exception)
            {
                
            }
        }

        public void Refresh()
        {
            try
            {
                Login();

                var jub = driver.FindElement(By.XPath("//*[@id='top3_1']"));                  //접수 클릭변수                     
                var close = driver.FindElement(By.ClassName("btn_close"));                    //닫기버튼 클릭 변수설정
                var dam = driver.FindElement(By.XPath("//*[@id='top3_2']"));                  //담당자배정 클릭 변수         
                dam.Click();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public void Login()
        {
          

            driver.Navigate().GoToUrl("https://lineusadmin.cwit.co.kr/ad/login/form.do"); //url설정

            var element = driver.FindElement(By.XPath("//*[@id='emp_no']"));              //아이디입력 변수
            element.SendKeys(id);

            element = driver.FindElement(By.XPath("//*[@id='pass']"));                    //비밀번호입력 변수
            element.SendKeys(pw);

            element = driver.FindElement(By.XPath("/html/body/div/div/div[1]/button"));   // 로그인버튼클릭 변수
            element.Click();

            driver.SwitchTo().Alert().Accept();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //try
            //{
                
                min = Convert.ToInt32(txtminute.Text);
                if (min > 2)
                {
                    timerstart();
                    Run();
                }
                else { { MessageBox.Show("3분이상의 값을 입력해주세요"); } }
           // }
           //  catch(Exception ex)
           // { MessageBox.Show("3분이상의 값을 입력해주세요");}
        }
    }

}

