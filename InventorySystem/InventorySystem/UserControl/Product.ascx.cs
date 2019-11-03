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

namespace InventorySystem
{
    public partial class Product : System.Web.UI.UserControl
    {
        DataSet ds;
        BEL BusinessEntityLayer;
        BLL BusinessLogicLayer;
        string p;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
               
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
            //UserControl.MenuControl ne = new UserControl.MenuControl();
            //string s = ne.tes;

            //Response.Write(s);
            try
            {
                string pageName = this.Page.ToString().Substring(4, this.Page.ToString().Substring(4).Length - 5) + ".aspx";
                if (pageName == "productlist.aspx" && p == "Add New Products")
                {
                    InventoryProductGrid.Visible = false;
                    this.ModalproductInventory.Show();
                }
                else
                {

                    InventoryProductGrid.Visible = true;
                }

            }
            catch
            {

            }
        }

        public void ControlState()
        {
            lblproductid.Text = "";
            txtprodtag2.Text = "";
            txtprodtag1.Text = "";
            txtproductname.Text = "";
            txtmanufacturar.Text = "";
            txtdescription.Text = "";
            txtsaleprice.Text = "";
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

                if (lblproductid.Text != "")
                {
                    BusinessEntityLayer.ID = Convert.ToInt32(lblproductid.Text);
                }
                else
                {
                    BusinessEntityLayer.ID = 0;
                }

                ds = BusinessLogicLayer.DisplayInventory(BusinessEntityLayer);

                gvprodct.DataSource = ds.Tables[0];
                gvprodct.DataBind();

                if (ds.Tables[1].Rows.Count == 0)
                {
                    ds.Tables[1].Rows.Add(ds.Tables[1].NewRow());
                    gvProdInventory.DataSource = ds.Tables[1];
                    gvProdInventory.DataBind();

                    int columncount = gvProdInventory.Rows[0].Cells.Count;
                    gvProdInventory.Rows[0].Cells.Clear();
                    gvProdInventory.Rows[0].Cells.Add(new TableCell());
                    gvProdInventory.Rows[0].Cells[0].ColumnSpan = columncount;
                    gvProdInventory.Rows[0].Cells[0].Text = " ";

                }
                else if (ds.Tables[1].Rows.Count > 0)
                {
                    gvProdInventory.DataSource = ds.Tables[1];
                    gvProdInventory.DataBind();

                }
     

        }

        protected void btnsaveclose_Click(object sender, EventArgs e)
        {
            BusinessEntityLayer = new BEL();

            BusinessLogicLayer = new BLL();

            if (lblproductid.Text != "")
            {
                BusinessEntityLayer.ID = Convert.ToInt32(lblproductid.Text);
            }
            else
            {
                BusinessEntityLayer.ID = 0;
            }

            BusinessEntityLayer.productname = txtproductname.Text;

            BusinessEntityLayer.Manufacturer = txtmanufacturar.Text;

            BusinessEntityLayer.description = txtdescription.Text;

            BusinessEntityLayer.prod_tag1 = txtprodtag1.Text;

            BusinessEntityLayer.prod_tag2 = txtprodtag2.Text;

            BusinessEntityLayer.saleprice = Convert.ToDecimal(txtsaleprice.Text);

            BusinessEntityLayer.CreatedBy = "Pankaj Sapkal";

            BusinessLogicLayer.InsertProductInventory(BusinessEntityLayer);

            if (BusinessEntityLayer.Retout == 1)
            {
                ShowMessage("Successfully Inserted Your Transaction");
                ControlState();
                bindgrid();
            }
            else
            {
                ShowMessage("Error while Inserting product Name" +BusinessEntityLayer.ErrorMessage);

            }
        }

        protected void ShowProduct_Click(object sender, EventArgs e)
        {
            this.ModalproductInventory.Show();

            ImageButton bindtextbox = sender as ImageButton;

            GridViewRow gvrow = (GridViewRow)bindtextbox.NamingContainer;

            string ID = gvprodct.DataKeys[gvrow.RowIndex].Value.ToString();

            lblproductid.Text = ID;
            Label lblClient = gvrow.FindControl("lblprod") as Label;
            txtproductname.Text = lblClient.Text;

           // txtproductname.Text = gvrow.Cells[1].Text;

            txtmanufacturar.Text = gvrow.Cells[2].Text;

            txtprodtag1.Text = gvrow.Cells[3].Text;

            txtprodtag2.Text = gvrow.Cells[4].Text;

            txtsaleprice.Text = gvrow.Cells[5].Text;
            HiddenField description = gvrow.FindControl("Description") as HiddenField;
            txtdescription.Text = description.Value.ToString();
          
            
        }

        protected void gvprodct_SelectedIndexChanged(object sender, EventArgs e)
        {
            HiddenField lblDescribe = gvprodct.SelectedRow.FindControl("Description") as HiddenField;
            txtDescriptionvaluse.Text = lblDescribe.Value.ToString();
            HiddenField lblprodID = gvprodct.SelectedRow.FindControl("lblID") as HiddenField;
            lblproductid.Text = lblprodID.Value.ToString();
            bindgrid();
        }

       
    }
}