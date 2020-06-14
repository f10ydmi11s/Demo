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
    public class OrdersBusinessModelLayers
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        string errResult = "";

        //BEGIN - readBy
        public OrdersSingle GetOrdersData(int OrderID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    OrdersSingle orders = new OrdersSingle();
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {

                        string sqlQuery = "SELECT * FROM [Orders] WHERE OrderID= " + OrderID.ToString();

                        using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                        {
                            con.Open();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {

                                //orders.OrderID = (int)rdr["OrderID"];
                                orders.OrderID = rdr["OrderID"] == DBNull.Value ? default(int) : (int)rdr["OrderID"];
                                //orders.CustomerID = (string)rdr["CustomerID"];
                                orders.CustomerID = rdr["CustomerID"] == DBNull.Value ? "" : (string)rdr["CustomerID"];


                                //orders.EmployeeID = (int?)rdr["EmployeeID"];
                                orders.EmployeeID = rdr["EmployeeID"] == DBNull.Value ? default(int?) : (int?)rdr["EmployeeID"];

                                //orders.OrderDate = (System.DateTime?)rdr["OrderDate"];
                                orders.OrderDate = rdr["OrderDate"] == DBNull.Value ? default(DateTime) : (System.DateTime?)rdr["OrderDate"];

                                //orders.RequiredDate = (System.DateTime?)rdr["RequiredDate"];
                                orders.RequiredDate = rdr["RequiredDate"] == DBNull.Value ? default(DateTime) : (System.DateTime?)rdr["RequiredDate"];

                                //orders.ShippedDate = (System.DateTime?)rdr["ShippedDate"];
                                orders.ShippedDate = rdr["ShippedDate"] == DBNull.Value ? default(DateTime) : (System.DateTime?)rdr["ShippedDate"];

                                //orders.ShipVia = (int?)rdr["ShipVia"];
                                orders.ShipVia = rdr["ShipVia"] == DBNull.Value ? default(int?) : (int?)rdr["ShipVia"];

                                //orders.Freight = (decimal?)rdr["Freight"];
                                orders.Freight = rdr["Freight"] == DBNull.Value ? default(decimal?) : (decimal?)rdr["Freight"];
                                //orders.ShipName = (string)rdr["ShipName"];
                                orders.ShipName = rdr["ShipName"] == DBNull.Value ? "" : (string)rdr["ShipName"];

                                //orders.ShipAddress = (string)rdr["ShipAddress"];
                                orders.ShipAddress = rdr["ShipAddress"] == DBNull.Value ? "" : (string)rdr["ShipAddress"];

                                //orders.ShipCity = (string)rdr["ShipCity"];
                                orders.ShipCity = rdr["ShipCity"] == DBNull.Value ? "" : (string)rdr["ShipCity"];

                                //orders.ShipRegion = (string)rdr["ShipRegion"];
                                orders.ShipRegion = rdr["ShipRegion"] == DBNull.Value ? "" : (string)rdr["ShipRegion"];

                                //orders.ShipPostalCode = (string)rdr["ShipPostalCode"];
                                orders.ShipPostalCode = rdr["ShipPostalCode"] == DBNull.Value ? "" : (string)rdr["ShipPostalCode"];

                                //orders.ShipCountry = (string)rdr["ShipCountry"];
                                orders.ShipCountry = rdr["ShipCountry"] == DBNull.Value ? "" : (string)rdr["ShipCountry"];


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
                    return orders;
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
        public void AddOrders(OrdersSingle orders)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    BusinessLayer.Validation isdte = new BusinessLayer.Validation();
                    if (isdte.IsDate(orders.OrderDate) == false)
                    {
                        orders.OrderDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                    }

                    if (isdte.IsDate(orders.RequiredDate) == false)
                    {
                        orders.RequiredDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                    }

                    if (isdte.IsDate(orders.ShippedDate) == false)
                    {
                        orders.ShippedDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                    }


                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spAddOrders", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        SqlParameter paramOrderID = new SqlParameter
                        {
                            ParameterName = "@OrderID",
                            Value = orders.OrderID
                        };
                        cmd.Parameters.Add(paramOrderID);

                        SqlParameter paramCustomerID = new SqlParameter
                        {
                            ParameterName = "@CustomerID",
                            Value = orders.CustomerID
                        };
                        cmd.Parameters.Add(paramCustomerID);

                        SqlParameter paramEmployeeID = new SqlParameter
                        {
                            ParameterName = "@EmployeeID",
                            Value = orders.EmployeeID
                        };
                        cmd.Parameters.Add(paramEmployeeID);

                        SqlParameter paramOrderDate = new SqlParameter
                        {
                            ParameterName = "@OrderDate",
                            Value = orders.OrderDate
                        };
                        cmd.Parameters.Add(paramOrderDate);

                        SqlParameter paramRequiredDate = new SqlParameter
                        {
                            ParameterName = "@RequiredDate",
                            Value = orders.RequiredDate
                        };
                        cmd.Parameters.Add(paramRequiredDate);

                        SqlParameter paramShippedDate = new SqlParameter
                        {
                            ParameterName = "@ShippedDate",
                            Value = orders.ShippedDate
                        };
                        cmd.Parameters.Add(paramShippedDate);

                        SqlParameter paramShipVia = new SqlParameter
                        {
                            ParameterName = "@ShipVia",
                            Value = orders.ShipVia
                        };
                        cmd.Parameters.Add(paramShipVia);

                        SqlParameter paramFreight = new SqlParameter
                        {
                            ParameterName = "@Freight",
                            Value = orders.Freight
                        };
                        cmd.Parameters.Add(paramFreight);

                        SqlParameter paramShipName = new SqlParameter
                        {
                            ParameterName = "@ShipName",
                            Value = orders.ShipName
                        };
                        cmd.Parameters.Add(paramShipName);

                        SqlParameter paramShipAddress = new SqlParameter
                        {
                            ParameterName = "@ShipAddress",
                            Value = orders.ShipAddress
                        };
                        cmd.Parameters.Add(paramShipAddress);

                        SqlParameter paramShipCity = new SqlParameter
                        {
                            ParameterName = "@ShipCity",
                            Value = orders.ShipCity
                        };
                        cmd.Parameters.Add(paramShipCity);

                        SqlParameter paramShipRegion = new SqlParameter
                        {
                            ParameterName = "@ShipRegion",
                            Value = orders.ShipRegion
                        };
                        cmd.Parameters.Add(paramShipRegion);

                        SqlParameter paramShipPostalCode = new SqlParameter
                        {
                            ParameterName = "@ShipPostalCode",
                            Value = orders.ShipPostalCode
                        };
                        cmd.Parameters.Add(paramShipPostalCode);

                        SqlParameter paramShipCountry = new SqlParameter
                        {
                            ParameterName = "@ShipCountry",
                            Value = orders.ShipCountry
                        };
                        cmd.Parameters.Add(paramShipCountry);

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
        public void UpdateOrders(OrdersSingle orders)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    BusinessLayer.Validation isdte = new BusinessLayer.Validation();
                    if (isdte.IsDate(orders.OrderDate) == false)
                    {
                        orders.OrderDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                    }

                    if (isdte.IsDate(orders.RequiredDate) == false)
                    {
                        orders.RequiredDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                    }

                    if (isdte.IsDate(orders.ShippedDate) == false)
                    {
                        orders.ShippedDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                    }

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spUpdateOrders", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@OrderID", orders.OrderID);
                            cmd.Parameters.AddWithValue("@CustomerID", (object)orders.CustomerID ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@EmployeeID", (object)orders.EmployeeID ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@OrderDate", (object)orders.OrderDate ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@RequiredDate", (object)orders.RequiredDate ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@ShippedDate", (object)orders.ShippedDate ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@ShipVia", (object)orders.ShipVia ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Freight", (object)orders.Freight ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@ShipName", (object)orders.ShipName ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@ShipAddress", (object)orders.ShipAddress ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@ShipCity", (object)orders.ShipCity ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@ShipRegion", (object)orders.ShipRegion ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@ShipPostalCode", (object)orders.ShipPostalCode ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@ShipCountry", (object)orders.ShipCountry ?? DBNull.Value);
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
        public void DeleteOrders(int OrderID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spDeleteOrders", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@OrderID", OrderID);
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
        public List<OrdersSingle> GetAllOrderss()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<OrdersSingle> orderss = new List<OrdersSingle>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spGetAllOrders", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            OrdersSingle orders = new OrdersSingle
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //OrderID = (int)rdr["OrderID"]
                                OrderID = rdr["OrderID"] == DBNull.Value ? default(int) : (int)rdr["OrderID"]
                                        //,CustomerID = (string)rdr["CustomerID"]
                                        ,
                                CustomerID = rdr["CustomerID"] == DBNull.Value ? "" : (string)rdr["CustomerID"]
                                    //,EmployeeID = (int?)rdr["EmployeeID"]
                                    ,
                                EmployeeID = rdr["EmployeeID"] == DBNull.Value ? default(int?) : (int?)rdr["EmployeeID"]
                                    //,OrderDate = (System.DateTime?)rdr["OrderDate"]
                                    ,
                                OrderDate = rdr["OrderDate"] == DBNull.Value ? default(DateTime) : (System.DateTime?)rdr["OrderDate"]
                                    //,RequiredDate = (System.DateTime?)rdr["RequiredDate"]
                                    ,
                                RequiredDate = rdr["RequiredDate"] == DBNull.Value ? default(DateTime) : (System.DateTime?)rdr["RequiredDate"]
                                    //,ShippedDate = (System.DateTime?)rdr["ShippedDate"]
                                    ,
                                ShippedDate = rdr["ShippedDate"] == DBNull.Value ? default(DateTime) : (System.DateTime?)rdr["ShippedDate"]
                                    //,ShipVia = (int?)rdr["ShipVia"]
                                    ,
                                ShipVia = rdr["ShipVia"] == DBNull.Value ? default(int?) : (int?)rdr["ShipVia"]
                                    //,Freight = (decimal?)rdr["Freight"]
                                    ,
                                Freight = rdr["Freight"] == DBNull.Value ? default(decimal?) : (decimal?)rdr["Freight"]
                                        //,ShipName = (string)rdr["ShipName"]
                                        ,
                                ShipName = rdr["ShipName"] == DBNull.Value ? "" : (string)rdr["ShipName"]
                                        //,ShipAddress = (string)rdr["ShipAddress"]
                                        ,
                                ShipAddress = rdr["ShipAddress"] == DBNull.Value ? "" : (string)rdr["ShipAddress"]
                                        //,ShipCity = (string)rdr["ShipCity"]
                                        ,
                                ShipCity = rdr["ShipCity"] == DBNull.Value ? "" : (string)rdr["ShipCity"]
                                        //,ShipRegion = (string)rdr["ShipRegion"]
                                        ,
                                ShipRegion = rdr["ShipRegion"] == DBNull.Value ? "" : (string)rdr["ShipRegion"]
                                        //,ShipPostalCode = (string)rdr["ShipPostalCode"]
                                        ,
                                ShipPostalCode = rdr["ShipPostalCode"] == DBNull.Value ? "" : (string)rdr["ShipPostalCode"]
                                        //,ShipCountry = (string)rdr["ShipCountry"]
                                        ,
                                ShipCountry = rdr["ShipCountry"] == DBNull.Value ? "" : (string)rdr["ShipCountry"]
                            };
                            orderss.Add(orders);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return orderss;

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
        public List<Vworders> GetAllVworderss()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<Vworders> Vworderss = new List<Vworders>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Vworders", con);

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Vworders vworders = new Vworders
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //OrderID = (int)rdr["OrderID"]
                                OrderID = rdr["OrderID"] == DBNull.Value ? default(int) : (int)rdr["OrderID"]
                               //,CustomerID = (string)rdr["CustomerID"]
                               ,
                                CustomerID = rdr["CustomerID"] == DBNull.Value ? "" : (string)rdr["CustomerID"]
            //,EmployeeID = (int?)rdr["EmployeeID"]
            ,
                                EmployeeID = rdr["EmployeeID"] == DBNull.Value ? default(int?) : (int?)rdr["EmployeeID"]
            //,OrderDate = (System.DateTime?)rdr["OrderDate"]
            ,
                                OrderDate = rdr["OrderDate"] == DBNull.Value ? default(DateTime) : (System.DateTime?)rdr["OrderDate"]
            //,RequiredDate = (System.DateTime?)rdr["RequiredDate"]
            ,
                                RequiredDate = rdr["RequiredDate"] == DBNull.Value ? default(DateTime) : (System.DateTime?)rdr["RequiredDate"]
            //,ShippedDate = (System.DateTime?)rdr["ShippedDate"]
            ,
                                ShippedDate = rdr["ShippedDate"] == DBNull.Value ? default(DateTime) : (System.DateTime?)rdr["ShippedDate"]
            //,ShipVia = (int?)rdr["ShipVia"]
            ,
                                ShipVia = rdr["ShipVia"] == DBNull.Value ? default(int?) : (int?)rdr["ShipVia"]
            //,Freight = (decimal?)rdr["Freight"]
            ,
                                Freight = rdr["Freight"] == DBNull.Value ? default(decimal?) : (decimal?)rdr["Freight"]
                               //,ShipName = (string)rdr["ShipName"]
                               ,
                                ShipName = rdr["ShipName"] == DBNull.Value ? "" : (string)rdr["ShipName"]
                               //,ShipAddress = (string)rdr["ShipAddress"]
                               ,
                                ShipAddress = rdr["ShipAddress"] == DBNull.Value ? "" : (string)rdr["ShipAddress"]
                               //,ShipCity = (string)rdr["ShipCity"]
                               ,
                                ShipCity = rdr["ShipCity"] == DBNull.Value ? "" : (string)rdr["ShipCity"]
                               //,ShipRegion = (string)rdr["ShipRegion"]
                               ,
                                ShipRegion = rdr["ShipRegion"] == DBNull.Value ? "" : (string)rdr["ShipRegion"]
                               //,ShipPostalCode = (string)rdr["ShipPostalCode"]
                               ,
                                ShipPostalCode = rdr["ShipPostalCode"] == DBNull.Value ? "" : (string)rdr["ShipPostalCode"]
                               //,ShipCountry = (string)rdr["ShipCountry"]
                               ,
                                ShipCountry = rdr["ShipCountry"] == DBNull.Value ? "" : (string)rdr["ShipCountry"]
                            };
                            Vworderss.Add(vworders);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return Vworderss;

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
        public string SelectedOrders { get; set; }
        public List<OrdersSelect> OrdersSelect
        {
            get
            {
                var all = GetAllOrderss()
                    .Select(a => new OrdersSelect() { OrderID = a.OrderID, CustomerID = a.CustomerID.ToString(), CustomerIDIsSelected = false })
                    .ToList();
                List<OrdersSelect> OrdersSelect = new List<OrdersSelect>();
                foreach (var a in all)
                {
                    OrdersSelect.Add(new OrdersSelect { CustomerID = a.CustomerID, OrderID = a.OrderID });
                }
                return OrdersSelect;
            }
        }

        public IEnumerable<string> SelectedOrderss { get; set; }

        public IEnumerable<SelectListItem> Orderss
        {
            get
            {
                List<SelectListItem> OrderssSelectListItems = new List<SelectListItem>();

                foreach (OrdersSingle orders in GetAllOrderss().ToList())
                {
                    SelectListItem selectList = new SelectListItem()
                    {
                        Text = orders.CustomerID.ToString(),
                        Value = orders.OrderID.ToString(),
                        Selected = false
                    };
                    OrderssSelectListItems.Add(selectList);
                }
                return OrderssSelectListItems;
            }
        }


        //END - LookUps List
    }
    //BEGIN - LookUps Class

    //public class OrderssViewModel
    //{
    //	public IEnumerable<string> SelectedOrderss { get; set; }
    //	public IEnumerable<SelectListItem> Orderss { get; set; }
    //}

    public class OrdersSelect
    {
        public bool CustomerIDIsSelected { set; get; }
        public string CustomerID { set; get; }
        public int OrderID { set; get; }
    }
}
//END - LookUps Class
