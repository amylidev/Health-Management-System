<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Health.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>iCareÜ</title>
    <script src="JavaScript.js" charset="utf-8"></script>
    <style>
        html {
            height: 100%;
        }

        body {
            background-image: url(登入背景.png);
            background-repeat: no-repeat;
            background-attachment: fixed;
            background-position: center;
            background-size: cover;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <header>
            <img src="icareu.png" alt="iCareÜ" width="380" height="160" title="iCareÜ"
                style="display:block; margin:auto;"/>
        </header>
        <br />
        <div style="height:540px; width:520px; margin:0 auto;">
            <div style="z-index:1; background-size: cover;">
            <img src="首頁登入.png"  alt="iCareÜ" width="520" height="540" title="iCareÜ"
                style="display:block;  margin:0 auto; z-index:1;"/>
        </div>   
         <div style="height:400px; width:440px; position:absolute; margin-left:35px; top:280px; text-align:center; z-index:20;">
            <asp:Label ID="account" runat="server" Text="帳號:" Font-Size="Large"></asp:Label>
            <br />
            <asp:Literal ID="Literal1" runat="server" Text="(預設為您的身份證字號)"></asp:Literal>
            <br />
            <asp:TextBox ID="TextBox_account" runat="server" AutoComplete="off"  TextMode="Password" BorderStyle="Groove"></asp:TextBox>
            <br /><br /> <br /><br />
            <asp:Label ID="password" runat="server" Text="密碼:" Font-Size="Large"></asp:Label>
            <br />
            <asp:Literal ID="Literal2" runat="server" Text="(預設為您的生日 e.g.19110101)"></asp:Literal>
            <br />
            <asp:TextBox ID="TextBox_password" runat="server" AutoComplete="off" TextMode="Password" BorderStyle="Groove"></asp:TextBox>
            <br /> <br />
            <asp:Label ID="text" runat="server" ForeColor="Red" Visible="False"></asp:Label>
            <br /><br />
            <asp:Button ID="Button_login" runat="server" OnClick="Button_login_Click" Text="登入" Height="27px" Width="67px" />
            <br /> <br /><br />
            <a href="create.aspx">創建帳號</a>
            <br />
            <a href="forget.aspx">忘記帳密</a>
        </div>
        </div>
    </form>
</body>
</html>
