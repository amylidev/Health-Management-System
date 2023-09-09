<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="H_E.aspx.cs" Inherits="Health.H_E" %>

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
             <img src="衛教小學堂.png" alt="iCareÜ" width="100%" height="100%" title="iCareÜ"
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
        <div style="height:420px; width:100%;">
             <div style="position:absolute; left:60px; z-index:1; background-size:cover;">
             <img src="認識高血壓.png" alt="iCareÜ" width="400" height="400" title="iCareÜ"
                style="display:block; z-index:0;"/>
        </div>
        <div style="position:absolute; text-align:center; left:160px; top:860px; z-index:20;">
            <asp:Button ID="Button_kp" runat="server" Text="查詢" OnClick="Button_kp_Click" Height="35px" Width="70px" />
        </div>
        <div style="position:absolute; left:520px; z-index:1; background-size:cover;">
            <img src="認識糖尿病.png" alt="iCareÜ" width="400" height="400" title="iCareÜ"
                style="display:block; z-index:0;"/>
        </div>
         <div  style="position:absolute; text-align:center;  left:600px; top:860px; z-index:20;">
            <asp:Button ID="Button_ks" runat="server" Text="查詢" OnClick="Button_ks_Click"  Height="35px" Width="70px" />
        </div>
        <div style="position:absolute; left:990px; z-index:1; background-size:cover;">
            <img src="認識代謝症候群.png" alt="iCareÜ" width="400" height="400" title="iCareÜ"
                style="display:block; z-index:0;"/>
        </div>
         <div  style="position:absolute; text-align:center;  left:1080px; top:860px; z-index:20;">
            <asp:Button ID="Button_kms" runat="server" Text="查詢" OnClick="Button_kms_Click" Height="35px" Width="70px" />
        </div>
             </div>
            <div style="height:420px; width:100%;">
        <div style="position:absolute; left:60px; z-index:1; background-size:cover;">
             <img src="高血壓居家照護.png" alt="iCareÜ" width="400" height="400" title="iCareÜ"
                style="display:block; z-index:0;"/>
        </div>
        <div  style="position:absolute; text-align:center;left:160px; top:1290px; z-index:20;">
            <asp:Button ID="Button_ptk" runat="server" Text="查詢" OnClick="Button_ptk_Click"  Height="35px" Width="70px" />
        </div>
        <div style="position:absolute; left:520px; z-index:1; background-size:cover;">
            <img src="糖尿病vs高血糖.png" alt="iCareÜ" width="400" height="400" title="iCareÜ"
                style="display:block; z-index:0;"/>
        </div>
        <div  style="position:absolute; text-align:center; left:600px; top:1290px; z-index:20;">
            <asp:Button ID="Button_s" runat="server" Text="查詢" OnClick="Button_s_Click" Height="35px" Width="70px" />
        </div>
        <div style="position:absolute; left:990px; z-index:1; background-size:cover;">
            <img src="地中海飲食.png" alt="iCareÜ" width="400" height="400" title="iCareÜ"
                style="display:block; z-index:0;"/>
        </div>
        <div  style="position:absolute; text-align:center; left:1080px; top:1290px; z-index:20;">
            <asp:Button ID="Button_md" runat="server" Text="查詢" OnClick="Button_md_Click"  Height="35px" Width="70px" />
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
