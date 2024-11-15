<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="FCMTest.aspx.cs" Inherits="Interstay_ConciergeCustomerWebFormApp.FCMTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            title : <asp:TextBox ID="txtTitle" runat="server" Text="title"></asp:TextBox><br />
            body : <asp:TextBox ID="txtBody" runat="server" Text="New Notification"></asp:TextBox><br />
            topic : <asp:TextBox ID="txtTopic" runat="server" Text=""></asp:TextBox><br />
            token : <asp:TextBox ID="txtToken" runat="server" Text=""></asp:TextBox><br /><br />
            data key : <asp:TextBox ID="txtDataKey" runat="server" Text="id"></asp:TextBox> : 
            data value : <asp:TextBox ID="txtDataValue" runat="server" Text="1234"></asp:TextBox> <br /> <br />
            <asp:Button ID="btnTopic" runat="server" Text="Topic으로 보내기" OnClick="btnTopic_Click" />&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnToken" runat="server" Text="Token으로 보내기" OnClick="btnToken_Click" />
        </div>
    </form>
</body>
</html>
