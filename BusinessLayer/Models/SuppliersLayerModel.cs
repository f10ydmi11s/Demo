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
    public class SuppliersBusinessModelLayers
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        string errResult = "";

        //BEGIN - readBy
        public SuppliersSingle GetSuppliersData(int SupplierID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    SuppliersSingle suppliers = new SuppliersSingle();
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {

                        string sqlQuery = "SELECT * FROM [Suppliers] WHERE SupplierID= " + SupplierID.ToString();

                        using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                        {
                            con.Open();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {

                                //suppliers.SupplierID = (int)rdr["SupplierID"];
                                suppliers.SupplierID = rdr["SupplierID"] == DBNull.Value ? default(int) : (int)rdr["SupplierID"];
                                //suppliers.CompanyName = (string)rdr["CompanyName"];
                                suppliers.CompanyName = rdr["CompanyName"] == DBNull.Value ? "" : (string)rdr["CompanyName"];

                                //suppliers.ContactName = (string)rdr["ContactName"];
                                suppliers.ContactName = rdr["ContactName"] == DBNull.Value ? "" : (string)rdr["ContactName"];

                                //suppliers.ContactTitle = (string)rdr["ContactTitle"];
                                suppliers.ContactTitle = rdr["ContactTitle"] == DBNull.Value ? "" : (string)rdr["ContactTitle"];

                                //suppliers.Address = (string)rdr["Address"];
                                suppliers.Address = rdr["Address"] == DBNull.Value ? "" : (string)rdr["Address"];

                                //suppliers.City = (string)rdr["City"];
                                suppliers.City = rdr["City"] == DBNull.Value ? "" : (string)rdr["City"];

                                //suppliers.Region = (string)rdr["Region"];
                                suppliers.Region = rdr["Region"] == DBNull.Value ? "" : (string)rdr["Region"];

                                //suppliers.PostalCode = (string)rdr["PostalCode"];
                                suppliers.PostalCode = rdr["PostalCode"] == DBNull.Value ? "" : (string)rdr["PostalCode"];

                                //suppliers.Country = (string)rdr["Country"];
                                suppliers.Country = rdr["Country"] == DBNull.Value ? "" : (string)rdr["Country"];

                                //suppliers.Phone = (string)rdr["Phone"];
                                suppliers.Phone = rdr["Phone"] == DBNull.Value ? "" : (string)rdr["Phone"];

                                //suppliers.Fax = (string)rdr["Fax"];
                                suppliers.Fax = rdr["Fax"] == DBNull.Value ? "" : (string)rdr["Fax"];

                                //suppliers.HomePage = (string)rdr["HomePage"];
                                suppliers.HomePage = rdr["HomePage"] == DBNull.Value ? "" : (string)rdr["HomePage"];


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
                    return suppliers;
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
        public void AddSuppliers(SuppliersSingle suppliers)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {




                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spAddSuppliers", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        SqlParameter paramSupplierID = new SqlParameter
                        {
                            ParameterName = "@SupplierID",
                            Value = suppliers.SupplierID
                        };
                        cmd.Parameters.Add(paramSupplierID);

                        SqlParameter paramCompanyName = new SqlParameter
                        {
                            ParameterName = "@CompanyName",
                            Value = suppliers.CompanyName
                        };
                        cmd.Parameters.Add(paramCompanyName);

                        SqlParameter paramContactName = new SqlParameter
                        {
                            ParameterName = "@ContactName",
                            Value = suppliers.ContactName
                        };
                        cmd.Parameters.Add(paramContactName);

                        SqlParameter paramContactTitle = new SqlParameter
                        {
                            ParameterName = "@ContactTitle",
                            Value = suppliers.ContactTitle
                        };
                        cmd.Parameters.Add(paramContactTitle);

                        SqlParameter paramAddress = new SqlParameter
                        {
                            ParameterName = "@Address",
                            Value = suppliers.Address
                        };
                        cmd.Parameters.Add(paramAddress);

                        SqlParameter paramCity = new SqlParameter
                        {
                            ParameterName = "@City",
                            Value = suppliers.City
                        };
                        cmd.Parameters.Add(paramCity);

                        SqlParameter paramRegion = new SqlParameter
                        {
                            ParameterName = "@Region",
                            Value = suppliers.Region
                        };
                        cmd.Parameters.Add(paramRegion);

                        SqlParameter paramPostalCode = new SqlParameter
                        {
                            ParameterName = "@PostalCode",
                            Value = suppliers.PostalCode
                        };
                        cmd.Parameters.Add(paramPostalCode);

                        SqlParameter paramCountry = new SqlParameter
                        {
                            ParameterName = "@Country",
                            Value = suppliers.Country
                        };
                        cmd.Parameters.Add(paramCountry);

                        SqlParameter paramPhone = new SqlParameter
                        {
                            ParameterName = "@Phone",
                            Value = suppliers.Phone
                        };
                        cmd.Parameters.Add(paramPhone);

                        SqlParameter paramFax = new SqlParameter
                        {
                            ParameterName = "@Fax",
                            Value = suppliers.Fax
                        };
                        cmd.Parameters.Add(paramFax);

                        SqlParameter paramHomePage = new SqlParameter
                        {
                            ParameterName = "@HomePage",
                            Value = suppliers.HomePage
                        };
                        cmd.Parameters.Add(paramHomePage);

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
        public void UpdateSuppliers(SuppliersSingle suppliers)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spUpdateSuppliers", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@SupplierID", suppliers.SupplierID);
                            cmd.Parameters.AddWithValue("@CompanyName", suppliers.CompanyName);
                            cmd.Parameters.AddWithValue("@ContactName", (object)suppliers.ContactName ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@ContactTitle", (object)suppliers.ContactTitle ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Address", (object)suppliers.Address ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@City", (object)suppliers.City ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Region", (object)suppliers.Region ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@PostalCode", (object)suppliers.PostalCode ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Country", (object)suppliers.Country ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Phone", (object)suppliers.Phone ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Fax", (object)suppliers.Fax ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@HomePage", (object)suppliers.HomePage ?? DBNull.Value);
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
        public void DeleteSuppliers(int SupplierID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spDeleteSuppliers", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@SupplierID", SupplierID);
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
        public List<SuppliersSingle> GetAllSupplierss()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<SuppliersSingle> supplierss = new List<SuppliersSingle>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spGetAllSuppliers", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            SuppliersSingle suppliers = new SuppliersSingle
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //SupplierID = (int)rdr["SupplierID"]
                                SupplierID = rdr["SupplierID"] == DBNull.Value ? default(int) : (int)rdr["SupplierID"]
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
                                        //,HomePage = (string)rdr["HomePage"]
                                        ,
                                HomePage = rdr["HomePage"] == DBNull.Value ? "" : (string)rdr["HomePage"]
                            };
                            supplierss.Add(suppliers);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return supplierss;

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
        public List<Vwsuppliers> GetAllVwsupplierss()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<Vwsuppliers> Vwsupplierss = new List<Vwsuppliers>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Vwsuppliers", con);

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Vwsuppliers vwsuppliers = new Vwsuppliers
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //SupplierID = (int)rdr["SupplierID"]
                                SupplierID = rdr["SupplierID"] == DBNull.Value ? default(int) : (int)rdr["SupplierID"]
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
                               //,HomePage = (string)rdr["HomePage"]
                               ,
                                HomePage = rdr["HomePage"] == DBNull.Value ? "" : (string)rdr["HomePage"]
                            };
                            Vwsupplierss.Add(vwsuppliers);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return Vwsupplierss;

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
        public string SelectedSuppliers { get; set; }
        public List<SuppliersSelect> SuppliersSelect
        {
            get
            {
                var all = GetAllSupplierss()
                    .Select(a => new SuppliersSelect() { SupplierID = a.SupplierID, CompanyName = a.CompanyName.ToString(), CompanyNameIsSelected = false })
                    .ToList();
                List<SuppliersSelect> SuppliersSelect = new List<SuppliersSelect>();
                foreach (var a in all)
                {
                    SuppliersSelect.Add(new SuppliersSelect { CompanyName = a.CompanyName, SupplierID = a.SupplierID });
                }
                return SuppliersSelect;
            }
        }

        public IEnumerable<string> SelectedSupplierss { get; set; }

        public IEnumerable<SelectListItem> Supplierss
        {
            get
            {
                List<SelectListItem> SupplierssSelectListItems = new List<SelectListItem>();

                foreach (SuppliersSingle suppliers in GetAllSupplierss().ToList())
                {
                    SelectListItem selectList = new SelectListItem()
                    {
                        Text = suppliers.CompanyName.ToString(),
                        Value = suppliers.SupplierID.ToString(),
                        Selected = false
                    };
                    SupplierssSelectListItems.Add(selectList);
                }
                return SupplierssSelectListItems;
            }
        }


        //END - LookUps List
    }
    //BEGIN - LookUps Class

    //public class SupplierssViewModel
    //{
    //	public IEnumerable<string> SelectedSupplierss { get; set; }
    //	public IEnumerable<SelectListItem> Supplierss { get; set; }
    //}

    public class SuppliersSelect
    {
        public bool CompanyNameIsSelected { set; get; }
        public string CompanyName { set; get; }
        public int SupplierID { set; get; }
    }
}
//END - LookUps Class
