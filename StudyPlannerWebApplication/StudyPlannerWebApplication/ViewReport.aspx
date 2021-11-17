<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewReport.aspx.cs" Inherits="StudyPlannerWebApplication.ViewReport" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <link href="Content/Report.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Chart id="chart" runat="server" Width="947px" Height="395px">
        <Titles>
            <asp:Title  runat="server" Text="Total Daily Studied Hours"></asp:Title>
        </Titles>
        <series>
            <asp:Series  runat="server" Name="Series1">
                <Points  >
                    
                
                </Points>
            </asp:Series>

        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX  Title="Days of the week"></AxisX>
                <AxisX Title="Study Hours"></AxisX>
            </asp:ChartArea>

        </chartareas>
    </asp:Chart>
</asp:Content>
