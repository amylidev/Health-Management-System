﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

namespace Health
{
    public partial class seBoth : System.Web.UI.Page
    {
        //舒張壓
        ArrayList S1 = new ArrayList();
        //收縮壓
        ArrayList S2 = new ArrayList();
        //日期 
        ArrayList S3 = new ArrayList();
        //時間
        ArrayList S4 = new ArrayList();
        //混和
        ArrayList S5 = new ArrayList();
        //血糖
        ArrayList S6 = new ArrayList();
        //血糖日期 
        ArrayList S7 = new ArrayList();
        //血糖時間
        ArrayList S8 = new ArrayList();
        //血糖混和
        ArrayList S9 = new ArrayList();
        //衛教師
        string S10 = "";
        //醫師
        string S11 = "";
        //個管師
        string S12 = "";
        //藥師
        string S13 = "";

        DBclass Method = new DBclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            //判斷是否第一次傳回
            if (!(Page.IsPostBack))
            {
                Month.Visible = false;
                MonthList.Visible = false;
                Calendar1.Visible = false;
                ChoseDate.Visible = false;
                YearList.Visible = false;
                Year.Visible = false;
                MonthYear.Visible = false;
                SugarGrid.Visible = false;

                //圖表預設
                BloodTitle.Visible = true;
                SugarTitle.Visible = true;

                //判斷病人狀態
                //Session["Num"] = "1";
                List<string> D1 = new List<string>();
                string c1 = "SELECT 三高 FROM Patient WHERE 病歷號='" + Session["Num"].ToString() + "'"; ;
                D1.Add(Method.ExecuteQuery(c1));
                string c2 = "SELECT 心血管疾病 FROM Patient WHERE 病歷號='" + Session["Num"].ToString() + "'"; ;
                D1.Add(Method.ExecuteQuery(c2));
                string c3 = "SELECT 糖尿病 FROM Patient WHERE 病歷號='" + Session["Num"].ToString() + "'"; ;
                D1.Add(Method.ExecuteQuery(c3));
                string c4 = "SELECT 生日 FROM Patient WHERE 病歷號='" + Session["Num"].ToString() + "'"; ;
                D1.Add(Method.ExecuteQuery(c4));

                if (D1[0].ToString().Equals("是") || D1[1].ToString().Equals("是"))
                {
                    Session["BloodCondition"] = "高風險";
                }
                else
                {
                    Session["BloodCondition"] = "健康";
                }

                if (D1[2].ToString().Equals("是"))
                {
                    Session["SugarCondition"] = "糖尿病";
                }
                else
                {
                    Session["SugarCondition"] = "健康";
                }

                //判斷是否為65歲以上
                DateTime DateObject = Convert.ToDateTime(D1[3]);
                DateTime Now = DateTime.Now;

                if ((Convert.ToInt32(Now.Year) - Convert.ToInt32(DateObject.Year)) >= 65)
                {
                    Session["Years"] = "老年";
                }
                else
                {
                    Session["Years"] = "非老年";
                }

                string date = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
                int bloodStandard1 = 0;
                int bloodStandard2 = 0;
                int SugarStandard = 0;

                //判斷病人血壓標準
                if (Session["BloodCondition"].ToString().Equals("高風險"))
                {
                    bloodStandard1 = 120;
                    bloodStandard2 = 80;
                }
                else
                {
                    bloodStandard1 = 130;
                    bloodStandard2 = 85;
                }

                //判斷病人血糖標準
                if (Session["SugarCondition"].ToString().Equals("健康"))
                {
                    SugarStandard = 100;
                }
                else if (Session["Years"].ToString().Equals("老年"))
                {
                    SugarStandard = 150;
                }
                else if (Session["Years"].ToString().Equals("非老年"))
                {
                    SugarStandard = 130;
                }

                //標題 最大數值
                Series series1 = new Series("舒張壓", 1000);
                Series series2 = new Series("收縮壓", 1000);
                Series series3 = new Series("舒張壓標準", 1000);
                Series series4 = new Series("收縮壓標準", 1000);
                //血糖 標題
                Series series5 = new Series("血糖", 1000);
                Series series6 = new Series("血糖標準", 1000);

                //設定線條顏色
                series1.Color = Color.Blue;
                series2.Color = Color.Red;
                series3.Color = Color.Gray;
                series4.Color = Color.Gray;
                series5.Color = Color.Blue;
                series6.Color = Color.Red;

                //設定字型
                series1.Font = new System.Drawing.Font("標楷體", 12);
                series2.Font = new System.Drawing.Font("標楷體", 12);
                series3.Font = new System.Drawing.Font("標楷體", 12);
                series4.Font = new System.Drawing.Font("標楷體", 12);
                series5.Font = new System.Drawing.Font("標楷體", 12);
                series6.Font = new System.Drawing.Font("標楷體", 12);

                //折線圖
                series1.ChartType = SeriesChartType.Line;
                series2.ChartType = SeriesChartType.Line;
                series3.ChartType = SeriesChartType.Line;
                series4.ChartType = SeriesChartType.Line;
                series5.ChartType = SeriesChartType.Line;
                series6.ChartType = SeriesChartType.Line;

                //將數值顯示在線上
                series1.IsValueShownAsLabel = false;
                series2.IsValueShownAsLabel = false;
                series3.IsValueShownAsLabel = false;
                series4.IsValueShownAsLabel = false;
                series5.IsValueShownAsLabel = false;
                series6.IsValueShownAsLabel = false;

                SugarGrid.Visible = false;
                string month = "";

                string ThisYear = Now.Year.ToString();

                if (Convert.ToInt32(Now.Month) < 10)
                {
                    month = ThisYear + "-0" + Now.Month.ToString();
                }
                else
                {
                    month = ThisYear + "-" + Now.Month.ToString();
                }

                string s1 = "SELECT 舒張壓 FROM BP WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 Like '" + month + "%'";
                string s2 = "SELECT 收縮壓 FROM BP WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 Like '" + month + "%'";
                string s3 = "SELECT 日期 FROM BP WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 Like '" + month + "%'";
                string s4 = "SELECT 時間 FROM BP WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 Like '" + month + "%'";
                string s6 = "SELECT 血糖值 FROM BS WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 Like '" + month + "%'";
                string s7 = "SELECT 日期 FROM BS WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 Like '" + month + "%'";
                string s8 = "SELECT 時間 FROM BS WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 Like '" + month + "%'";

                if (Method.ExecuteQuery(s1).Equals("找不到資料") || Method.ExecuteQuery(s2).Equals("找不到資料") || Method.ExecuteQuery(s3).Equals("找不到資料") || Method.ExecuteQuery(s4).Equals("找不到資料"))
                {
                    BloodChart.Visible = false;
                    BloodTitle.Text = "本月無血壓紀錄";
                }
                else
                {
                    S1 = Method.ExecuteQuery_array(s1);
                    S2 = Method.ExecuteQuery_array(s2);
                    S3 = Method.ExecuteQuery_array(s3);
                    S4 = Method.ExecuteQuery_array(s4);

                    //取出部分日期時間再組合
                    for (int i = 0; i < S3.Count; i++)
                    {
                        S3[i] = Convert.ToDateTime(S3[i]).ToString("MM/dd");
                        S4[i] = S4[i].ToString().Substring(0, 5);
                    }

                    for (int i = 0; i < S3.Count; i++)
                    {
                        S5.Add(S3[i] + " " + S4[i]);
                    }

                    //資料小於五筆顯示數字在線上
                    if (S1.Count <= 5)
                    {
                        series1.IsValueShownAsLabel = true;
                        series2.IsValueShownAsLabel = true;
                    }

                    //將數值新增至序列
                    for (int i = 0; i < S1.Count; i++)
                    {
                        series1.Points.AddXY(S5[i], S1[i]);
                        series2.Points.AddXY(S5[i], S2[i]);
                        series3.Points.AddY(bloodStandard1);
                        series4.Points.AddY(bloodStandard2);
                    }

                    //將序列新增到圖上
                    this.BloodChart.Series.Add(series1);
                    this.BloodChart.Series.Add(series2);
                    this.BloodChart.Series.Add(series3);
                    this.BloodChart.Series.Add(series4);

                    //標題
                    this.BloodChart.Titles.Add("本月血壓變化");

                    BloodTitle.Text = "";
                }

                if (Method.ExecuteQuery(s6).Equals("找不到資料") || Method.ExecuteQuery(s7).Equals("找不到資料") || Method.ExecuteQuery(s8).Equals("找不到資料"))
                {
                    SugarChart.Visible = false;
                    SugarTitle.Text = "本月無血糖紀錄";
                }
                else
                {
                    S6 = Method.ExecuteQuery_array(s6);
                    S7 = Method.ExecuteQuery_array(s7);
                    S8 = Method.ExecuteQuery_array(s8);

                    //取出部分日期時間再組合
                    for (int i = 0; i < S7.Count; i++)
                    {
                        S7[i] = Convert.ToDateTime(S7[i]).ToString("MM/dd");
                        S8[i] = S8[i].ToString().Substring(0, 5);
                    }

                    for (int i = 0; i < S7.Count; i++)
                    {
                        S9.Add(S7[i] + " " + S8[i]);
                    }

                    //資料小於五筆顯示數字在線上
                    if (S6.Count <= 5)
                    {
                        series5.IsValueShownAsLabel = true;
                    }

                    //將數值新增至序列
                    for (int i = 0; i < S6.Count; i++)
                    {
                        series5.Points.AddXY(S9[i], S6[i]);
                        series6.Points.AddY(SugarStandard);
                    }

                    //將序列新增到圖上
                    this.SugarChart.Series.Add(series5);
                    this.SugarChart.Series.Add(series6);

                    //標題
                    this.SugarChart.Titles.Add("本月血糖變化");

                    SugarTitle.Text = "";
                }
            }
        }

