<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reAccount.aspx.cs" Inherits="Health.reAccount" %>

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
            <img src="修改.png" alt="iCareÜ" width="100%" height="100%" title="iCareÜ"
                style="display:block; margin:auto; z-index:0;"/>
            <div style="clear:both;"> </div>
        </header>
        <nav style="z-index:5">
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
        <div style="height:420px; width:360px; float:left; margin-left:140px; text-align:center; ">
            <br />
            <asp:Label ID="Label" runat="server" Text="請選擇您要更改的項目:"></asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>更改帳號</asp:ListItem>
                <asp:ListItem>更改密碼</asp:ListItem>
                <asp:ListItem>更改帳號及密碼</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="newaccount" runat="server" Text="請輸入新帳號:"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBox_na" runat="server" AutoComplete="off" BorderColor="#E3D7CE" BorderStyle="Solid" BorderWidth="5px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button_con1" runat="server" OnClick="Button_con1_Click" Text="送出" />
            <br />
            <asp:Label ID="newpassword" runat="server" Text="請輸入新密碼:" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBox_np" runat="server" Visible="False" AutoComplete="off" BorderColor="#E3D7CE" BorderStyle="Solid" BorderWidth="5px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button_con2" runat="server" OnClick="Button_con2_Click" Text="送出" Visible="False" />
            <br />
            <asp:Label ID="text" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Button ID="Button_confirm" runat="server" OnClick="Button_confirm_Click" Text="確認" Visible="False" />
        </div>
         <div style="height:480px; width:480px; float:left; margin-left:220px;">
              <img src="個人資料管理-修改.png" alt="iCareÜ" width="100%" height="100%"
                style="display:block;"/>
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
