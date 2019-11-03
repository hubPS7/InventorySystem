<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Client.ascx.cs" Inherits="InventorySystem.UserControl.Client" %>
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
<div id="InventoryClientGrid" runat="server">
    <table width="100%">
        <tr style="background-color: #4b6c9e; color: #FFFFFF;">
            <td colspan="2">
                WareHouse Listing
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvclientvendor" runat="server" AutoGenerateColumns="False" Width="100%"
                    DataKeyNames="ClientID" CssClass="EU_DataTable" OnSelectedIndexChanged="gvclientvendor_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton ID="Showclientvendor" runat="server" OnClick="Showclientvendor_Click"
                                   ImageUrl="~/images/gridimages/actionseditpage.gif" Width="25px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Client Name">
                            <ItemTemplate>
                                <asp:Label ID="lblCLientName" runat="server" Text='<%# Bind("ClientName") %>'></asp:Label>
                                <asp:HiddenField ID="HDAddress" runat="server" Value='<%#Eval("Address")%>' />
                                    <asp:HiddenField ID="IsVendor" runat="server" Value='<%#Eval("IsVendor")%>' />
                                    <asp:HiddenField ID="IsCustomer" runat="server" Value='<%#Eval("IsCustomer")%>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="50%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="ContactNo" HeaderText="ContactNo" HeaderStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="ContactPerson" HeaderText="ContactPerson" HeaderStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="EmailID" HeaderText="EmailID" HeaderStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="ClientID" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("ClientID") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
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
                    <asp:TabPanel runat="server" HeaderText="Address" ID="TabPanel1" Width="100%" BackColor="Gray">
                        <ContentTemplate>
                            <asp:TextBox ID="txtAddressValue" runat="server" TextMode="MultiLine" Width="100%"
                                Height="100%" BackColor="Gray"></asp:TextBox>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Inventory" Width="100%">
                        <ContentTemplate>
                            <asp:GridView ID="gvclientvendorInventory" runat="server" AutoGenerateColumns="False"
                                Width="100%" CssClass="EU_DataTable">
                                <Columns>
                                    <asp:BoundField DataField="OrderID" HeaderText="Order No" HeaderStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Details" HeaderText="Details" HeaderStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle Width="50%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TransactionType" HeaderText="Transaction Type" HeaderStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" HeaderStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Comments" HeaderText="Remarks" HeaderStyle-HorizontalAlign="Left">
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
<asp:LinkButton ID="lnkClientVendor" runat="server"></asp:LinkButton>
<asp:ModalPopupExtender ID="ModalClientVendorInventory" runat="server" DropShadow="true"
    DynamicServicePath="" Enabled="True" PopupControlID="PnlNewClientVendor" TargetControlID="lnkClientVendor"
    CancelControlID="btnclose" BackgroundCssClass="modalbackground">
</asp:ModalPopupExtender>
<asp:Panel ID="PnlNewClientVendor" runat="server" BackColor="#DFE8F6">
    <div>
    <table width="100%">
        <tr style="background-color: #4b6c9e; color: #FFFFFF;">
            <td style="text-align: left; text-decoration: underline;" >
                Add Client Information</td>
        </tr>
    </table> 
        <table width="100%">
            <tr>
                <td colspan="4" class="style1">
                    <asp:Label ID="lblclientvendorid" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Client Name:
                </td>
                <td>
                    <asp:TextBox ID="txtclientname" runat="server"></asp:TextBox>
                </td>
                <td>
                    Contact Person:
                </td>
                <td>
                    <asp:TextBox ID="txtContactperson" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Contact No:
                </td>
                <td>
                    <asp:TextBox ID="txtContactNo" runat="server"></asp:TextBox>
                </td>
                <td>
                    Email ID:
                </td>
                <td>
                    <asp:TextBox ID="txtemailid" runat="server"></asp:TextBox>
                </td>
            </tr>
         <tr>
                <td>
                    Address:
                </td>
                <td>
                    <asp:TextBox ID="txtClientAddress" runat="server" Height="91px" TextMode="MultiLine"
                        Width="349px"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="chkIsVendor" runat="server" Text="Is Client a Vendor" />
                </td>
                <td>
                    <asp:CheckBox ID="chkCustomer" runat="server" Text="Is Client a Customer" />
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
                    <asp:Button ID="btnsaveclose" runat="server" Text="Save And Close" CssClass="button_example"
                        OnClick="btnclientsaveclose_Click" />
                    &nbsp;
                    <asp:Button ID="btnclose" runat="server" Text="Cancel" CssClass="button_example" />
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
