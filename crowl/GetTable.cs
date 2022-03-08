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

namespace crowl
{
    class GetTable
    {
        ChromeDriver driver = null;
        List<IWebElement> list = new List<IWebElement>();
        int Count = 0;
        public void Jubsu(IWebElement table)
        {
         
            try
            {
               

           

                var tbody = table.FindElement(By.XPath("//*[@id='asListBody']")); //담당자배정 xpath
                var rows = tbody.FindElements(By.TagName("tr"));
          

                foreach (IWebElement row in rows)
                {
                    Trace.WriteLine(row.Text);

                    list.Add(row);                    

                    if (row.Text.Contains("이태현") || row.Text.Contains("김우준"))
                    {
                        Count = Count + 1;                  
                    }
                }
               
                Trace.WriteLine(Count.ToString());


            }
            catch { }
        }
    }
}
