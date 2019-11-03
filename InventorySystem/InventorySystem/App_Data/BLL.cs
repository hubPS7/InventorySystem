using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace InventorySystem
{
    public class BLL
    {

        public DataSet DisplayInventory(BEL BusinessEntityLayer)
        {
            DAL Databaselayer = new DAL();

            try
            {
                return Databaselayer.ShowInventoryDetails(BusinessEntityLayer);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Databaselayer = null;
            }
        }

        public string InsertProductInventory(BEL BusinessEntityLayer)
        {
            DAL Databaselayer = new DAL();

            try
            {
                return Databaselayer.ProductInventory(BusinessEntityLayer);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Databaselayer = null;
            }
        }

        public string InsertWarehouseInventory(BEL BusinessEntityLayer)
        {
            DAL Databaselayer = new DAL();

            try
            {
                return Databaselayer.WarehouseInventory(BusinessEntityLayer);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Databaselayer = null;
            }
        }

        public string InsertClientInventory(BEL BusinessEntityLayer)
        {
            DAL Databaselayer = new DAL();

            try
            {
                return Databaselayer.ClientInventory(BusinessEntityLayer);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Databaselayer = null;
            }
        }

        public string InsertAddStock(BEL BusinessEntityLayer)
        {
            DAL Databaselayer = new DAL();

            try
            {
                return Databaselayer.AddStock(BusinessEntityLayer);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Databaselayer = null;
            }
        }

        public string TransferAddStock(BEL BusinessEntityLayer)
        {
            DAL Databaselayer = new DAL();

            try
            {
                return Databaselayer.TransferStock(BusinessEntityLayer);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Databaselayer = null;
            }
        }

        public string RemoveAddStock(BEL BusinessEntityLayer)
        {
            DAL Databaselayer = new DAL();

            try
            {
                return Databaselayer.RemoveStockDetails(BusinessEntityLayer);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Databaselayer = null;
            }
        }
    }
}