<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StudyPlannerWebApplication.Login" %>
     <asp:Content ID="HeaderContent" ContentPlaceHolderID="Header"  runat="server">
         <link href="Content/Login.css" rel="stylesheet" />
      </asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <div  class="login_form">
        <h2><%: Title %></h2>
        <input type="text" placeholder="Username" id="txtUsername" ClientIDMode="Static" runat="server"/>
        <input type="password" placeholder="Password" id="txtPassword" ClientIDMode="Static" runat="server"/>
        <div class="alert alert-success" id="success_message" runat="server" role="alert">
        
        </div>
        <div class="alert alert-danger" id="error_message" runat="server" role="alert">
   
        </div>
      
        <asp:Button ID="btnLogin" ClientIDMode="Static" runat="server" Text="Login" OnClick="btnLogin_Click" />
      
    </div>
</asp:Content>
