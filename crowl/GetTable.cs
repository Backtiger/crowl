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
        
        public (List<IWebElement> LIST,int COUNT) Jubsu(IWebElement table)
        {
         
            try
            {    
                var tbody = table.FindElement(By.XPath("//*[@id='asListBody']"));   //담당자배정 xpath
                var rows = tbody.FindElements(By.TagName("tr"));
          

                foreach (IWebElement row in rows)
                {
                    Trace.WriteLine(row.Text);

                    list.Add(row);                                                  //라인어스 웹 테이블 값 list넣기           

                    if (row.Text.Contains("오혜빈") || row.Text.Contains("김우준")) //배정 테이블 조회 할사람 이름 세팅
                    {
                        Count = Count + 1;                  
                    }
                }               
              

                if (Count > 0)
                {
                  //popupset(Count);                                                //notification기능 사용한 팝업
                    popupshow(Count);
                }
                Trace.WriteLine(Count);
                
            }
            catch { }
            // Tuple 사용해서 list,Count값 반환
            return (list, Count);
        }
       
        //<summary>
        //notification 기능 사용 팝업창
        //</summary>
        //
        //public void popupset(int Count)
        //{
        //    PopupNotifier Popup = new PopupNotifier();
    
           
        //    Popup.TitleText = "라인어스 담당자 배정 알리미";
        //    Popup.ContentText = "기준시간" + DateTime.Now.ToString()+"\n" + Count + "건 접수되었습니다.";
        //    Popup.Popup();
        
        //}


        public void popupshow(int Count)
        {
            
            string msg = "기준시간" + DateTime.Now.ToString() + "\n" + Count + "건 접수되었습니다.";
            Trace.WriteLine(msg);
            frmPopup frmPopup = new frmPopup();
            frmPopup.showPopup(msg);
           

        }

    }

}
