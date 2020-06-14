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
    public class Tbl_LoginBusinessModelLayers
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        string errResult = "";

        //BEGIN - readBy
        public Tbl_LoginSingle GetTbl_LoginData(string Username)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    Tbl_LoginSingle tbl_login = new Tbl_LoginSingle();
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string sqlQuery = "SELECT * FROM [tbl_Login] WHERE Username= '" + Username.ToString() + "'";

                        using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                        {
                            con.Open();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                //tbl_login.Username = (string)rdr["Username"];
                                tbl_login.Username = rdr["Username"] == DBNull.Value ? "" : (string)rdr["Username"];

                                //tbl_login.Password = (string)rdr["Password"];
                                tbl_login.Password = rdr["Password"] == DBNull.Value ? "" : (string)rdr["Password"];

                                //tbl_login.Roles = (string)rdr["Roles"];
                                tbl_login.Roles = rdr["Roles"] == DBNull.Value ? "" : (string)rdr["Roles"];


                                //tbl_login.ActiveStatus = (bool)rdr["ActiveStatus"];
                                tbl_login.ActiveStatus = rdr["ActiveStatus"] == DBNull.Value ? false : (bool)rdr["ActiveStatus"];

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
                    return tbl_login;
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
        public void AddTbl_Login(Tbl_LoginSingle tbl_login)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {




                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spAddTbl_Login", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        SqlParameter paramUsername = new SqlParameter
                        {
                            ParameterName = "@Username",
                            Value = tbl_login.Username
                        };
                        cmd.Parameters.Add(paramUsername);

                        SqlParameter paramPassword = new SqlParameter
                        {
                            ParameterName = "@Password",
                            Value = tbl_login.Password
                        };
                        cmd.Parameters.Add(paramPassword);

                        SqlParameter paramRoles = new SqlParameter
                        {
                            ParameterName = "@Roles",
                            Value = tbl_login.Roles
                        };
                        cmd.Parameters.Add(paramRoles);

                        SqlParameter paramActiveStatus = new SqlParameter
                        {
                            ParameterName = "@ActiveStatus",
                            Value = tbl_login.ActiveStatus
                        };
                        cmd.Parameters.Add(paramActiveStatus);

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
        public void UpdateTbl_Login(Tbl_LoginSingle tbl_login)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spUpdateTbl_Login", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@Username", tbl_login.Username);
                            cmd.Parameters.AddWithValue("@Password", tbl_login.Password);
                            cmd.Parameters.AddWithValue("@Roles", tbl_login.Roles);
                            cmd.Parameters.AddWithValue("@ActiveStatus", tbl_login.ActiveStatus);
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
        public void DeleteTbl_Login(string Username)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spDeleteTbl_Login", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@Username", Username);
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
        public List<Tbl_LoginSingle> GetAllTbl_Logins()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<Tbl_LoginSingle> tbl_logins = new List<Tbl_LoginSingle>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spGetAllTbl_Login", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Tbl_LoginSingle tbl_login = new Tbl_LoginSingle
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //Username = (string)rdr["Username"]
                                Username = rdr["Username"] == DBNull.Value ? "" : (string)rdr["Username"]
                                        //,Password = (string)rdr["Password"]
                                        ,
                                Password = rdr["Password"] == DBNull.Value ? "" : (string)rdr["Password"]
                                        //,Roles = (string)rdr["Roles"]
                                        ,
                                Roles = rdr["Roles"] == DBNull.Value ? "" : (string)rdr["Roles"]

                                    //,ActiveStatus = (bool)rdr["ActiveStatus"]
                                    ,
                                ActiveStatus = rdr["ActiveStatus"] == DBNull.Value ? false : (bool)rdr["ActiveStatus"]
                            };
                            tbl_logins.Add(tbl_login);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return tbl_logins;

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
        public List<Vwtbl_login> GetAllVwtbl_logins()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<Vwtbl_login> Vwtbl_Logins = new List<Vwtbl_login>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Vwtbl_Login", con);

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Vwtbl_login vwtbl_login = new Vwtbl_login
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //Username = (string)rdr["Username"]
                                Username = rdr["Username"] == DBNull.Value ? "" : (string)rdr["Username"]
                               //,Password = (string)rdr["Password"]
                               ,
                                Password = rdr["Password"] == DBNull.Value ? "" : (string)rdr["Password"]
                               //,Roles = (string)rdr["Roles"]
                               ,
                                Roles = rdr["Roles"] == DBNull.Value ? "" : (string)rdr["Roles"]
            //,ActiveStatus = (bool)rdr["ActiveStatus"]
            ,
                                ActiveStatus = rdr["ActiveStatus"] == DBNull.Value ? false : (bool)rdr["ActiveStatus"]
                            };
                            Vwtbl_Logins.Add(vwtbl_login);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return Vwtbl_Logins;

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
        public string SelectedTbl_Login { get; set; }
        public List<Tbl_LoginSelect> Tbl_LoginSelect
        {
            get
            {
                var all = GetAllTbl_Logins()
                    .Select(a => new Tbl_LoginSelect() { Username = a.Username, Password = a.Password.ToString(), PasswordIsSelected = false })
                    .ToList();
                List<Tbl_LoginSelect> Tbl_LoginSelect = new List<Tbl_LoginSelect>();
                foreach (var a in all)
                {
                    Tbl_LoginSelect.Add(new Tbl_LoginSelect { Password = a.Password, Username = a.Username });
                }
                return Tbl_LoginSelect;
            }
        }

        public IEnumerable<string> SelectedTbl_Logins { get; set; }

        public IEnumerable<SelectListItem> Tbl_Logins
        {
            get
            {
                List<SelectListItem> Tbl_LoginsSelectListItems = new List<SelectListItem>();

                foreach (Tbl_LoginSingle tbl_login in GetAllTbl_Logins().ToList())
                {
                    SelectListItem selectList = new SelectListItem()
                    {
                        Text = tbl_login.Password.ToString(),
                        Value = tbl_login.Username.ToString(),
                        Selected = false
                    };
                    Tbl_LoginsSelectListItems.Add(selectList);
                }
                return Tbl_LoginsSelectListItems;
            }
        }


        //END - LookUps List
    }
    //BEGIN - LookUps Class

    //public class Tbl_LoginsViewModel
    //{
    //	public IEnumerable<string> SelectedTbl_Logins { get; set; }
    //	public IEnumerable<SelectListItem> Tbl_Logins { get; set; }
    //}

    public class Tbl_LoginSelect
    {
        public bool PasswordIsSelected { set; get; }
        public string Password { set; get; }
        public string Username { set; get; }
    }
}
//END - LookUps Class
