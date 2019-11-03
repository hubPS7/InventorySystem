<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Warehouse.ascx.cs" Inherits="InventorySystem.UserControl.Warehouse" %>
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
<div id="InventoryWarehouseGrid" runat="server">
    <table width="100%">
        <tr style="background-color: #4b6c9e; color: #FFFFFF;">
            <td colspan="2">
                WareHouse Listing
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvwarehouse" runat="server" AutoGenerateColumns="False" Width="100%"
                    DataKeyNames="WareHouseID" OnSelectedIndexChanged="gvwarehouse_SelectedIndexChanged"
                    CssClass="EU_DataTable">
                    <Columns>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton ID="ShowPopUp" runat="server" OnClick="ShowProduct_Click" ImageUrl="~/images/gridimages/actionseditpage.gif"
                                    Width="25px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="WareHouse Name">
                            <ItemTemplate>
                                <asp:Label ID="lblware" runat="server" Text='<%# Bind("WareHouseName") %>'></asp:Label>
                                  <asp:HiddenField ID="Description" runat="server" Value='<%#Eval("Description")%>' ></asp:HiddenField>
                                  <asp:HiddenField ID="lblID" runat="server" Value='<%# Bind("WareHouseID") %>'></asp:HiddenField>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="50%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Address" HeaderText="Address" HeaderStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="TelephoneNo" HeaderText="TelephoneNo" HeaderStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Description" HeaderText="Description" HeaderStyle-HorizontalAlign="Left">
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
                <asp:TabContainer ID="warehousedetails" runat="server" ActiveTabIndex="0" TabStripPlacement="Top"
                    Height="100%">
                    <asp:TabPanel runat="server" HeaderText="Description" ID="TabPanel1" Width="100%" BackColor="Gray">
                        <ContentTemplate>
                            <asp:TextBox ID="txtDescriptionvaluse" runat="server" TextMode="MultiLine" Width="100%"
                                Height="100%" BackColor="Gray"></asp:TextBox>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Inventory" Width="100%">
                        <ContentTemplate>
                            <asp:GridView ID="gvwarehouseInventory" runat="server" AutoGenerateColumns="False"
                                Width="100%" CssClass="EU_DataTable">
                                <Columns>
                                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-Width="50%">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle Width="50%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Manufacturer" HeaderText="Manufacturer" HeaderStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Cost" HeaderText="Cost" HeaderStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" HeaderStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
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
<asp:LinkButton ID="lnkwarehouse" runat="server"></asp:LinkButton>
<asp:ModalPopupExtender ID="ModalwarehouseInventory" runat="server" DropShadow="true"
    DynamicServicePath="" Enabled="True" PopupControlID="PnlNewwarehouse" TargetControlID="lnkwarehouse"
    CancelControlID="btnclose" BackgroundCssClass="modalbackground">
</asp:ModalPopupExtender>
<asp:Panel ID="PnlNewwarehouse" runat="server" BackColor="#DFE8F6">
    <div>
    <table width="100%">
        <tr style="background-color: #4b6c9e; color: #FFFFFF;">
            <td style="text-align: left; text-decoration: underline;" >
                Add Warehouse Details</td>
        </tr>
    </table>
        <table width="100%">
            <tr>
                <td colspan="4" class="style1">
                    <asp:Label ID="lbladdupdate" runat="server"></asp:Label>
                    &nbsp;<asp:Label ID="lblwarehouseid" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Ware House Name:
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtwarehousename" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Description:
                </td>
                <td>
                    <asp:TextBox ID="txtwarehousedescription" runat="server" Height="91px" TextMode="MultiLine"
                        Width="349px"></asp:TextBox>
                </td>
                <td>
                    Address:
                </td>
                <td>
                    <asp:TextBox ID="txtwarehouseAddress" runat="server" Height="91px" TextMode="MultiLine"
                        Width="349px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Telephone NO:
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txttelephonnumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnsavenew" runat="server" Text="Save And New" CssClass="button_example" />
                </td>
                <td colspan="3">
                    <asp:Button ID="btnsaveclose" runat="server" Text="Save And Close" OnClick="btnwaresaveclose_Click"
                        CssClass="button_example" />
                    &nbsp;
                    <asp:Button ID="btnclose" runat="server" Text="Cancel" CssClass="button_example" />
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
