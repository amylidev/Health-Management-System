using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Health
{
    public partial class appointment : System.Web.UI.Page
    {
        DBclass db = new DBclass();
        string date;
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = "SELECT 姓名 FROM Patient WHERE 病歷號='" + Session["Num"].ToString() + "'";
            Name.Text = db.ExecuteQuery(name) + "<br>歡迎回來!";
        }

        protected void Button_send_Click(object sender, EventArgs e)
        {
            DateTime date = Calendar1.SelectedDate;
            if (DropDownList_fre.SelectedValue == "1")
                date = date.AddMonths(1);
            else if (DropDownList_fre.SelectedValue == "2")
                date = date.AddMonths(2);
            else if (DropDownList_fre.SelectedValue == "3")
                date = date.AddMonths(3);
            else
                date = date.AddMonths(6);

            string s = "INSERT INTO MR VALUES( '"+ Session["Num"].ToString() +"' , '" + TextBox_date.Text + "','" + DropDownList_fre.SelectedValue
               + "','" + date.ToString("yyyy/MM/dd") + "')";
            Label1.Text = db.ExecuteUpdate(s);
            Label1.Visible = true;
            Label_text.Text = "回診日期為 " + date.ToString("yyyy/MM/dd");
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox_date.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
        }
    }
}