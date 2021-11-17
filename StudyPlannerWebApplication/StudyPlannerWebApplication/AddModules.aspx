<%@ Page Title="Add module" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddModules.aspx.cs" Inherits="StudyPlannerWebApplication.AddModules" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <link href="Content/addModule.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <h2>Add Module</h2>
   <div class="module-content">
    <input type="text" placeholder="Module Code"  id="txtCode" runat="server"  />
       
     <input type="text" placeholder="Module Name" id="txtName" runat="server" ClientIDMode="Static" />
  
       
    <input type="number" min="0" placeholder="Module Credit" id="txtCredit" runat="server" ClientIDMode="Static" />
  
    <input type="number" min="0" id="txtClassHours" placeholder="Module Hours" runat="server" ClientIDMode="Static" />
        <p ID="lblError" ClientIDMode="Static" runat="server" Text="Label"></p>
         <asp:Button ID="btnAddModule" ClientIDMode="Static" runat="server" Text="Add Module" OnClick="btnAddModule_Click" /> 
   </div>

</asp:Content>
