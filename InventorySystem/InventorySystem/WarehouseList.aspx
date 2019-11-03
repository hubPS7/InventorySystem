<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WarehouseList.aspx.cs" Inherits="InventorySystem.WarehouseList" %>
<%@ Register src="UserControl/Warehouse.ascx" tagname="Warehouse" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:Warehouse ID="Warehouse1" runat="server" />
</asp:Content>
