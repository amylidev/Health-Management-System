using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Health
{
    public partial class H_E : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBclass db = new DBclass();

            string name = "SELECT 姓名 FROM Patient WHERE 病歷號='" + Session["Num"].ToString() + "'";
            Name.Text = db.ExecuteQuery(name) + "<br>歡迎回來!";
        }

        protected void Button_kp_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "test", "window.open('https://www.cmuh.cmu.edu.tw/HealthEdus/Detail?no=4863')", true);
        }

        protected void Button_ks_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "test", "window.open('https://www.country.org.tw/%E8%A1%9B%E6%95%99%E5%9C%92%E5%9C%B0/%E8%A1%9B%E6%95%99%E5%96%AE%E5%BC%B5/538')", true);
        }

        protected void Button_kms_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "test", "window.open('https://www.hpa.gov.tw/Pages/List.aspx?nodeid=221')", true);
        }

        protected void Button_ptk_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "test", "window.open('https://www.chimei.org.tw/main/cmh_department/59012/info/7320/A7320106.html')", true);
        }

        protected void Button_s_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "test", "window.open('http://www.kmuh.org.tw/www/kmcj/data/10306/6.htm')", true);
        }

        protected void Button_md_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "test", "window.open('https://www.medpartner.club/mediterranean-diet-introduction/')", true);
        }
    }
}