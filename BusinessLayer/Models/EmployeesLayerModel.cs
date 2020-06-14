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
    public class EmployeesBusinessModelLayers
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        string errResult = "";

        //BEGIN - readBy
        public EmployeesSingle GetEmployeesData(int EmployeeID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    EmployeesSingle employees = new EmployeesSingle();
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {

                        string sqlQuery = "SELECT * FROM [Employees] WHERE EmployeeID= " + EmployeeID.ToString();

                        using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                        {
                            con.Open();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {

                                //employees.EmployeeID = (int)rdr["EmployeeID"];
                                employees.EmployeeID = rdr["EmployeeID"] == DBNull.Value ? default(int) : (int)rdr["EmployeeID"];
                                //employees.LastName = (string)rdr["LastName"];
                                employees.LastName = rdr["LastName"] == DBNull.Value ? "" : (string)rdr["LastName"];

                                //employees.FirstName = (string)rdr["FirstName"];
                                employees.FirstName = rdr["FirstName"] == DBNull.Value ? "" : (string)rdr["FirstName"];

                                //employees.Title = (string)rdr["Title"];
                                employees.Title = rdr["Title"] == DBNull.Value ? "" : (string)rdr["Title"];

                                //employees.TitleOfCourtesy = (string)rdr["TitleOfCourtesy"];
                                employees.TitleOfCourtesy = rdr["TitleOfCourtesy"] == DBNull.Value ? "" : (string)rdr["TitleOfCourtesy"];


                                //employees.BirthDate = (System.DateTime?)rdr["BirthDate"];
                                employees.BirthDate = rdr["BirthDate"] == DBNull.Value ? default(DateTime) : (System.DateTime?)rdr["BirthDate"];

                                //employees.HireDate = (System.DateTime?)rdr["HireDate"];
                                employees.HireDate = rdr["HireDate"] == DBNull.Value ? default(DateTime) : (System.DateTime?)rdr["HireDate"];
                                //employees.Address = (string)rdr["Address"];
                                employees.Address = rdr["Address"] == DBNull.Value ? "" : (string)rdr["Address"];

                                //employees.City = (string)rdr["City"];
                                employees.City = rdr["City"] == DBNull.Value ? "" : (string)rdr["City"];

                                //employees.Region = (string)rdr["Region"];
                                employees.Region = rdr["Region"] == DBNull.Value ? "" : (string)rdr["Region"];

                                //employees.PostalCode = (string)rdr["PostalCode"];
                                employees.PostalCode = rdr["PostalCode"] == DBNull.Value ? "" : (string)rdr["PostalCode"];

                                //employees.Country = (string)rdr["Country"];
                                employees.Country = rdr["Country"] == DBNull.Value ? "" : (string)rdr["Country"];

                                //employees.HomePhone = (string)rdr["HomePhone"];
                                employees.HomePhone = rdr["HomePhone"] == DBNull.Value ? "" : (string)rdr["HomePhone"];

                                //employees.Extension = (string)rdr["Extension"];
                                employees.Extension = rdr["Extension"] == DBNull.Value ? "" : (string)rdr["Extension"];


                                //employees.Photo = (byte[])rdr["Photo"];
                                employees.Photo = rdr["Photo"] == DBNull.Value ? default(byte[]) : (byte[])rdr["Photo"];
                                //employees.Notes = (string)rdr["Notes"];
                                employees.Notes = rdr["Notes"] == DBNull.Value ? "" : (string)rdr["Notes"];


                                //employees.ReportsTo = (int?)rdr["ReportsTo"];
                                employees.ReportsTo = rdr["ReportsTo"] == DBNull.Value ? default(int?) : (int?)rdr["ReportsTo"];
                                //employees.PhotoPath = (string)rdr["PhotoPath"];
                                employees.PhotoPath = rdr["PhotoPath"] == DBNull.Value ? "" : (string)rdr["PhotoPath"];


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
                    return employees;
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
        public void AddEmployees(EmployeesSingle employees)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    BusinessLayer.Validation isdte = new BusinessLayer.Validation();
                    if (isdte.IsDate(employees.BirthDate) == false)
                    {
                        employees.BirthDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                    }

                    if (isdte.IsDate(employees.HireDate) == false)
                    {
                        employees.HireDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                    }


                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spAddEmployees", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        SqlParameter paramEmployeeID = new SqlParameter
                        {
                            ParameterName = "@EmployeeID",
                            Value = employees.EmployeeID
                        };
                        cmd.Parameters.Add(paramEmployeeID);

                        SqlParameter paramLastName = new SqlParameter
                        {
                            ParameterName = "@LastName",
                            Value = employees.LastName
                        };
                        cmd.Parameters.Add(paramLastName);

                        SqlParameter paramFirstName = new SqlParameter
                        {
                            ParameterName = "@FirstName",
                            Value = employees.FirstName
                        };
                        cmd.Parameters.Add(paramFirstName);

                        SqlParameter paramTitle = new SqlParameter
                        {
                            ParameterName = "@Title",
                            Value = employees.Title
                        };
                        cmd.Parameters.Add(paramTitle);

                        SqlParameter paramTitleOfCourtesy = new SqlParameter
                        {
                            ParameterName = "@TitleOfCourtesy",
                            Value = employees.TitleOfCourtesy
                        };
                        cmd.Parameters.Add(paramTitleOfCourtesy);

                        SqlParameter paramBirthDate = new SqlParameter
                        {
                            ParameterName = "@BirthDate",
                            Value = employees.BirthDate
                        };
                        cmd.Parameters.Add(paramBirthDate);

                        SqlParameter paramHireDate = new SqlParameter
                        {
                            ParameterName = "@HireDate",
                            Value = employees.HireDate
                        };
                        cmd.Parameters.Add(paramHireDate);

                        SqlParameter paramAddress = new SqlParameter
                        {
                            ParameterName = "@Address",
                            Value = employees.Address
                        };
                        cmd.Parameters.Add(paramAddress);

                        SqlParameter paramCity = new SqlParameter
                        {
                            ParameterName = "@City",
                            Value = employees.City
                        };
                        cmd.Parameters.Add(paramCity);

                        SqlParameter paramRegion = new SqlParameter
                        {
                            ParameterName = "@Region",
                            Value = employees.Region
                        };
                        cmd.Parameters.Add(paramRegion);

                        SqlParameter paramPostalCode = new SqlParameter
                        {
                            ParameterName = "@PostalCode",
                            Value = employees.PostalCode
                        };
                        cmd.Parameters.Add(paramPostalCode);

                        SqlParameter paramCountry = new SqlParameter
                        {
                            ParameterName = "@Country",
                            Value = employees.Country
                        };
                        cmd.Parameters.Add(paramCountry);

                        SqlParameter paramHomePhone = new SqlParameter
                        {
                            ParameterName = "@HomePhone",
                            Value = employees.HomePhone
                        };
                        cmd.Parameters.Add(paramHomePhone);

                        SqlParameter paramExtension = new SqlParameter
                        {
                            ParameterName = "@Extension",
                            Value = employees.Extension
                        };
                        cmd.Parameters.Add(paramExtension);

                        SqlParameter paramPhoto = new SqlParameter
                        {
                            ParameterName = "@Photo",
                            Value = employees.Photo
                        };
                        cmd.Parameters.Add(paramPhoto);

                        SqlParameter paramNotes = new SqlParameter
                        {
                            ParameterName = "@Notes",
                            Value = employees.Notes
                        };
                        cmd.Parameters.Add(paramNotes);

                        SqlParameter paramReportsTo = new SqlParameter
                        {
                            ParameterName = "@ReportsTo",
                            Value = employees.ReportsTo
                        };
                        cmd.Parameters.Add(paramReportsTo);

                        SqlParameter paramPhotoPath = new SqlParameter
                        {
                            ParameterName = "@PhotoPath",
                            Value = employees.PhotoPath
                        };
                        cmd.Parameters.Add(paramPhotoPath);

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
        public void UpdateEmployees(EmployeesSingle employees)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    BusinessLayer.Validation isdte = new BusinessLayer.Validation();
                    if (isdte.IsDate(employees.BirthDate) == false)
                    {
                        employees.BirthDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                    }

                    if (isdte.IsDate(employees.HireDate) == false)
                    {
                        employees.HireDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                    }

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spUpdateEmployees", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@EmployeeID", employees.EmployeeID);
                            cmd.Parameters.AddWithValue("@LastName", employees.LastName);
                            cmd.Parameters.AddWithValue("@FirstName", employees.FirstName);
                            cmd.Parameters.AddWithValue("@Title", (object)employees.Title ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@TitleOfCourtesy", (object)employees.TitleOfCourtesy ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@BirthDate", (object)employees.BirthDate ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@HireDate", (object)employees.HireDate ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Address", (object)employees.Address ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@City", (object)employees.City ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Region", (object)employees.Region ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@PostalCode", (object)employees.PostalCode ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Country", (object)employees.Country ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@HomePhone", (object)employees.HomePhone ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Extension", (object)employees.Extension ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Photo", (object)employees.Photo ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Notes", (object)employees.Notes ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@ReportsTo", (object)employees.ReportsTo ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@PhotoPath", (object)employees.PhotoPath ?? DBNull.Value);
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
        public void DeleteEmployees(int EmployeeID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spDeleteEmployees", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
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
        public List<EmployeesSingle> GetAllEmployeess()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<EmployeesSingle> employeess = new List<EmployeesSingle>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spGetAllEmployees", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            EmployeesSingle employees = new EmployeesSingle
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //EmployeeID = (int)rdr["EmployeeID"]
                                EmployeeID = rdr["EmployeeID"] == DBNull.Value ? default(int) : (int)rdr["EmployeeID"]
                                        //,LastName = (string)rdr["LastName"]
                                        ,
                                LastName = rdr["LastName"] == DBNull.Value ? "" : (string)rdr["LastName"]
                                        //,FirstName = (string)rdr["FirstName"]
                                        ,
                                FirstName = rdr["FirstName"] == DBNull.Value ? "" : (string)rdr["FirstName"]
                                        //,Title = (string)rdr["Title"]
                                        ,
                                Title = rdr["Title"] == DBNull.Value ? "" : (string)rdr["Title"]
                                        //,TitleOfCourtesy = (string)rdr["TitleOfCourtesy"]
                                        ,
                                TitleOfCourtesy = rdr["TitleOfCourtesy"] == DBNull.Value ? "" : (string)rdr["TitleOfCourtesy"]
                                    //,BirthDate = (System.DateTime?)rdr["BirthDate"]
                                    ,
                                BirthDate = rdr["BirthDate"] == DBNull.Value ? default(DateTime) : (System.DateTime?)rdr["BirthDate"]
                                    //,HireDate = (System.DateTime?)rdr["HireDate"]
                                    ,
                                HireDate = rdr["HireDate"] == DBNull.Value ? default(DateTime) : (System.DateTime?)rdr["HireDate"]
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
                                        //,HomePhone = (string)rdr["HomePhone"]
                                        ,
                                HomePhone = rdr["HomePhone"] == DBNull.Value ? "" : (string)rdr["HomePhone"]
                                        //,Extension = (string)rdr["Extension"]
                                        ,
                                Extension = rdr["Extension"] == DBNull.Value ? "" : (string)rdr["Extension"]
                                    //,Photo = (byte[])rdr["Photo"]
                                    ,
                                Photo = rdr["Photo"] == DBNull.Value ? default(byte[]) : (byte[])rdr["Photo"]
                                        //,Notes = (string)rdr["Notes"]
                                        ,
                                Notes = rdr["Notes"] == DBNull.Value ? "" : (string)rdr["Notes"]
                                    //,ReportsTo = (int?)rdr["ReportsTo"]
                                    ,
                                ReportsTo = rdr["ReportsTo"] == DBNull.Value ? default(int?) : (int?)rdr["ReportsTo"]
                                        //,PhotoPath = (string)rdr["PhotoPath"]
                                        ,
                                PhotoPath = rdr["PhotoPath"] == DBNull.Value ? "" : (string)rdr["PhotoPath"]
                            };
                            employeess.Add(employees);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return employeess;

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
        public List<Vwemployees> GetAllVwemployeess()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<Vwemployees> Vwemployeess = new List<Vwemployees>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Vwemployees", con);

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Vwemployees vwemployees = new Vwemployees
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //EmployeeID = (int)rdr["EmployeeID"]
                                EmployeeID = rdr["EmployeeID"] == DBNull.Value ? default(int) : (int)rdr["EmployeeID"]
                               //,LastName = (string)rdr["LastName"]
                               ,
                                LastName = rdr["LastName"] == DBNull.Value ? "" : (string)rdr["LastName"]
                               //,FirstName = (string)rdr["FirstName"]
                               ,
                                FirstName = rdr["FirstName"] == DBNull.Value ? "" : (string)rdr["FirstName"]
                               //,Title = (string)rdr["Title"]
                               ,
                                Title = rdr["Title"] == DBNull.Value ? "" : (string)rdr["Title"]
                               //,TitleOfCourtesy = (string)rdr["TitleOfCourtesy"]
                               ,
                                TitleOfCourtesy = rdr["TitleOfCourtesy"] == DBNull.Value ? "" : (string)rdr["TitleOfCourtesy"]
            //,BirthDate = (System.DateTime?)rdr["BirthDate"]
            ,
                                BirthDate = rdr["BirthDate"] == DBNull.Value ? default(DateTime) : (System.DateTime?)rdr["BirthDate"]
            //,HireDate = (System.DateTime?)rdr["HireDate"]
            ,
                                HireDate = rdr["HireDate"] == DBNull.Value ? default(DateTime) : (System.DateTime?)rdr["HireDate"]
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
                               //,HomePhone = (string)rdr["HomePhone"]
                               ,
                                HomePhone = rdr["HomePhone"] == DBNull.Value ? "" : (string)rdr["HomePhone"]
                               //,Extension = (string)rdr["Extension"]
                               ,
                                Extension = rdr["Extension"] == DBNull.Value ? "" : (string)rdr["Extension"]
            //,Photo = (byte[])rdr["Photo"]
            ,
                                Photo = rdr["Photo"] == DBNull.Value ? default(byte[]) : (byte[])rdr["Photo"]
                               //,Notes = (string)rdr["Notes"]
                               ,
                                Notes = rdr["Notes"] == DBNull.Value ? "" : (string)rdr["Notes"]
            //,ReportsTo = (int?)rdr["ReportsTo"]
            ,
                                ReportsTo = rdr["ReportsTo"] == DBNull.Value ? default(int?) : (int?)rdr["ReportsTo"]
                               //,PhotoPath = (string)rdr["PhotoPath"]
                               ,
                                PhotoPath = rdr["PhotoPath"] == DBNull.Value ? "" : (string)rdr["PhotoPath"]
                            };
                            Vwemployeess.Add(vwemployees);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return Vwemployeess;

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
        public string SelectedEmployees { get; set; }
        public List<EmployeesSelect> EmployeesSelect
        {
            get
            {
                var all = GetAllEmployeess()
                    .Select(a => new EmployeesSelect() { EmployeeID = a.EmployeeID, LastName = a.LastName.ToString(), LastNameIsSelected = false })
                    .ToList();
                List<EmployeesSelect> EmployeesSelect = new List<EmployeesSelect>();
                foreach (var a in all)
                {
                    EmployeesSelect.Add(new EmployeesSelect { LastName = a.LastName, EmployeeID = a.EmployeeID });
                }
                return EmployeesSelect;
            }
        }

        public IEnumerable<string> SelectedEmployeess { get; set; }

        public IEnumerable<SelectListItem> Employeess
        {
            get
            {
                List<SelectListItem> EmployeessSelectListItems = new List<SelectListItem>();

                foreach (EmployeesSingle employees in GetAllEmployeess().ToList())
                {
                    SelectListItem selectList = new SelectListItem()
                    {
                        Text = employees.LastName.ToString(),
                        Value = employees.EmployeeID.ToString(),
                        Selected = false
                    };
                    EmployeessSelectListItems.Add(selectList);
                }
                return EmployeessSelectListItems;
            }
        }


        //END - LookUps List
    }
    //BEGIN - LookUps Class

    //public class EmployeessViewModel
    //{
    //	public IEnumerable<string> SelectedEmployeess { get; set; }
    //	public IEnumerable<SelectListItem> Employeess { get; set; }
    //}

    public class EmployeesSelect
    {
        public bool LastNameIsSelected { set; get; }
        public string LastName { set; get; }
        public int EmployeeID { set; get; }
    }
}
//END - LookUps Class
