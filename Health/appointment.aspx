<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="appointment.aspx.cs" Inherits="Health.appointment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>iCareÜ</title>
    <link type="text/css" href="style.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <header>
             <img src="回診間隔.png" alt="iCareÜ" width="100%" height="100%" title="iCareÜ"
                style="display:block; margin:auto; z-index:0;"/>
            <div style="clear:both;"> </div>
        </header>
        <nav>
             <ul class="flex-nav">
                <li><a href="index.aspx">首頁</a></li>
                <li><a href="#">新增資料</a>
                    <ul>
                        <li><a href="inBP.aspx">新增血壓</a></li>
                        <li><a href="inBS.aspx">新增血糖</a></li>
                    </ul>
                </li>
                <li><a href="#">修改資料</a>
                    <ul>
                        <li><a href="reBP.aspx">修改血壓</a></li>
                        <li><a href="reBS.aspx">修改血糖</a></li>
                    </ul>
                </li>
                <li><a href="#">查詢資料</a>
                     <ul>
                        <li><a href="seBP.aspx">查詢血壓</a></li>
                        <li><a href="seBS.aspx">查詢血糖</a></li>
                        <li><a href="seBoth.aspx">查詢血糖及血糖</a></li>
                    </ul>
                </li>
                <li><a href="H_E.aspx">衛教小學堂</a>
                    <ul>
                        <li><a href="chatroom.aspx">互動聊天室</a></li>
                    </ul>
                </li>
                <li><a href="#">個人資料管理</a>
                    <ul>
                        <li><a href="rePD.aspx">修改個人資料</a></li>
                        <li><a href="reAccount.aspx">修改帳號密碼</a></li>
                        <li><a href="login.aspx">登出</a></li>
                    </ul>
                </li>
            </ul>
        </nav>
        <div style=" text-align:center; position:absolute; right:12px; z-index:1;">
                <asp:Label ID="Name" runat="server"></asp:Label>
            </div>
            <br />
            <div style="height:300px; width:210px; float:left; margin-left:180px; text-align:center;">
                <asp:Label ID="Label_date" runat="server" Text="看診日期："></asp:Label>
                <br />
                <br />
            <asp:TextBox ID="TextBox_date" runat="server" AutoComplete="off" BorderColor="#E3D7CE" BorderStyle="Solid" BorderWidth="5px"></asp:TextBox>
            <br />
            <br />
                <div >
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" OnSelectionChanged="Calendar1_SelectionChanged" Width="200px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
                </div>
            </div>
            <br />
            <div style="height:270px; width:420px; float:left; margin-left:180px; text-align:center; ">
                <asp:Label ID="Label_fre" runat="server" Text="回診間隔："></asp:Label>
            <asp:DropDownList ID="DropDownList_fre" runat="server" Height="36px" Width="80px">
                <asp:ListItem>請選擇</asp:ListItem>
                <asp:ListItem Value="1">一個月</asp:ListItem>
                <asp:ListItem Value="2">兩個月</asp:ListItem>
                <asp:ListItem Value="3">三個月</asp:ListItem>
                <asp:ListItem Value="6">半年</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
                 <img src="回診間隔-醫生護士招手.jpg" alt="iCareÜ" width="200" height="200""
                style="display:block; margin:auto;"/>
            </div>
            <br />
            <div style="height:120px; width:320px; float:left; margin-left:30px; text-align:center;"> 
                <br />
                <asp:Button ID="Button_send" runat="server" OnClick="Button_send_Click" Text="送出" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="Label_text" runat="server"></asp:Label>
                <br />
                <br />
        </div>
            <br />
        <div id="footer" style="clear:both;text-align:center; background-color:white; width:100%; font-family:'Microsoft JhengHei';">
            <hr />
           【聯絡我們】
            <br />
            服務時間:
            週一至週六 9:00～12:00 14:00~17:00 18:00~21:00<br />
            國定假日與週日公休
            <br />
            電話: 03-1234567<br />
            Email: b0710001@gmail.com
        </div>
    </form>
</body>
</html>
