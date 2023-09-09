<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forget.aspx.cs" Inherits="Health.forget" %>

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
            <img src="身分驗證.png" alt="iCareÜ" width="100%" height="100%" title="iCareÜ"
                style="display:block; margin:auto;"/>
            <div style="clear:both;"> </div>
        </header>
        <nav>
             <ul class="flex-nav">
                <li><a href="login.aspx">回登入畫面</a></li>
            </ul>
        </nav>
        <br />
         <div style=" height:530px; width:100%; "> 
        <div style="position:absolute; top:75%; left:12%; background-size: cover;">
            <img src="小提醒.png"  alt="iCareÜ" width="470" height="470" title="iCareÜ"
                style="display:block; z-index:-1;"/>
        </div>
        <div style="border-radius:50px; height:470px; width:450px; position:absolute;
                    top:75%; right:12%; z-index:-1; background-color:#E3D7CE">
        </div>
        <div style="border-radius:50px; height:440px; width:420px; position:absolute;
                top:77%; right:13%; text-align:center; background-color:antiquewhite;  z-index:10;">
            <br />
            <asp:Label ID="identity_verification" runat="server" Text="身分驗證" Font-Size="40px" CssClass="font-family:'Microsoft JhengHei';"></asp:Label>
            <hr />
            <br /><br /> <br />
            <asp:Label ID="birth" runat="server" Text="請輸入您的生日 (格式:2000/01/01)"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox_birth" runat="server" AutoComplete="off"></asp:TextBox>
            <br /><br /><br /><br />
            <asp:Label ID="id" runat="server" Text="請輸入您的身份證字號"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox_id" runat="server" AutoComplete="off"></asp:TextBox>
            <br /><br /><br /><br />
            <asp:Button ID="Button_confirm" runat="server" OnClick="Button_confirm_Click" Text="確認" />
            <br /><br />
            <asp:Label ID="text" runat="server" ForeColor="Red" Visible="False"></asp:Label>
            <br /><br /><br />
        </div>
             </div>
        <div id="footer" style="clear:both; text-align:center; background-color:white; width:100%; font-family:'Microsoft JhengHei';">
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
