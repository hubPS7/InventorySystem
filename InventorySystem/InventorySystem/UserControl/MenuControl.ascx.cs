using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySystem.UserControl
{
    public partial class MenuControl : System.Web.UI.UserControl
    {
        BEL businessEntityLayer = new BEL();
        public string tes
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
          
        }
        //public  string passvalue( )
        //{
        //    return tes;
        //}
        protected void mMain_MenuItemClick(object sender, MenuEventArgs e)
        {
            //tes = mMain.SelectedItem.Value;
            //passvalue();
            businessEntityLayer.AddNew = mMain.SelectedItem.Value;
            if (businessEntityLayer.AddNew == "List All Products" || businessEntityLayer.AddNew == "Add New Products")
            {
                Session["passvalue"] = businessEntityLayer.AddNew;
                Response.Redirect("ProductList.aspx");

            }
            else if (businessEntityLayer.AddNew == "List All WareHouse" || businessEntityLayer.AddNew == "Add New WareHouse")
            {
                Session["passvalue"] = businessEntityLayer.AddNew;
                Response.Redirect("WarehouseList.aspx");
            }
            else if (businessEntityLayer.AddNew == "List All Customers" || businessEntityLayer.AddNew == "List All Vendors" || businessEntityLayer.AddNew =="Add New Client")
            {
                Session["passvalue"] = businessEntityLayer.AddNew;
                Response.Redirect("ClientList.aspx");
            }
            else if (businessEntityLayer.AddNew == "Add Stock")
            {
                //Session["passvalue"] = businessEntityLayer.AddNew;
                Response.Redirect("AddStockDetails.aspx");
            }
        }

    }
}