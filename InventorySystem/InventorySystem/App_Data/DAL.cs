using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace InventorySystem
{
    public class DAL
    {
        SqlConnection sqlcon;
        SqlCommand sqlcmd;
        SqlDataAdapter sqlad;
        DataSet ds;

        string strMessage;
        public string DatabaseCredientials = ConfigurationManager.ConnectionStrings["InventorySystemConnectionString"].ToString();

        public DataSet ShowInventoryDetails(BEL BusinessEntityLayer)
        {
            try
            {
                sqlcon = new SqlConnection(DatabaseCredientials);
                sqlcon.Open();

                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "Sp_AllInventorydetails";
                sqlcmd.Parameters.Add("@ID", SqlDbType.Int).Value = BusinessEntityLayer.ID;
                sqlad = new SqlDataAdapter(sqlcmd);
                ds = new DataSet();
                sqlad.Fill(ds);

                if (ds.Tables[7].Rows.Count != 0)
                {
                    BusinessEntityLayer.Retout = 1;
                }
                else
                {
                    BusinessEntityLayer.Retout = 0;
                }
            }
            catch (Exception e)
            {
                BusinessEntityLayer.ErrorMessage = e.ToString();
               
            }
            finally
            {

            }
            return ds;
        }

        public string ProductInventory(BEL BusinessEntityLayer)
        {
             
            try
            {
                sqlcon = new SqlConnection(DatabaseCredientials);
                sqlcon.Open();

                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "Sp_InsInventoryProddetails";
                sqlcmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = BusinessEntityLayer.ID;
                sqlcmd.Parameters.Add("@ProductName", SqlDbType.VarChar,255).Value = BusinessEntityLayer.productname;
                sqlcmd.Parameters.Add("@Describtion", SqlDbType.VarChar,255).Value = BusinessEntityLayer.description;
                sqlcmd.Parameters.Add("@Manufacturer", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.Manufacturer;
                sqlcmd.Parameters.Add("@ProductTag1", SqlDbType.VarChar , 255).Value = BusinessEntityLayer.prod_tag1;
                sqlcmd.Parameters.Add("@ProductTag2", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.prod_tag2;
                sqlcmd.Parameters.Add("@Saleprice",SqlDbType.Decimal).Value = BusinessEntityLayer.saleprice;
                sqlcmd.Parameters.Add("@CreatedOrModifiedBy",SqlDbType.VarChar, 255).Value = BusinessEntityLayer.CreatedBy;

                sqlcmd.Parameters.Add("@Retout", SqlDbType.Int).Direction = ParameterDirection.Output;

                sqlcmd.ExecuteNonQuery();

                BusinessEntityLayer.Retout =Convert.ToInt32(sqlcmd.Parameters["@Retout"].Value.ToString());

                strMessage = sqlcmd.Parameters["@Retout"].Value.ToString();

            }
            catch (Exception e)
            {
                BusinessEntityLayer.ErrorMessage = e.ToString();
            }
            finally
            {
                sqlcmd.Dispose();
                sqlcon.Close();
                sqlcon.Dispose();
            }
            return strMessage;;
        }

        public string WarehouseInventory(BEL BusinessEntityLayer)
        {

            try
            {
                sqlcon = new SqlConnection(DatabaseCredientials);
                sqlcon.Open();

                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "Sp_InsInventoryWarehouseDetails";
                sqlcmd.Parameters.Add("@WarehouseID", SqlDbType.Int).Value = BusinessEntityLayer.ID;
                sqlcmd.Parameters.Add("@WarehouseName", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.warehousename;
                sqlcmd.Parameters.Add("@Describtion", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.description;
                sqlcmd.Parameters.Add("@Address", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.Address;
                sqlcmd.Parameters.Add("@Telephone", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.telephone;
                sqlcmd.Parameters.Add("@CreatedOrModifiedBy", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.CreatedBy;

                sqlcmd.Parameters.Add("@Retout", SqlDbType.Int).Direction = ParameterDirection.Output;

                sqlcmd.ExecuteNonQuery();

                BusinessEntityLayer.Retout = Convert.ToInt32(sqlcmd.Parameters["@Retout"].Value.ToString());

                strMessage = sqlcmd.Parameters["@Retout"].Value.ToString();

            }
            catch (Exception e)
            {
                BusinessEntityLayer.ErrorMessage = e.ToString();
            }
            finally
            {
                sqlcmd.Dispose();
                sqlcon.Close();
                sqlcon.Dispose();
            }
            return strMessage; ;
        }

        public string ClientInventory(BEL BusinessEntityLayer)
        {

            try
            {
                sqlcon = new SqlConnection(DatabaseCredientials);
                sqlcon.Open();

                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "Sp_InsInventoryClient";
                sqlcmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = BusinessEntityLayer.ID;
                sqlcmd.Parameters.Add("@ClientName", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.CLientName;
                sqlcmd.Parameters.Add("@ContactNo", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.contactno;
                sqlcmd.Parameters.Add("@ContactPerson", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.contactperson;
                sqlcmd.Parameters.Add("@Address", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.Address;
                sqlcmd.Parameters.Add("@EmailID", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.EmailID;
                sqlcmd.Parameters.Add("@IsVendor", SqlDbType.Bit).Value = BusinessEntityLayer.IsVendor;
                sqlcmd.Parameters.Add("@IsCustomer", SqlDbType.Bit).Value = BusinessEntityLayer.IsCustomer;
                sqlcmd.Parameters.Add("@CreatedOrModifiedBy", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.CreatedBy;

                sqlcmd.Parameters.Add("@Retout", SqlDbType.Int).Direction = ParameterDirection.Output;

                sqlcmd.ExecuteNonQuery();

                BusinessEntityLayer.Retout = Convert.ToInt32(sqlcmd.Parameters["@Retout"].Value.ToString());

                strMessage = sqlcmd.Parameters["@Retout"].Value.ToString();

            }
            catch (Exception e)
            {
                BusinessEntityLayer.ErrorMessage = e.ToString();
            }
            finally
            {
                sqlcmd.Dispose();
                sqlcon.Close();
                sqlcon.Dispose();
            }
            return strMessage; ;
        }

        public string AddStock(BEL BusinessEntityLayer)
        {

            try
            {
                sqlcon = new SqlConnection(DatabaseCredientials);
                sqlcon.Open();

                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "AddStock";
                sqlcmd.Parameters.Add("@InventoryID", SqlDbType.Int).Value = BusinessEntityLayer.ID;
                sqlcmd.Parameters.Add("@TransactionDetails", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.TransDetails;
                sqlcmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.productname;
                sqlcmd.Parameters.Add("@WarehouseName", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.warehousename;
                sqlcmd.Parameters.Add("@Cost", SqlDbType.Decimal).Value = BusinessEntityLayer.Cost;
                sqlcmd.Parameters.Add("@OldQuantity", SqlDbType.Decimal).Value = BusinessEntityLayer.OldQuantity;
                sqlcmd.Parameters.Add("@NewQuantity", SqlDbType.Decimal).Value = BusinessEntityLayer.NewQuantity;
                sqlcmd.Parameters.Add("@Comments", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.Comments;
                sqlcmd.Parameters.Add("@TransactionType", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.TransType;
                sqlcmd.Parameters.Add("@ClientName", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.CLientName;
                sqlcmd.Parameters.Add("@CreatedOrModifiedBy", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.CreatedBy;

                sqlcmd.Parameters.Add("@Retout", SqlDbType.Int).Direction = ParameterDirection.Output;

                sqlcmd.ExecuteNonQuery();

                BusinessEntityLayer.Retout = Convert.ToInt32(sqlcmd.Parameters["@Retout"].Value.ToString());

                strMessage = sqlcmd.Parameters["@Retout"].Value.ToString();

            }
            catch (Exception e)
            {
                BusinessEntityLayer.ErrorMessage = e.ToString();
            }
            finally
            {
                sqlcmd.Dispose();
                sqlcon.Close();
                sqlcon.Dispose();
            }
            return strMessage; ;
        }

        public string RemoveStockDetails(BEL BusinessEntityLayer)
        {

            try
            {
                sqlcon = new SqlConnection(DatabaseCredientials);
                sqlcon.Open();

                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "RemoveStock";
                sqlcmd.Parameters.Add("@InventoryID", SqlDbType.Int).Value = BusinessEntityLayer.ID;
                sqlcmd.Parameters.Add("@TransactionDetails", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.TransDetails;
                sqlcmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.productname;
                sqlcmd.Parameters.Add("@WarehouseName", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.warehousename;
                sqlcmd.Parameters.Add("@Cost", SqlDbType.Decimal).Value = BusinessEntityLayer.Cost;
                sqlcmd.Parameters.Add("@NewQuantity", SqlDbType.Decimal).Value = BusinessEntityLayer.NewQuantity;
                sqlcmd.Parameters.Add("@CreatedOrModifiedBy", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.CreatedBy;

                sqlcmd.Parameters.Add("@Retout", SqlDbType.Int).Direction = ParameterDirection.Output;

                sqlcmd.ExecuteNonQuery();

                BusinessEntityLayer.Retout = Convert.ToInt32(sqlcmd.Parameters["@Retout"].Value.ToString());

                strMessage = sqlcmd.Parameters["@Retout"].Value.ToString();

            }
            catch (Exception e)
            {
                BusinessEntityLayer.ErrorMessage = e.ToString();
            }
            finally
            {
                sqlcmd.Dispose();
                sqlcon.Close();
                sqlcon.Dispose();
            }
            return strMessage; ;
        }

        public string TransferStock(BEL BusinessEntityLayer)
        {

            try
            {
                sqlcon = new SqlConnection(DatabaseCredientials);
                sqlcon.Open();

                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "TransferStock";       
                sqlcmd.Parameters.Add("@TransactionDetails", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.TransDetails;
                sqlcmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.productname;
                sqlcmd.Parameters.Add("@FromWarehouseName", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.warehousename;
                sqlcmd.Parameters.Add("@ToWarehouseName", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.Towarehousename;
                sqlcmd.Parameters.Add("@NewQuantity", SqlDbType.Decimal).Value = BusinessEntityLayer.NewQuantity;
                sqlcmd.Parameters.Add("@Comments", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.Comments;
                sqlcmd.Parameters.Add("@TransactionType", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.TransType;
                sqlcmd.Parameters.Add("@ClientName", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.CLientName;
                sqlcmd.Parameters.Add("@CreatedOrModifiedBy", SqlDbType.VarChar, 255).Value = BusinessEntityLayer.CreatedBy;

                sqlcmd.Parameters.Add("@Retout", SqlDbType.Int).Direction = ParameterDirection.Output;

                sqlcmd.ExecuteNonQuery();

                BusinessEntityLayer.Retout = Convert.ToInt32(sqlcmd.Parameters["@Retout"].Value.ToString());

                strMessage = sqlcmd.Parameters["@Retout"].Value.ToString();

            }
            catch (Exception e)
            {
                BusinessEntityLayer.ErrorMessage = e.ToString();
            }
            finally
            {
                sqlcmd.Dispose();
                sqlcon.Close();
                sqlcon.Dispose();
            }
            return strMessage; ;
        }


    }
}