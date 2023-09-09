using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;
using System.Globalization;

namespace Health
{
    public partial class index : System.Web.UI.Page
    {
        List <DateTime> list = new List<DateTime>();
        protected void Page_Load(object sender, EventArgs e)
        {
            DBclass db = new DBclass();

            string name = "SELECT 姓名 FROM Patient WHERE 病歷號='" + Session["Num"].ToString() + "'";
            Name.Text = db.ExecuteQuery(name) + "<br>歡迎回來!";

            string note = "SELECT CONVERT(varchar(100), 回診日期, 21) FROM MR WHERE 病歷號='" + Session["Num"].ToString() + "' ";
            ArrayList array_note = db.ExecuteQuery_array(note);

            string n = "SELECT 員工代號 FROM Staff WHERE 身分別 = '醫師'";
            ArrayList array_n = db.ExecuteQuery_array(n);
            for (int i = 0 ; i < array_n.Count ; i++)
            {
                n = "SELECT CONVERT(varchar(100), 紀錄時間, 21) FROM Remark WHERE 員工代號= '"+ array_n[i].ToString() +"'";
                ArrayList array_t = db.ExecuteQuery_array(n);
                for (int j = 0 ; j < array_t.Count ; j++)
                {
                    list.Add(DateTime.ParseExact(array_t[j].ToString(),"yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));
                }
            }
            list.Sort();
            if (list.Count > 0)
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    string time = Convert.ToDateTime(list[i]).ToString("yyyy/MM/dd HH:mm:ss");
                    string document = "SELECT 紀錄 FROM Remark WHERE 病歷號='" + Session["Num"].ToString() + "' AND 紀錄時間='" + time + "' ";
                    if (db.ExecuteQuery(document) == "找不到資料")
                    {
                        doc_text.Text = "今日無訊息哦!";
                        continue;
                    } 
                    else
                    {
                        doc_text.Text = db.ExecuteQuery(document) + "<br/><br/>醫師紀錄時間：<br/>" + Convert.ToDateTime(list[i]).ToString("yyyy/MM/dd") ;
                        //doc_text.Text += "<br/><br/><br/>下次需回診日期：" + Convert.ToDateTime(array_note[array_note.Count - 1]).ToString("yyyy/MM/dd") ;
                        break;
                    }
                }
            }
            else
                doc_text.Text = "無";
        }
    }
}