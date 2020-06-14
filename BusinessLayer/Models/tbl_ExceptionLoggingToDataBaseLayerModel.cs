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
    public class Tbl_ExceptionloggingtodatabaseBusinessModelLayers
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        string errResult = "";

        //BEGIN - readBy
        public Tbl_ExceptionloggingtodatabaseSingle GetTbl_ExceptionloggingtodatabaseData(long Logid)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    Tbl_ExceptionloggingtodatabaseSingle tbl_exceptionloggingtodatabase = new Tbl_ExceptionloggingtodatabaseSingle();
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {

                        string sqlQuery = "SELECT * FROM [tbl_ExceptionLoggingToDataBase] WHERE Logid= " + Logid.ToString();

                        using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                        {
                            con.Open();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {

                                //tbl_exceptionloggingtodatabase.Logid = (long)rdr["Logid"];
                                tbl_exceptionloggingtodatabase.Logid = rdr["Logid"] == DBNull.Value ? default(long) : (long)rdr["Logid"];
                                //tbl_exceptionloggingtodatabase.ExceptionMsg = (string)rdr["ExceptionMsg"];
                                tbl_exceptionloggingtodatabase.ExceptionMsg = rdr["ExceptionMsg"] == DBNull.Value ? "" : (string)rdr["ExceptionMsg"];

                                //tbl_exceptionloggingtodatabase.ExceptionType = (string)rdr["ExceptionType"];
                                tbl_exceptionloggingtodatabase.ExceptionType = rdr["ExceptionType"] == DBNull.Value ? "" : (string)rdr["ExceptionType"];

                                //tbl_exceptionloggingtodatabase.ExceptionSource = (string)rdr["ExceptionSource"];
                                tbl_exceptionloggingtodatabase.ExceptionSource = rdr["ExceptionSource"] == DBNull.Value ? "" : (string)rdr["ExceptionSource"];

                                //tbl_exceptionloggingtodatabase.ExceptionURL = (string)rdr["ExceptionURL"];
                                tbl_exceptionloggingtodatabase.ExceptionURL = rdr["ExceptionURL"] == DBNull.Value ? "" : (string)rdr["ExceptionURL"];


                                //tbl_exceptionloggingtodatabase.Logdate = (System.DateTime?)rdr["Logdate"];
                                tbl_exceptionloggingtodatabase.Logdate = rdr["Logdate"] == DBNull.Value ? default(DateTime) : (System.DateTime?)rdr["Logdate"];

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
                    return tbl_exceptionloggingtodatabase;
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
        public void AddTbl_Exceptionloggingtodatabase(Tbl_ExceptionloggingtodatabaseSingle tbl_exceptionloggingtodatabase)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    BusinessLayer.Validation isdte = new BusinessLayer.Validation();
                    if (isdte.IsDate(tbl_exceptionloggingtodatabase.Logdate) == false)
                    {
                        tbl_exceptionloggingtodatabase.Logdate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                    }


                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spAddTbl_Exceptionloggingtodatabase", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        SqlParameter paramLogid = new SqlParameter
                        {
                            ParameterName = "@Logid",
                            Value = tbl_exceptionloggingtodatabase.Logid
                        };
                        cmd.Parameters.Add(paramLogid);

                        SqlParameter paramExceptionMsg = new SqlParameter
                        {
                            ParameterName = "@ExceptionMsg",
                            Value = tbl_exceptionloggingtodatabase.ExceptionMsg
                        };
                        cmd.Parameters.Add(paramExceptionMsg);

                        SqlParameter paramExceptionType = new SqlParameter
                        {
                            ParameterName = "@ExceptionType",
                            Value = tbl_exceptionloggingtodatabase.ExceptionType
                        };
                        cmd.Parameters.Add(paramExceptionType);

                        SqlParameter paramExceptionSource = new SqlParameter
                        {
                            ParameterName = "@ExceptionSource",
                            Value = tbl_exceptionloggingtodatabase.ExceptionSource
                        };
                        cmd.Parameters.Add(paramExceptionSource);

                        SqlParameter paramExceptionURL = new SqlParameter
                        {
                            ParameterName = "@ExceptionURL",
                            Value = tbl_exceptionloggingtodatabase.ExceptionURL
                        };
                        cmd.Parameters.Add(paramExceptionURL);

                        SqlParameter paramLogdate = new SqlParameter
                        {
                            ParameterName = "@Logdate",
                            Value = tbl_exceptionloggingtodatabase.Logdate
                        };
                        cmd.Parameters.Add(paramLogdate);

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
        public void UpdateTbl_Exceptionloggingtodatabase(Tbl_ExceptionloggingtodatabaseSingle tbl_exceptionloggingtodatabase)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    BusinessLayer.Validation isdte = new BusinessLayer.Validation();
                    if (isdte.IsDate(tbl_exceptionloggingtodatabase.Logdate) == false)
                    {
                        tbl_exceptionloggingtodatabase.Logdate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                    }

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spUpdateTbl_Exceptionloggingtodatabase", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@Logid", tbl_exceptionloggingtodatabase.Logid);
                            cmd.Parameters.AddWithValue("@ExceptionMsg", (object)tbl_exceptionloggingtodatabase.ExceptionMsg ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@ExceptionType", (object)tbl_exceptionloggingtodatabase.ExceptionType ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@ExceptionSource", (object)tbl_exceptionloggingtodatabase.ExceptionSource ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@ExceptionURL", (object)tbl_exceptionloggingtodatabase.ExceptionURL ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Logdate", (object)tbl_exceptionloggingtodatabase.Logdate ?? DBNull.Value);
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
        public void DeleteTbl_Exceptionloggingtodatabase(long Logid)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spDeleteTbl_Exceptionloggingtodatabase", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@Logid", Logid);
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
        public List<Tbl_ExceptionloggingtodatabaseSingle> GetAllTbl_Exceptionloggingtodatabases()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<Tbl_ExceptionloggingtodatabaseSingle> tbl_exceptionloggingtodatabases = new List<Tbl_ExceptionloggingtodatabaseSingle>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spGetAllTbl_Exceptionloggingtodatabase", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Tbl_ExceptionloggingtodatabaseSingle tbl_exceptionloggingtodatabase = new Tbl_ExceptionloggingtodatabaseSingle
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //Logid = (long)rdr["Logid"]
                                Logid = rdr["Logid"] == DBNull.Value ? default(long) : (long)rdr["Logid"]
                                        //,ExceptionMsg = (string)rdr["ExceptionMsg"]
                                        ,
                                ExceptionMsg = rdr["ExceptionMsg"] == DBNull.Value ? "" : (string)rdr["ExceptionMsg"]
                                        //,ExceptionType = (string)rdr["ExceptionType"]
                                        ,
                                ExceptionType = rdr["ExceptionType"] == DBNull.Value ? "" : (string)rdr["ExceptionType"]
                                        //,ExceptionSource = (string)rdr["ExceptionSource"]
                                        ,
                                ExceptionSource = rdr["ExceptionSource"] == DBNull.Value ? "" : (string)rdr["ExceptionSource"]
                                        //,ExceptionURL = (string)rdr["ExceptionURL"]
                                        ,
                                ExceptionURL = rdr["ExceptionURL"] == DBNull.Value ? "" : (string)rdr["ExceptionURL"]
                                    //,Logdate = (System.DateTime?)rdr["Logdate"]
                                    ,
                                Logdate = rdr["Logdate"] == DBNull.Value ? default(DateTime) : (System.DateTime?)rdr["Logdate"]
                            };
                            tbl_exceptionloggingtodatabases.Add(tbl_exceptionloggingtodatabase);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return tbl_exceptionloggingtodatabases;

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
        public List<Vwtbl_exceptionloggingtodatabase> GetAllVwtbl_exceptionloggingtodatabases()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<Vwtbl_exceptionloggingtodatabase> Vwtbl_Exceptionloggingtodatabases = new List<Vwtbl_exceptionloggingtodatabase>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Vwtbl_Exceptionloggingtodatabase", con);

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Vwtbl_exceptionloggingtodatabase vwtbl_exceptionloggingtodatabase = new Vwtbl_exceptionloggingtodatabase
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //Logid = (long)rdr["Logid"]
                                Logid = rdr["Logid"] == DBNull.Value ? default(long) : (long)rdr["Logid"]
                               //,ExceptionMsg = (string)rdr["ExceptionMsg"]
                               ,
                                ExceptionMsg = rdr["ExceptionMsg"] == DBNull.Value ? "" : (string)rdr["ExceptionMsg"]
                               //,ExceptionType = (string)rdr["ExceptionType"]
                               ,
                                ExceptionType = rdr["ExceptionType"] == DBNull.Value ? "" : (string)rdr["ExceptionType"]
                               //,ExceptionSource = (string)rdr["ExceptionSource"]
                               ,
                                ExceptionSource = rdr["ExceptionSource"] == DBNull.Value ? "" : (string)rdr["ExceptionSource"]
                               //,ExceptionURL = (string)rdr["ExceptionURL"]
                               ,
                                ExceptionURL = rdr["ExceptionURL"] == DBNull.Value ? "" : (string)rdr["ExceptionURL"]
            //,Logdate = (System.DateTime?)rdr["Logdate"]
            ,
                                Logdate = rdr["Logdate"] == DBNull.Value ? default(DateTime) : (System.DateTime?)rdr["Logdate"]
                            };
                            Vwtbl_Exceptionloggingtodatabases.Add(vwtbl_exceptionloggingtodatabase);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return Vwtbl_Exceptionloggingtodatabases;

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
        public string SelectedTbl_Exceptionloggingtodatabase { get; set; }
        public List<Tbl_ExceptionloggingtodatabaseSelect> Tbl_ExceptionloggingtodatabaseSelect
        {
            get
            {
                var all = GetAllTbl_Exceptionloggingtodatabases()
                    .Select(a => new Tbl_ExceptionloggingtodatabaseSelect() { Logid = a.Logid, ExceptionMsg = a.ExceptionMsg.ToString(), ExceptionMsgIsSelected = false })
                    .ToList();
                List<Tbl_ExceptionloggingtodatabaseSelect> Tbl_ExceptionloggingtodatabaseSelect = new List<Tbl_ExceptionloggingtodatabaseSelect>();
                foreach (var a in all)
                {
                    Tbl_ExceptionloggingtodatabaseSelect.Add(new Tbl_ExceptionloggingtodatabaseSelect { ExceptionMsg = a.ExceptionMsg, Logid = a.Logid });
                }
                return Tbl_ExceptionloggingtodatabaseSelect;
            }
        }

        public IEnumerable<string> SelectedTbl_Exceptionloggingtodatabases { get; set; }

        public IEnumerable<SelectListItem> Tbl_Exceptionloggingtodatabases
        {
            get
            {
                List<SelectListItem> Tbl_ExceptionloggingtodatabasesSelectListItems = new List<SelectListItem>();

                foreach (Tbl_ExceptionloggingtodatabaseSingle tbl_exceptionloggingtodatabase in GetAllTbl_Exceptionloggingtodatabases().ToList())
                {
                    SelectListItem selectList = new SelectListItem()
                    {
                        Text = tbl_exceptionloggingtodatabase.ExceptionMsg.ToString(),
                        Value = tbl_exceptionloggingtodatabase.Logid.ToString(),
                        Selected = false
                    };
                    Tbl_ExceptionloggingtodatabasesSelectListItems.Add(selectList);
                }
                return Tbl_ExceptionloggingtodatabasesSelectListItems;
            }
        }


        //END - LookUps List
    }
    //BEGIN - LookUps Class

    //public class Tbl_ExceptionloggingtodatabasesViewModel
    //{
    //	public IEnumerable<string> SelectedTbl_Exceptionloggingtodatabases { get; set; }
    //	public IEnumerable<SelectListItem> Tbl_Exceptionloggingtodatabases { get; set; }
    //}

    public class Tbl_ExceptionloggingtodatabaseSelect
    {
        public bool ExceptionMsgIsSelected { set; get; }
        public string ExceptionMsg { set; get; }
        public long Logid { set; get; }
    }
}
//END - LookUps Class
