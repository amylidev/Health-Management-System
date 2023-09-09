<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chatroom.aspx.cs" Inherits="Health.chatroom" %>

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
         <div style=" text-align:center; position:absolute; right:12px; z-index:1;">
                <asp:Label ID="Name" runat="server"></asp:Label>
            </div>
        <br />
        <div style="height:535px; width:100%;">
        <div  style="position:absolute; left:70px; z-index:1; background-size:cover;  text-align:center;">
            <div>
             <img src="1.png" alt="iCareÜ" width="460" height="490" title="iCareÜ"
                style="display:block; z-index:0;"/>
            </div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="詢問"  Height="35px" Width="70px"/>
           </div>
           <div style="position:absolute; left:550px; z-index:1; background-size:cover; text-align:center;">
            <div>
             <img src="2.png" alt="iCareÜ" width="460" height="490" title="iCareÜ"
                style="display:block; margin:auto 0; z-index:0;"/>
            </div>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="詢問" Height="35px" Width="70px" />
           </div> 
           <div style="position:absolute; left:1020px; z-index:1; background-size:cover; text-align:center;">
            <div>
             <img src="5.png" alt="iCareÜ" width="460" height="490" title="iCareÜ"
                style="display:block; z-index:0;"/>
            </div>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="詢問" Height="35px" Width="70px" />
           </div>
            </div>
         <div style="height:535px; width:100%;">
        <div style="position:absolute; left:70px; z-index:1; background-size:cover; text-align:center;">
            <div >
             <img src="4.png" alt="iCareÜ" width="460" height="490" title="iCareÜ"
                style="display:block; z-index:0;"/>
            </div>
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="詢問" Height="35px" Width="70px" />
           </div>
           <div style="position:absolute; left:550px; z-index:1; background-size:cover; text-align:center;">
            <div >
             <img src="3.png" alt="iCareÜ" width="460" height="490" title="iCareÜ"
                style="display:block; z-index:0;"/>
            </div>
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="詢問"  Height="35px" Width="70px"/>
           </div>
           <div style="position:absolute; left:1020px; z-index:1; background-size:cover; text-align:center;">
            <div>
             <img src="6.png" alt="iCareÜ" width="460" height="490" title="iCareÜ"
                style="display:block; z-index:0;"/>
            </div>
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="詢問" Height="35px" Width="70px" />
           </div>
              </div>
        <footer>
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
        </footer>
    </form>
</body>
</html>
