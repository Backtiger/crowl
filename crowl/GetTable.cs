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
using Tulpep.NotificationWindow;

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
                    //Trace.WriteLine(row.Text);

                    //list.Add(row);                    

                    if (row.Text.Contains("이태현") || row.Text.Contains("김우준"))
                    {
                        Count = Count + 1;                  
                    }
                }               
                Trace.WriteLine(Count.ToString());

                if (Count > 0)
                {
                    popupset(Count);
                }
                
            }
            catch { }
        }
       //<summary>
       //notification 기능 사용 팝업창
       //</summary>
       //
        public void popupset(int Count)
        {
            PopupNotifier Popup = new PopupNotifier();
    
            Popup.TitleText = "라인어스 배정 알리미";
            Popup.ContentText = "기준시간" + DateTime.Now.ToString()+ "|n" + Count + "건 접수되었습니다.";
            Popup.Popup();


        }
    }

}