        protected void ChoseDate_Click(object sender, EventArgs e)
        {
            BloodTitle.Visible = true;
            SugarTitle.Visible = true;

            //判斷病人狀態
            List<string> C1 = new List<string>();
            string c1 = "SELECT 三高 FROM Patient WHERE 病歷號='" + Session["Num"].ToString() + "'"; ;
            C1.Add(Method.ExecuteQuery(c1));
            string c2 = "SELECT 心血管疾病 FROM Patient WHERE 病歷號='" + Session["Num"].ToString() + "'"; ;
            C1.Add(Method.ExecuteQuery(c2));
            string c3 = "SELECT 糖尿病 FROM Patient WHERE 病歷號='" + Session["Num"].ToString() + "'"; ;
            C1.Add(Method.ExecuteQuery(c3));
            string c4 = "SELECT 生日 FROM Patient WHERE 病歷號='" + Session["Num"].ToString() + "'"; ;
            C1.Add(Method.ExecuteQuery(c4));

            if (C1[0].ToString().Equals("是") || C1[1].ToString().Equals("是"))
            {
                Session["BloodCondition"] = "高風險";
            }
            else
            {
                Session["BloodCondition"] = "健康";
            }

            if (C1[2].ToString().Equals("是"))
            {
                Session["SugarCondition"] = "糖尿病";
            }
            else
            {
                Session["SugarCondition"] = "健康";
            }

            //判斷是否為65歲以上
            DateTime DateObject = Convert.ToDateTime(C1[3]);
            DateTime Now = DateTime.Now;

            if ((Convert.ToInt32(Now.Year) - Convert.ToInt32(DateObject.Year)) >= 65)
            {
                Session["Years"] = "老年";
            }
            else
            {
                Session["Years"] = "非老年";
            }

            int bloodStandard1 = 0;
            int bloodStandard2 = 0;
            int SugarStandard = 0;

            //判斷病人血壓標準
            if (Session["BloodCondition"].ToString().Equals("高風險"))
            {
                bloodStandard1 = 120;
                bloodStandard2 = 80;
            }
            else
            {
                bloodStandard1 = 130;
                bloodStandard2 = 85;
            }

            //判斷病人血糖標準
            if (Session["SugarCondition"].ToString().Equals("健康"))
            {
                SugarStandard = 100;
            }
            else if (Session["Years"].ToString().Equals("老年"))
            {
                SugarStandard = 150;
            }
            else if (Session["Years"].ToString().Equals("非老年"))
            {
                SugarStandard = 130;
            }

            //標題 最大數值
            Series series1 = new Series("舒張壓", 1000);
            Series series2 = new Series("收縮壓", 1000);
            Series series3 = new Series("舒張壓標準", 1000);
            Series series4 = new Series("收縮壓標準", 1000);
            //血糖 標題
            Series series5 = new Series("血糖", 1000);
            Series series6 = new Series("血糖標準", 1000);

            //設定線條顏色
            series1.Color = Color.Blue;
            series2.Color = Color.Red;
            series3.Color = Color.Gray;
            series4.Color = Color.Gray;
            series5.Color = Color.Blue;
            series6.Color = Color.Red;

            //設定字型
            series1.Font = new System.Drawing.Font("標楷體", 12);
            series2.Font = new System.Drawing.Font("標楷體", 12);
            series3.Font = new System.Drawing.Font("標楷體", 12);
            series4.Font = new System.Drawing.Font("標楷體", 12);
            series5.Font = new System.Drawing.Font("標楷體", 12);
            series6.Font = new System.Drawing.Font("標楷體", 12);

            //折線圖
            series1.ChartType = SeriesChartType.Line;
            series2.ChartType = SeriesChartType.Line;
            series3.ChartType = SeriesChartType.Line;
            series4.ChartType = SeriesChartType.Line;
            series5.ChartType = SeriesChartType.Line;
            series6.ChartType = SeriesChartType.Line;

            //將數值顯示在線上
            series1.IsValueShownAsLabel = false;
            series2.IsValueShownAsLabel = false;
            series3.IsValueShownAsLabel = false;
            series4.IsValueShownAsLabel = false;
            series5.IsValueShownAsLabel = false;
            series6.IsValueShownAsLabel = false;

            //小提醒
            string Identity = "";
            string Identity1 = "";
            string Identity2 = "";
            string Identity3 = "";

            //辨別身分
            //護士
            ArrayList P1 = new ArrayList();
            //醫生
            ArrayList P2 = new ArrayList();
            //個管師
            ArrayList P3 = new ArrayList();
            //藥師
            ArrayList P4 = new ArrayList();

            string p1 = "SELECT 員工代號 FROM Staff WHERE 身分別='護士'";
            if (Method.ExecuteQuery(p1).Equals("找不到資料"))
                P1.Add("本院無護士");
            else
            {
                P1 = Method.ExecuteQuery_array(p1);
                for (int i = 0; i < P1.Count; i++)
                {
                    if (i < (P1.Count - 1))
                    {
                        Identity += "'" + P1[i] + "',";
                    }
                    else
                    {
                        Identity += "'" + P1[i] + "'";
                    }
                }
            }

            string p2 = "SELECT 員工代號 FROM Staff WHERE 身分別='醫師'";
            if (Method.ExecuteQuery(p2).Equals("找不到資料"))
                P2.Add("本院無醫師");
            else
            {
                P2 = Method.ExecuteQuery_array(p2);
                for (int i = 0; i < P2.Count; i++)
                {
                    if (i < (P2.Count - 1))
                    {
                        Identity1 += "'" + P2[i] + "',";
                    }
                    else
                    {
                        Identity1 += "'" + P2[i] + "'";
                    }
                }
            }

            string p3 = "SELECT 員工代號 FROM Staff WHERE 身分別='個管師'";
            if (Method.ExecuteQuery(p3).Equals("找不到資料"))
                P3.Add("本院無個管師");
            else
            {
                P3 = Method.ExecuteQuery_array(p3);
                for (int i = 0; i < P3.Count; i++)
                {
                    if (i < (P3.Count - 1))
                    {
                        Identity2 += "'" + P3[i] + "',";
                    }
                    else
                    {
                        Identity2 += "'" + P3[i] + "'";
                    }
                }
            }

            string p4 = "SELECT 員工代號 FROM Staff WHERE 身分別='藥劑師'";
            if (Method.ExecuteQuery(p4).Equals("找不到資料"))
                P4.Add("本院無藥劑師");
            else
            {
                P4 = Method.ExecuteQuery_array(p4);
                for (int i = 0; i < P4.Count; i++)
                {
                    if (i < (P4.Count - 1))
                    {
                        Identity3 += "'" + P4[i] + "',";
                    }
                    else
                    {
                        Identity3 += "'" + P4[i] + "'";
                    }
                }
            }

            if (ModeList.SelectedItem.Text.Equals("某一日"))
            {
                SugarChart.Visible = false;
                GridTitle.Visible = true;

                //一日血糖紀錄表取日期
                string date = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
                Session["Date"] = date;

                //血壓
                string s1 = "SELECT 舒張壓 FROM BP WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期='" + date + "'ORDER BY 時間";
                string s2 = "SELECT 收縮壓 FROM BP WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期='" + date + "'ORDER BY 時間";
                string s4 = "SELECT 時間 FROM BP WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期='" + date + "'ORDER BY 時間";
                //血糖
                string s6 = "SELECT 血糖值 FROM BS WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期='" + date + "'ORDER BY 時間";
                string s8 = "SELECT 時間 FROM BS WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期='" + date + "'ORDER BY 時間";


                if (Method.ExecuteQuery(s1).Equals("找不到資料") || Method.ExecuteQuery(s2).Equals("找不到資料") || Method.ExecuteQuery(s4).Equals("找不到資料"))
                {
                    BloodChart.Visible = false;
                    BloodTitle.Text = "本日無血壓紀錄";
                }
                else
                {
                    S1 = Method.ExecuteQuery_array(s1);
                    S2 = Method.ExecuteQuery_array(s2);
                    S4 = Method.ExecuteQuery_array(s4);

                    //血壓數值新增至序列
                    for (int i = 0; i < S1.Count; i++)
                    {
                        series1.Points.AddXY(S4[i], S1[i]);
                        series2.Points.AddXY(S4[i], S2[i]);
                        series3.Points.AddY(bloodStandard1);
                        series4.Points.AddY(bloodStandard2);
                    }

                    //取出TIME部分
                    for (int i = 0; i < S4.Count; i++)
                    {
                        S4[i] = S4[i].ToString().Substring(0, 5);
                    }

                    //資料小於五筆顯示數字在線上
                    if (S1.Count <= 5)
                    {
                        series1.IsValueShownAsLabel = true;
                        series2.IsValueShownAsLabel = true;
                        series5.IsValueShownAsLabel = true;
                    }

                    //將序列新增到圖上
                    this.BloodChart.Series.Add(series1);
                    this.BloodChart.Series.Add(series2);
                    this.BloodChart.Series.Add(series3);
                    this.BloodChart.Series.Add(series4);

                    // 標題
                    this.BloodChart.Titles.Add("一日血壓變化");
                    BloodTitle.Text = "";
                }

                if(Method.ExecuteQuery(s6).Equals("找不到資料") || Method.ExecuteQuery(s8).Equals("找不到資料"))
                {
                    GridTitle.Text = "";
                    SugarChart.Visible = false;
                    SugarGrid.Visible = false;
                    SugarTitle.Text = "本日無血糖紀錄";
                }
                else
                {
                    S6 = Method.ExecuteQuery_array(s6);
                    S8 = Method.ExecuteQuery_array(s8);

                    SugarGrid.Visible = true;
                    GridTitle.Text = Convert.ToDateTime(date).Month + "月" + Convert.ToDateTime(date).Day + "日血糖值";

                    SugarTitle.Text = "";
                }

                //備註
                if (P1[0].Equals("本院無護士"))
                {
                    S10 = "暫無護士";
                }
                else
                {
                    string s10 = "SELECT 紀錄 FROM Remark WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 員工代號 IN(" + Identity + ") AND 紀錄時間類別='" + date + "' AND 紀錄類別='Both'" + "ORDER BY 紀錄時間 ";
                    S10 = Method.ExecuteQuery(s10);
                }

                if (P2[0].Equals("本院無醫師"))
                {
                    S11 = "暫無醫師";
                }
                else
                {
                    string s11 = "SELECT 紀錄 FROM Remark WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 員工代號 IN(" + Identity1 + ") AND 紀錄時間類別='" + date + "' AND 紀錄類別='Both'" + "ORDER BY 紀錄時間 ";
                    S11 = Method.ExecuteQuery(s11);
                }

                if (P3[0].Equals("本院無個管師"))
                {
                    S12 = "暫無個管師";
                }
                else
                {
                    string s12 = "SELECT 紀錄 FROM Remark WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 員工代號 IN(" + Identity2 + ") AND 紀錄時間類別='" + date + "' AND 紀錄類別='Both'" + "ORDER BY 紀錄時間 ";
                    S12 = Method.ExecuteQuery(s12);
                }

                if (P4[0].Equals("本院無藥劑師"))
                {
                    S13 = "暫無藥劑師";
                }
                else
                {
                    string s13 = "SELECT 紀錄 FROM Remark WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 員工代號 IN(" + Identity3 + ") AND 紀錄時間類別='" + date + "' AND 紀錄類別='Both'" + "ORDER BY 紀錄時間 ";
                    S13 = Method.ExecuteQuery(s13);
                }

                if (S10.Equals("找不到資料"))
                    Nurse.Text = "護士備註:" + "</br>" + "本日無注意事項";
                else
                    Nurse.Text = "護士備註:" + "</br>" + S10;

                if (S11.Equals("找不到資料"))
                    Doctor.Text = "醫師備註:" + "</br>" + "本日無注意事項";
                else
                    Doctor.Text = "醫師備註:" + "</br>" + S11;

                if (S12.Equals("找不到資料"))
                    Manager.Text = "個管師備註:" + "</br>" + "本日無注意事項";
                else
                    Manager.Text = "個管師備註:" + "</br>" + S12;

                if (S13.Equals("找不到資料"))
                    Pharmacist.Text = "藥師備註:" + "</br>" + "本日無注意事項";
                else
                    Pharmacist.Text = "藥師備註:" + "</br>" + S13;

            }
            else if (ModeList.SelectedItem.Text.Equals("某一週"))
            {
                SugarGrid.Visible = false;

                //一周日期
                string D1 = Calendar1.SelectedDates[0].ToString("yyyy-MM-dd");
                string D2 = Calendar1.SelectedDates[1].ToString("yyyy-MM-dd");
                string D3 = Calendar1.SelectedDates[2].ToString("yyyy-MM-dd");
                string D4 = Calendar1.SelectedDates[3].ToString("yyyy-MM-dd");
                string D5 = Calendar1.SelectedDates[4].ToString("yyyy-MM-dd");
                string D6 = Calendar1.SelectedDates[5].ToString("yyyy-MM-dd");
                string D7 = Calendar1.SelectedDates[6].ToString("yyyy-MM-dd");

                //備註用日期
                string RemarkDay = D1 + "~" + D7;

                string s1 = "SELECT 舒張壓 FROM BP WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 In('" + D1 + "', '" + D2 + "', '" + D3 + "', '" + D4 + "', '" + D5 + "', '" + D6 + "', '" + D7 + "') ";
                string s2 = "SELECT 收縮壓 FROM BP WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 In('" + D1 + "', '" + D2 + "', '" + D3 + "', '" + D4 + "', '" + D5 + "', '" + D6 + "', '" + D7 + "') ";
                string s3 = "SELECT 日期 FROM BP WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 In('" + D1 + "', '" + D2 + "', '" + D3 + "', '" + D4 + "', '" + D5 + "', '" + D6 + "', '" + D7 + "') ";
                string s4 = "SELECT 時間 FROM BP WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 In('" + D1 + "', '" + D2 + "', '" + D3 + "', '" + D4 + "', '" + D5 + "', '" + D6 + "', '" + D7 + "') ";
                string s6 = "SELECT 血糖值 FROM BS WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 In('" + D1 + "', '" + D2 + "', '" + D3 + "', '" + D4 + "', '" + D5 + "', '" + D6 + "', '" + D7 + "') ";
                string s7 = "SELECT 日期 FROM BS WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 In('" + D1 + "', '" + D2 + "', '" + D3 + "', '" + D4 + "', '" + D5 + "', '" + D6 + "', '" + D7 + "') ";
                string s8 = "SELECT 時間 FROM BS WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 In('" + D1 + "', '" + D2 + "', '" + D3 + "', '" + D4 + "', '" + D5 + "', '" + D6 + "', '" + D7 + "') ";

                if (Method.ExecuteQuery(s1).Equals("找不到資料") || Method.ExecuteQuery(s2).Equals("找不到資料") || Method.ExecuteQuery(s3).Equals("找不到資料") || Method.ExecuteQuery(s4).Equals("找不到資料"))
                {
                    BloodChart.Visible = false;
                    BloodTitle.Text = "本週無血壓紀錄";
                }
                else
                {
                    S1 = Method.ExecuteQuery_array(s1);
                    S2 = Method.ExecuteQuery_array(s2);
                    S3 = Method.ExecuteQuery_array(s3);
                    S4 = Method.ExecuteQuery_array(s4);

                    //取出部分日期時間再組合
                    for (int i = 0; i < S3.Count; i++)
                    {
                        S3[i] = Convert.ToDateTime(S3[i]).ToString("MM/dd");
                        S4[i] = S4[i].ToString().Substring(0, 5);
                    }

                    for (int i = 0; i < S3.Count; i++)
                    {
                        S5.Add(S3[i] + " " + S4[i]);
                    }

                        //資料小於五筆顯示數字在線上
                        if (S1.Count <= 5)
                        {
                            series1.IsValueShownAsLabel = true;
                            series2.IsValueShownAsLabel = true;
                        }

                        //將數值新增至序列
                         for (int i = 0; i < S1.Count; i++)
                         {
                            series1.Points.AddXY(S5[i], S1[i]);
                            series2.Points.AddXY(S5[i], S2[i]);
                            series3.Points.AddY(bloodStandard1);
                            series4.Points.AddY(bloodStandard2);
                         }

                        //將序列新增到圖上
                        this.BloodChart.Series.Add(series1);
                        this.BloodChart.Series.Add(series2);
                        this.BloodChart.Series.Add(series3);
                        this.BloodChart.Series.Add(series4);

                        //標題
                        this.BloodChart.Titles.Add("本週血壓變化");
                        BloodTitle.Text = "";
                }

                if (Method.ExecuteQuery(s6).Equals("找不到資料") || Method.ExecuteQuery(s7).Equals("找不到資料") || Method.ExecuteQuery(s8).Equals("找不到資料"))
                {
                    SugarChart.Visible = false;
                    SugarTitle.Text = "本週無血糖紀錄";
                }
                else
                {
                    S6 = Method.ExecuteQuery_array(s6);
                    S7 = Method.ExecuteQuery_array(s7);
                    S8 = Method.ExecuteQuery_array(s8);

                    //取出部分日期時間再組合
                    for (int i = 0; i < S7.Count; i++)
                    {
                        S7[i] = Convert.ToDateTime(S7[i]).ToString("MM/dd");
                        S8[i] = S8[i].ToString().Substring(0, 5);
                    }

                    for (int i = 0; i < S7.Count; i++)
                    {
                        S9.Add(S7[i] + " " + S8[i]);
                    }

                    //資料小於五筆顯示數字在線上
                    if (S6.Count <= 5)
                    {
                        series5.IsValueShownAsLabel = true;
                    }

                    //將數值新增至序列
                    for (int i = 0; i < S6.Count; i++)
                    {
                        series5.Points.AddXY(S9[i], S6[i]);
                        series6.Points.AddY(SugarStandard);
                    }

                    //將序列新增到圖上
                    this.SugarChart.Series.Add(series5);
                    this.SugarChart.Series.Add(series6);

                    //標題
                    this.SugarChart.Titles.Add("本週血糖變化");

                    SugarTitle.Text = "";

                }

                //備註
                if (P1[0].Equals("本院無護士"))
                {
                    S10 = "暫無護士";
                }
                else
                {
                    string s10 = "SELECT 紀錄 FROM Remark WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 員工代號 IN(" + Identity + ") AND 紀錄時間類別='" + RemarkDay + "' AND 紀錄類別='Both'" + "ORDER BY 紀錄時間 ";
                    S10 = Method.ExecuteQuery(s10);
                }

                if (P2[0].Equals("本院無醫師"))
                {
                    S11 = "暫無醫師";
                }
                else
                {
                    string s11 = "SELECT 紀錄 FROM Remark WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 員工代號 IN(" + Identity1 + ") AND 紀錄時間類別='" + RemarkDay + "' AND 紀錄類別='Both'" + "ORDER BY 紀錄時間 ";
                    S11 = Method.ExecuteQuery(s11);
                }

                if (P3[0].Equals("本院無個管師"))
                {
                    S12 = "暫無個管師";
                }
                else
                {
                    string s12 = "SELECT 紀錄 FROM Remark WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 員工代號 IN(" + Identity2 + ") AND 紀錄時間類別='" + RemarkDay + "' AND 紀錄類別='Both'" + "ORDER BY 紀錄時間 ";
                    S12 = Method.ExecuteQuery(s12);
                }

                if (P4[0].Equals("本院無藥劑師"))
                {
                    S13 = "暫無藥劑師";
                }
                else
                {
                    string s13 = "SELECT 紀錄 FROM Remark WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 員工代號 IN(" + Identity3 + ") AND 紀錄時間類別='" + RemarkDay + "' AND 紀錄類別='Both'" + "ORDER BY 紀錄時間 ";
                    S13 = Method.ExecuteQuery(s13);
                }

                if (S10.Equals("找不到資料"))
                    Nurse.Text = "護士備註:" + "</br>" + "本週無注意事項";
                else
                    Nurse.Text = "護士備註:" + "</br>" + S10;

                if (S11.Equals("找不到資料"))
                    Doctor.Text = "醫師備註:" + "</br>" + "本週無注意事項";
                else
                    Doctor.Text = "醫師備註:" + "</br>" + S11;

                if (S12.Equals("找不到資料"))
                    Manager.Text = "個管師備註:" + "</br>" + "本週無注意事項";
                else
                    Manager.Text = "個管師備註:" + "</br>" + S12;

                if (S13.Equals("找不到資料"))
                    Pharmacist.Text = "藥師備註:" + "</br>" + "本週無注意事項";
                else
                    Pharmacist.Text = "藥師備註:" + "</br>" + S13;

            }
            else if (ModeList.SelectedItem.Text.Equals("某一月"))
            {
                SugarGrid.Visible = false;

                string month = "";

                string TheYear = MonthYear.SelectedItem.Value.ToString();

                month = TheYear + "-" + MonthList.SelectedItem.Value.ToString();

                string s1 = "SELECT 舒張壓 FROM BP WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 Like '" + month + "%'";
                string s2 = "SELECT 收縮壓 FROM BP WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 Like '" + month + "%'";
                string s3 = "SELECT 日期 FROM BP WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 Like '" + month + "%'";
                string s4 = "SELECT 時間 FROM BP WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 Like '" + month + "%'";
                string s6 = "SELECT 血糖值 FROM BS WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 Like '" + month + "%'";
                string s7 = "SELECT 日期 FROM BS WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 Like '" + month + "%'";
                string s8 = "SELECT 時間 FROM BS WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 Like '" + month + "%'";

                if (Method.ExecuteQuery(s1).Equals("找不到資料") || Method.ExecuteQuery(s2).Equals("找不到資料") || Method.ExecuteQuery(s3).Equals("找不到資料") || Method.ExecuteQuery(s4).Equals("找不到資料"))
                {
                    BloodChart.Visible = false;
                    BloodTitle.Text = "本月無血壓紀錄";
                }
                else
                {
                    S1 = Method.ExecuteQuery_array(s1);
                    S2 = Method.ExecuteQuery_array(s2);
                    S3 = Method.ExecuteQuery_array(s3);
                    S4 = Method.ExecuteQuery_array(s4);

                    //取出部分日期時間再組合
                    for (int i = 0; i < S3.Count; i++)
                    {
                        S3[i] = Convert.ToDateTime(S3[i]).ToString("MM/dd");
                        S4[i] = S4[i].ToString().Substring(0, 5);
                    }

                    for (int i = 0; i < S3.Count; i++)
                    {
                        S5.Add(S3[i] + " " + S4[i]);
                    }

                    //資料小於五筆顯示數字在線上
                    if (S1.Count <= 5)
                    {
                        series1.IsValueShownAsLabel = true;
                        series2.IsValueShownAsLabel = true;
                    }

                    //將數值新增至序列
                    for (int i = 0; i < S1.Count; i++)
                    {
                        series1.Points.AddXY(S5[i], S1[i]);
                        series2.Points.AddXY(S5[i], S2[i]);
                        series3.Points.AddY(bloodStandard1);
                        series4.Points.AddY(bloodStandard2);
                    }

                    //將序列新增到圖上
                    this.BloodChart.Series.Add(series1);
                    this.BloodChart.Series.Add(series2);
                    this.BloodChart.Series.Add(series3);
                    this.BloodChart.Series.Add(series4);

                    //標題
                    this.BloodChart.Titles.Add("本月血壓變化");

                    BloodTitle.Text = "";
                }

                if (Method.ExecuteQuery(s6).Equals("找不到資料") || Method.ExecuteQuery(s7).Equals("找不到資料") || Method.ExecuteQuery(s8).Equals("找不到資料"))
                {
                    SugarChart.Visible = false;
                    SugarTitle.Text = "本月無血糖紀錄";
                }
                else
                {
                    S6 = Method.ExecuteQuery_array(s6);
                    S7 = Method.ExecuteQuery_array(s7);
                    S8 = Method.ExecuteQuery_array(s8);


                    //取出部分日期時間再組合
                    for (int i = 0; i < S7.Count; i++)
                    {
                        S7[i] = Convert.ToDateTime(S7[i]).ToString("MM/dd");
                        S8[i] = S8[i].ToString().Substring(0, 5);
                    }

                    for (int i = 0; i < S7.Count; i++)
                    {
                        S9.Add(S7[i] + " " + S8[i]);
                    }

                    //資料小於五筆顯示數字在線上
                    if (S6.Count <= 5)
                    {
                        series5.IsValueShownAsLabel = true;
                    }

                    //將數值新增至序列
                    for (int i = 0; i < S6.Count; i++)
                    {
                        series5.Points.AddXY(S9[i], S6[i]);
                        series6.Points.AddY(SugarStandard);
                    }

                    //將序列新增到圖上
                    this.SugarChart.Series.Add(series5);
                    this.SugarChart.Series.Add(series6);

                    //標題
                    this.SugarChart.Titles.Add("本月血糖變化");

                    SugarTitle.Text = "";
                }

                //備註
                if (P1[0].Equals("本院無護士"))
                {
                    S10 = "暫無護士";
                }
                else
                {
                    string s10 = "SELECT 紀錄 FROM Remark WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 員工代號 IN(" + Identity + ") AND 紀錄時間類別='" + month + "' AND 紀錄類別='Both'" + "ORDER BY 紀錄時間 ";
                    S10 = Method.ExecuteQuery(s10);
                }

                if (P2[0].Equals("本院無醫師"))
                {
                    S11 = "暫無醫師";
                }
                else
                {
                    string s11 = "SELECT 紀錄 FROM Remark WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 員工代號 IN(" + Identity1 + " ) AND 紀錄時間類別='" + month + "' AND 紀錄類別='Both'" + "ORDER BY 紀錄時間 ";
                    S11 = Method.ExecuteQuery(s11);
                }

                if (P3[0].Equals("本院無個管師"))
                {
                    S12 = "暫無個管師";
                }
                else
                {
                    string s12 = "SELECT 紀錄 FROM Remark WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 員工代號 IN(" + Identity2 + ") AND 紀錄時間類別='" + month + "' AND 紀錄類別='Both'" + "ORDER BY 紀錄時間 ";
                    S12 = Method.ExecuteQuery(s12);
                }

                if (P4[0].Equals("本院無藥劑師"))
                {
                    S13 = "暫無藥劑師";
                }
                else
                {
                    string s13 = "SELECT 紀錄 FROM Remark WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 員工代號 IN(" + Identity3 + ") AND 紀錄時間類別='" + month + "' AND 紀錄類別='Both'" + "ORDER BY 紀錄時間 ";
                    S13 = Method.ExecuteQuery(s13);
                }

                if (S10.Equals("找不到資料"))
                    Nurse.Text = "護士備註:" + "</br>" + "本月無注意事項";
                else
                    Nurse.Text = "護士備註:" + "</br>" + S10;

                if (S11.Equals("找不到資料"))
                    Doctor.Text = "醫師備註:" + "</br>" + "本月無注意事項";
                else
                    Doctor.Text = "醫師備註:" + "</br>" + S11;

                if (S12.Equals("找不到資料"))
                    Manager.Text = "個管師備註:" + "</br>" + "本月無注意事項";
                else
                    Manager.Text = "個管師備註:" + "</br>" + S12;

                if (S13.Equals("找不到資料"))
                    Pharmacist.Text = "藥師備註:" + "</br>" + "本月無注意事項";
                else
                    Pharmacist.Text = "藥師備註:" + "</br>" + S13;
            }
            else if (ModeList.SelectedItem.Text.Equals("一年走勢"))
            {
                SugarGrid.Visible = false;

                string year = " ";
                year = YearList.SelectedItem.Text.ToString();

                string s1 = "SELECT 舒張壓 FROM BP WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 Like '" + year + "%'";
                string s2 = "SELECT 收縮壓 FROM BP WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 Like '" + year + "%'";
                string s3 = "SELECT 日期 FROM BP WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 Like '" + year + "%'";
                string s4 = "SELECT 時間 FROM BP WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 Like '" + year + "%'";
                string s6 = "SELECT 血糖值 FROM BS WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 Like '" + year + "%'";
                string s7 = "SELECT 日期 FROM BS WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 Like '" + year + "%'";
                string s8 = "SELECT 時間 FROM BS WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 日期 Like '" + year + "%'";

                if (Method.ExecuteQuery(s1).Equals("找不到資料") || Method.ExecuteQuery(s2).Equals("找不到資料") || Method.ExecuteQuery(s3).Equals("找不到資料") || Method.ExecuteQuery(s4).Equals("找不到資料"))
                {
                    BloodChart.Visible = false;
                    BloodTitle.Text = "本年無血壓紀錄";
                }
                else
                {
                    S1 = Method.ExecuteQuery_array(s1);
                    S2 = Method.ExecuteQuery_array(s2);
                    S3 = Method.ExecuteQuery_array(s3);
                    S4 = Method.ExecuteQuery_array(s4);

                    //取出部分日期時間再組合
                    for (int i = 0; i < S3.Count; i++)
                    {
                        S3[i] = Convert.ToDateTime(S3[i]).ToString("MM/dd");
                        S4[i] = S4[i].ToString().Substring(0, 5);
                    }

                    for (int i = 0; i < S3.Count; i++)
                    {
                        S5.Add(S3[i] + " " + S4[i]);
                    }

                    //資料小於五筆顯示數字在線上
                    if (S1.Count <= 5)
                    {
                        series1.IsValueShownAsLabel = true;
                        series2.IsValueShownAsLabel = true;
                    }

                    //將數值新增至序列
                    for (int i = 0; i < S1.Count; i++)
                    {
                        series1.Points.AddXY(S5[i], S1[i]);
                        series2.Points.AddXY(S5[i], S2[i]);
                        series3.Points.AddY(bloodStandard1);
                        series4.Points.AddY(bloodStandard2);
                    }

                    //將序列新增到圖上
                    this.BloodChart.Series.Add(series1);
                    this.BloodChart.Series.Add(series2);
                    this.BloodChart.Series.Add(series3);
                    this.BloodChart.Series.Add(series4);

                    //標題
                    this.BloodChart.Titles.Add("本年血壓變化");

                    BloodTitle.Text = "";
                }

                if (Method.ExecuteQuery(s6).Equals("找不到資料") || Method.ExecuteQuery(s7).Equals("找不到資料") || Method.ExecuteQuery(s8).Equals("找不到資料"))
                {
                    SugarChart.Visible = false;
                    SugarTitle.Text = "本年無血糖紀錄";
                }
                else
                {
                    S6 = Method.ExecuteQuery_array(s6);
                    S7 = Method.ExecuteQuery_array(s7);
                    S8 = Method.ExecuteQuery_array(s8);

                    //取出部分日期時間再組合
                    for (int i = 0; i < S7.Count; i++)
                    {
                        S7[i] = Convert.ToDateTime(S7[i]).ToString("MM/dd");
                        S8[i] = S8[i].ToString().Substring(0, 5);
                    }

                    for (int i = 0; i < S7.Count; i++)
                    {
                        S9.Add(S7[i] + " " + S8[i]);
                    }

                    //資料小於五筆顯示數字在線上
                    if (S6.Count <= 5)
                    {
                        series5.IsValueShownAsLabel = true;
                    }

                    //將數值新增至序列
                    for (int i = 0; i < S6.Count; i++)
                    {
                        series5.Points.AddXY(S9[i], S6[i]);
                        series6.Points.AddY(SugarStandard);
                    }

                    //將序列新增到圖上
                    this.SugarChart.Series.Add(series5);
                    this.SugarChart.Series.Add(series6);

                    //標題
                    this.SugarChart.Titles.Add("本年血糖變化");

                    SugarTitle.Text = "";
                }

                //備註
                if (P1[0].Equals("本院無護士"))
                {
                    S10 = "暫無護士";
                }
                else
                {
                    string s10 = "SELECT 紀錄 FROM Remark WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 員工代號 IN(" + Identity + ") AND 紀錄時間類別='" + year + "' AND 紀錄類別='Both'" + "ORDER BY 紀錄時間 ";
                    S10 = Method.ExecuteQuery(s10);
                }

                if (P2[0].Equals("本院無醫師"))
                {
                    S11 = "暫無醫師";
                }
                else
                {
                    string s11 = "SELECT 紀錄 FROM Remark WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 員工代號 IN(" + Identity1 + ") AND 紀錄時間類別='" + year + "' AND 紀錄類別='Both'" + "ORDER BY 紀錄時間 ";
                    S11 = Method.ExecuteQuery(s11);
                }

                if (P3[0].Equals("本院無個管師"))
                {
                    S12 = "暫無個管師";
                }
                else
                {
                    string s12 = "SELECT 紀錄 FROM Remark WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 員工代號 IN(" + Identity2 + ") AND 紀錄時間類別='" + year + "' AND 紀錄類別='Both'" + "ORDER BY 紀錄時間 ";
                    S12 = Method.ExecuteQuery(s12);
                }

                if (P4[0].Equals("本院無藥劑師"))
                {
                    S13 = "暫無藥劑師";
                }
                else
                {
                    string s13 = "SELECT 紀錄 FROM Remark WHERE 病歷號='" + Session["Num"].ToString() + "'" + "AND 員工代號 IN(" + Identity3 + ") AND 紀錄時間類別='" + year + "' AND 紀錄類別='Both'" + "ORDER BY 紀錄時間 ";
                    S13 = Method.ExecuteQuery(s13);
                }

                if (S10.Equals("找不到資料"))
                    Nurse.Text = "護士備註:" + "</br>" + "本年無注意事項";
                else
                    Nurse.Text = "護士備註:" + "</br>" + S10;

                if (S11.Equals("找不到資料"))
                    Doctor.Text = "醫師備註:" + "</br>" + "本年無注意事項";
                else
                    Doctor.Text = "醫師備註:" + "</br>" + S11;

                if (S12.Equals("找不到資料"))
                    Manager.Text = "個管師備註:" + "</br>" + "本年無注意事項";
                else
                    Manager.Text = "個管師備註:" + "</br>" + S12;

                if (S13.Equals("找不到資料"))
                    Pharmacist.Text = "藥師備註:" + "</br>" + "本年無注意事項";
                else
                    Pharmacist.Text = "藥師備註:" + "</br>" + S13;
            }
        }
        protected void ModeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ModeList.SelectedItem.Text.Equals("某一日"))
            {
                Calendar1.Visible = true;
                ChoseDate.Visible = true;
                MonthList.Visible = false;
                YearList.Visible = false;
                Month.Visible = false;
                Year.Visible = false;
                Calendar1.SelectionMode = CalendarSelectionMode.Day;
                BloodTitle.Text = "";
                SugarTitle.Text = "";
            }
            else if (ModeList.SelectedItem.Text.Equals("某一週"))
            {
                Calendar1.Visible = true;
                ChoseDate.Visible = true;
                MonthList.Visible = false;
                YearList.Visible = false;
                Month.Visible = false;
                Year.Visible = false;
                Calendar1.SelectionMode = CalendarSelectionMode.DayWeek;
                BloodTitle.Text = "";
                SugarTitle.Text = "";
                SugarGrid.Visible = false;
                MonthYear.Visible = false;
                GridTitle.Visible = false;
            }
            else if (ModeList.SelectedItem.Text.Equals("某一月"))
            {
                Calendar1.Visible = false;
                ChoseDate.Visible = true;
                MonthList.Visible = true;
                Month.Visible = true;
                YearList.Visible = false;
                Year.Visible = false;
                BloodTitle.Text = "";
                SugarTitle.Text = "";
                GridTitle.Visible = false;

                SugarGrid.Visible = false;

                MonthYear.Visible = true;

                //將年份輸入List 預設系統2020年開始
                DateTime NowYear = DateTime.Now;
                MonthYear.Items.Clear();
                int j = 0;

                for (int i = 2020; i <= NowYear.Year; i++)
                {
                    MonthYear.Items.Insert(j, i.ToString());
                    j++;
                }
            }
            else if (ModeList.SelectedItem.Text.Equals("一年走勢"))
            {
                Calendar1.Visible = false;
                ChoseDate.Visible = true;
                MonthList.Visible = false;
                Month.Visible = false;
                YearList.Visible = true;
                Year.Visible = true;
                BloodTitle.Text = "";
                SugarTitle.Text = "";
                BloodTitle.Visible = false;
                SugarTitle.Visible = false;
                MonthYear.Visible = false;
                GridTitle.Visible = false;

                //將年份輸入List 預設系統2020年開始
                DateTime NowYear = DateTime.Now;
                YearList.Items.Clear();
                int j = 0;

                for (int i = 2020; i <= NowYear.Year; i++)
                {
                    YearList.Items.Insert(j, i.ToString());
                    j++;
                }

                SugarGrid.Visible = false;
            }
        }
    }
}