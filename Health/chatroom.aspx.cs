using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Health
{
    public partial class chatroom : System.Web.UI.Page
    {
        DBclass db = new DBclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            string n = "SELECT 姓名 FROM Patient WHERE 病歷號='" + Session["Num"].ToString() + "'";
            Name.Text = db.ExecuteQuery(n) + "<br>歡迎回來!";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["doctorID"] = "1";
            Response.Redirect("message.aspx?doctorID=1");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["doctorID"] = "5";
            Response.Redirect("message.aspx?doctorID=5");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["doctorID"] = "7";
            Response.Redirect("message.aspx?doctorID=7");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session["doctorID"] = "10";
            Response.Redirect("message.aspx?doctorID= 10");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Session["doctorID"] = "11";
            Response.Redirect("message.aspx?doctorID=11");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Session["doctorID"] = "12";
            Response.Redirect("message.aspx?doctorID=12");
        }
    }
}