<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="seBS.aspx.cs" Inherits="Health.seBS" %>

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
            <img src="查詢.png" alt="iCareÜ" width="100%" height="100%" title="iCareÜ"
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
          <div style=" text-align:center; float:right;">
          <asp:Label ID="Name" runat="server"></asp:Label>
          </div>
        <div style="height:30px; width:420px; float:left; margin-left:80px; text-align:center;">
            <br />
            <asp:Label ID="Label1" runat="server" Text="請選擇查詢方式:"></asp:Label>
            <asp:DropDownList ID="ModeList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ModeList_SelectedIndexChanged">
            <asp:ListItem>請選擇</asp:ListItem>
            <asp:ListItem>某一日</asp:ListItem>
            <asp:ListItem>某一週</asp:ListItem>
            <asp:ListItem>某一月</asp:ListItem>
            <asp:ListItem>一年走勢</asp:ListItem>
        </asp:DropDownList>
        </div>
        <br />
        <div style="clear:both;"> </div>
        <div style="height:340px; width:420px; float:left; margin-left:80px; text-align:center;">
            <br />
        <asp:Label ID="Month" runat="server" Text="請選擇查詢年份及月份:"></asp:Label>
            <asp:DropDownList ID="MonthYear" runat="server">
            </asp:DropDownList>
        <asp:DropDownList ID="MonthList" runat="server">
            <asp:ListItem Value="01">1</asp:ListItem>
            <asp:ListItem Value="02">2</asp:ListItem>
            <asp:ListItem Value="03">3</asp:ListItem>
            <asp:ListItem Value="04">4</asp:ListItem>
            <asp:ListItem Value="05">5</asp:ListItem>
            <asp:ListItem Value="06">6</asp:ListItem>
            <asp:ListItem Value="07">7</asp:ListItem>
            <asp:ListItem Value="08">8</asp:ListItem>
            <asp:ListItem Value="09">9</asp:ListItem>
            <asp:ListItem Value="10">10</asp:ListItem>
            <asp:ListItem Value="11">11</asp:ListItem>
            <asp:ListItem Value="12">12</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="Year" runat="server" Text="請選擇查詢年份:"></asp:Label>
        <asp:DropDownList ID="YearList" runat="server">
        </asp:DropDownList>
        <br />
            <div style="width:280px; margin:0 auto">
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="179px" SelectionMode="DayWeek" Width="305px">
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
            <br />
        <asp:Button ID="ChoseDate" runat="server" OnClick="ChoseDate_Click" Text="查詢" />
        </div>
        <div style="height:380px; width:660px; float:left; margin-left:80px; text-align:center;">
        <asp:Label ID="GridTitle" runat="server"></asp:Label>
            <br />
            <div style="width:360px; margin:0 auto">
                 <asp:GridView ID="BloodsugarGrid" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="100px" Width="346px">
            <Columns>
                <asp:BoundField DataField="時間" HeaderText="時間" SortExpression="時間" />
                <asp:BoundField DataField="血糖值" HeaderText="血糖值" SortExpression="血糖值" />
            </Columns>
        </asp:GridView>
            </div>
            <span>
                 <asp:Label ID="SugarTitle" runat="server" ForeColor="Red"></asp:Label>
            <br />
        <asp:Chart ID="SugarChart" runat="server" Height="325px" Width="750px">
            <Series>
                <asp:Series Name="Series1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
            <br />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnDB %>" SelectCommand="SELECT [時間], [血糖值] FROM [BS] WHERE (([病歷號] = @病歷號) AND ([日期] = @日期))">
            <SelectParameters>
                <asp:SessionParameter Name="病歷號" SessionField="Num" Type="Int32" />
                <asp:SessionParameter DbType="Date" Name="日期" SessionField="Date" />
            </SelectParameters>
        </asp:SqlDataSource>
            </span>
        </div>
        <div style="clear:both;"> </div>
        <div  style="height:290px; width:100%;">
        <div style="position:absolute; left:50px; z-index:1; background-size:cover;">
            <img src="查詢-醫生.png" alt="iCareÜ"  width="330" height="280" title="iCareÜ"
                style="display:block; z-index:0;"/>
        </div>
        <div style="width:180px; position:absolute; left:180px; text-align:center; z-index:20">
            <br />
                <asp:Label ID="Doctor" runat="server">醫生的話：</asp:Label>
             </div>
         <div  style="position:absolute; left:420px; z-index:1; background-size:cover;">
            <img src="查詢-護士.png" alt="iCareÜ"  width="330" height="280" title="iCareÜ"
                style="display:block; z-index:0;"/>
        </div>
             <div style="width:180px; position:absolute; left:515px; text-align:center;  z-index:20">
                 <br />
                   <asp:Label ID="Nurse" runat="server">護士的話：</asp:Label>
                 </div>
         <div  style="position:absolute; left:780px; z-index:1; background-size:cover;">
            <img src="查詢-個管師.png" alt="iCareÜ" width="330" height="280" title="iCareÜ"
                style="display:block; z-index:0;"/>
        </div>
        <div style="width:180px; position:absolute; left:820px; text-align:center;  z-index:20">
            <br />
                 <asp:Label ID="Manager" runat="server">個管師的話：</asp:Label>
             </div>
         <div  style="position:absolute; left:1150px; z-index:1; background-size:cover;">
            <img src="查詢-藥師.png" alt="iCareÜ" width="330" height="280" title="iCareÜ"
                style="display:block; z-index:0;"/>
        </div>
        <div style="width:175px; position:absolute; left:1180px; text-align:center;  z-index:20">
            <br />
                  <asp:Label ID="Pharmacist" runat="server">藥師的話：</asp:Label>
             </div>
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