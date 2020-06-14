using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessModelLayer
{
    public class ProductsBusinessModelLayers
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        string errResult = "";

        //BEGIN - readBy
        public ProductsSingle GetProductsData(int ProductID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    ProductsSingle products = new ProductsSingle();
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {

                        string sqlQuery = "SELECT * FROM [Products] WHERE ProductID= " + ProductID.ToString();

                        using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                        {
                            con.Open();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {

                                //products.ProductID = (int)rdr["ProductID"];
                                products.ProductID = rdr["ProductID"] == DBNull.Value ? default(int) : (int)rdr["ProductID"];
                                //products.ProductName = (string)rdr["ProductName"];
                                products.ProductName = rdr["ProductName"] == DBNull.Value ? "" : (string)rdr["ProductName"];


                                //products.SupplierID = (int?)rdr["SupplierID"];
                                products.SupplierID = rdr["SupplierID"] == DBNull.Value ? default(int?) : (int?)rdr["SupplierID"];

                                //products.CategoryID = (int?)rdr["CategoryID"];
                                products.CategoryID = rdr["CategoryID"] == DBNull.Value ? default(int?) : (int?)rdr["CategoryID"];
                                //products.QuantityPerUnit = (string)rdr["QuantityPerUnit"];
                                products.QuantityPerUnit = rdr["QuantityPerUnit"] == DBNull.Value ? "" : (string)rdr["QuantityPerUnit"];


                                //products.UnitPrice = (decimal?)rdr["UnitPrice"];
                                products.UnitPrice = rdr["UnitPrice"] == DBNull.Value ? default(decimal?) : (decimal?)rdr["UnitPrice"];

                                //products.UnitsInStock = (short?)rdr["UnitsInStock"];
                                products.UnitsInStock = rdr["UnitsInStock"] == DBNull.Value ? default(short?) : (short?)rdr["UnitsInStock"];

                                //products.UnitsOnOrder = (short?)rdr["UnitsOnOrder"];
                                products.UnitsOnOrder = rdr["UnitsOnOrder"] == DBNull.Value ? default(short?) : (short?)rdr["UnitsOnOrder"];

                                //products.ReorderLevel = (short?)rdr["ReorderLevel"];
                                products.ReorderLevel = rdr["ReorderLevel"] == DBNull.Value ? default(short?) : (short?)rdr["ReorderLevel"];

                                //products.Discontinued = (bool)rdr["Discontinued"];
                                products.Discontinued = rdr["Discontinued"] == DBNull.Value ? false : (bool)rdr["Discontinued"];

                                //EXAMPLES:
                                //employee.EmployeeId = Convert.ToInt32(rdr["EmployeeID"]);
                                //employee.Name = rdr["Name"].ToString();
                                //employee.Gender = rdr["Gender"].ToString();
                                //employee.Salary = (decimal)rdr["Salary"];
                                //employee.City = rdr["City"].ToString();
                                //employee.IsPermanent = (bool)rdr["IsPermanent"];
                                //employee.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                            }
                        }
                    }
                    return products;
                }
                catch (Exception ex)
                {
                    BusinessLayer.ExceptionLogging exlog = new BusinessLayer.ExceptionLogging();
                    exlog.SendExcepToDB(ex);
                    //errResult = "A Technical Error occurred, Please visit after some time.";
                    throw;
                }
            }
            catch (Exception fx)
            {
                errResult = fx.Message.ToString();
                throw;
            }
        }
        //END - readBy
        //BEGIN - create
        public void AddProducts(ProductsSingle products)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {




                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spAddProducts", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        SqlParameter paramProductID = new SqlParameter
                        {
                            ParameterName = "@ProductID",
                            Value = products.ProductID
                        };
                        cmd.Parameters.Add(paramProductID);

                        SqlParameter paramProductName = new SqlParameter
                        {
                            ParameterName = "@ProductName",
                            Value = products.ProductName
                        };
                        cmd.Parameters.Add(paramProductName);

                        SqlParameter paramSupplierID = new SqlParameter
                        {
                            ParameterName = "@SupplierID",
                            Value = products.SupplierID
                        };
                        cmd.Parameters.Add(paramSupplierID);

                        SqlParameter paramCategoryID = new SqlParameter
                        {
                            ParameterName = "@CategoryID",
                            Value = products.CategoryID
                        };
                        cmd.Parameters.Add(paramCategoryID);

                        SqlParameter paramQuantityPerUnit = new SqlParameter
                        {
                            ParameterName = "@QuantityPerUnit",
                            Value = products.QuantityPerUnit
                        };
                        cmd.Parameters.Add(paramQuantityPerUnit);

                        SqlParameter paramUnitPrice = new SqlParameter
                        {
                            ParameterName = "@UnitPrice",
                            Value = products.UnitPrice
                        };
                        cmd.Parameters.Add(paramUnitPrice);

                        SqlParameter paramUnitsInStock = new SqlParameter
                        {
                            ParameterName = "@UnitsInStock",
                            Value = products.UnitsInStock
                        };
                        cmd.Parameters.Add(paramUnitsInStock);

                        SqlParameter paramUnitsOnOrder = new SqlParameter
                        {
                            ParameterName = "@UnitsOnOrder",
                            Value = products.UnitsOnOrder
                        };
                        cmd.Parameters.Add(paramUnitsOnOrder);

                        SqlParameter paramReorderLevel = new SqlParameter
                        {
                            ParameterName = "@ReorderLevel",
                            Value = products.ReorderLevel
                        };
                        cmd.Parameters.Add(paramReorderLevel);

                        SqlParameter paramDiscontinued = new SqlParameter
                        {
                            ParameterName = "@Discontinued",
                            Value = products.Discontinued
                        };
                        cmd.Parameters.Add(paramDiscontinued);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }

                }
                catch (Exception ex)
                {
                    BusinessLayer.ExceptionLogging exlog = new BusinessLayer.ExceptionLogging();
                    exlog.SendExcepToDB(ex);
                    //errResult = "A Technical Error occurred, Please visit after some time.";
                    throw;
                }
            }
            catch (Exception fx)
            {
                errResult = fx.Message.ToString();
                throw;
            }

        }
        //END - create

        //BEGIN - update
        public void UpdateProducts(ProductsSingle products)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spUpdateProducts", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@ProductID", products.ProductID);
                            cmd.Parameters.AddWithValue("@ProductName", products.ProductName);
                            cmd.Parameters.AddWithValue("@SupplierID", (object)products.SupplierID ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@CategoryID", (object)products.CategoryID ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@QuantityPerUnit", (object)products.QuantityPerUnit ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@UnitPrice", (object)products.UnitPrice ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@UnitsInStock", (object)products.UnitsInStock ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@UnitsOnOrder", (object)products.UnitsOnOrder ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@ReorderLevel", (object)products.ReorderLevel ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Discontinued", products.Discontinued);
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                        con.Close();
                    }

                }
                catch (Exception ex)
                {
                    BusinessLayer.ExceptionLogging exlog = new BusinessLayer.ExceptionLogging();
                    exlog.SendExcepToDB(ex);
                    //errResult = "A Technical Error occurred, Please visit after some time.";
                    throw;
                }
            }
            catch (Exception fx)
            {
                errResult = fx.Message.ToString();
                throw;
            }
        }
        //END - update

        //BEGIN  - delete      
        public void DeleteProducts(int ProductID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spDeleteProducts", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@ProductID", ProductID);
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                        con.Close();
                    }

                }
                catch (Exception ex)
                {
                    BusinessLayer.ExceptionLogging exlog = new BusinessLayer.ExceptionLogging();
                    exlog.SendExcepToDB(ex);
                    //errResult = "A Technical Error occurred, Please visit after some time.";
                    throw;
                }
            }
            catch (Exception fx)
            {
                errResult = fx.Message.ToString();
                throw;
            }
        }

        public void EXE_sql(string strSQL)
        {

            // Create Instance of Connection and Command Object
            SqlConnection myConnection = new SqlConnection(connectionString);
            SqlCommand myCommand = new SqlCommand(strSQL, myConnection);

            // Mark the Command as a STEXT
            myCommand.CommandType = CommandType.Text;
            myCommand.CommandTimeout = 0;
            string errStr = "";

            try
            {
                // Open the database connection and execute the command
                myConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                errStr = e.ToString();
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
        }

        //END - delete


        //BEGIN - read
        public List<ProductsSingle> GetAllProductss()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<ProductsSingle> productss = new List<ProductsSingle>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spGetAllProducts", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            ProductsSingle products = new ProductsSingle
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //ProductID = (int)rdr["ProductID"]
                                ProductID = rdr["ProductID"] == DBNull.Value ? default(int) : (int)rdr["ProductID"]
                                        //,ProductName = (string)rdr["ProductName"]
                                        ,
                                ProductName = rdr["ProductName"] == DBNull.Value ? "" : (string)rdr["ProductName"]
                                    //,SupplierID = (int?)rdr["SupplierID"]
                                    ,
                                SupplierID = rdr["SupplierID"] == DBNull.Value ? default(int?) : (int?)rdr["SupplierID"]
                                    //,CategoryID = (int?)rdr["CategoryID"]
                                    ,
                                CategoryID = rdr["CategoryID"] == DBNull.Value ? default(int?) : (int?)rdr["CategoryID"]
                                        //,QuantityPerUnit = (string)rdr["QuantityPerUnit"]
                                        ,
                                QuantityPerUnit = rdr["QuantityPerUnit"] == DBNull.Value ? "" : (string)rdr["QuantityPerUnit"]
                                    //,UnitPrice = (decimal?)rdr["UnitPrice"]
                                    ,
                                UnitPrice = rdr["UnitPrice"] == DBNull.Value ? default(decimal?) : (decimal?)rdr["UnitPrice"]
                                    //,UnitsInStock = (short?)rdr["UnitsInStock"]
                                    ,
                                UnitsInStock = rdr["UnitsInStock"] == DBNull.Value ? default(short?) : (short?)rdr["UnitsInStock"]
                                    //,UnitsOnOrder = (short?)rdr["UnitsOnOrder"]
                                    ,
                                UnitsOnOrder = rdr["UnitsOnOrder"] == DBNull.Value ? default(short?) : (short?)rdr["UnitsOnOrder"]
                                    //,ReorderLevel = (short?)rdr["ReorderLevel"]
                                    ,
                                ReorderLevel = rdr["ReorderLevel"] == DBNull.Value ? default(short?) : (short?)rdr["ReorderLevel"]

                                    //,Discontinued = (bool)rdr["Discontinued"]
                                    ,
                                Discontinued = rdr["Discontinued"] == DBNull.Value ? false : (bool)rdr["Discontinued"]
                            };
                            productss.Add(products);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return productss;

                }
                catch (Exception ex)
                {
                    BusinessLayer.ExceptionLogging exlog = new BusinessLayer.ExceptionLogging();
                    exlog.SendExcepToDB(ex);
                    //errResult = "A Technical Error occurred, Please visit after some time.";
                    throw;
                }
            }
            catch (Exception fx)
            {
                errResult = fx.Message.ToString();
                throw;
            }

        }
        //END - read



        //BEGIN - sql view
        public List<Vwproducts> GetAllVwproductss()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<Vwproducts> Vwproductss = new List<Vwproducts>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Vwproducts", con);

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Vwproducts vwproducts = new Vwproducts
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //ProductID = (int)rdr["ProductID"]
                                ProductID = rdr["ProductID"] == DBNull.Value ? default(int) : (int)rdr["ProductID"]
                               //,ProductName = (string)rdr["ProductName"]
                               ,
                                ProductName = rdr["ProductName"] == DBNull.Value ? "" : (string)rdr["ProductName"]
            //,SupplierID = (int?)rdr["SupplierID"]
            ,
                                SupplierID = rdr["SupplierID"] == DBNull.Value ? default(int?) : (int?)rdr["SupplierID"]
            //,CategoryID = (int?)rdr["CategoryID"]
            ,
                                CategoryID = rdr["CategoryID"] == DBNull.Value ? default(int?) : (int?)rdr["CategoryID"]
                               //,QuantityPerUnit = (string)rdr["QuantityPerUnit"]
                               ,
                                QuantityPerUnit = rdr["QuantityPerUnit"] == DBNull.Value ? "" : (string)rdr["QuantityPerUnit"]
            //,UnitPrice = (decimal?)rdr["UnitPrice"]
            ,
                                UnitPrice = rdr["UnitPrice"] == DBNull.Value ? default(decimal?) : (decimal?)rdr["UnitPrice"]
            //,UnitsInStock = (short?)rdr["UnitsInStock"]
            ,
                                UnitsInStock = rdr["UnitsInStock"] == DBNull.Value ? default(short?) : (short?)rdr["UnitsInStock"]
            //,UnitsOnOrder = (short?)rdr["UnitsOnOrder"]
            ,
                                UnitsOnOrder = rdr["UnitsOnOrder"] == DBNull.Value ? default(short?) : (short?)rdr["UnitsOnOrder"]
            //,ReorderLevel = (short?)rdr["ReorderLevel"]
            ,
                                ReorderLevel = rdr["ReorderLevel"] == DBNull.Value ? default(short?) : (short?)rdr["ReorderLevel"]
            //,Discontinued = (bool)rdr["Discontinued"]
            ,
                                Discontinued = rdr["Discontinued"] == DBNull.Value ? false : (bool)rdr["Discontinued"]
                            };
                            Vwproductss.Add(vwproducts);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return Vwproductss;

                }
                catch (Exception ex)
                {
                    BusinessLayer.ExceptionLogging exlog = new BusinessLayer.ExceptionLogging();
                    exlog.SendExcepToDB(ex);
                    //errResult = "A Technical Error occurred, Please visit after some time.";
                    throw;
                }
            }
            catch (Exception fx)
            {
                errResult = fx.Message.ToString();
                throw;
            }

        }
        //END - sql view



        //BEGIN - LookUps List
        public string SelectedProducts { get; set; }
        public List<ProductsSelect> ProductsSelect
        {
            get
            {
                var all = GetAllProductss()
                    .Select(a => new ProductsSelect() { ProductID = a.ProductID, ProductName = a.ProductName.ToString(), ProductNameIsSelected = false })
                    .ToList();
                List<ProductsSelect> ProductsSelect = new List<ProductsSelect>();
                foreach (var a in all)
                {
                    ProductsSelect.Add(new ProductsSelect { ProductName = a.ProductName, ProductID = a.ProductID });
                }
                return ProductsSelect;
            }
        }

        public IEnumerable<string> SelectedProductss { get; set; }

        public IEnumerable<SelectListItem> Productss
        {
            get
            {
                List<SelectListItem> ProductssSelectListItems = new List<SelectListItem>();

                foreach (ProductsSingle products in GetAllProductss().ToList())
                {
                    SelectListItem selectList = new SelectListItem()
                    {
                        Text = products.ProductName.ToString(),
                        Value = products.ProductID.ToString(),
                        Selected = false
                    };
                    ProductssSelectListItems.Add(selectList);
                }
                return ProductssSelectListItems;
            }
        }


        //END - LookUps List
    }
    //BEGIN - LookUps Class

    //public class ProductssViewModel
    //{
    //	public IEnumerable<string> SelectedProductss { get; set; }
    //	public IEnumerable<SelectListItem> Productss { get; set; }
    //}

    public class ProductsSelect
    {
        public bool ProductNameIsSelected { set; get; }
        public string ProductName { set; get; }
        public int ProductID { set; get; }
    }
}
//END - LookUps Class
