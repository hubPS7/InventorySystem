<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuControl.ascx.cs"
    Inherits="InventorySystem.UserControl.MenuControl" %>
<asp:Menu ID="mMain" runat="server" CssClass="menu" IncludeStyleBlock="false" Orientation="Horizontal"
    ShowPopOutImages="True" OnMenuItemClick="mMain_MenuItemClick">
    <Items>
        <asp:MenuItem Text="Products" Selected="True">
            <asp:MenuItem Text="List All Products"></asp:MenuItem>
            <asp:MenuItem Text="Add New Products"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="WareHouse">
            <asp:MenuItem Text="List All WareHouse"></asp:MenuItem>
            <asp:MenuItem Text="Add New WareHouse"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="Client">
            <asp:MenuItem Text="List All Customers"></asp:MenuItem>
            <asp:MenuItem Text="List All Vendors"></asp:MenuItem>
            <asp:MenuItem Text="Add New Client"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="Add stock">
            <asp:MenuItem Text="Add Stock"></asp:MenuItem>
            <asp:MenuItem Text="Transfer Stock"></asp:MenuItem>
        </asp:MenuItem>
    </Items>
</asp:Menu>
<asp:Label ID="lbltext" runat="server"></asp:Label>
