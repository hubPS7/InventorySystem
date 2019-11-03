<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddStockDetails.aspx.cs" Inherits="InventorySystem.AddStock" %><%@ Register src="UserControl/Stock.ascx" tagname="Stock" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    
    
    <uc1:Stock ID="Stock1" runat="server" />
    
    
    
</asp:Content>
