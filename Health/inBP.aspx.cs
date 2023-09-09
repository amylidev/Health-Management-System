using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Health
{
    public partial class inBP : System.Web.UI.Page
    {
        DBclass db = new DBclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            string n = "SELECT 姓名 FROM Patient WHERE 病歷號='" + Session["Num"].ToString() + "'";
            Name.Text = db.ExecuteQuery(n) + "<br>歡迎回來!";
            TextBox_time.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox_date.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
        }

        protected void Button_send_Click(object sender, EventArgs e)
        {
            string time = TextBox_time.Text;
            string s = "INSERT INTO BP VALUES( '" + Session["Num"].ToString() + " ' , '" + TextBox_date.Text + "','" + TextBox_time.Text
            + "','" + TextBox_DBP.Text + "',NULL,'" + TextBox_SBP.Text + "',NULL,NULL)";
            Label1.Text = db.ExecuteUpdate(s);
            Label1.Visible = true;
            Label_result.Text = "日期:" + TextBox_date.Text + "<br>" + "時間:" + time + "<br>" + "舒張壓:" + TextBox_DBP.Text + "<br>" + "收縮壓:" + TextBox_SBP.Text;
            TextBox_date.Text = "";          
            TextBox_DBP.Text = "";
            TextBox_SBP.Text = "";
        }
    }
}