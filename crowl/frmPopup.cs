using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crowl
{
    public partial class frmPopup : Form
    {
        public EventHandler Open;
        GetTable get = new GetTable();
        private frmPopup.enmAction action;
        private int x, y;

        public frmPopup()
        {
            InitializeComponent();
            
        }

        public enum enmAction
        {
            wait,
            start,
            close
            
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = enmAction.close;
        }

        //animation 효과
        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:          //wati일때 아래시간 만큼 작동
                    timer1.Interval = 10000;  //시간설정 5초
                    action = enmAction.close;
                break;

                case enmAction.start:
                    timer1.Interval = 1;
                    action = enmAction.start;
                    this.Opacity += 0.1;      //투명도 추가

                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = enmAction.wait;
                        }
                    }
                break;
                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0)
                    {
                        base.Close();
                    }

                    break;

            }
        }

        public  void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Refresh();
        }

        public void showPopup(string msg)
        {
            this.Opacity = 0.0;                                                           //현재 폼 투명도 설정 1 = 100%
            this.StartPosition = FormStartPosition.Manual;                                //Manual로 설정하면 추후에 설정하는 Location값을 시작위치로 사용
            string fname;

            for (int i = 0; i < 10; i++)
            {
                fname = "alert" + i.ToString();                                            //폼이름설정
                frmPopup frm = (frmPopup)Application.OpenForms[fname];                     //fname의 폼 생성

                if (frm == null)
                {
                    this.Name = fname;                                                      //팝업창 여러개 뜰시 차례대로 팝업 겹치지 않게하는 세팅
                    
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width;           //기본디스플레이(내 컴퓨터 화면) - 50
                    this.y = Screen.PrimaryScreen.WorkingArea.Height  * i;                  //기본디스플레이(내 컴퓨터 화면) y축 세팅
                    //this.y = Screen.PrimaryScreen.Bounds.Height / 2 - this.Size.Height /2; 

                    this.Location = new Point(this.x, this.y);                              //시작위치 Location값 설정

                    break;
                }

            }

            this.lbmsg.Text = msg;            //표시할 텍스트 메세지 값 입력
            this.Show();                      //폼 띄우기
            this.action = enmAction.start;
            this.timer1.Interval = 1;         //시간 세팅
            timer1.Start();                   //타이머 시작


        }
     

    }
}
