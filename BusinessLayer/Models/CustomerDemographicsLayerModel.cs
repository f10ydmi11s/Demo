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
    public class CustomerdemographicsBusinessModelLayers
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        string errResult = "";

        //BEGIN - readBy
        public CustomerdemographicsSingle GetCustomerdemographicsData(string CustomerTypeID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    CustomerdemographicsSingle customerdemographics = new CustomerdemographicsSingle();
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string sqlQuery = "SELECT * FROM [CustomerDemographics] WHERE CustomerTypeID= '" + CustomerTypeID.ToString() + "'";

                        using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                        {
                            con.Open();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                //customerdemographics.CustomerTypeID = (string)rdr["CustomerTypeID"];
                                customerdemographics.CustomerTypeID = rdr["CustomerTypeID"] == DBNull.Value ? "" : (string)rdr["CustomerTypeID"];

                                //customerdemographics.CustomerDesc = (string)rdr["CustomerDesc"];
                                customerdemographics.CustomerDesc = rdr["CustomerDesc"] == DBNull.Value ? "" : (string)rdr["CustomerDesc"];


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
                    return customerdemographics;
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
        public void AddCustomerdemographics(CustomerdemographicsSingle customerdemographics)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {




                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spAddCustomerdemographics", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        SqlParameter paramCustomerTypeID = new SqlParameter
                        {
                            ParameterName = "@CustomerTypeID",
                            Value = customerdemographics.CustomerTypeID
                        };
                        cmd.Parameters.Add(paramCustomerTypeID);

                        SqlParameter paramCustomerDesc = new SqlParameter
                        {
                            ParameterName = "@CustomerDesc",
                            Value = customerdemographics.CustomerDesc
                        };
                        cmd.Parameters.Add(paramCustomerDesc);

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
        public void UpdateCustomerdemographics(CustomerdemographicsSingle customerdemographics)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spUpdateCustomerdemographics", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@CustomerTypeID", customerdemographics.CustomerTypeID);
                            cmd.Parameters.AddWithValue("@CustomerDesc", (object)customerdemographics.CustomerDesc ?? DBNull.Value);
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
        public void DeleteCustomerdemographics(string CustomerTypeID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spDeleteCustomerdemographics", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@CustomerTypeID", CustomerTypeID);
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
        public List<CustomerdemographicsSingle> GetAllCustomerdemographicss()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<CustomerdemographicsSingle> customerdemographicss = new List<CustomerdemographicsSingle>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spGetAllCustomerdemographics", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            CustomerdemographicsSingle customerdemographics = new CustomerdemographicsSingle
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //CustomerTypeID = (string)rdr["CustomerTypeID"]
                                CustomerTypeID = rdr["CustomerTypeID"] == DBNull.Value ? "" : (string)rdr["CustomerTypeID"]
                                        //,CustomerDesc = (string)rdr["CustomerDesc"]
                                        ,
                                CustomerDesc = rdr["CustomerDesc"] == DBNull.Value ? "" : (string)rdr["CustomerDesc"]
                            };
                            customerdemographicss.Add(customerdemographics);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return customerdemographicss;

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
        public List<Vwcustomerdemographics> GetAllVwcustomerdemographicss()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<Vwcustomerdemographics> Vwcustomerdemographicss = new List<Vwcustomerdemographics>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Vwcustomerdemographics", con);

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Vwcustomerdemographics vwcustomerdemographics = new Vwcustomerdemographics
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //CustomerTypeID = (string)rdr["CustomerTypeID"]
                                CustomerTypeID = rdr["CustomerTypeID"] == DBNull.Value ? "" : (string)rdr["CustomerTypeID"]
                               //,CustomerDesc = (string)rdr["CustomerDesc"]
                               ,
                                CustomerDesc = rdr["CustomerDesc"] == DBNull.Value ? "" : (string)rdr["CustomerDesc"]
                            };
                            Vwcustomerdemographicss.Add(vwcustomerdemographics);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return Vwcustomerdemographicss;

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
        public string SelectedCustomerdemographics { get; set; }
        public List<CustomerdemographicsSelect> CustomerdemographicsSelect
        {
            get
            {
                var all = GetAllCustomerdemographicss()
                    .Select(a => new CustomerdemographicsSelect() { CustomerTypeID = a.CustomerTypeID, CustomerDesc = a.CustomerDesc.ToString(), CustomerDescIsSelected = false })
                    .ToList();
                List<CustomerdemographicsSelect> CustomerdemographicsSelect = new List<CustomerdemographicsSelect>();
                foreach (var a in all)
                {
                    CustomerdemographicsSelect.Add(new CustomerdemographicsSelect { CustomerDesc = a.CustomerDesc, CustomerTypeID = a.CustomerTypeID });
                }
                return CustomerdemographicsSelect;
            }
        }

        public IEnumerable<string> SelectedCustomerdemographicss { get; set; }

        public IEnumerable<SelectListItem> Customerdemographicss
        {
            get
            {
                List<SelectListItem> CustomerdemographicssSelectListItems = new List<SelectListItem>();

                foreach (CustomerdemographicsSingle customerdemographics in GetAllCustomerdemographicss().ToList())
                {
                    SelectListItem selectList = new SelectListItem()
                    {
                        Text = customerdemographics.CustomerDesc.ToString(),
                        Value = customerdemographics.CustomerTypeID.ToString(),
                        Selected = false
                    };
                    CustomerdemographicssSelectListItems.Add(selectList);
                }
                return CustomerdemographicssSelectListItems;
            }
        }


        //END - LookUps List
    }
    //BEGIN - LookUps Class

    //public class CustomerdemographicssViewModel
    //{
    //	public IEnumerable<string> SelectedCustomerdemographicss { get; set; }
    //	public IEnumerable<SelectListItem> Customerdemographicss { get; set; }
    //}

    public class CustomerdemographicsSelect
    {
        public bool CustomerDescIsSelected { set; get; }
        public string CustomerDesc { set; get; }
        public string CustomerTypeID { set; get; }
    }
}
//END - LookUps Class
