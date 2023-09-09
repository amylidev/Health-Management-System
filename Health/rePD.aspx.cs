using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Health
{
    public partial class rePD : System.Web.UI.Page
    {
        DBclass DB = new DBclass();
        string str;
        string y;
        protected void Page_Load(object sender, EventArgs e)
        {

            string n = "SELECT 姓名 FROM Patient WHERE 病歷號='" + Session["Num"].ToString() + "'";
            N.Text = DB.ExecuteQuery(n) + "<br>歡迎回來!";

            str = Session["Num"].ToString();
            y = "SELECT 姓名 FROM Patient WHERE 病歷號='" + str + "' ";
            name.Text = DB.ExecuteQuery(y);
            bday.Text = DB.ExecuteQuery("SELECT 生日 FROM Patient WHERE 病歷號='" + str + "' ");
            pid.Text = DB.ExecuteQuery("SELECT 身份證字號 FROM Patient WHERE 病歷號='" + str + "' ");
            sex.Text = DB.ExecuteQuery("SELECT 性別 FROM Patient WHERE 病歷號='" + str + "' ");

            height.Text = DB.ExecuteQuery("SELECT 身高 FROM Patient WHERE 病歷號='" + str + "' ");
            weight.Text = DB.ExecuteQuery("SELECT 體重 FROM Patient WHERE 病歷號='" + str + "' ");
            phone.Text = DB.ExecuteQuery("SELECT 電話 FROM Patient WHERE 病歷號='" + str + "' ");
            mail.Text = DB.ExecuteQuery("SELECT 電子郵件 FROM Patient WHERE 病歷號='" + str + "' ");
            highrisk.Text = DB.ExecuteQuery("SELECT 三高 FROM Patient WHERE 病歷號='" + str + "' ");
            cardio.Text = DB.ExecuteQuery("SELECT 心血管疾病 FROM Patient WHERE 病歷號='" + str + "' ");
            diabete.Text = DB.ExecuteQuery("SELECT 糖尿病 FROM Patient WHERE 病歷號='" + str + "' ");
        }

        protected void info_Click(object sender, EventArgs e)
        {
            string s = "UPDATE Patient SET  姓名='" + name.Text + "'," +
                " 身份證字號='" + pid.Text + "' , 性別='" + sex.Text + "' , 生日='" + bday.Text + "' ," +
                " 身高='" + height.Text + "' , 體重='" + weight.Text + "',電話='" + phone.Text + "' ," +
                "電子郵件='" + mail.Text + "' , 三高='" + highrisk.Text + "' , 心血管疾病='" + cardio.Text + "' , 糖尿病='" + diabete.Text + "' WHERE 病歷號='" + str + "' ";
            show.Text = DB.ExecuteUpdate(s);
            show.Visible = true;

            if (bday.Text != DB.ExecuteQuery("SELECT 生日 FROM Patient WHERE 病歷號='" + str + "' "))
            {
                Response.Write("<Script language='JavaScript'>alert('您即將修改出生日期！');</Script>");
            }
        }
    }
}