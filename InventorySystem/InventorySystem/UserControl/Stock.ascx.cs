using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using InventorySystem;


namespace InventorySystem.UserControl
{
    public partial class AddStock : System.Web.UI.UserControl
    {
        DataSet ds;
        BEL BusinessEntityLayer;
        BLL BusinessLogicLayer;
        string p;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindgrid();
                
            }
        }
        public void bindgrid()
        {
            
                BusinessEntityLayer = new BEL();

                BusinessLogicLayer = new BLL();

                ds = new DataSet();

                ds = BusinessLogicLayer.DisplayInventory(BusinessEntityLayer);

                gvaddstock.DataSource = ds.Tables[5];
                gvaddstock.DataBind();

                if (ds.Tables[6].Rows.Count == 0)
                {
                    ds.Tables[6].Rows.Add(ds.Tables[6].NewRow());
                    gvtransferstock.DataSource = ds.Tables[6];
                    gvtransferstock.DataBind();

                    int columncount = gvtransferstock.Rows[0].Cells.Count;
                    gvtransferstock.Rows[0].Cells.Clear();
                    gvtransferstock.Rows[0].Cells.Add(new TableCell());
                    gvtransferstock.Rows[0].Cells[0].ColumnSpan = columncount;
                    gvtransferstock.Rows[0].Cells[0].Text = " ";

                }
                else if (ds.Tables[6].Rows.Count > 0)
                {
                    gvtransferstock.DataSource = ds.Tables[6];
                    gvtransferstock.DataBind();
                }

            
   
           
        }

        public void ShowMessage(string message)
        {
            Page.RegisterStartupScript("", "<script>alert('" + message + "');</script>");
        }

        protected void btnaddstock_Click(object sender, EventArgs e)
        {
            BusinessEntityLayer = new BEL();
            BusinessLogicLayer = new BLL();

            if (lblAddstockinventoryid.Text != "")
            {
                BusinessEntityLayer.ID = Convert.ToInt32(lblAddstockinventoryid.Text);
                BusinessEntityLayer.TransDetails = "Changing stock details of " + BusinessEntityLayer.warehousename + txttransactiondetails.Text;
            }
            else
            {
                BusinessEntityLayer.ID = 0;
                BusinessEntityLayer.TransDetails = "Adding stock to " + BusinessEntityLayer.warehousename + txttransactiondetails.Text;
            }
            if (txtproduct.Text != "")
            {
                BusinessEntityLayer.productname = txtproduct.Text;
            }
            else
            {
                BusinessEntityLayer.productname = drpprdctname.SelectedItem.Value;
            }
            if (txtWarehouse.Text !="")
            {
                BusinessEntityLayer.warehousename = txtWarehouse.Text;
            }
            else
            {
                BusinessEntityLayer.warehousename = drpwarehousename.SelectedItem.Value;
            }
            if (txtCostvalue.Text != "")
            {
                BusinessEntityLayer.Cost = Convert.ToDecimal(txtCostvalue.Text);
            }
            else
            {
                BusinessEntityLayer.Cost = Convert.ToDecimal(txttransactCost.Text);
            }

            if (txtQuantity.Text != "" && lblOldQuantity.Text !="")
            {
                BusinessEntityLayer.NewQuantity = Convert.ToDecimal(txtQuantity.Text);
                BusinessEntityLayer.OldQuantity = Convert.ToDecimal(lblOldQuantity.Text);
            }
            else
            {
                BusinessEntityLayer.NewQuantity = Convert.ToDecimal(txttransactQuantity.Text);
                BusinessEntityLayer.OldQuantity = 0;
            }
            BusinessEntityLayer.CLientName = drpclientname.SelectedItem.Value;
            BusinessEntityLayer.TransType = drptransactionType.SelectedItem.Text;
            BusinessEntityLayer.Comments = txtRemark.Text;
            BusinessEntityLayer.CreatedBy = "Pankaj Sapkal";

            BusinessLogicLayer.InsertAddStock(BusinessEntityLayer);

            if (BusinessEntityLayer.Retout == 1)
            {
                ShowMessage("Successfully Inserted Your Transaction");
                //ControlState();
                bindgrid();
            }
            else
            {
                ShowMessage("Error while Insertion" + BusinessEntityLayer.ErrorMessage);

            }
        }

        protected void showstock_Click(object sender, EventArgs e)
        {

          this.ModalAddstock.Show();

            ImageButton bindtextbox = sender as ImageButton;

            GridViewRow gvrow = (GridViewRow)bindtextbox.NamingContainer;

            string ID = gvaddstock.DataKeys[gvrow.RowIndex].Value.ToString();

            lblAddstockinventoryid.Text = ID;

            txtproduct.Text = gvrow.Cells[1].Text;

            txtWarehouse.Text = gvrow.Cells[2].Text;

            txtCostvalue.Text = gvrow.Cells[3].Text;

            txtQuantity.Text = gvrow.Cells[4].Text;

            lblOldQuantity.Text = gvrow.Cells[4].Text;

        }

        protected void deleteStock_Click(object sender, EventArgs e)
        {
            BusinessEntityLayer = new BEL();
            BusinessLogicLayer = new BLL();

            ImageButton bindtextbox = sender as ImageButton;

            GridViewRow gvrow = (GridViewRow)bindtextbox.NamingContainer;

            string ID = gvaddstock.DataKeys[gvrow.RowIndex].Value.ToString();

            BusinessEntityLayer.ID = Convert.ToInt32(ID);

            BusinessEntityLayer.TransDetails = "Removic stock details from " + BusinessEntityLayer.warehousename;

            BusinessEntityLayer.productname = txtproduct.Text = gvrow.Cells[1].Text;

            BusinessEntityLayer.warehousename= txtWarehouse.Text = gvrow.Cells[2].Text;

            txtCostvalue.Text = gvrow.Cells[3].Text;
            BusinessEntityLayer.Cost = Convert.ToDecimal(txtCostvalue.Text);

            txtQuantity.Text = gvrow.Cells[4].Text;
            BusinessEntityLayer.NewQuantity = Convert.ToDecimal(txtQuantity.Text);
            BusinessEntityLayer.CreatedBy = "Pankaj Sapkal";

            BusinessLogicLayer.RemoveAddStock(BusinessEntityLayer);

            if (BusinessEntityLayer.Retout == 1)
            {
                ShowMessage("Successfully Deleted Your Transaction");
                //ControlState();
                bindgrid();
            }
            else
            {
                ShowMessage("Error while Deleting" + BusinessEntityLayer.ErrorMessage);

            }
        }

        protected void drptransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drptransactionType.SelectedIndex ==2)
                {
                    lblStockHeader.Text = "Transfer Stock";
                    lblFrom.Visible = true;
                    TOWarehouse.Visible = true;
                    TOWarehouse2.Visible = true;
                    tdtransactCost1.Visible = false;
                    tdtransactCost2.Visible = false;
                    btnaddstock.Visible = false;
                    btnTransferstock.Visible = true;
                    gvaddstock.Visible = false;
                    gvtransferstock.Visible = true;
                    bindgrid();
                    
                }
                else
                {
                    lblStockHeader.Text = "Adding Stock";
                    lblFrom.Visible = false;
                    TOWarehouse.Visible = false;
                    TOWarehouse2.Visible = false;
                    tdtransactCost1.Visible = true;
                    tdtransactCost2.Visible = true;
                    btnaddstock.Visible = true;
                    btnTransferstock.Visible = false;
                    gvaddstock.Visible = true;
                    gvtransferstock.Visible = false;
                    bindgrid();
                }
            }
            catch
            {

            }

        }

        protected void btnTransferstock_Click(object sender, EventArgs e)
        {

            BusinessEntityLayer = new BEL();
            BusinessLogicLayer = new BLL();

            ds = new DataSet();

            BusinessEntityLayer.ID = Convert.ToInt32(txttransactQuantity.Text);

            ds = BusinessLogicLayer.DisplayInventory(BusinessEntityLayer);

            if (BusinessEntityLayer.Retout == 1)
            {
                BusinessEntityLayer.TransDetails = txttransactiondetails.Text;
                BusinessEntityLayer.TransType = drptransactionType.SelectedItem.Value;
                BusinessEntityLayer.Comments = txtRemark.Text;
                BusinessEntityLayer.CLientName = drpclientname.SelectedItem.Value;
                BusinessEntityLayer.productname = drpprdctname.SelectedItem.Value;
                BusinessEntityLayer.warehousename = drpwarehousename.SelectedItem.Value;
                BusinessEntityLayer.Towarehousename = drpWarehouseNameTO.SelectedItem.Value;
                BusinessEntityLayer.NewQuantity = Convert.ToDecimal(txttransactQuantity.Text);
                BusinessEntityLayer.CreatedBy = "Pankaj Sapkal";

                BusinessLogicLayer.TransferAddStock(BusinessEntityLayer);

                if (BusinessEntityLayer.Retout == 1)
                {
                    ShowMessage("Successfully Transfer Your Transaction");
                    //ControlState();
                    bindgrid();
                }
                else
                {
                    ShowMessage("Error while Transferring" + BusinessEntityLayer.ErrorMessage);

                }
            }
            else
            {
                ShowMessage("The stock is not available, please add stock for particular product");
            }
        }

        protected void gvaddstock_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvaddstock.PageIndex = e.NewPageIndex;
            bindgrid();
        }

        protected void gvtransferstock_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvtransferstock.PageIndex = e.NewPageIndex;
            bindgrid();
        }


    }
}