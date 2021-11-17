<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CaptureHoursSpent.aspx.cs" Inherits="StudyPlannerWebApplication.CaptureHoursSpent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <link href="Content/caputerModule.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="capture-content">
       
        <h2 id="lblPrompt"  runat="server" ClientIDMode="Static"></h2>
        <input type="date" id="date_picker" placeholder="Module Hours" runat="server" ClientIDMode="Static" />
        <input type="text" id="txtHours" placeholder="Module Hours" runat="server" ClientIDMode="Static" />
        <p ID="lblError" ClientIDMode="Static" runat="server" Text="Label"></p>
        <asp:Button ID="btnCapture" ClientIDMode="Static" runat="server" Text="Capture" OnClick="btnCapture_Click" /> 
   
    </div>
</asp:Content>
