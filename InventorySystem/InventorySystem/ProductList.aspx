<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ProductList.aspx.cs" Inherits="InventorySystem._Default" %>



<%@ Register src="UserControl/Product.ascx" tagname="Product" tagprefix="uc1" %>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">


    <uc1:Product ID="Product1" runat="server" />


    </asp:Content>
