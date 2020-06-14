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
    public class CustomercustomerdemoBusinessModelLayers
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        string errResult = "";

        //BEGIN - readBy
        public CustomercustomerdemoSingle GetCustomercustomerdemoData(string CustomerID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    CustomercustomerdemoSingle customercustomerdemo = new CustomercustomerdemoSingle();
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string sqlQuery = "SELECT * FROM [CustomerCustomerDemo] WHERE CustomerID= '" + CustomerID.ToString() + "'";

                        using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                        {
                            con.Open();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                //customercustomerdemo.CustomerID = (string)rdr["CustomerID"];
                                customercustomerdemo.CustomerID = rdr["CustomerID"] == DBNull.Value ? "" : (string)rdr["CustomerID"];

                                //customercustomerdemo.CustomerTypeID = (string)rdr["CustomerTypeID"];
                                customercustomerdemo.CustomerTypeID = rdr["CustomerTypeID"] == DBNull.Value ? "" : (string)rdr["CustomerTypeID"];


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
                    return customercustomerdemo;
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
        public void AddCustomercustomerdemo(CustomercustomerdemoSingle customercustomerdemo)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {




                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spAddCustomercustomerdemo", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        SqlParameter paramCustomerID = new SqlParameter
                        {
                            ParameterName = "@CustomerID",
                            Value = customercustomerdemo.CustomerID
                        };
                        cmd.Parameters.Add(paramCustomerID);

                        SqlParameter paramCustomerTypeID = new SqlParameter
                        {
                            ParameterName = "@CustomerTypeID",
                            Value = customercustomerdemo.CustomerTypeID
                        };
                        cmd.Parameters.Add(paramCustomerTypeID);

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
        public void UpdateCustomercustomerdemo(CustomercustomerdemoSingle customercustomerdemo)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spUpdateCustomercustomerdemo", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@CustomerID", customercustomerdemo.CustomerID);
                            cmd.Parameters.AddWithValue("@CustomerTypeID", customercustomerdemo.CustomerTypeID);
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
        public void DeleteCustomercustomerdemo(string CustomerID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spDeleteCustomercustomerdemo", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
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
        public List<CustomercustomerdemoSingle> GetAllCustomercustomerdemos()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<CustomercustomerdemoSingle> customercustomerdemos = new List<CustomercustomerdemoSingle>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spGetAllCustomercustomerdemo", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            CustomercustomerdemoSingle customercustomerdemo = new CustomercustomerdemoSingle
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //CustomerID = (string)rdr["CustomerID"]
                                CustomerID = rdr["CustomerID"] == DBNull.Value ? "" : (string)rdr["CustomerID"]
                                        //,CustomerTypeID = (string)rdr["CustomerTypeID"]
                                        ,
                                CustomerTypeID = rdr["CustomerTypeID"] == DBNull.Value ? "" : (string)rdr["CustomerTypeID"]
                            };
                            customercustomerdemos.Add(customercustomerdemo);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return customercustomerdemos;

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
        public List<Vwcustomercustomerdemo> GetAllVwcustomercustomerdemos()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<Vwcustomercustomerdemo> Vwcustomercustomerdemos = new List<Vwcustomercustomerdemo>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Vwcustomercustomerdemo", con);

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Vwcustomercustomerdemo vwcustomercustomerdemo = new Vwcustomercustomerdemo
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //CustomerID = (string)rdr["CustomerID"]
                                CustomerID = rdr["CustomerID"] == DBNull.Value ? "" : (string)rdr["CustomerID"]
                               //,CustomerTypeID = (string)rdr["CustomerTypeID"]
                               ,
                                CustomerTypeID = rdr["CustomerTypeID"] == DBNull.Value ? "" : (string)rdr["CustomerTypeID"]
                            };
                            Vwcustomercustomerdemos.Add(vwcustomercustomerdemo);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return Vwcustomercustomerdemos;

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
        public string SelectedCustomercustomerdemo { get; set; }
        public List<CustomercustomerdemoSelect> CustomercustomerdemoSelect
        {
            get
            {
                var all = GetAllCustomercustomerdemos()
                    .Select(a => new CustomercustomerdemoSelect() { CustomerID = a.CustomerID, CustomerTypeID = a.CustomerTypeID.ToString(), CustomerTypeIDIsSelected = false })
                    .ToList();
                List<CustomercustomerdemoSelect> CustomercustomerdemoSelect = new List<CustomercustomerdemoSelect>();
                foreach (var a in all)
                {
                    CustomercustomerdemoSelect.Add(new CustomercustomerdemoSelect { CustomerTypeID = a.CustomerTypeID, CustomerID = a.CustomerID });
                }
                return CustomercustomerdemoSelect;
            }
        }

        public IEnumerable<string> SelectedCustomercustomerdemos { get; set; }

        public IEnumerable<SelectListItem> Customercustomerdemos
        {
            get
            {
                List<SelectListItem> CustomercustomerdemosSelectListItems = new List<SelectListItem>();

                foreach (CustomercustomerdemoSingle customercustomerdemo in GetAllCustomercustomerdemos().ToList())
                {
                    SelectListItem selectList = new SelectListItem()
                    {
                        Text = customercustomerdemo.CustomerTypeID.ToString(),
                        Value = customercustomerdemo.CustomerID.ToString(),
                        Selected = false
                    };
                    CustomercustomerdemosSelectListItems.Add(selectList);
                }
                return CustomercustomerdemosSelectListItems;
            }
        }


        //END - LookUps List
    }
    //BEGIN - LookUps Class

    //public class CustomercustomerdemosViewModel
    //{
    //	public IEnumerable<string> SelectedCustomercustomerdemos { get; set; }
    //	public IEnumerable<SelectListItem> Customercustomerdemos { get; set; }
    //}

    public class CustomercustomerdemoSelect
    {
        public bool CustomerTypeIDIsSelected { set; get; }
        public string CustomerTypeID { set; get; }
        public string CustomerID { set; get; }
    }
}
//END - LookUps Class
