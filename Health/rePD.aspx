<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rePD.aspx.cs" Inherits="Health.rePD" %>

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
                <asp:Label ID="N" runat="server"></asp:Label>
            </div>  
        <div style="height:580px; width:260px; float:left; margin-left:60px;">
            <br />
            <br />
            <asp:Label ID="LBname" runat="server" Text="姓名:"></asp:Label>
            <br /><br />
            <asp:TextBox ID="name" runat="server" BorderColor="#E3D7CE" BorderStyle="Solid" BorderWidth="5px"></asp:TextBox>
            <br /><br />
            <asp:Label ID="LBpid" runat="server" Text="身份證字號:"></asp:Label>
            <br /><br />
            <asp:TextBox ID="pid" runat="server" BorderColor="#E3D7CE" BorderStyle="Solid" BorderWidth="5px"></asp:TextBox>
            <br /><br />
            <asp:Label ID="LBbday" runat="server" Text="生日:"></asp:Label>
            <br /><br />
            <asp:TextBox ID="bday" runat="server" BorderColor="#E3D7CE" BorderStyle="Solid" BorderWidth="5px"></asp:TextBox>
            <br /><br />
            <asp:Label ID="LBsex" runat="server" Text="性別:"></asp:Label>
            <br /><br />
            <asp:TextBox ID="sex" runat="server" BorderColor="#E3D7CE" BorderStyle="Solid" BorderWidth="5px"></asp:TextBox>
            <br /><br />
            <asp:Label ID="LBheight" runat="server" Text="身高:"></asp:Label>
            <br /><br />
            <asp:TextBox ID="height" runat="server" BorderColor="#E3D7CE" BorderStyle="Solid" BorderWidth="5px"></asp:TextBox>
            <br /><br />
            <asp:Label ID="LBweight" runat="server" Text="體重:"></asp:Label>
            <br /><br />
            <asp:TextBox ID="weight" runat="server" Height="19px" BorderColor="#E3D7CE" BorderStyle="Solid" BorderWidth="5px"></asp:TextBox>
            <br /><br />
           </div>
         <div  style="height:580px; width:340px; float:left; margin-left:50px;">
             <br /><br />
            <asp:Label ID="LBphone" runat="server" Text="電話:"></asp:Label>
            <br /><br />
            <asp:TextBox ID="phone" runat="server" BorderColor="#E3D7CE" BorderStyle="Solid" BorderWidth="5px"></asp:TextBox>
            <br /><br />
            <asp:Label ID="LBmail" runat="server" Text="郵件"></asp:Label>
             <br /><br />
             <asp:TextBox ID="mail" runat="server" BorderColor="#E3D7CE" BorderStyle="Solid" BorderWidth="5px"></asp:TextBox>
             <br /><br />
             <asp:Label ID="LBdiabete" runat="server" Text="是否有糖尿病:"></asp:Label>
            <br /><br />
            <asp:TextBox ID="diabete" runat="server" style="height: 19px" BorderColor="#E3D7CE" BorderStyle="Solid" BorderWidth="5px"></asp:TextBox>
            <br /><br />
            <asp:Label ID="LBcardio" runat="server" Text="是否有心血管疾病:"></asp:Label>
             <br /><br />
             <asp:TextBox ID="cardio" runat="server" BorderColor="#E3D7CE" BorderStyle="Solid" BorderWidth="5px"></asp:TextBox>
             <br /><br />
            <asp:Label ID="LBhighrisk" runat="server" Text="是否為三高患者:"></asp:Label>
            <br /><br />
            <asp:TextBox ID="highrisk" runat="server" BorderColor="#E3D7CE" BorderStyle="Solid" BorderWidth="5px"></asp:TextBox>
            <br /><br />
             <br />
            <asp:Button ID="info" runat="server" OnClick="info_Click" Text="送出修改" />
            <br />
             <asp:Label ID="show" runat="server" Text=" "></asp:Label>
             <asp:Label ID="sucess" runat="server" Text=" "></asp:Label>
            </div>
        <br /><br />
        <div style="height:480px; width:480px; float:left; margin-left:90px;">
              <img src="個人資料管理-提醒.png" alt="iCareÜ" width="100%" height="100%"
                style="display:block; margin:auto;"/>
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
