using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;

namespace Health
{
    public class DBclass
    {
        public string ExecuteQuery(string sqlStr)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlStr;

            try
            {
                SqlDataReader sread = cmd.ExecuteReader();
                if (sread.Read())
                {
                    return sread[0].ToString();
                }
                else
                {
                    return "找不到資料";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return "Error";
            }
            finally
            {
                con.Close();
            }
        }

        public string ExecuteUpdate(string sqlStr)      //用於增刪改;
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlStr;

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return "輸入成功";
                }
                else
                    return "輸入失敗";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return "匯入錯誤";
            }
            finally
            {
                con.Close();
            }
        }
        public ArrayList ExecuteQuery_array(string sqlStr)
        {
            ArrayList array = new ArrayList();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlStr;

            try
            {
                SqlDataReader sread = cmd.ExecuteReader();
                while (sread.Read())
                {
                    for (int i = 0; i < sread.FieldCount; i++)
                    {
                        array.Add(sread[i].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                con.Close();
            }
            return array;
        }
    }
}