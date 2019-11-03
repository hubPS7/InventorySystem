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
    public partial class Client : System.Web.UI.UserControl
    {
        DataSet ds;
        BEL BusinessEntityLayer;
        BLL BusinessLogicLayer;
        string p;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //gvwarehouse.Columns[4].Visible = false;
                if (Session["passvalue"] == null)
                {
                  
                    showform();
                }
                else
                {
                    p = Session["passvalue"].ToString();
                    
                    showform();
                }

            }

        }

        public void showform()
        {
            try
            {
                string pageName = this.Page.ToString().Substring(4, this.Page.ToString().Substring(4).Length - 5) + ".aspx";
                if (pageName == "clientlist.aspx" && p == "Add New Client")
                {
                    InventoryClientGrid.Visible = false;
                    this.ModalClientVendorInventory.Show();
                }
                else if (pageName == "clientlist.aspx" && p == "List All Customers")
                {
                    bindgrid();
                    InventoryClientGrid.Visible = true;
                }
                else if (pageName == "clientlist.aspx" && p == "List All Vendors")
                {
                    bindgrid();
                    InventoryClientGrid.Visible = true;
                }

            }
            catch
            {
              
      
            }
        }

        public void ControlState()
        {
           
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

                if (lblclientvendorid.Text != "")
                {
                    BusinessEntityLayer.ID = Convert.ToInt32(lblclientvendorid.Text);
                }
                else
                {
                    BusinessEntityLayer.ID = 0;
                }

                ds = BusinessLogicLayer.DisplayInventory(BusinessEntityLayer);

                if (p == "List All Vendors")
                {
                    gvclientvendor.DataSource = ds.Tables[3];
                    gvclientvendor.DataBind();
                }
                else if (p == "List All Customers")
                {
                    gvclientvendor.DataSource = ds.Tables[4];
                    gvclientvendor.DataBind();
                }
                if (ds.Tables[8].Rows.Count == 0)
                {
                    ds.Tables[8].Rows.Add(ds.Tables[8].NewRow());
                    gvclientvendorInventory.DataSource = ds.Tables[8];
                    gvclientvendorInventory.DataBind();

                    int columncount = gvclientvendorInventory.Rows[0].Cells.Count;
                    gvclientvendorInventory.Rows[0].Cells.Clear();
                    gvclientvendorInventory.Rows[0].Cells.Add(new TableCell());
                    gvclientvendorInventory.Rows[0].Cells[0].ColumnSpan = columncount;
                    gvclientvendorInventory.Rows[0].Cells[0].Text = " ";

                }
                else if (ds.Tables[8].Rows.Count > 0)
                {
                    gvclientvendorInventory.DataSource = ds.Tables[8];
                    gvclientvendorInventory.DataBind();

                }
          

        }

        protected void btnclientsaveclose_Click(object sender, EventArgs e)
        {
            BusinessEntityLayer = new BEL();

            BusinessLogicLayer = new BLL();

            if (lblclientvendorid.Text != "")
            {
                BusinessEntityLayer.ID = Convert.ToInt32(lblclientvendorid.Text);
            }
            else
            {
                BusinessEntityLayer.ID = 0;
            }

            BusinessEntityLayer.CLientName = txtclientname.Text;

            BusinessEntityLayer.contactperson = txtContactperson.Text;

            BusinessEntityLayer.contactno = txtContactNo.Text;

            BusinessEntityLayer.Address = txtClientAddress.Text;

            BusinessEntityLayer.EmailID = txtemailid.Text;

            if (chkCustomer.Checked == true)
            {
                BusinessEntityLayer.IsCustomer = 1;
                BusinessEntityLayer.IsVendor = 0;
            }
            else if (chkIsVendor.Checked == true)
            {
                BusinessEntityLayer.IsCustomer = 0;
                BusinessEntityLayer.IsVendor = 1;
            }

            BusinessEntityLayer.CreatedBy = "Pankaj Sapkal";

            BusinessLogicLayer.InsertClientInventory(BusinessEntityLayer);

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

        protected void Showclientvendor_Click(object sender, EventArgs e)
        {
            
            this.ModalClientVendorInventory.Show();

            ImageButton bindtextbox = sender as ImageButton;

            GridViewRow gvrow = (GridViewRow)bindtextbox.NamingContainer;

            string ID = gvclientvendor.DataKeys[gvrow.RowIndex].Value.ToString();

            lblclientvendorid.Text = ID;
            Label lblClient = gvrow.FindControl("lblCLientName") as Label;
            txtclientname.Text = lblClient.Text;
            //txtclientname.Text = gvrow.Cells[1].Text;

            txtContactNo.Text = gvrow.Cells[2].Text;

            txtContactperson.Text = gvrow.Cells[3].Text;

            txtemailid.Text = gvrow.Cells[4].Text;

           HiddenField Isvendor = gvrow.FindControl("IsVendor") as HiddenField;
           HiddenField Iscustomer = gvrow.FindControl("IsCustomer") as HiddenField;
           HiddenField Address = gvrow.FindControl("HDAddress") as HiddenField;
           txtClientAddress.Text = Address.Value.ToString();
           if (Isvendor.Value.ToString() == "True")
            {
                chkIsVendor.Checked = true;
            }
           else if (Iscustomer.Value.ToString() == "True")
            {
                chkCustomer.Checked = true;
            }
        }

        protected void gvclientvendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            HiddenField AddressValue = gvclientvendor.SelectedRow.FindControl("HDAddress") as HiddenField;
            txtAddressValue.Text = AddressValue.Value.ToString();
            Label lblClientID = gvclientvendor.SelectedRow.FindControl("lblID") as Label;
            lblclientvendorid.Text = lblClientID.Text;
            bindgrid();
        }
    }
}