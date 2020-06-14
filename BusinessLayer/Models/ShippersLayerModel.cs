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
    public class ShippersBusinessModelLayers
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        string errResult = "";

        //BEGIN - readBy
        public ShippersSingle GetShippersData(int ShipperID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    ShippersSingle shippers = new ShippersSingle();
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {

                        string sqlQuery = "SELECT * FROM [Shippers] WHERE ShipperID= " + ShipperID.ToString();

                        using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                        {
                            con.Open();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {

                                //shippers.ShipperID = (int)rdr["ShipperID"];
                                shippers.ShipperID = rdr["ShipperID"] == DBNull.Value ? default(int) : (int)rdr["ShipperID"];
                                //shippers.CompanyName = (string)rdr["CompanyName"];
                                shippers.CompanyName = rdr["CompanyName"] == DBNull.Value ? "" : (string)rdr["CompanyName"];

                                //shippers.Phone = (string)rdr["Phone"];
                                shippers.Phone = rdr["Phone"] == DBNull.Value ? "" : (string)rdr["Phone"];


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
                    return shippers;
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
        public void AddShippers(ShippersSingle shippers)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {




                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spAddShippers", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        SqlParameter paramShipperID = new SqlParameter
                        {
                            ParameterName = "@ShipperID",
                            Value = shippers.ShipperID
                        };
                        cmd.Parameters.Add(paramShipperID);

                        SqlParameter paramCompanyName = new SqlParameter
                        {
                            ParameterName = "@CompanyName",
                            Value = shippers.CompanyName
                        };
                        cmd.Parameters.Add(paramCompanyName);

                        SqlParameter paramPhone = new SqlParameter
                        {
                            ParameterName = "@Phone",
                            Value = shippers.Phone
                        };
                        cmd.Parameters.Add(paramPhone);

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
        public void UpdateShippers(ShippersSingle shippers)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spUpdateShippers", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@ShipperID", shippers.ShipperID);
                            cmd.Parameters.AddWithValue("@CompanyName", shippers.CompanyName);
                            cmd.Parameters.AddWithValue("@Phone", (object)shippers.Phone ?? DBNull.Value);
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
        public void DeleteShippers(int ShipperID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spDeleteShippers", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@ShipperID", ShipperID);
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
        public List<ShippersSingle> GetAllShipperss()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<ShippersSingle> shipperss = new List<ShippersSingle>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spGetAllShippers", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            ShippersSingle shippers = new ShippersSingle
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //ShipperID = (int)rdr["ShipperID"]
                                ShipperID = rdr["ShipperID"] == DBNull.Value ? default(int) : (int)rdr["ShipperID"]
                                        //,CompanyName = (string)rdr["CompanyName"]
                                        ,
                                CompanyName = rdr["CompanyName"] == DBNull.Value ? "" : (string)rdr["CompanyName"]
                                        //,Phone = (string)rdr["Phone"]
                                        ,
                                Phone = rdr["Phone"] == DBNull.Value ? "" : (string)rdr["Phone"]
                            };
                            shipperss.Add(shippers);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return shipperss;

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
        public List<Vwshippers> GetAllVwshipperss()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<Vwshippers> Vwshipperss = new List<Vwshippers>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Vwshippers", con);

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Vwshippers vwshippers = new Vwshippers
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //ShipperID = (int)rdr["ShipperID"]
                                ShipperID = rdr["ShipperID"] == DBNull.Value ? default(int) : (int)rdr["ShipperID"]
                               //,CompanyName = (string)rdr["CompanyName"]
                               ,
                                CompanyName = rdr["CompanyName"] == DBNull.Value ? "" : (string)rdr["CompanyName"]
                               //,Phone = (string)rdr["Phone"]
                               ,
                                Phone = rdr["Phone"] == DBNull.Value ? "" : (string)rdr["Phone"]
                            };
                            Vwshipperss.Add(vwshippers);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return Vwshipperss;

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
        public string SelectedShippers { get; set; }
        public List<ShippersSelect> ShippersSelect
        {
            get
            {
                var all = GetAllShipperss()
                    .Select(a => new ShippersSelect() { ShipperID = a.ShipperID, CompanyName = a.CompanyName.ToString(), CompanyNameIsSelected = false })
                    .ToList();
                List<ShippersSelect> ShippersSelect = new List<ShippersSelect>();
                foreach (var a in all)
                {
                    ShippersSelect.Add(new ShippersSelect { CompanyName = a.CompanyName, ShipperID = a.ShipperID });
                }
                return ShippersSelect;
            }
        }

        public IEnumerable<string> SelectedShipperss { get; set; }

        public IEnumerable<SelectListItem> Shipperss
        {
            get
            {
                List<SelectListItem> ShipperssSelectListItems = new List<SelectListItem>();

                foreach (ShippersSingle shippers in GetAllShipperss().ToList())
                {
                    SelectListItem selectList = new SelectListItem()
                    {
                        Text = shippers.CompanyName.ToString(),
                        Value = shippers.ShipperID.ToString(),
                        Selected = false
                    };
                    ShipperssSelectListItems.Add(selectList);
                }
                return ShipperssSelectListItems;
            }
        }


        //END - LookUps List
    }
    //BEGIN - LookUps Class

    //public class ShipperssViewModel
    //{
    //	public IEnumerable<string> SelectedShipperss { get; set; }
    //	public IEnumerable<SelectListItem> Shipperss { get; set; }
    //}

    public class ShippersSelect
    {
        public bool CompanyNameIsSelected { set; get; }
        public string CompanyName { set; get; }
        public int ShipperID { set; get; }
    }
}
//END - LookUps Class
