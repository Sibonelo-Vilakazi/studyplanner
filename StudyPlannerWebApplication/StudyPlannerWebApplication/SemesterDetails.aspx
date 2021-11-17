<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SemesterDetails.aspx.cs" Inherits="StudyPlannerWebApplication.SemesterDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <link href="Content/semesterDetails.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="semester-content">
        <h2>Semester Details</h2>
        <input type="date" placeholder="Start Date"  id="datePicker" runat="server"  />
         <input type="text" placeholder="Start Date"  id="dateStart" runat="server"  />
        <input type="text" placeholder="No. Semester Weeks"  id="txtWeeks" runat="server"  />
        <div class="alert alert-danger" id="error_message" runat="server" role="alert">
   
        </div>
        <asp:Button ID="btnSubmit" ClientIDMode="Static" runat="server" Text="Submit" OnClick="btnSubmit_Click" /> 
    </div>
</asp:Content>
