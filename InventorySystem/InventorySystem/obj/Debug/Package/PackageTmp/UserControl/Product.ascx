<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Product.ascx.cs" Inherits="InventorySystem.Product" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<style type="text/css">
    .style1
    {
        height: 23px;
    }
    .modalbackground
    {
        background-color: gray;
        filter: alpha(opacity=50);
        opacity: 0.7;
    }
    
    .PanelDiv
    {
        min-width: 200px;
        min-height: 150px;
        background: #DFE8F6;
    }
</style>
<div id="InventoryProductGrid" runat="server">
    <table width="100%">
        <tr style="background-color: #4b6c9e; color: #FFFFFF;">
            <td colspan="2">
                Product Listing
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvprodct" runat="server" AutoGenerateColumns="False" Width="100%"
                    DataKeyNames="ProductID" OnSelectedIndexChanged="gvprodct_SelectedIndexChanged"  CssClass="EU_DataTable">
                    <Columns>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton ID="ShowPopUp" runat="server" OnClick="ShowProduct_Click" ImageUrl="~/images/gridimages/actionseditpage.gif"
                                    Width="25px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product Name">
                            <ItemTemplate>
                                <asp:Label ID="lblprod" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                                <asp:HiddenField ID="Description" runat="server" Value='<%#Eval("Description")%>' />
                                   <asp:HiddenField ID="lblID" runat="server" Value='<%#Eval("ProductID")%>' /> 
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="50%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Manufacturer" HeaderText="Manufacturer" HeaderStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="ProductTag1" HeaderText="Tag1" HeaderStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="ProductTag2" HeaderText="Tag2" HeaderStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="SalePrice" HeaderText="SalePrice" HeaderStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:CommandField ShowSelectButton="True" ItemStyle-Width="40px" ItemStyle-Font-Bold="true">
                            <ItemStyle Width="10px"></ItemStyle>
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TabContainer ID="productdetails" runat="server" ActiveTabIndex="0" 
                    TabStripPlacement="Top" Height="100%">
                    <asp:TabPanel runat="server" HeaderText="Description" ID="TabPanel1" Width="100%" BackColor="Gray">
                        <ContentTemplate>
                            <asp:TextBox ID="txtDescriptionvaluse" runat="server" TextMode="MultiLine" 
                                Width="100%" Height="100%" BackColor="Gray"></asp:TextBox>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Inventory" Width="100%">
                        <ContentTemplate>
                            <asp:GridView ID="gvProdInventory" runat="server" AutoGenerateColumns="False" Width="100%"  CssClass="EU_DataTable">
                                <Columns>
                                    <asp:BoundField DataField="WareHouseName" HeaderText="WareHouse Name">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle Width="50%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Cost" HeaderText="Cost">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
            </td>
        </tr>
    </table>
</div>
<asp:LinkButton ID="lnkproduct" runat="server"></asp:LinkButton>
<asp:ModalPopupExtender ID="ModalproductInventory" runat="server" DropShadow="true"
    DynamicServicePath="" Enabled="True" PopupControlID="PnlNewproduct" TargetControlID="lnkproduct"
    CancelControlID="btnclose" BackgroundCssClass="modalbackground">
</asp:ModalPopupExtender>
<asp:Panel ID="PnlNewproduct" runat="server" BackColor="#DFE8F6">
    <div>
    <table width="100%">
        <tr style="background-color: #4b6c9e; color: #FFFFFF;">
            <td style="text-align: left; text-decoration: underline;" >
                Add Product Details</td>
        </tr>
    </table>
        <table width="100%">
            <tr>
                <td colspan="4" class="style1">
                    <asp:Label ID="lbladdupdate" runat="server"></asp:Label>
                    &nbsp;<asp:Label ID="lblproductid" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Product Name:
                </td>
                <td>
                    <asp:TextBox ID="txtproductname" runat="server"></asp:TextBox>
                </td>
                <td>
                    Manufacturer:
                </td>
                <td>
                    <asp:TextBox ID="txtmanufacturar" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Product Tag 1:
                </td>
                <td>
                    <asp:TextBox ID="txtprodtag1" runat="server"></asp:TextBox>
                </td>
                <td>
                    Product Tag 2:
                </td>
                <td>
                    <asp:TextBox ID="txtprodtag2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Sale Price:
                </td>
                <td>
                    <asp:TextBox ID="txtsaleprice" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Description:
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtdescription" runat="server" Height="91px" TextMode="MultiLine"
                        Width="349px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnsavenew" runat="server" Text="Save And New" CssClass="button_example" />
                </td>
                <td colspan="3">
                    <asp:Button ID="btnsaveclose" runat="server" Text="Save And Close" OnClick="btnsaveclose_Click" CssClass="button_example" />
                    &nbsp;
                    <asp:Button ID="btnclose" runat="server" Text="Cancel" CssClass="button_example" />
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
