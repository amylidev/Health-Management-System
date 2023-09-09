using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Health
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Num"] = "";
        }

        protected void Button_login_Click(object sender, EventArgs e)
        {
            //string d = DateTime.ParseExact(TextBox_account.Text, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
            DBclass db = new DBclass();
            string a = "SELECT 帳號 FROM Account WHERE 帳號='" + TextBox_account.Text + "' ";
            a = db.ExecuteQuery(a);
            string p = "SELECT 密碼 FROM Account WHERE 密碼='" + TextBox_password.Text + "' ";
            p = db.ExecuteQuery(p);
            string str = "SELECT 病歷號 FROM Account WHERE 帳號='" + TextBox_account.Text + "' AND 密碼='" + TextBox_password.Text + "'";
            str = db.ExecuteQuery(str);

            if (a != "找不到資料" && a != "Error" && p != "找不到資料" && p != "Error" && str != "找不到資料" && str != "Error")
            {
                Session["Num"] = str;
                Response.Redirect("index.aspx?num=" + str);
            }
            else if (a == "找不到資料" || a == "Error")
            {
                text.Visible = true;
                text.Text = "帳號輸入錯誤!!";
            }
            else if (p == "找不到資料" || p == "Error")
            {
                text.Visible = true;
                text.Text = "密碼輸入錯誤!!";
            }
            else
            {
                text.Visible = true;
                text.Text = "輸入錯誤!";
            }
        }
    }
}