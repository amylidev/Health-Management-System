using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Health
{
    public partial class message : System.Web.UI.Page
    {
        DBclass db = new DBclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DBclass db = new DBclass();
                string s1 = "SELECT 姓名 FROM Staff WHERE 員工代號 ='" + Session["doctorID"] + "'";
                s1 = db.ExecuteQuery(s1);
                string s2 = "SELECT 姓名 FROM Patient WHERE 病歷號 ='" + Session["Num"] + "'";
                s2 = db.ExecuteQuery(s2);
                Session["doctorName"] = s1;
                Session["PatientName"] = s2;
                Label_txt.Text += "歡迎來到" + s1 + "醫師的互動專區~有甚麼可以幫你解決的嗎?";
                Application["content"] = "";
                string s3 = "SELECT 留言時間,識別,留言內容,留言時間 FROM Message WHERE 病歷號='" + Session["Num"] + "'AND 員工代號='"
               + Session["doctorID"] + "'AND (識別=12 OR 識別=21)";
                ArrayList MessArrayList = db.ExecuteQuery_array(s3);

                for (int i = 0; i < MessArrayList.Count; i = i + 4)
                {
                    string DATE = "";
                    string TIME = "";
                    DATE = MessArrayList[i].ToString().Substring(0, 4) + "/";
                    if (MessArrayList[i].ToString().Substring(6, 1) == "/")
                    {
                        DATE += MessArrayList[i].ToString().Substring(5, 1) + "/";
                        if (MessArrayList[i].ToString().Substring(8, 1) == "/")
                        {
                            DATE += "0" + MessArrayList[i].ToString().Substring(7, 1);
                            TIME = MessArrayList[i + 3].ToString().Substring(9, 8);
                        }
                        else
                        {
                            DATE += MessArrayList[i].ToString().Substring(7, 2);
                            TIME = MessArrayList[i + 3].ToString().Substring(10, 8);
                        }
                    }
                    else
                    {
                        DATE += MessArrayList[i].ToString().Substring(5, 2) + "/";
                        if (MessArrayList[i].ToString().Substring(9, 1) == "/")
                        {
                            DATE += "0" + MessArrayList[i].ToString().Substring(8, 1);
                            TIME = MessArrayList[i + 3].ToString().Substring(10, 8);
                        }
                        else
                        {
                            DATE += MessArrayList[i].ToString().Substring(8, 2);
                            TIME = MessArrayList[i + 3].ToString().Substring(11, 8);
                        }

                    }
                    MessArrayList[i] = DATE;
                    MessArrayList[i + 3] = TIME;
                }
                for (int i = 0; i < MessArrayList.Count; i = i + 4)
                {
                    for (int j = MessArrayList.Count - 1; j > i; j--)
                    {
                        if (MessArrayList[i].ToString() == MessArrayList[j].ToString())
                        {
                            MessArrayList[j] = "";
                        }
                    }
                }

                for (int i = 0; i < MessArrayList.Count; i = i + 4)
                {
                    if (MessArrayList[i].ToString() != "")
                        Application["content"] += MessArrayList[i].ToString() + "\n";
                    else
                        Application["content"] += MessArrayList[i].ToString();

                    if (Int32.Parse(MessArrayList[i + 1].ToString()) == 21)
                        Application["content"] += Session["doctorName"] + "醫師(" + MessArrayList[i + 3] + "):" + MessArrayList[i + 2] + "\n";
                    else
                        Application["content"] += Session["PatientName"] + "(" + MessArrayList[i + 3] + "):" + MessArrayList[i + 2] + "\n";
                }

                if (Application["content"] == null)
                {
                    Application["content"] = TextBox_messageboard.Text;
                }
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //Timer,每秒更新一次聊天內容
            TextBox_messageboard.Text = Application["content"].ToString();
            if (Application["content"] != null)
                Timer1.Interval = 10000;
            else
                Timer1.Interval = 1000;
        }
        protected void Button_send_Click(object sender, EventArgs e)
        {
            if (TextBox_enter.Text != "")
            {
                Application["content"] += Session["PatientName"] + "(" + DateTime.Now.ToShortTimeString() + "):" + TextBox_enter.Text + "\n";
                DBclass db = new DBclass();
                string s = "INSERT INTO Message VALUES( '" + Session["doctorID"] + "','" + Session["Num"] + "','"
                    + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + TextBox_enter.Text + "','12')";
                s = db.ExecuteUpdate(s);

                TextBox_enter.Text = "";
            }
        }
    }
}
