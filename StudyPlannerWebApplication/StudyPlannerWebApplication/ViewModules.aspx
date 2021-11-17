<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewModules.aspx.cs" Inherits="StudyPlannerWebApplication.ViewModules" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    
    <link href="Content/ViewModule.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row col-12">
        <table class="auto-style1">
            <thead>
            <tr>
            <th>Module Name</th>
            <th>Study Per Week Hours</th>
            <th>Remaining Hours</th>
            <th>Report</th>    
            <th>Caputer hours</th>
            </tr>
            </thead>
            <tbody id="table_details" runat="server">
               <!--Dynamic data will be displayed here-->
            </tbody>
        </table>
    </div>
</asp:Content>
