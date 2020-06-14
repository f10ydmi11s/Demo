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
    public class EmployeeterritoriesBusinessModelLayers
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        string errResult = "";

        //BEGIN - readBy
        public EmployeeterritoriesSingle GetEmployeeterritoriesData(int EmployeeID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    EmployeeterritoriesSingle employeeterritories = new EmployeeterritoriesSingle();
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {

                        string sqlQuery = "SELECT * FROM [EmployeeTerritories] WHERE EmployeeID= " + EmployeeID.ToString();

                        using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                        {
                            con.Open();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {

                                //employeeterritories.EmployeeID = (int)rdr["EmployeeID"];
                                employeeterritories.EmployeeID = rdr["EmployeeID"] == DBNull.Value ? default(int) : (int)rdr["EmployeeID"];
                                //employeeterritories.TerritoryID = (string)rdr["TerritoryID"];
                                employeeterritories.TerritoryID = rdr["TerritoryID"] == DBNull.Value ? "" : (string)rdr["TerritoryID"];


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
                    return employeeterritories;
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
        public void AddEmployeeterritories(EmployeeterritoriesSingle employeeterritories)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {




                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spAddEmployeeterritories", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        SqlParameter paramEmployeeID = new SqlParameter
                        {
                            ParameterName = "@EmployeeID",
                            Value = employeeterritories.EmployeeID
                        };
                        cmd.Parameters.Add(paramEmployeeID);

                        SqlParameter paramTerritoryID = new SqlParameter
                        {
                            ParameterName = "@TerritoryID",
                            Value = employeeterritories.TerritoryID
                        };
                        cmd.Parameters.Add(paramTerritoryID);

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
        public void UpdateEmployeeterritories(EmployeeterritoriesSingle employeeterritories)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spUpdateEmployeeterritories", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@EmployeeID", employeeterritories.EmployeeID);
                            cmd.Parameters.AddWithValue("@TerritoryID", employeeterritories.TerritoryID);
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
        public void DeleteEmployeeterritories(int EmployeeID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spDeleteEmployeeterritories", con)
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
        public List<EmployeeterritoriesSingle> GetAllEmployeeterritoriess()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<EmployeeterritoriesSingle> employeeterritoriess = new List<EmployeeterritoriesSingle>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spGetAllEmployeeterritories", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            EmployeeterritoriesSingle employeeterritories = new EmployeeterritoriesSingle
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //EmployeeID = (int)rdr["EmployeeID"]
                                EmployeeID = rdr["EmployeeID"] == DBNull.Value ? default(int) : (int)rdr["EmployeeID"]
                                        //,TerritoryID = (string)rdr["TerritoryID"]
                                        ,
                                TerritoryID = rdr["TerritoryID"] == DBNull.Value ? "" : (string)rdr["TerritoryID"]
                            };
                            employeeterritoriess.Add(employeeterritories);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return employeeterritoriess;

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
        public List<Vwemployeeterritories> GetAllVwemployeeterritoriess()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<Vwemployeeterritories> Vwemployeeterritoriess = new List<Vwemployeeterritories>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Vwemployeeterritories", con);

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Vwemployeeterritories vwemployeeterritories = new Vwemployeeterritories
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //EmployeeID = (int)rdr["EmployeeID"]
                                EmployeeID = rdr["EmployeeID"] == DBNull.Value ? default(int) : (int)rdr["EmployeeID"]
                               //,TerritoryID = (string)rdr["TerritoryID"]
                               ,
                                TerritoryID = rdr["TerritoryID"] == DBNull.Value ? "" : (string)rdr["TerritoryID"]
                            };
                            Vwemployeeterritoriess.Add(vwemployeeterritories);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return Vwemployeeterritoriess;

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
        public string SelectedEmployeeterritories { get; set; }
        public List<EmployeeterritoriesSelect> EmployeeterritoriesSelect
        {
            get
            {
                var all = GetAllEmployeeterritoriess()
                    .Select(a => new EmployeeterritoriesSelect() { EmployeeID = a.EmployeeID, TerritoryID = a.TerritoryID.ToString(), TerritoryIDIsSelected = false })
                    .ToList();
                List<EmployeeterritoriesSelect> EmployeeterritoriesSelect = new List<EmployeeterritoriesSelect>();
                foreach (var a in all)
                {
                    EmployeeterritoriesSelect.Add(new EmployeeterritoriesSelect { TerritoryID = a.TerritoryID, EmployeeID = a.EmployeeID });
                }
                return EmployeeterritoriesSelect;
            }
        }

        public IEnumerable<string> SelectedEmployeeterritoriess { get; set; }

        public IEnumerable<SelectListItem> Employeeterritoriess
        {
            get
            {
                List<SelectListItem> EmployeeterritoriessSelectListItems = new List<SelectListItem>();

                foreach (EmployeeterritoriesSingle employeeterritories in GetAllEmployeeterritoriess().ToList())
                {
                    SelectListItem selectList = new SelectListItem()
                    {
                        Text = employeeterritories.TerritoryID.ToString(),
                        Value = employeeterritories.EmployeeID.ToString(),
                        Selected = false
                    };
                    EmployeeterritoriessSelectListItems.Add(selectList);
                }
                return EmployeeterritoriessSelectListItems;
            }
        }


        //END - LookUps List
    }
    //BEGIN - LookUps Class

    //public class EmployeeterritoriessViewModel
    //{
    //	public IEnumerable<string> SelectedEmployeeterritoriess { get; set; }
    //	public IEnumerable<SelectListItem> Employeeterritoriess { get; set; }
    //}

    public class EmployeeterritoriesSelect
    {
        public bool TerritoryIDIsSelected { set; get; }
        public string TerritoryID { set; get; }
        public int EmployeeID { set; get; }
    }
}
//END - LookUps Class
