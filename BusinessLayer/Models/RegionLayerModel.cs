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
    public class RegionBusinessModelLayers
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        string errResult = "";

        //BEGIN - readBy
        public RegionSingle GetRegionData(int RegionID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    RegionSingle region = new RegionSingle();
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {

                        string sqlQuery = "SELECT * FROM [Region] WHERE RegionID= " + RegionID.ToString();

                        using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                        {
                            con.Open();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {

                                //region.RegionID = (int)rdr["RegionID"];
                                region.RegionID = rdr["RegionID"] == DBNull.Value ? default(int) : (int)rdr["RegionID"];
                                //region.RegionDescription = (string)rdr["RegionDescription"];
                                region.RegionDescription = rdr["RegionDescription"] == DBNull.Value ? "" : (string)rdr["RegionDescription"];


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
                    return region;
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
        public void AddRegion(RegionSingle region)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {




                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spAddRegion", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        SqlParameter paramRegionID = new SqlParameter
                        {
                            ParameterName = "@RegionID",
                            Value = region.RegionID
                        };
                        cmd.Parameters.Add(paramRegionID);

                        SqlParameter paramRegionDescription = new SqlParameter
                        {
                            ParameterName = "@RegionDescription",
                            Value = region.RegionDescription
                        };
                        cmd.Parameters.Add(paramRegionDescription);

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
        public void UpdateRegion(RegionSingle region)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spUpdateRegion", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@RegionID", region.RegionID);
                            cmd.Parameters.AddWithValue("@RegionDescription", region.RegionDescription);
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
        public void DeleteRegion(int RegionID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spDeleteRegion", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@RegionID", RegionID);
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
        public List<RegionSingle> GetAllRegions()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<RegionSingle> regions = new List<RegionSingle>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spGetAllRegion", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            RegionSingle region = new RegionSingle
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //RegionID = (int)rdr["RegionID"]
                                RegionID = rdr["RegionID"] == DBNull.Value ? default(int) : (int)rdr["RegionID"]
                                        //,RegionDescription = (string)rdr["RegionDescription"]
                                        ,
                                RegionDescription = rdr["RegionDescription"] == DBNull.Value ? "" : (string)rdr["RegionDescription"]
                            };
                            regions.Add(region);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return regions;

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
        public List<Vwregion> GetAllVwregions()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<Vwregion> Vwregions = new List<Vwregion>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Vwregion", con);

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Vwregion vwregion = new Vwregion
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //RegionID = (int)rdr["RegionID"]
                                RegionID = rdr["RegionID"] == DBNull.Value ? default(int) : (int)rdr["RegionID"]
                               //,RegionDescription = (string)rdr["RegionDescription"]
                               ,
                                RegionDescription = rdr["RegionDescription"] == DBNull.Value ? "" : (string)rdr["RegionDescription"]
                            };
                            Vwregions.Add(vwregion);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return Vwregions;

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
        public string SelectedRegion { get; set; }
        public List<RegionSelect> RegionSelect
        {
            get
            {
                var all = GetAllRegions()
                    .Select(a => new RegionSelect() { RegionID = a.RegionID, RegionDescription = a.RegionDescription.ToString(), RegionDescriptionIsSelected = false })
                    .ToList();
                List<RegionSelect> RegionSelect = new List<RegionSelect>();
                foreach (var a in all)
                {
                    RegionSelect.Add(new RegionSelect { RegionDescription = a.RegionDescription, RegionID = a.RegionID });
                }
                return RegionSelect;
            }
        }

        public IEnumerable<string> SelectedRegions { get; set; }

        public IEnumerable<SelectListItem> Regions
        {
            get
            {
                List<SelectListItem> RegionsSelectListItems = new List<SelectListItem>();

                foreach (RegionSingle region in GetAllRegions().ToList())
                {
                    SelectListItem selectList = new SelectListItem()
                    {
                        Text = region.RegionDescription.ToString(),
                        Value = region.RegionID.ToString(),
                        Selected = false
                    };
                    RegionsSelectListItems.Add(selectList);
                }
                return RegionsSelectListItems;
            }
        }


        //END - LookUps List
    }
    //BEGIN - LookUps Class

    //public class RegionsViewModel
    //{
    //	public IEnumerable<string> SelectedRegions { get; set; }
    //	public IEnumerable<SelectListItem> Regions { get; set; }
    //}

    public class RegionSelect
    {
        public bool RegionDescriptionIsSelected { set; get; }
        public string RegionDescription { set; get; }
        public int RegionID { set; get; }
    }
}
//END - LookUps Class
