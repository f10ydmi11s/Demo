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
    public class CustomersBusinessModelLayers
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        string errResult = "";

        //BEGIN - readBy
        public CustomersSingle GetCustomersData(string CustomerID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    CustomersSingle customers = new CustomersSingle();
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string sqlQuery = "SELECT * FROM [Customers] WHERE CustomerID= '" + CustomerID.ToString() + "'";

                        using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                        {
                            con.Open();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                //customers.CustomerID = (string)rdr["CustomerID"];
                                customers.CustomerID = rdr["CustomerID"] == DBNull.Value ? "" : (string)rdr["CustomerID"];

                                //customers.CompanyName = (string)rdr["CompanyName"];
                                customers.CompanyName = rdr["CompanyName"] == DBNull.Value ? "" : (string)rdr["CompanyName"];

                                //customers.ContactName = (string)rdr["ContactName"];
                                customers.ContactName = rdr["ContactName"] == DBNull.Value ? "" : (string)rdr["ContactName"];

                                //customers.ContactTitle = (string)rdr["ContactTitle"];
                                customers.ContactTitle = rdr["ContactTitle"] == DBNull.Value ? "" : (string)rdr["ContactTitle"];

                                //customers.Address = (string)rdr["Address"];
                                customers.Address = rdr["Address"] == DBNull.Value ? "" : (string)rdr["Address"];

                                //customers.City = (string)rdr["City"];
                                customers.City = rdr["City"] == DBNull.Value ? "" : (string)rdr["City"];

                                //customers.Region = (string)rdr["Region"];
                                customers.Region = rdr["Region"] == DBNull.Value ? "" : (string)rdr["Region"];

                                //customers.PostalCode = (string)rdr["PostalCode"];
                                customers.PostalCode = rdr["PostalCode"] == DBNull.Value ? "" : (string)rdr["PostalCode"];

                                //customers.Country = (string)rdr["Country"];
                                customers.Country = rdr["Country"] == DBNull.Value ? "" : (string)rdr["Country"];

                                //customers.Phone = (string)rdr["Phone"];
                                customers.Phone = rdr["Phone"] == DBNull.Value ? "" : (string)rdr["Phone"];

                                //customers.Fax = (string)rdr["Fax"];
                                customers.Fax = rdr["Fax"] == DBNull.Value ? "" : (string)rdr["Fax"];


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
                    return customers;
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
        public void AddCustomers(CustomersSingle customers)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {




                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spAddCustomers", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        SqlParameter paramCustomerID = new SqlParameter
                        {
                            ParameterName = "@CustomerID",
                            Value = customers.CustomerID
                        };
                        cmd.Parameters.Add(paramCustomerID);

                        SqlParameter paramCompanyName = new SqlParameter
                        {
                            ParameterName = "@CompanyName",
                            Value = customers.CompanyName
                        };
                        cmd.Parameters.Add(paramCompanyName);

                        SqlParameter paramContactName = new SqlParameter
                        {
                            ParameterName = "@ContactName",
                            Value = customers.ContactName
                        };
                        cmd.Parameters.Add(paramContactName);

                        SqlParameter paramContactTitle = new SqlParameter
                        {
                            ParameterName = "@ContactTitle",
                            Value = customers.ContactTitle
                        };
                        cmd.Parameters.Add(paramContactTitle);

                        SqlParameter paramAddress = new SqlParameter
                        {
                            ParameterName = "@Address",
                            Value = customers.Address
                        };
                        cmd.Parameters.Add(paramAddress);

                        SqlParameter paramCity = new SqlParameter
                        {
                            ParameterName = "@City",
                            Value = customers.City
                        };
                        cmd.Parameters.Add(paramCity);

                        SqlParameter paramRegion = new SqlParameter
                        {
                            ParameterName = "@Region",
                            Value = customers.Region
                        };
                        cmd.Parameters.Add(paramRegion);

                        SqlParameter paramPostalCode = new SqlParameter
                        {
                            ParameterName = "@PostalCode",
                            Value = customers.PostalCode
                        };
                        cmd.Parameters.Add(paramPostalCode);

                        SqlParameter paramCountry = new SqlParameter
                        {
                            ParameterName = "@Country",
                            Value = customers.Country
                        };
                        cmd.Parameters.Add(paramCountry);

                        SqlParameter paramPhone = new SqlParameter
                        {
                            ParameterName = "@Phone",
                            Value = customers.Phone
                        };
                        cmd.Parameters.Add(paramPhone);

                        SqlParameter paramFax = new SqlParameter
                        {
                            ParameterName = "@Fax",
                            Value = customers.Fax
                        };
                        cmd.Parameters.Add(paramFax);

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
        public void UpdateCustomers(CustomersSingle customers)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spUpdateCustomers", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@CustomerID", customers.CustomerID);
                            cmd.Parameters.AddWithValue("@CompanyName", customers.CompanyName);
                            cmd.Parameters.AddWithValue("@ContactName", (object)customers.ContactName ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@ContactTitle", (object)customers.ContactTitle ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Address", (object)customers.Address ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@City", (object)customers.City ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Region", (object)customers.Region ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@PostalCode", (object)customers.PostalCode ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Country", (object)customers.Country ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Phone", (object)customers.Phone ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Fax", (object)customers.Fax ?? DBNull.Value);
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
        public void DeleteCustomers(string CustomerID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spDeleteCustomers", con)
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
        public List<CustomersSingle> GetAllCustomerss()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<CustomersSingle> customerss = new List<CustomersSingle>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spGetAllCustomers", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            CustomersSingle customers = new CustomersSingle
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //CustomerID = (string)rdr["CustomerID"]
                                CustomerID = rdr["CustomerID"] == DBNull.Value ? "" : (string)rdr["CustomerID"]
                                        //,CompanyName = (string)rdr["CompanyName"]
                                        ,
                                CompanyName = rdr["CompanyName"] == DBNull.Value ? "" : (string)rdr["CompanyName"]
                                        //,ContactName = (string)rdr["ContactName"]
                                        ,
                                ContactName = rdr["ContactName"] == DBNull.Value ? "" : (string)rdr["ContactName"]
                                        //,ContactTitle = (string)rdr["ContactTitle"]
                                        ,
                                ContactTitle = rdr["ContactTitle"] == DBNull.Value ? "" : (string)rdr["ContactTitle"]
                                        //,Address = (string)rdr["Address"]
                                        ,
                                Address = rdr["Address"] == DBNull.Value ? "" : (string)rdr["Address"]
                                        //,City = (string)rdr["City"]
                                        ,
                                City = rdr["City"] == DBNull.Value ? "" : (string)rdr["City"]
                                        //,Region = (string)rdr["Region"]
                                        ,
                                Region = rdr["Region"] == DBNull.Value ? "" : (string)rdr["Region"]
                                        //,PostalCode = (string)rdr["PostalCode"]
                                        ,
                                PostalCode = rdr["PostalCode"] == DBNull.Value ? "" : (string)rdr["PostalCode"]
                                        //,Country = (string)rdr["Country"]
                                        ,
                                Country = rdr["Country"] == DBNull.Value ? "" : (string)rdr["Country"]
                                        //,Phone = (string)rdr["Phone"]
                                        ,
                                Phone = rdr["Phone"] == DBNull.Value ? "" : (string)rdr["Phone"]
                                        //,Fax = (string)rdr["Fax"]
                                        ,
                                Fax = rdr["Fax"] == DBNull.Value ? "" : (string)rdr["Fax"]
                            };
                            customerss.Add(customers);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return customerss;

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
        public List<Vwcustomers> GetAllVwcustomerss()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<Vwcustomers> Vwcustomerss = new List<Vwcustomers>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Vwcustomers", con);

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Vwcustomers vwcustomers = new Vwcustomers
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //CustomerID = (string)rdr["CustomerID"]
                                CustomerID = rdr["CustomerID"] == DBNull.Value ? "" : (string)rdr["CustomerID"]
                               //,CompanyName = (string)rdr["CompanyName"]
                               ,
                                CompanyName = rdr["CompanyName"] == DBNull.Value ? "" : (string)rdr["CompanyName"]
                               //,ContactName = (string)rdr["ContactName"]
                               ,
                                ContactName = rdr["ContactName"] == DBNull.Value ? "" : (string)rdr["ContactName"]
                               //,ContactTitle = (string)rdr["ContactTitle"]
                               ,
                                ContactTitle = rdr["ContactTitle"] == DBNull.Value ? "" : (string)rdr["ContactTitle"]
                               //,Address = (string)rdr["Address"]
                               ,
                                Address = rdr["Address"] == DBNull.Value ? "" : (string)rdr["Address"]
                               //,City = (string)rdr["City"]
                               ,
                                City = rdr["City"] == DBNull.Value ? "" : (string)rdr["City"]
                               //,Region = (string)rdr["Region"]
                               ,
                                Region = rdr["Region"] == DBNull.Value ? "" : (string)rdr["Region"]
                               //,PostalCode = (string)rdr["PostalCode"]
                               ,
                                PostalCode = rdr["PostalCode"] == DBNull.Value ? "" : (string)rdr["PostalCode"]
                               //,Country = (string)rdr["Country"]
                               ,
                                Country = rdr["Country"] == DBNull.Value ? "" : (string)rdr["Country"]
                               //,Phone = (string)rdr["Phone"]
                               ,
                                Phone = rdr["Phone"] == DBNull.Value ? "" : (string)rdr["Phone"]
                               //,Fax = (string)rdr["Fax"]
                               ,
                                Fax = rdr["Fax"] == DBNull.Value ? "" : (string)rdr["Fax"]
                            };
                            Vwcustomerss.Add(vwcustomers);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return Vwcustomerss;

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
        public string SelectedCustomers { get; set; }
        public List<CustomersSelect> CustomersSelect
        {
            get
            {
                var all = GetAllCustomerss()
                    .Select(a => new CustomersSelect() { CustomerID = a.CustomerID, CompanyName = a.CompanyName.ToString(), CompanyNameIsSelected = false })
                    .ToList();
                List<CustomersSelect> CustomersSelect = new List<CustomersSelect>();
                foreach (var a in all)
                {
                    CustomersSelect.Add(new CustomersSelect { CompanyName = a.CompanyName, CustomerID = a.CustomerID });
                }
                return CustomersSelect;
            }
        }

        public IEnumerable<string> SelectedCustomerss { get; set; }

        public IEnumerable<SelectListItem> Customerss
        {
            get
            {
                List<SelectListItem> CustomerssSelectListItems = new List<SelectListItem>();

                foreach (CustomersSingle customers in GetAllCustomerss().ToList())
                {
                    SelectListItem selectList = new SelectListItem()
                    {
                        Text = customers.CompanyName.ToString(),
                        Value = customers.CustomerID.ToString(),
                        Selected = false
                    };
                    CustomerssSelectListItems.Add(selectList);
                }
                return CustomerssSelectListItems;
            }
        }


        //END - LookUps List
    }
    //BEGIN - LookUps Class

    //public class CustomerssViewModel
    //{
    //	public IEnumerable<string> SelectedCustomerss { get; set; }
    //	public IEnumerable<SelectListItem> Customerss { get; set; }
    //}

    public class CustomersSelect
    {
        public bool CompanyNameIsSelected { set; get; }
        public string CompanyName { set; get; }
        public string CustomerID { set; get; }
    }
}
//END - LookUps Class
