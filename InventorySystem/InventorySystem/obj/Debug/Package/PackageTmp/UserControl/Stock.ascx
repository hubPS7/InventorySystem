<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Stock.ascx.cs" Inherits="InventorySystem.UserControl.AddStock" %>
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
.Freezing {
   position:absolute;
}
</style>
<div>
    <table width="100%">
        <tr style="background-color: #4b6c9e; color: #FFFFFF;">
            <td colspan="2" style="text-align: left; text-decoration: underline;" >
                Transaction Information</td>
        </tr>
    </table>
   <table Width="100%" class="hovertable">
        <tr onmouseover="this.style.backgroundColor='White';" onmouseout="this.style.backgroundColor='#d4e3e5';">
            <td style="text-align: left";>
                <strong>Transaction Details: </strong>
            </td>
        <td>
            <asp:TextBox ID="txttransactiondetails" runat="server" TextMode="MultiLine" 
                Width="250px"></asp:TextBox>
            </td>
        <td>
                <strong>Transaction Type:</strong></td>
        <td>
            <asp:DropDownList ID="drptransactionType" runat="server" Width="100px" 
                onselectedindexchanged="drptransactionType_SelectedIndexChanged" 
                AutoPostBack="True" >
                <asp:ListItem Value="0">---Select---</asp:ListItem>
                <asp:ListItem Value="1">Add Stock</asp:ListItem>
                <asp:ListItem Value="2">Transfer Stock</asp:ListItem>
            </asp:DropDownList>
            </td>
        </tr>
        </table>
    <table width="100%">
        <tr style="background-color: #4b6c9e; color: #FFFFFF;">
            <td colspan="2" style="text-align: left; text-decoration: underline;" >
                Client And Order Information</td>
        </tr>
    </table>
   <table Width="100%"  class="hovertable">
        <tr onmouseover="this.style.backgroundColor='White';" onmouseout="this.style.backgroundColor='#d4e3e5';">
         <td style="text-align: left";>
                <strong>&nbsp;Remark:</strong></td>
            <td  Width="50%">
                <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="250px"></asp:TextBox>
            </td>
            <td>
                <strong>Client Name:</strong></td>
            <td>
                <asp:DropDownList ID="drpclientname" runat="server" Width="100px" 
                    DataSourceID="ClientName" DataTextField="ClientName" 
                    DataValueField="ClientName">
                </asp:DropDownList>
                <asp:SqlDataSource ID="ClientName" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:InventorySystemConnectionString %>" 
                    SelectCommand="SELECT DISTINCT [ClientName] FROM [tblClient]">
                </asp:SqlDataSource>
            </td>
        </tr>
        </table>
