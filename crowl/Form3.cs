using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using HtmlAgilityPack;

namespace crowl
{
    public partial class Form3 : Form
    {
        protected ChromeDriverService _driverService = null;
        protected ChromeOptions _options = null;
        protected ChromeDriver _driver = null;


        public Form3()
        {
            InitializeComponent();

            try
            {
                _driverService = ChromeDriverService.CreateDefaultService();
                _driverService.HideCommandPromptWindow = true;

                _options = new ChromeOptions();
                _options.AddArgument("disable-gpu");
            }
            catch (Exception exc)
            {
                Trace.WriteLine(exc.Message);
            }
        }

    
      

        private void buttonSearch_Click_1(object sender, EventArgs e)
        {
            try
            {
                _driver = new ChromeDriver(_driverService, _options);

                _driver.Navigate().GoToUrl("https://ko.wikipedia.org/wiki/%EB%A7%88%EC%9D%B4%ED%81%AC%EB%A1%9C%EC%86%8C%ED%94%84%ED%8A%B8_%EB%B9%84%EC%A3%BC%EC%96%BC_%EC%8A%A4%ED%8A%9C%EB%94%94%EC%98%A4");

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

                var table = _driver.FindElement(By.XPath("//*[@id='mw-content-text']/div[1]/table[2]"));
                var tbody = table.FindElement(By.TagName("tbody"));
                var trs = tbody.FindElements(By.TagName("tr"));
                foreach (var tr in trs)
                {
                    var ths = tr.FindElements(By.TagName("th"));
                    foreach (var th in ths)
                    {
                        Trace.WriteLine("th: " + th.Text);
                    }

                    var tds = tr.FindElements(By.TagName("td"));
                   
                    foreach (var td in tds)
                    {
                        Trace.WriteLine("td: " + td.Text);
                        //dataGridView1.Columns.Add(td.Text);
                    }
                }
            }
            catch (Exception exc)
            {
                Trace.WriteLine(exc.Message);
            }
        }
    }
    }

