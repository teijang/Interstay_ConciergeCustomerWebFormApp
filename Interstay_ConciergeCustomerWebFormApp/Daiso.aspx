<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Daiso.aspx.cs" Inherits="Interstay_ConciergeCustomerWebFormApp.Daiso" %>

<!DOCTYPE html>

<html lang="ko">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - Daiso Quick Search</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="/Content/bootstrap.css" rel="stylesheet">
    <link href="/Content/Site_Daiso.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>
        <div class="navbar navbar-inverse navbar-fixed-top">
                    <a runat="server" href="~/">
                        <img src="images/daiso_logo.gif" width="100px" height="auto" /></span></a>
            
                    &nbsp;&nbsp;찾기:<asp:TextBox ID="TextBox1" runat="server" Width="100px" ></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/icon_search.png" CssClass="daiso-header"/>
                    <asp:DropDownList ID="lstLanguage" runat="server" style="display:inline-block;" cssClass="lg">
                        <asp:ListItem Text="English" Value="en-US"></asp:ListItem>
                        <asp:ListItem Text="한국어" Value="ko-KR"></asp:ListItem>
                        <asp:ListItem Text="简体中文" Value="zh-CN"></asp:ListItem>
                        <asp:ListItem Text="繁體中文" Value="zh-TW"></asp:ListItem>
                        <asp:ListItem Text="日本語" Value="ja-JP"></asp:ListItem>
                    </asp:DropDownList>
        </div>
        <div class="container body-content">
            
            <hr />
            <footer>
                <p>&copy; <%: DateTime.Now.Year %> - Interstay Inc.</p>
            </footer>
        </div>        
    </form>
    </form>
</body>
</html>
