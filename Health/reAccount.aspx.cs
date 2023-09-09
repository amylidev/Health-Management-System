using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Health
{
    public partial class reAccount : System.Web.UI.Page
    {
        DBclass db = new DBclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = "SELECT 姓名 FROM Patient WHERE 病歷號='" + Session["Num"].ToString() + "'";
            Name.Text = db.ExecuteQuery(name) + "<br>歡迎回來!";
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "更改帳號")
            {
                newaccount.Visible = true;
                TextBox_na.Visible = true;
                Button_con1.Visible = true;

                newpassword.Visible = false;
                TextBox_np.Visible = false;
                Button_con2.Visible = false;
                Button_confirm.Visible = false;
            }
            else if (DropDownList1.SelectedValue == "更改密碼")
            {
                newpassword.Visible = true;
                TextBox_np.Visible = true;
                Button_con2.Visible = true;

                newaccount.Visible = false;
                TextBox_na.Visible = false;
                Button_con1.Visible = false;
                Button_confirm.Visible = false;
            }
            else
            {
                newaccount.Visible = true;
                TextBox_na.Visible = true;
                newpassword.Visible = true;
                TextBox_np.Visible = true;
                Button_confirm.Visible = true;

                Button_con1.Visible = false;
                Button_con2.Visible = false;
            }
        }

        protected void Button_con1_Click(object sender, EventArgs e)
        {
            string a = "UPDATE Account SET 帳號='" + TextBox_na.Text + "'  WHERE 病歷號='" + Session["Num"].ToString() + "'";
            text.Text = "帳號" + db.ExecuteUpdate(a);
        }

        protected void Button_con2_Click(object sender, EventArgs e)
        {
            DBclass db = new DBclass();
            string p = "UPDATE Account SET 密碼='" + TextBox_np.Text + "'  WHERE 病歷號='" + Session["Num"].ToString() + "'";
            text.Text = "密碼" + db.ExecuteUpdate(p);
        }

        protected void Button_confirm_Click(object sender, EventArgs e)
        {
            DBclass db = new DBclass();
            string ap = "UPDATE Account SET 帳號='" + TextBox_na.Text + "' , 密碼='" + TextBox_np.Text + "'  WHERE 病歷號='" + Session["Num"].ToString() + "'";
            text.Text = "帳號及密碼" + db.ExecuteUpdate(ap);
        }
    }
}