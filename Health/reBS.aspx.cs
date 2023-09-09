using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Health
{
    public partial class reBS : System.Web.UI.Page
    {
        string Patientid;
        DBclass DB = new DBclass();
        ArrayList pdatetime = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            string n = "SELECT 姓名 FROM Patient WHERE 病歷號='" + Session["Num"].ToString() + "'";
            N.Text = DB.ExecuteQuery(n) + "<br>歡迎回來!";

            //個人資料修改
            
            Patientid = Session["Num"].ToString() ;
            //Sbefore.Text = DB.ExecuteQuery("SELECT 血糖值 FROM BS WHERE 病歷號='" + Session["Num"].ToString() + "'");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "UPDATE BS SET 血糖值='" + bsugar.Text + "', 時間='" + newtime.Text + "'  , 修改前血糖值='" + Sbefore.Text +
                "'  ,修改時間='" + DateTime.Now.ToString("yyyy-MM-dd") + "'   WHERE 病歷號='" + Patientid + "' AND 日期='" + selecttime.Text +
                "' AND 時間='" + datelist.SelectedValue.ToString() + "' ";

            sucess.Text =  DB.ExecuteUpdate(s);

            if (datelist.SelectedValue.ToString() != newtime.Text)
            {
                Response.Write("<Script language='JavaScript'>alert('請注意！您即將修改血糖資料之時間！');</Script>");
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            selecttime.Text = changedate.SelectedDate.Date.Year.ToString();
            selecttime.Text += "/" + changedate.SelectedDate.Date.Month.ToString();
            selecttime.Text += "/" + changedate.SelectedDate.Date.Day.ToString();
            show.Text = "";


            string change = "SELECT 時間 FROM BS WHERE 病歷號='" + Patientid + "'AND 日期='" + selecttime.Text + "' ";
            pdatetime = DB.ExecuteQuery_array(change);
            
            if (show.Text.Equals("Error") || show.Text.Equals("找不到資料"))
            {
                show.Text = "該天無血糖資料";
            }
            for (int x = 0; x < pdatetime.Count; x++)
            {
                datelist.Items.Insert(x, pdatetime[x].ToString());
            }
        }
        protected void datelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            newtime.Text = datelist.SelectedItem.Text;
            Sbefore.Text = DB.ExecuteQuery("SELECT 血糖值 FROM BS WHERE 病歷號='" + Session["Num"].ToString() + "'AND 日期 = '"  + selecttime.Text + "' AND  時間 = '" + newtime.Text + "' ");
        }
    }
}
