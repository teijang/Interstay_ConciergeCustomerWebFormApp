<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Neighborhod.aspx.cs" Inherits="Interstay_ConciergeCustomerWebFormApp.Neighborhod" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
    
    .row{
        width: 90%;
        margin:10px auto;
        border-bottom: 1px solid #ddd;
    }
    .row:last-child{
        border:none;
    }
    .left{
        padding:15px;
        width: 33.333%;
    }
    .left img{
        width: 60px;
        margin-left: 50%;
        transform: translate(-50%);
    }
    .right{
        padding:10px 15px;
    }
    .right .tit{
        font-size: 16px;
        font-weight: bold;
    }
    .right .txt{
        font-size: 12px;
    }
    .right a{
        display: block;
        font-size: 14px;
        text-decoration: none;
        color:#e43a19;
        margin:10px 0;
    }
    .right a:hover{
        text-decoration: underline;
    }
    </style>    
    <div class="wrap">
        <asp:Label ID="lblBody" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
