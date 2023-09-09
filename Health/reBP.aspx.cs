using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Health
{
    public partial class reBP : System.Web.UI.Page
    {
        string Patientid;
        DBclass DB = new DBclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            string n = "SELECT 姓名 FROM Patient WHERE 病歷號='" + Session["Num"].ToString() + "'";
            N.Text = DB.ExecuteQuery(n) + "<br>歡迎回來!";

            //個人資料修改
            Patientid = Session["Num"].ToString();
        }

        protected void info_Click(object sender, EventArgs e)
        {
            string dbp = "SELECT 舒張壓 FROM BP  WHERE 病歷號='" + Patientid + "' AND 日期='" + selecttime.Text +
                "' AND 時間='" + datelist.SelectedValue.ToString() + "' ";
            dbp = DB.ExecuteQuery(dbp);
            string hbp = "SELECT 收縮壓 FROM BP  WHERE 病歷號='" + Patientid + "' AND 日期='" + selecttime.Text +
                "' AND 時間='" + datelist.SelectedValue.ToString() + "' ";
            hbp = DB.ExecuteQuery(hbp);

            string s = "UPDATE BP SET 舒張壓='" + ndiapressure.Text + "' ,  修改前舒張壓='" + dbp + "' , 收縮壓='" + nsyspressure.Text + "' , 修改前收縮壓='" + hbp + "' , 時間='" + newtime.Text +
                "'  ,修改時間='" + DateTime.Now.ToString("yyyy-MM-dd") + "'   WHERE 病歷號='" + Patientid + "' AND 日期='" + selecttime.Text +
                "' AND 時間='" + datelist.SelectedValue.ToString() + "' ";
            sucess.Text = "狀態:" + DB.ExecuteUpdate(s);

            if (datelist.SelectedValue.ToString() != newtime.Text)
            {
                Response.Write("<Script language='JavaScript'>alert('請注意！您即將修改血壓資料之時間！');</Script>");
            }
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            selecttime.Text = changedate.SelectedDate.Date.Year.ToString();
            selecttime.Text += "/" + changedate.SelectedDate.Date.Month.ToString();
            selecttime.Text += "/" + changedate.SelectedDate.Date.Day.ToString();
            show.Text = "";


            string change = "SELECT 時間 FROM BP WHERE 病歷號='" + Patientid + "'AND 日期='" + selecttime.Text + "' ";
            ArrayList pdatetime = new ArrayList();
            pdatetime = DB.ExecuteQuery_array(change);
           
            if (show.Text.Equals("Error") || show.Text.Equals("找不到資料"))
            {
                show.Text += "該天無看診資料";
            }
            for (int x = 0; x < pdatetime.Count; x++)
            {
                datelist.Items.Insert(x, pdatetime[x].ToString());
            }
        }

        protected void datelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            newtime.Text = datelist.SelectedItem.Text;
        }
    }
}