<table width="100%">
        <tr style="background-color: #4b6c9e; color: #FFFFFF;">
            <td colspan="6" style="text-align: left; text-decoration: underline;" >
                Stock Information</td>
        </tr>
    </table> 
    <table Width="100%" class="hovertable">

        <tr onmouseover="this.style.backgroundColor='White';" onmouseout="this.style.backgroundColor='#d4e3e5';">
            <td style="text-align: left";>
                <strong>Product: </strong>
            </td>
            <td colspan="7">
                <asp:DropDownList ID="drpprdctname" runat="server" DataSourceID="ProductName" DataTextField="ProductName"
                    DataValueField="ProductName" Width="100px">
                </asp:DropDownList>
                <asp:SqlDataSource ID="ProductName" runat="server" ConnectionString="<%$ ConnectionStrings:InventorySystemConnectionString %>" 
                    SelectCommand="SELECT [ProductName] FROM [tblProducts]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr onmouseover="this.style.backgroundColor='White';" onmouseout="this.style.backgroundColor='#d4e3e5';">
            <td style="text-align: left";>
                <asp:Label ID="lblFrom" runat="server" style="font-weight: 700" Text="From " 
                    Visible="False"></asp:Label>
                <strong>Ware House: </strong>
            </td>
            <td>
                <asp:DropDownList ID="drpwarehousename" runat="server" DataSourceID="Warehouse" DataTextField="WareHouseName"
                    DataValueField="WareHouseName" Width="100px">
                </asp:DropDownList>
                <asp:SqlDataSource ID="Warehouse" runat="server" ConnectionString="<%$ ConnectionStrings:InventorySystemConnectionString %>"
                    SelectCommand="SELECT [WareHouseName] FROM [tblWareHouse]"></asp:SqlDataSource>
            </td>
            <td id="TOWarehouse" runat="server" visible ="false">
                <asp:Label ID="lblTo" runat="server" style="font-weight: 700" Text="To"></asp:Label>
                <strong>Ware House: </strong>
            </td>
              <td id="TOWarehouse2" runat="server" visible="false">
                <asp:DropDownList ID="drpWarehouseNameTO" runat="server" DataSourceID="WarehouseTo" DataTextField="WareHouseName"
                    DataValueField="WareHouseName" Width="100px">
                </asp:DropDownList>
                <asp:SqlDataSource ID="WarehouseTo" runat="server" ConnectionString="<%$ ConnectionStrings:InventorySystemConnectionString %>"
                    SelectCommand="SELECT [WareHouseName] FROM [tblWareHouse]"></asp:SqlDataSource></td>
            <td id="tdtransactCost1" runat="server">
                <strong>Transact Cost: </strong>
            </td>
          <td id="tdtransactCost2" runat="server">
                <asp:TextBox ID="txttransactCost" runat="server"></asp:TextBox>
            </td>
            <td>
                <strong>Transact Quantity:</strong>
            </td>
            <td>
                <asp:TextBox ID="txttransactQuantity" runat="server"></asp:TextBox>
            </td>
        </tr>  
    </table>
    <table width="100%">
    <tr>
            <td style="text-align:right">
                <asp:Button ID="btnaddstock" runat="server" Text="Add Stock" OnClick="btnaddstock_Click" CssClass="button_example" />
                <asp:Button ID="btnTransferstock" runat="server" Text="Transfer Stock" 
                    OnClick="btnTransferstock_Click" CssClass="button_example"/>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="background-color: #4b6c9e; color: #FFFFFF; text-decoration: underline;" >
            <td colspan="2">
               <asp:Label ID="lblStockHeader" runat="server" >Adding Stock</asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvaddstock" runat="server" AutoGenerateColumns="False" Width="100%"
                    DataKeyNames="InventoryID" CssClass="EU_DataTable" AllowPaging="True" 
                     PageSize="5" onpageindexchanging="gvaddstock_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton ID="showstock" runat="server" OnClick="showstock_Click" ImageUrl="~/images/gridimages/actionseditpage.gif"
                                    Width="25px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" HeaderStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="WareHouseName" HeaderText="WareHouse Name" HeaderStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Cost" HeaderText="Cost" HeaderStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" HeaderStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="TotalCost" HeaderText="TotalCost" HeaderStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="InventoryID" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("InventoryID") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ID="deleteStock" runat="server" OnClick="deleteStock_Click" ImageUrl="~/images/gridimages/mewa_errorb.gif"
                                    Width="25px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
          
               <asp:GridView ID="gvtransferstock" runat="server" AutoGenerateColumns="False"  CssClass="EU_DataTable"
                    Width="100%" Visible="False"  PageSize="5" 
                    onpageindexchanging="gvtransferstock_PageIndexChanging" AllowPaging="True" > 
                    <Columns>
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >                             
                        </asp:BoundField>
                        <asp:BoundField DataField="FromWarehouse" HeaderText="From WareHouse" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >                        
                        </asp:BoundField>
                        <asp:BoundField DataField="ToWarehouse" HeaderText="To WareHouse" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >
                        </asp:BoundField>
                        <asp:BoundField DataField="TransactQuantity" HeaderText="Transact Quantity" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >
                        </asp:BoundField>
                          <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ID="deleteStock" runat="server" OnClick="deleteStock_Click" ImageUrl="~/images/gridimages/mewa_errorb.gif"
                                    Width="25px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</div>
<asp:LinkButton ID="lnkAddstock" runat="server"></asp:LinkButton>
<asp:ModalPopupExtender ID="ModalAddstock" runat="server" DropShadow="true" DynamicServicePath=""
    Enabled="True" PopupControlID="PnlAddStock" TargetControlID="lnkAddstock" CancelControlID="btnaddstockclose"
    BackgroundCssClass="modalbackground">
    
</asp:ModalPopupExtender>
<asp:Panel ID="PnlAddStock" runat="server" BackColor="#DFE8F6">
    <div>
        <table width="100%">
            <tr>
                <td colspan="4" class="style1">
                    <asp:Label ID="lbladdupdate" runat="server"></asp:Label>
                    &nbsp;<asp:Label ID="lblAddstockinventoryid" runat="server" Visible="False"></asp:Label>
                    &nbsp;<asp:Label ID="lblOldQuantity" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Product Name:
                </td>
                <td>
                    <asp:TextBox ID="txtproduct" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                </td>
                <td>
                    WareHouse Name:
                </td>
                <td>
                    <asp:TextBox ID="txtWarehouse" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Cost:
                </td>
                <td>
                    <asp:TextBox ID="txtCostvalue" runat="server"></asp:TextBox>
                </td>
                <td>
                    Quantity:
                </td>
                <td>
                    <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
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
                    <asp:Button ID="btnsavenew" runat="server" Text="Save And New" 
                        CssClass="button_example" />
                </td>
                <td colspan="3">
                    <asp:Button ID="btnsaveclose" runat="server" Text="Save And Close" CssClass="button_example"
                        OnClick="btnaddstock_Click" />
                    &nbsp;
                    <asp:Button ID="btnaddstockclose" runat="server" Text="Cancel" CssClass="button_example" />
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
