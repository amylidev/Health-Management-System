using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using System.Text;

namespace Health
{
    public partial class forget : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_confirm_Click(object sender, EventArgs e)
        {
            DBclass db = new DBclass();

            string email = "SELECT 電子郵件 FROM Patient WHERE 生日='" + TextBox_birth.Text + "' AND 身份證字號='" + TextBox_id.Text + "'";
            email = db.ExecuteQuery(email);
            string n = "SELECT 病歷號 FROM Patient WHERE 生日='" + TextBox_birth.Text + "' AND 身份證字號='" + TextBox_id.Text + "'";
            n = db.ExecuteQuery(n);

            if (email == "找不到資料" || email == "Error")
            {
                text.Visible = true;
                text.Text = "資料驗證錯誤!!";
            }
            else
            {
                string str = "SELECT 姓名 FROM Patient WHERE 病歷號='" + n + "' ";
                str = db.ExecuteQuery(str);
                string a = "SELECT 帳號 FROM Account WHERE 病歷號='" + n + "' ";
                a = db.ExecuteQuery(a);
                string p = "SELECT 密碼 FROM Account WHERE 病歷號='" + n + "' ";
                p = db.ExecuteQuery(p);

                string account = "";
                string password = "";

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com"; //設定 server
                client.Port = 587; //hrer is gmail port
                client.Credentials = new NetworkCredential(account , password);
                client.EnableSsl = true;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(account, "技術人員", Encoding.UTF8);
                mail.To.Add(email);
                mail.Subject = "身分確認信件";
                mail.SubjectEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Body = str + "  先生/女士 您好:<br><br> 以下是您的帳號密碼<br>帳號: " + a +"<br>密碼: " + p + "<br><br>請您牢記，謝謝。<br><br>*提醒您，若目前非您本人進行身分認證，請勿將帳號密碼告訴他人!";       
                mail.BodyEncoding = Encoding.UTF8;

                try
                {
                    client.Send(mail);
                    text.Visible = true;
                    text.Text = "身份驗證成功!" + "<br/>" + "已將您的帳號密碼寄至您的信箱";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    mail.Dispose();
                    client.Dispose();
                }
            }
        }
    }
}