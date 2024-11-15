<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FacilityGuide.aspx.cs" Inherits="Interstay_ConciergeCustomerWebFormApp.FacilityGuide" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .RadPanelBar .rpImage {
        float: left;
        border: 0;
        vertical-align: middle;
        padding: 13px 3px 3px;
    }
    </style>
    <telerik:radpanelbar ID="pnlContentType" Width="100%" runat="server" Skin="MetroTouch">        
    </telerik:radpanelbar>
</asp:Content>
