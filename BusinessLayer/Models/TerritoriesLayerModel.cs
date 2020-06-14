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
    public class TerritoriesBusinessModelLayers
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        string errResult = "";

        //BEGIN - readBy
        public TerritoriesSingle GetTerritoriesData(string TerritoryID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    TerritoriesSingle territories = new TerritoriesSingle();
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string sqlQuery = "SELECT * FROM [Territories] WHERE TerritoryID= '" + TerritoryID.ToString() + "'";

                        using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                        {
                            con.Open();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                //territories.TerritoryID = (string)rdr["TerritoryID"];
                                territories.TerritoryID = rdr["TerritoryID"] == DBNull.Value ? "" : (string)rdr["TerritoryID"];

                                //territories.TerritoryDescription = (string)rdr["TerritoryDescription"];
                                territories.TerritoryDescription = rdr["TerritoryDescription"] == DBNull.Value ? "" : (string)rdr["TerritoryDescription"];


                                //territories.RegionID = (int)rdr["RegionID"];
                                territories.RegionID = rdr["RegionID"] == DBNull.Value ? default(int) : (int)rdr["RegionID"];

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
                    return territories;
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
        public void AddTerritories(TerritoriesSingle territories)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {




                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spAddTerritories", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        SqlParameter paramTerritoryID = new SqlParameter
                        {
                            ParameterName = "@TerritoryID",
                            Value = territories.TerritoryID
                        };
                        cmd.Parameters.Add(paramTerritoryID);

                        SqlParameter paramTerritoryDescription = new SqlParameter
                        {
                            ParameterName = "@TerritoryDescription",
                            Value = territories.TerritoryDescription
                        };
                        cmd.Parameters.Add(paramTerritoryDescription);

                        SqlParameter paramRegionID = new SqlParameter
                        {
                            ParameterName = "@RegionID",
                            Value = territories.RegionID
                        };
                        cmd.Parameters.Add(paramRegionID);

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
        public void UpdateTerritories(TerritoriesSingle territories)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spUpdateTerritories", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@TerritoryID", territories.TerritoryID);
                            cmd.Parameters.AddWithValue("@TerritoryDescription", territories.TerritoryDescription);
                            cmd.Parameters.AddWithValue("@RegionID", territories.RegionID);
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
        public void DeleteTerritories(string TerritoryID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spDeleteTerritories", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@TerritoryID", TerritoryID);
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
        public List<TerritoriesSingle> GetAllTerritoriess()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<TerritoriesSingle> territoriess = new List<TerritoriesSingle>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spGetAllTerritories", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            TerritoriesSingle territories = new TerritoriesSingle
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //TerritoryID = (string)rdr["TerritoryID"]
                                TerritoryID = rdr["TerritoryID"] == DBNull.Value ? "" : (string)rdr["TerritoryID"]
                                        //,TerritoryDescription = (string)rdr["TerritoryDescription"]
                                        ,
                                TerritoryDescription = rdr["TerritoryDescription"] == DBNull.Value ? "" : (string)rdr["TerritoryDescription"]
                                    //,RegionID = (int)rdr["RegionID"]
                                    ,
                                RegionID = rdr["RegionID"] == DBNull.Value ? default(int) : (int)rdr["RegionID"]
                            };
                            territoriess.Add(territories);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return territoriess;

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
        public List<Vwterritories> GetAllVwterritoriess()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<Vwterritories> Vwterritoriess = new List<Vwterritories>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Vwterritories", con);

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Vwterritories vwterritories = new Vwterritories
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //TerritoryID = (string)rdr["TerritoryID"]
                                TerritoryID = rdr["TerritoryID"] == DBNull.Value ? "" : (string)rdr["TerritoryID"]
                               //,TerritoryDescription = (string)rdr["TerritoryDescription"]
                               ,
                                TerritoryDescription = rdr["TerritoryDescription"] == DBNull.Value ? "" : (string)rdr["TerritoryDescription"]
            //,RegionID = (int)rdr["RegionID"]
            ,
                                RegionID = rdr["RegionID"] == DBNull.Value ? default(int) : (int)rdr["RegionID"]
                            };
                            Vwterritoriess.Add(vwterritories);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return Vwterritoriess;

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
        public string SelectedTerritories { get; set; }
        public List<TerritoriesSelect> TerritoriesSelect
        {
            get
            {
                var all = GetAllTerritoriess()
                    .Select(a => new TerritoriesSelect() { TerritoryID = a.TerritoryID, TerritoryDescription = a.TerritoryDescription.ToString(), TerritoryDescriptionIsSelected = false })
                    .ToList();
                List<TerritoriesSelect> TerritoriesSelect = new List<TerritoriesSelect>();
                foreach (var a in all)
                {
                    TerritoriesSelect.Add(new TerritoriesSelect { TerritoryDescription = a.TerritoryDescription, TerritoryID = a.TerritoryID });
                }
                return TerritoriesSelect;
            }
        }

        public IEnumerable<string> SelectedTerritoriess { get; set; }

        public IEnumerable<SelectListItem> Territoriess
        {
            get
            {
                List<SelectListItem> TerritoriessSelectListItems = new List<SelectListItem>();

                foreach (TerritoriesSingle territories in GetAllTerritoriess().ToList())
                {
                    SelectListItem selectList = new SelectListItem()
                    {
                        Text = territories.TerritoryDescription.ToString(),
                        Value = territories.TerritoryID.ToString(),
                        Selected = false
                    };
                    TerritoriessSelectListItems.Add(selectList);
                }
                return TerritoriessSelectListItems;
            }
        }


        //END - LookUps List
    }
    //BEGIN - LookUps Class

    //public class TerritoriessViewModel
    //{
    //	public IEnumerable<string> SelectedTerritoriess { get; set; }
    //	public IEnumerable<SelectListItem> Territoriess { get; set; }
    //}

    public class TerritoriesSelect
    {
        public bool TerritoryDescriptionIsSelected { set; get; }
        public string TerritoryDescription { set; get; }
        public string TerritoryID { set; get; }
    }
}
//END - LookUps Class
