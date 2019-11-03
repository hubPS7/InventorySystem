<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="InventorySystem.UserControl.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <table>
<tr>
<td style="text-decoration: underline">
<h2>An Error Has Occurred</h2>
</td>
</tr>
<tr>
<td>
An unexpected error occured on our website. The website administrator has been notified. 
</td>
</tr>
<tr>
<td>
    <asp:Label ID="Label1" runat="server" Text="*"></asp:Label>
    &nbsp;
    <asp:HyperLink ID="HyperLink1" runat="server">Send a request to your Administrator</asp:HyperLink>
</td>
</tr>
<tr>
<td>
  <asp:Label ID="Label2" runat="server" Text="*"></asp:Label>
    &nbsp;
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ProductList.aspx">Return to the Homepage</asp:HyperLink>
</td>
</tr>
</table>
</asp:Content>
