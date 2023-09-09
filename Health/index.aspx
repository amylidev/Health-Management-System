<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Health.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>iCareÜ</title>
    <link type="text/css" href="style.css" rel="stylesheet"/>
    <script src="JavaScript.js" charset="utf-8"></script>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <img src="登入後.png" alt="iCareÜ"  width="100%" height="100%" title="iCareÜ"
                style="display:block; margin:auto;"/>
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
        <div style=" height:750px; width:100%; z-index:-10;"> 
             <div style=" text-align:center; position:absolute; right:12px; z-index:1;">
                <asp:Label ID="Name" runat="server"></asp:Label>
            </div>
        <div style="position:absolute; top:71%; left:6%; background-size:cover;">
            <img src="登入後-醫生小叮嚀.png"  alt="iCareÜ" width="460" height="720" title="iCareÜ"
                style="display:block;"/>
        </div>
            <div style="height:480px; width:300px; z-index:10; text-align:center; position:absolute; top:71%; left:11%;">
            <br /><br />
            <asp:Label ID="Doctor" runat="server" Text="醫師小叮嚀" Font-Size="36px"></asp:Label>
            <br /><br /><br />
            <asp:Label ID="doc_text" runat="server" Font-Size="24px" Width="240px"></asp:Label>
            <br />
        </div>
        <div style="height:390px; width:860px; position:absolute; top:73%; right:1%; z-index:0;">
            <img src="登入後-輸入回診日期.png"  alt="iCareÜ" width="820" height="345" title="iCareÜ"
                style="display:block; "/>
             </div>
        <div style="height:100px; width:730px; position:absolute; top:105%; right:4%; text-align:center; z-index:10;">
            <a href="appointment.aspx" style="font-size:50px" >按此登入回診日期 !</a>
        </div>
            <div style="position:absolute; top:125%; right:15%; text-align:center; z-index:10;">
                 <img src="班表.png"  alt="iCareÜ" width="500" height="300" title="iCareÜ"
                style="display:block; "/>
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
