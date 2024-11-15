<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Interstay_ConciergeCustomerWebFormApp._Default" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadNotification ID="notificationSuccess" runat="server" AutoCloseDelay="3000" Width="300px" Height="100px" 
            Position="TopCenter" Title="Success" Text="Your request has been successfully submitted." meta:resourcekey="notificationSuccessResource1"></telerik:RadNotification>
    <telerik:RadNotification ID="notificationSuccessCheckOut" runat="server" AutoCloseDelay="3000" Width="300px" Height="100px" 
            Position="TopCenter" Title="Success" Text="Your request has been successfully submitted." meta:resourcekey="notificationSuccessCheckOutResource1"></telerik:RadNotification>
    <div class="page-header text-center">
        <h2><asp:Label ID="lblMainTitle" runat="server" Text="Concierge Menu" meta:resourcekey="lblMainTitleResource1"></asp:Label></h2>        
    </div>
    <div class="row">
        <telerik:RadPanelBar ID="pnlPendingRequests" Width="100%" runat="server" Skin="MetroTouch" Visible="false"></telerik:RadPanelBar>
    </div>
    <div class="row">
        <div class="col-xs-6 text-center">            
            <a href="ServiceRequest/?MessageType_Id=6" style="border:none;"><img src="images/checkout.png" style="width:100%; height:auto; max-width:100px" /></a>
            <h3><asp:Label ID="lblCheckOut" runat="server" Text="Check-Out" meta:resourcekey="lblCheckOutResource1"></asp:Label></h3>
        </div>
        <div class="col-xs-6 text-center">            
            <a href="FacilityGuide" style="border:none;"><img src="images/manual.png" style="width:100%; height:auto; max-width:100px" /></a>
            <h3><asp:Label ID="lblManual" runat="server" Text="Facility Manual" meta:resourcekey="lblManualResource1"></asp:Label></h3>
        </div>
    </div>
   <br />
    <div class="row">
        <div class="col-xs-6 text-center">            
            <a href="ServiceRequest" style="border:none;"><img src="images/chat.png" style="width:100%; height:auto; max-width:100px" /></a>
            <h3><asp:Label ID="lblServiceRequest" runat="server" Text="Service Request" meta:resourcekey="lblServiceRequestResource1"></asp:Label></h3>
        </div>
        <div class="col-xs-6 text-center">            
            <a href="Neighborhod" style="border:none;"><img src="images/navigate2.png" style="width:100%; height:auto; max-width:100px" /></a>
            <h3><asp:Label ID="lblNeighborhood" runat="server" Text="Neighborhood" meta:resourcekey="lblNeighborhoodResource1"></asp:Label></h3>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-xs-12 text-center">
            <a href='<% = Request.Cookies["bnbmall_URL"].Value %>' target="_blank" style="border:none"><img src="images/bnbmall2_transparent.png" style="width:100%; height:auto; max-width:350px;" /></a>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-xs-4  text-center">
            <a href="https://dev.bnbmall.com/jeju001?affiliate=interstay" target="_blank" style="border:none"><img src="https://images.bnbmall.com/0001250_2019CW009_100.jpeg" style="border:none;width:100%;height:auto;max-width:100px" /></a>
        </div>
        <div class="col-xs-8">
            <h4><a href="https://dev.bnbmall.com/jeju001?affiliate=interstay" target="_blank" style="border:none">[제주] 지역 명물 돌빵</a></h4>
            <h5>요즘 제주에서 가장 핫한 제주돌빵으로 제주도 여행시 필수 쇼핑 리스트 및 코스입니다.</h5>
            <h5>12,000 원&nbsp;&nbsp;<a href="https://dev.bnbmall.com/jeju001?affiliate=interstay" target="_blank" style="border:none"><button type="button" class="btn btn-primary">자세히 보기</button></a></h5>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-xs-4  text-center">
            <a href="https://dev.bnbmall.com/seoul001?affiliate=interstay" target="_blank" style="border:none"><img src="https://images.bnbmall.com/0001252_seoul001_100.jpeg" style="border:none;width:100%;height:auto;max-width:100px" /></a>
        </div>
        <div class="col-xs-8">
            <h4><a href="https://dev.bnbmall.com/seoul001??affiliate=interstay" target="_blank" style="border:none">[서울] 에버랜드 얼리버드 종일 이용권</a></h4>
            <h5>40% 할인권 입니다.(방문일 지정)(20/11/1~21/1/3)</h5>
            <h5>25,000 원&nbsp;&nbsp;<a href="https://dev.bnbmall.com/seoul001?affiliate=interstay" target="_blank" style="border:none"><button type="button" class="btn btn-primary">자세히 보기</button></a></h5>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-xs-4  text-center">
            <a href="https://dev.bnbmall.com/busan001?affiliate=interstay" target="_blank" style="border:none"><img src="https://images.bnbmall.com/0001253_busan001_100.jpeg" style="border:none;width:100%;height:auto;max-width:100px" /></a>
        </div>
        <div class="col-xs-8">
            <h4><a href="https://dev.bnbmall.com/busan001?affiliate=interstay" target="_blank" style="border:none">[부산] 해운대 SEA LIFE 아쿠아리움</a></h4>
            <h5>아름다운 해저 깊숙이 펼쳐지는 부산 아쿠아리움</h5>
            <h5>20,900 원&nbsp;&nbsp;<a href="https://dev.bnbmall.com/busan001?affiliate=interstay" target="_blank" style="border:none"><button type="button" class="btn btn-primary">자세히 보기</button></a></h5>
        </div>
    </div>
    <asp:HiddenField ID="hdnHotel_Id" runat="server" Value="0" />
    <asp:HiddenField ID="hdnRoom_Number" runat="server" Value="0" />
    <asp:HiddenField ID="hdnLanguage" runat="server" Value="en-US" />
</asp:Content>
