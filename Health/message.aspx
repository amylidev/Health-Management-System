<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="message.aspx.cs" Inherits="Health.message" %>

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
            <img src="聊天室.png" alt="iCareÜ" width="100%" height="100%" title="iCareÜ"
                style="display:block; margin:auto; z-index:0;"/>
            <div style="clear:both;"> </div>
            <nav>
             <ul class="flex-nav">
                <li><a href="index.aspx">首頁</a></li>
                <li><a href="#">新增資料</a>
                    <ul style="z-index:150!important;">
                        <li><a href="inBP.aspx">新增血壓</a></li>
                        <li><a href="inBS.aspx">新增血糖</a></li>
                    </ul>
                </li>
                <li><a href="#">修改資料</a>
                    <ul style="z-index:150!important;">
                        <li><a href="reBP.aspx">修改血壓</a></li>
                        <li><a href="reBS.aspx">修改血糖</a></li>
                    </ul>
                </li>
                <li><a href="#">查詢資料</a>
                     <ul style="z-index:150!important;">
                        <li><a href="seBP.aspx">查詢血壓</a></li>
                        <li><a href="seBS.aspx">查詢血糖</a></li>
                        <li><a href="seBoth.aspx">查詢血糖及血糖</a></li>
                    </ul>
                </li>
                <li><a href="H_E.aspx">衛教小學堂</a>
                    <ul style="z-index:150!important;">
                        <li><a href="chatroom.aspx">互動聊天室</a></li>
                    </ul>
                </li>
                <li><a href="#">個人資料管理</a>
                    <ul style="z-index:150!important;">
                        <li><a href="rePD.aspx">修改個人資料</a></li>
                        <li><a href="reAccount.aspx">修改帳號密碼</a></li>
                        <li><a href="login.aspx">登出</a></li>
                    </ul>
                </li>
            </ul>
        </nav>
        </header>
        <div style="height:640px; width:100%;">
        <div style=" text-align:center; position:absolute; right:12px; z-index:1;">
                <asp:Label ID="Name" runat="server"></asp:Label>
            </div>
            <div style="float:left; margin-left:15px; z-index:1";>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
            </asp:Timer>
            <br />
            <asp:Label ID="Label_txt" runat="server" Font-Size="23px"></asp:Label>
            <br /> <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <contenttemplate>
                    <asp:TextBox ID="TextBox_messageboard" runat="server" Height="425px" TextMode="MultiLine" Width="550px" ReadOnly="True"></asp:TextBox>
                </contenttemplate>
                <triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                    <asp:AsyncPostBackTrigger ControlID="Button_send" EventName="Click" />
                </triggers>
            </asp:UpdatePanel>    
                <ContentTemplate>
                    <br /><br />
            <div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                 <asp:Label ID="Label_txtmess" runat="server" Text="訊息："></asp:Label>               
                 <asp:TextBox ID="TextBox_enter" runat="server" AutoCompleteType="Disabled"  AutoComplete="off" Width="370px" Height="35px" ></asp:TextBox>
&nbsp;<asp:Button ID="Button_send" runat="server" OnClick="Button_send_Click" Text="送出" Height="35px" Width="65px" />
                    &nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </ContentTemplate>
                </asp:UpdatePanel> 
            </div>
                </ContentTemplate>
            </div>
           <div style="float:left; margin-left:125px;z-index:1; background-size: cover;">
               <br /><br />
            <img src="icareu小車車.png"  alt="iCareÜ" width="555" height="580" title="iCareÜ"
                style="display:block; z-index:5;"/>
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
