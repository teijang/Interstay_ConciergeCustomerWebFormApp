<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Async="true" CodeBehind="ServiceRequest.aspx.cs" EnableEventValidation="false" Inherits="Interstay_ConciergeCustomerWebFormApp.ServiceRequest" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style type="text/css">
    .col-xs-12 {
        padding-left:0px;
        padding-right:0px;
    }
</style>
<div class="row">&nbsp;
</div>
<div class="row">
    <div class="col-xs-5" style="text-align:right;">
        <telerik:RadLabel ID="lblRequestType" runat="server" Skin="MetroTouch" RenderMode="Lightweight" Text="Request Type:" meta:resourcekey="lblRequestTypeResource1"></telerik:RadLabel>
    </div>
    <div class="col-xs-7" style="text-align:left;">
        <telerik:RadDropDownList ID="lstMessageType" runat="server" Skin="MetroTouch" RenderMode="Lightweight" Width="90%" OnSelectedIndexChanged="lstMessageType_SelectedIndexChanged" AutoPostBack="true">            
        </telerik:RadDropDownList>
    </div>    
</div>
<br />
<div class="row">
    <div class="col-xs-12">
        <telerik:RadEditor ID="txtBody" runat="server" Width="100%" Height="450px" BorderStyle="None" Skin="MetroTouch" EditModes="Preview"
            IsSkinTouch="True" Language="ko-KR" meta:resourcekey="txtBodyResource1" OnClientLoad="OnClientLoad">
            <Tools>
                <telerik:EditorToolGroup>
                    <telerik:EditorTool Name="Cut"/>
                    <telerik:EditorTool Name="Copy"/>
                    <telerik:EditorTool Name="Paste"/>
                </telerik:EditorToolGroup>
            </Tools>
            <Tools>
                <telerik:EditorToolGroup>
                    <telerik:EditorTool Name="Bold"/>
                    <telerik:EditorTool Name="Italic"/>
                    <telerik:EditorTool Name="ForeColor"/>
                </telerik:EditorToolGroup>
            </Tools>
            <Tools>
                <telerik:EditorToolGroup>
                    <telerik:EditorTool Name="InsertDate"/>
                    <telerik:EditorTool Name="InsertTime"/>
                </telerik:EditorToolGroup>
            </Tools>        
        </telerik:RadEditor>
    </div>
</div>
<br />
<div class="row text-center">
    <div class="col-xs-12">
        <telerik:RadButton ID="txtSubmit" runat="server" Text="Submit" Skin="MetroTouch" RenderMode="Lightweight" Width="100%" 
            OnClick="txtSubmit_Click" OnClientClicking="StandardConfirm" meta:resourcekey="txtSubmitResource1" style="position: relative;"></telerik:RadButton>
        
    </div>
</div>
    <asp:HiddenField ID="hdnHotel_Id" runat="server" Value="0" />
    <asp:HiddenField ID="hdnRoom_Number" runat="server" Value="0" />
    <asp:HiddenField ID="hdnLanguage" runat="server" Value="en-US" />    
    <script type="text/javascript">
        var editor;
        var oDocument;

        function OnClientLoad(editor) {
            //set the width and height of the RadEditor
            
            editor.setSize(editor.get_element().style.width, window.innerHeight - 230);            
        }

        //submit 하기 전 iframe 내에서 변경된 사항을 업데이트한다.
        function StandardConfirm(sender, args) {
            try {

                editor = $find("<%=txtBody.ClientID%>");

                oDocument = editor.get_document(); //get a reference to the editor's document  

                var InputTags = oDocument.getElementsByTagName('INPUT');
                for (var k = 0, elm; elm = InputTags[k++];) updateDOM(elm);

                var TextAreaTags = oDocument.getElementsByTagName('TEXTAREA');
                for (var k = 0, elm; elm = TextAreaTags[k++];) updateDOM(elm);

                var SelectTags = oDocument.getElementsByTagName('SELECT');
                for (var k = 0, elm; elm = SelectTags[k++];) updateDOM(elm);

                //메시지 내용 중에서 전체가 아닌 특정 태그의 내용만 반환하고자 할 때
                var isReuturnElement = oDocument.querySelector('[return="true"]');
                if (isReuturnElement != null) {
                    var rethtml = "";
                    const element = oDocument.querySelectorAll('[return="true"]');

                    for (let elem of element) {
                        rethtml += elem.outerHTML;
                    }
                    //alert(rethtml);                
                    editor.set_html(rethtml);
                }
            } catch (error) {

            }
        }

        
        function updateDOM(inputField) {
            // if the inputField ID string has been passed in, get the inputField object  

            if (typeof inputField == "string") {
                inputField = oDocument.getElementById(inputField);
            }

            if (inputField.type == "select-one") {
                for (var i = 0; i < inputField.options.length; i++) {
                    if (i == inputField.selectedIndex) {
                        inputField.options[inputField.selectedIndex].setAttribute("selected", "selected");
                    }
                    else {
                        inputField.options[i].removeAttribute("selected");
                    }
                }
            } else if (inputField.type == "select-multiple") {
                for (var i = 0; i < inputField.options.length; i++) {
                    if (inputField.options[i].selected) {
                        inputField.options[i].setAttribute("selected", "selected");
                    } else {
                        inputField.options[i].removeAttribute("selected");
                    }
                }
            } else if (inputField.type == "text") {
                inputField.setAttribute("value", inputField.value);
            } else if (inputField.type == "textarea") {
                inputField.setAttribute("value", inputField.value);
                inputField.innerHTML = inputField.value;
            } else if (inputField.type == "checkbox") {
                if (inputField.checked) {
                    inputField.setAttribute("checked", "checked");
                } else {
                    inputField.removeAttribute("checked");
                }
            } else if (inputField.type == "radio") {                
                if (inputField.checked) {
                    inputField.setAttribute("checked", "checked");
                } else {
                    inputField.removeAttribute("checked");
                }                
            }
        }
    </script>
</asp:Content>
