<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="StudyPlannerWebApplication.Register" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="Header"  runat="server">
    <link href="Content/Register.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <div  class="login_form">
        <h2><%: Title %></h2>
        <input type="text" id="txtUsername" placeholder="Username" ClientIDMode="Static" runat="server"/>
        <input type="password" ID="txtPassword" placeholder="Password" ClientIDMode="Static" runat="server"/>
        <input type="password" ID="txtConfirmPassword" placeholder="Confirm Password" ClientIDMode="Static" runat="server"/>
        <p ID="lblError" ClientIDMode="Static" runat="server" Text="Label"></p>
         <div class="alert alert-success" id="success_message" runat="server" role="alert">
        
        </div>
        <div class="alert alert-danger" id="error_message" runat="server" role="alert">
   
        </div>
        <asp:Button ID="btnRegister" ClientIDMode="Static" runat="server" Text="Register" OnClick="btnRegister_Click" />
    </div>
</asp:Content>
