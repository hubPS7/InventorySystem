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
    public partial class Warehouse : System.Web.UI.UserControl
    {
        DataSet ds;
        BEL BusinessEntityLayer;
        BLL BusinessLogicLayer;
        string p;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                gvwarehouse.Columns[4].Visible = false;
                if (Session["passvalue"] == null)
                {
                    bindgrid();
                    showform();
                }
                else
                {
                    p = Session["passvalue"].ToString();
                    bindgrid();
                    showform();
                }

            }

        }

        public void showform()
        {
            try
            {
                string pageName = this.Page.ToString().Substring(4, this.Page.ToString().Substring(4).Length - 5) + ".aspx";
                if (pageName == "warehouselist.aspx" && p == "Add New WareHouse")
                {
                    InventoryWarehouseGrid.Visible = false;
                    this.ModalwarehouseInventory.Show();
                }
                else
                {

                    InventoryWarehouseGrid.Visible = true;
                }

            }
            catch
            {

            }
        }

        public void ControlState()
        {
            txtwarehousename.Text = "";
            txtwarehouseAddress.Text = "";
            txtwarehousedescription.Text = "";
            txttelephonnumber.Text = "";
            txtDescriptionvaluse.Text = "";
        }

        public void ShowMessage(string message)
        {
            Page.RegisterStartupScript("", "<script>alert('" + message + "');</script>");
        }

        public void bindgrid()
        {
           
                BusinessEntityLayer = new BEL();

                BusinessLogicLayer = new BLL();

                ds = new DataSet();

                if (lblwarehouseid.Text != "")
                {
                    BusinessEntityLayer.ID = Convert.ToInt32(lblwarehouseid.Text);
                }
                else
                {
                    BusinessEntityLayer.ID = 0;
                }

                ds = BusinessLogicLayer.DisplayInventory(BusinessEntityLayer);

                gvwarehouse.DataSource = ds.Tables[2];
                gvwarehouse.DataBind();

                if (ds.Tables[1].Rows.Count == 0)
                {
                    ds.Tables[1].Rows.Add(ds.Tables[1].NewRow());
                    gvwarehouseInventory.DataSource = ds.Tables[1];
                    gvwarehouseInventory.DataBind();

                    int columncount = gvwarehouseInventory.Rows[0].Cells.Count;
                    gvwarehouseInventory.Rows[0].Cells.Clear();
                    gvwarehouseInventory.Rows[0].Cells.Add(new TableCell());
                    gvwarehouseInventory.Rows[0].Cells[0].ColumnSpan = columncount;
                    gvwarehouseInventory.Rows[0].Cells[0].Text = " ";

                }
                else if (ds.Tables[1].Rows.Count > 0)
                {
                    gvwarehouseInventory.DataSource = ds.Tables[1];
                    gvwarehouseInventory.DataBind();

                }
            }

        

        protected void btnwaresaveclose_Click(object sender, EventArgs e)
        {
            BusinessEntityLayer = new BEL();

            BusinessLogicLayer = new BLL();

            if (lblwarehouseid.Text != "")
            {
                BusinessEntityLayer.ID = Convert.ToInt32(lblwarehouseid.Text);
            }
            else
            {
                BusinessEntityLayer.ID = 0;
            }

            BusinessEntityLayer.warehousename = txtwarehousename.Text;

            BusinessEntityLayer.description = txtwarehousedescription.Text;

            BusinessEntityLayer.Address = txtwarehouseAddress.Text;

            BusinessEntityLayer.telephone = txttelephonnumber.Text;

            BusinessEntityLayer.CreatedBy = "Pankaj Sapkal";

            BusinessLogicLayer.InsertWarehouseInventory(BusinessEntityLayer);

            if (BusinessEntityLayer.Retout == 1)
            {
                ShowMessage("Successfully Inserted Your Transaction");
                ControlState();
                bindgrid();
            }
            else
            {
                ShowMessage("Error while Inserting product Name" + BusinessEntityLayer.ErrorMessage);

            }
        }

        protected void ShowProduct_Click(object sender, EventArgs e)
        {
            this.ModalwarehouseInventory.Show();

            ImageButton bindtextbox = sender as ImageButton;

            GridViewRow gvrow = (GridViewRow)bindtextbox.NamingContainer;

            string ID = gvwarehouse.DataKeys[gvrow.RowIndex].Value.ToString();

            lblwarehouseid.Text = ID;
            Label lblwarehousename = gvrow.FindControl("lblware") as Label;
            txtwarehousename.Text = lblwarehousename.Text;
           // txtwarehousename.Text = gvrow.Cells[1].Text;

            txtwarehouseAddress.Text = gvrow.Cells[2].Text;
            
            txttelephonnumber.Text = gvrow.Cells[3].Text;

            HiddenField description = gvrow.FindControl("Description") as HiddenField;
            txtwarehousedescription.Text = description.Value.ToString();
        }

        protected void gvwarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            HiddenField lblDescribe = gvwarehouse.SelectedRow.FindControl("Description") as HiddenField;
            txtDescriptionvaluse.Text = lblDescribe.Value.ToString();
            HiddenField lblprodID = gvwarehouse.SelectedRow.FindControl("lblID") as HiddenField;
            lblwarehouseid.Text = lblprodID.Value.ToString();
            bindgrid();
        }
    }
}