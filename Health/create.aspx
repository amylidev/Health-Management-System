<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create.aspx.cs" Inherits="Health.create" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>iCareÜ</title>
    <link type="text/css" href="style.css" rel="stylesheet"/>
</head>
<body style="background-color:#FDF8F2;">
    <form id="form1" runat="server">
        <header style="background-color:white; width:100%;">
            <img src="icareu.png" alt="iCareÜ" width="200" height="80" title="iCareÜ"
                style="display:block; margin:auto;"/>
            <hr />
        </header>
        <nav>
             <ul class="flex-nav">
                <li><a href="login.aspx">回登入畫面</a></li>
            </ul>
        </nav>
        <br />
        <div style="height:500px; width:400px; float:left; margin-left:190px; text-align:center; ">
            <br />
            <asp:Label ID="name" runat="server" Text="請輸入姓名:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox_name" runat="server"  AutoComplete="off" BorderColor="#E3D7CE" BorderStyle="Solid" BorderWidth="5px"></asp:TextBox>
            <br /> <br /> <br />
            <asp:Label ID="id" runat="server" Text="請輸入身份證字號:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox_id" runat="server"  AutoComplete="off" BorderColor="#E3D7CE" BorderStyle="Solid" BorderWidth="5px"></asp:TextBox>
            <br /><br /> <br />
            <asp:Label ID="gender" runat="server" Text="請選擇性別"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList_gender" runat="server" style="margin-bottom: 0px">
                <asp:ListItem>男</asp:ListItem>
                <asp:ListItem>女</asp:ListItem>
                <asp:ListItem>不公開</asp:ListItem>
            </asp:DropDownList>
            <br /> <br />
            <asp:Label ID="birth" runat="server" Text="出生日"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList_year" runat="server" OnSelectedIndexChanged="DropDownList_year_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
&nbsp;
            <asp:DropDownList ID="DropDownList_month" runat="server" OnSelectedIndexChanged="DropDownList_year_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
&nbsp;
            <asp:DropDownList ID="DropDownList_day" runat="server" OnSelectedIndexChanged="DropDownList_year_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <div style=" margin-left:100px;">
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="Calendar1_SelectionChanged" >
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
            <div style="height:500px; width:580px; float:left; margin-left:120px; text-align:center; ">
            <br />
            <asp:Label ID="phone" runat="server" Text="請輸入手機號碼:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox_phone" runat="server" AutoComplete="off" BorderColor="#E3D7CE" BorderStyle="Solid" BorderWidth="5px"></asp:TextBox>
            <br /><br /><br />
            <asp:Label ID="mail" runat="server" Text="請輸入電子郵件:(請使用gmail)"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox_mail" runat="server" AutoComplete="off" Width="270px" BorderColor="#E3D7CE" BorderStyle="Solid" BorderWidth="5px"></asp:TextBox>
            <br /> <br /> <br />
            <asp:Label ID="height" runat="server" Text="請輸入身高:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox_height" runat="server"  AutoComplete="off" BorderColor="#E3D7CE" BorderStyle="Solid" BorderWidth="5px" Width="126px"></asp:TextBox>
            <asp:Literal ID="Literal1" runat="server" Text="公分(cm)"></asp:Literal>
            <br /> <br /> <br />
            <asp:Label ID="weight" runat="server" Text="請輸入體重:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox_weight" runat="server"  AutoComplete="off" BorderColor="#E3D7CE" BorderStyle="Solid" BorderWidth="5px" Width="126px"></asp:TextBox>
            <asp:Literal ID="Literal2" runat="server" Text="公斤(kg)"></asp:Literal>
            <br /> <br /><br />
            <asp:Label ID="disease" runat="server" Text="請勾選您有以下哪些疾病     (可複選)"></asp:Label>
            <br />            
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal" CellSpacing="10" RepeatLayout="Flow" >
                <asp:ListItem>高血壓</asp:ListItem>
                <asp:ListItem>高血脂</asp:ListItem>
                <asp:ListItem>高血糖</asp:ListItem>
                <asp:ListItem>心血管疾病</asp:ListItem>
                <asp:ListItem>糖尿病</asp:ListItem>
                <asp:ListItem>無</asp:ListItem>
            </asp:CheckBoxList>
            <br /><br /><br />
            <asp:Button ID="Button_confirm" runat="server" Text="送出" OnClick="Button_confirm_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="label" runat="server" Visible="False" ForeColor="Red"></asp:Label>
             <br />
                </div>
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
