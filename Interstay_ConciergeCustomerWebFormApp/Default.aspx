<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Interstay_ConciergeCustomerWebFormApp._Default" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        @import url('https://fonts.googleapis.com/css2?family=Nanum+Pen+Script&display=swap');
    </style>
    <telerik:RadNotification ID="notificationSuccess" runat="server" AutoCloseDelay="3000" Width="300px" Height="100px" 
            Position="TopCenter" Title="Success" Text="Your request has been successfully submitted." meta:resourcekey="notificationSuccessResource1"></telerik:RadNotification>
    <telerik:RadNotification ID="notificationSuccessCheckOut" runat="server" AutoCloseDelay="3000" Width="300px" Height="100px" 
            Position="TopCenter" Title="Success" Text="Your request has been successfully submitted." meta:resourcekey="notificationSuccessCheckOutResource1"></telerik:RadNotification>
    <div class="row1">
        <telerik:RadPanelBar ID="pnlPendingRequests" Width="100%" runat="server" Skin="MetroTouch" Visible="false"></telerik:RadPanelBar>
    </div>
    <div class="page-header text-center">
        <h2><asp:Label ID="lblMainTitle" runat="server" Text="Concierge Menu" meta:resourcekey="lblMainTitleResource1"></asp:Label></h2>  
        <div class="bar"></div>
    </div>    
    <div class="row1">
        <div class="col-xs-6 text-center">            
            <% if (Request.Cookies["messageType_id_check_out"] != null) { %>
                <div class="box"><a href="ServiceRequest/?SpecialFeature=Check-Out&MessageType_Id=<% = Request.Cookies["messageType_id_check_out"].Value %>" style="border:none;"><img src="images/check-out.png" style="width:110px; height:auto; max-width:130px" /></a></div>
                <h3><asp:Label ID="lblCheckOut" runat="server" Text="Check-Out" meta:resourcekey="lblCheckOutResource1"></asp:Label></h3>
            <% } %>
        </div>
        <div class="col-xs-6 text-center">            
            <div class="box"><a href="FacilityGuide" style="border:none;"><img src="images/manual.png" style="width:90px; height:auto; max-width:100px" /></a></div>
            <h3><asp:Label ID="lblManual" runat="server" Text="Facility Manual" meta:resourcekey="lblManualResource1"></asp:Label></h3>
        </div>
    </div>
   <br />
    <div class="row1">
        <div class="col-xs-6 text-center">            
            <div class="box"><a href="ServiceRequest" style="border:none;"><img src="images/help.png" style="width:100px; height:auto; max-width:100px" /></a></div>
            <h3><asp:Label ID="lblServiceRequest" runat="server" Text="Service Request" meta:resourcekey="lblServiceRequestResource1"></asp:Label></h3>
        </div>
        <div class="col-xs-6 text-center">            
            <div class="box"><a href="Neighborhod" style="border:none;"><img src="images/map.png" style="width:100px; height:auto; max-width:100px" /></a></div>
            <h3><asp:Label ID="lblNeighborhood" runat="server" Text="Neighborhood" meta:resourcekey="lblNeighborhoodResource1"></asp:Label></h3>
        </div>
    </div>
    <div class="row2">
            <div class="bnb">
                <div class="col-xs-12 text-center">
                    <img src="https://images.inter-stay.com/IS_LOGO.png" style="width:100%; height:auto; max-width:250px;">
                </div>
            </div><!--bnb-->
    </div><!--row2-->
    
    <asp:HiddenField ID="hdnHotel_Id" runat="server" Value="0" />
    <asp:HiddenField ID="hdnRoom_Number" runat="server" Value="0" />
    <asp:HiddenField ID="hdnLanguage" runat="server" Value="en-US" />
</asp:Content>
