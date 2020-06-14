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
    public class Order_DetailsBusinessModelLayers
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        string errResult = "";

        //BEGIN - readBy
        public Order_DetailsSingle GetOrder_DetailsData(int OrderID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    Order_DetailsSingle order_details = new Order_DetailsSingle();
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {

                        string sqlQuery = "SELECT * FROM [Order Details] WHERE OrderID= " + OrderID.ToString();

                        using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                        {
                            con.Open();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {

                                //order_details.OrderID = (int)rdr["OrderID"];
                                order_details.OrderID = rdr["OrderID"] == DBNull.Value ? default(int) : (int)rdr["OrderID"];

                                //order_details.ProductID = (int)rdr["ProductID"];
                                order_details.ProductID = rdr["ProductID"] == DBNull.Value ? default(int) : (int)rdr["ProductID"];

                                //order_details.UnitPrice = (decimal)rdr["UnitPrice"];
                                order_details.UnitPrice = rdr["UnitPrice"] == DBNull.Value ? default(decimal) : (decimal)rdr["UnitPrice"];

                                //order_details.Quantity = (short)rdr["Quantity"];
                                order_details.Quantity = rdr["Quantity"] == DBNull.Value ? default(short) : (short)rdr["Quantity"];

                                //order_details.Discount = (float)rdr["Discount"];
                                order_details.Discount = rdr["Discount"] == DBNull.Value ? default(float) : (float)rdr["Discount"];

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
                    return order_details;
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
        public void AddOrder_Details(Order_DetailsSingle order_details)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {




                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spAddOrder_Details", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        SqlParameter paramOrderID = new SqlParameter
                        {
                            ParameterName = "@OrderID",
                            Value = order_details.OrderID
                        };
                        cmd.Parameters.Add(paramOrderID);

                        SqlParameter paramProductID = new SqlParameter
                        {
                            ParameterName = "@ProductID",
                            Value = order_details.ProductID
                        };
                        cmd.Parameters.Add(paramProductID);

                        SqlParameter paramUnitPrice = new SqlParameter
                        {
                            ParameterName = "@UnitPrice",
                            Value = order_details.UnitPrice
                        };
                        cmd.Parameters.Add(paramUnitPrice);

                        SqlParameter paramQuantity = new SqlParameter
                        {
                            ParameterName = "@Quantity",
                            Value = order_details.Quantity
                        };
                        cmd.Parameters.Add(paramQuantity);

                        SqlParameter paramDiscount = new SqlParameter
                        {
                            ParameterName = "@Discount",
                            Value = order_details.Discount
                        };
                        cmd.Parameters.Add(paramDiscount);

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
        public void UpdateOrder_Details(Order_DetailsSingle order_details)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spUpdateOrder_Details", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@OrderID", order_details.OrderID);
                            cmd.Parameters.AddWithValue("@ProductID", order_details.ProductID);
                            cmd.Parameters.AddWithValue("@UnitPrice", order_details.UnitPrice);
                            cmd.Parameters.AddWithValue("@Quantity", order_details.Quantity);
                            cmd.Parameters.AddWithValue("@Discount", order_details.Discount);
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
        public void DeleteOrder_Details(int OrderID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spDeleteOrder_Details", con)
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
        public List<Order_DetailsSingle> GetAllOrder_Detailss()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<Order_DetailsSingle> order_detailss = new List<Order_DetailsSingle>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spGetAllOrder_Details", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Order_DetailsSingle order_details = new Order_DetailsSingle
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //OrderID = (int)rdr["OrderID"]
                                OrderID = rdr["OrderID"] == DBNull.Value ? default(int) : (int)rdr["OrderID"]
                                    //,ProductID = (int)rdr["ProductID"]
                                    ,
                                ProductID = rdr["ProductID"] == DBNull.Value ? default(int) : (int)rdr["ProductID"]
                                    //,UnitPrice = (decimal)rdr["UnitPrice"]
                                    ,
                                UnitPrice = rdr["UnitPrice"] == DBNull.Value ? default(decimal) : (decimal)rdr["UnitPrice"]
                                    //,Quantity = (short)rdr["Quantity"]
                                    ,
                                Quantity = rdr["Quantity"] == DBNull.Value ? default(short) : (short)rdr["Quantity"]
                                    //,Discount = (float)rdr["Discount"]
                                    ,
                                Discount = rdr["Discount"] == DBNull.Value ? default(float) : (float)rdr["Discount"]
                            };
                            order_detailss.Add(order_details);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return order_detailss;

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
        public List<Vworder_details> GetAllVworder_detailss()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<Vworder_details> Vworder_Detailss = new List<Vworder_details>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Vworder_Details", con);

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Vworder_details vworder_details = new Vworder_details
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //OrderID = (int)rdr["OrderID"]
                                OrderID = rdr["OrderID"] == DBNull.Value ? default(int) : (int)rdr["OrderID"]
            //,ProductID = (int)rdr["ProductID"]
            ,
                                ProductID = rdr["ProductID"] == DBNull.Value ? default(int) : (int)rdr["ProductID"]
            //,UnitPrice = (decimal)rdr["UnitPrice"]
            ,
                                UnitPrice = rdr["UnitPrice"] == DBNull.Value ? default(decimal) : (decimal)rdr["UnitPrice"]
            //,Quantity = (short)rdr["Quantity"]
            ,
                                Quantity = rdr["Quantity"] == DBNull.Value ? default(short) : (short)rdr["Quantity"]
            //,Discount = (float)rdr["Discount"]
            ,
                                Discount = rdr["Discount"] == DBNull.Value ? default(float) : (float)rdr["Discount"]
                            };
                            Vworder_Detailss.Add(vworder_details);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return Vworder_Detailss;

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
        public string SelectedOrder_Details { get; set; }
        public List<Order_DetailsSelect> Order_DetailsSelect
        {
            get
            {
                var all = GetAllOrder_Detailss()
                    .Select(a => new Order_DetailsSelect() { OrderID = a.OrderID, ProductID = a.ProductID.ToString(), ProductIDIsSelected = false })
                    .ToList();
                List<Order_DetailsSelect> Order_DetailsSelect = new List<Order_DetailsSelect>();
                foreach (var a in all)
                {
                    Order_DetailsSelect.Add(new Order_DetailsSelect { ProductID = a.ProductID, OrderID = a.OrderID });
                }
                return Order_DetailsSelect;
            }
        }

        public IEnumerable<string> SelectedOrder_Detailss { get; set; }

        public IEnumerable<SelectListItem> Order_Detailss
        {
            get
            {
                List<SelectListItem> Order_DetailssSelectListItems = new List<SelectListItem>();

                foreach (Order_DetailsSingle order_details in GetAllOrder_Detailss().ToList())
                {
                    SelectListItem selectList = new SelectListItem()
                    {
                        Text = order_details.ProductID.ToString(),
                        Value = order_details.OrderID.ToString(),
                        Selected = false
                    };
                    Order_DetailssSelectListItems.Add(selectList);
                }
                return Order_DetailssSelectListItems;
            }
        }


        //END - LookUps List
    }
    //BEGIN - LookUps Class

    //public class Order_DetailssViewModel
    //{
    //	public IEnumerable<string> SelectedOrder_Detailss { get; set; }
    //	public IEnumerable<SelectListItem> Order_Detailss { get; set; }
    //}

    public class Order_DetailsSelect
    {
        public bool ProductIDIsSelected { set; get; }
        public string ProductID { set; get; }
        public int OrderID { set; get; }
    }
}
//END - LookUps Class
