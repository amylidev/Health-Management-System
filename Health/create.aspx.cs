using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Health
{
    public partial class create : System.Web.UI.Page
    {
        string str;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // First time actions
            {
                for (int i = 0; i < 100; i++)
                {
                    DropDownList_year.Items.Add((DateTime.Now.Year - i).ToString());
                }
                for (int i = 0; i < 12; i++)
                {
                    DropDownList_month.Items.Add((12 - i).ToString());
                }
                for (int i = 0; i < 31; i++)
                {
                    DropDownList_day.Items.Add((31 - i).ToString());
                }
                DropDownList_year.SelectedValue = Convert.ToString(DateTime.Now.Year);
                DropDownList_month.SelectedValue = Convert.ToString(DateTime.Now.Month);
                DropDownList_day.SelectedValue = Convert.ToString(DateTime.Now.Day);
            }
        }
        protected void DropDownList_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calendar1.TodaysDate = new DateTime(Convert.ToInt32(DropDownList_year.SelectedValue), Convert.ToInt32(DropDownList_month.SelectedValue) , Convert.ToInt32(DropDownList_day.SelectedValue) ); // 2. Calendar.VisibleDate
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DropDownList_year.SelectedValue = Convert.ToString(Calendar1.SelectedDate.Year);
            DropDownList_month.SelectedValue = Convert.ToString(Calendar1.SelectedDate.Month);
            DropDownList_day.SelectedValue = Convert.ToString(Calendar1.SelectedDate.Day);
        }
        protected void Button_confirm_Click(object sender, EventArgs e)
        {
            DBclass db = new DBclass();
            string b, h, s;
            if (CheckBoxList1.Items[0].Selected || CheckBoxList1.Items[1].Selected || CheckBoxList1.Items[2].Selected)
                b = "是";
            else
                b = "否";
            
            if (CheckBoxList1.Items[3].Selected)
                h = "是";
            else
                h = "否";
            
            if (CheckBoxList1.Items[4].Selected)
                s = "是";
            else
                s = "否";
            
            if (CheckBoxList1.Items[5].Selected)
            {
                b = "否" ; h = "否";  s = "否";
            }

            str = "INSERT INTO Patient (姓名, 身份證字號, 性別, 生日, 電話, 電子郵件, 身高, 體重, 三高, 心血管疾病, 糖尿病) VALUES( '" + TextBox_name.Text + "','" + TextBox_id.Text + "'," +
                "'" + DropDownList_gender.SelectedValue + "','" + (DropDownList_year.SelectedValue+"/"+DropDownList_month.SelectedValue+"/"+DropDownList_day.SelectedValue) + "' ," +
                "'" +TextBox_phone.Text+ "', '" + TextBox_mail.Text + "' , '" + TextBox_height.Text + "' , '" + TextBox_weight.Text + "' , '" + b + "' , '" + h + "' , '" + s + "' )";
            label.Text = db.ExecuteUpdate(str);
            label.Visible = true;

            if (label.Text.Equals("輸入成功"))
            {
                string d = "SELECT 生日 FROM Patient WHERE 身份證字號='" + TextBox_id.Text + "' ";
                d = Convert.ToDateTime(db.ExecuteQuery(d)).ToString("yyyyMMdd") ;
                string n = "SELECT 病歷號 FROM Patient WHERE 身份證字號='" + TextBox_id.Text + "' ";
                str = "INSERT INTO Account (病歷號, 帳號, 密碼) VALUES( '" + db.ExecuteQuery(n) + " ' , '" + TextBox_id.Text + "','" + d + "' )";
                db.ExecuteUpdate(str);
            }
            else
                label.Text = "輸入失敗";
        }
    }
}