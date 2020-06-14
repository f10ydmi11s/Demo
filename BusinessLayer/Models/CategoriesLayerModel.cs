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
    public class CategoriesBusinessModelLayers
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        string errResult = "";

        //BEGIN - readBy
        public CategoriesSingle GetCategoriesData(int CategoryID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    CategoriesSingle categories = new CategoriesSingle();
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {

                        string sqlQuery = "SELECT * FROM [Categories] WHERE CategoryID= " + CategoryID.ToString();

                        using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                        {
                            con.Open();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {

                                //categories.CategoryID = (int)rdr["CategoryID"];
                                categories.CategoryID = rdr["CategoryID"] == DBNull.Value ? default(int) : (int)rdr["CategoryID"];
                                //categories.CategoryName = (string)rdr["CategoryName"];
                                categories.CategoryName = rdr["CategoryName"] == DBNull.Value ? "" : (string)rdr["CategoryName"];

                                //categories.Description = (string)rdr["Description"];
                                categories.Description = rdr["Description"] == DBNull.Value ? "" : (string)rdr["Description"];


                                //categories.Picture = (byte[])rdr["Picture"];
                                categories.Picture = rdr["Picture"] == DBNull.Value ? default(byte[]) : (byte[])rdr["Picture"];

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
                    return categories;
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
        public void AddCategories(CategoriesSingle categories)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {




                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spAddCategories", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        SqlParameter paramCategoryID = new SqlParameter
                        {
                            ParameterName = "@CategoryID",
                            Value = categories.CategoryID
                        };
                        cmd.Parameters.Add(paramCategoryID);

                        SqlParameter paramCategoryName = new SqlParameter
                        {
                            ParameterName = "@CategoryName",
                            Value = categories.CategoryName
                        };
                        cmd.Parameters.Add(paramCategoryName);

                        SqlParameter paramDescription = new SqlParameter
                        {
                            ParameterName = "@Description",
                            Value = categories.Description
                        };
                        cmd.Parameters.Add(paramDescription);

                        SqlParameter paramPicture = new SqlParameter
                        {
                            ParameterName = "@Picture",
                            Value = categories.Picture
                        };
                        cmd.Parameters.Add(paramPicture);

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
        public void UpdateCategories(CategoriesSingle categories)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spUpdateCategories", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@CategoryID", categories.CategoryID);
                            cmd.Parameters.AddWithValue("@CategoryName", categories.CategoryName);
                            cmd.Parameters.AddWithValue("@Description", (object)categories.Description ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Picture", (object)categories.Picture ?? DBNull.Value);
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
        public void DeleteCategories(int CategoryID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spDeleteCategories", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
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
        public List<CategoriesSingle> GetAllCategoriess()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<CategoriesSingle> categoriess = new List<CategoriesSingle>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spGetAllCategories", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            CategoriesSingle categories = new CategoriesSingle
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //CategoryID = (int)rdr["CategoryID"]
                                CategoryID = rdr["CategoryID"] == DBNull.Value ? default(int) : (int)rdr["CategoryID"]
                                        //,CategoryName = (string)rdr["CategoryName"]
                                        ,
                                CategoryName = rdr["CategoryName"] == DBNull.Value ? "" : (string)rdr["CategoryName"]
                                        //,Description = (string)rdr["Description"]
                                        ,
                                Description = rdr["Description"] == DBNull.Value ? "" : (string)rdr["Description"]
                                    //,Picture = (byte[])rdr["Picture"]
                                    ,
                                Picture = rdr["Picture"] == DBNull.Value ? default(byte[]) : (byte[])rdr["Picture"]
                            };
                            categoriess.Add(categories);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return categoriess;

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
        public List<Vwcategories> GetAllVwcategoriess()
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    List<Vwcategories> Vwcategoriess = new List<Vwcategories>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Vwcategories", con);

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Vwcategories vwcategories = new Vwcategories
                            {
                                // EXAMPLES:
                                //EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                                //Name = rdr["Name"].ToString(),
                                //IsPermanent = (bool)rdr["IsPermanent"],
                                //Salary = Convert.ToDecimal(rdr["Salary"]),
                                //DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"])

                                //CategoryID = (int)rdr["CategoryID"]
                                CategoryID = rdr["CategoryID"] == DBNull.Value ? default(int) : (int)rdr["CategoryID"]
                               //,CategoryName = (string)rdr["CategoryName"]
                               ,
                                CategoryName = rdr["CategoryName"] == DBNull.Value ? "" : (string)rdr["CategoryName"]
                               //,Description = (string)rdr["Description"]
                               ,
                                Description = rdr["Description"] == DBNull.Value ? "" : (string)rdr["Description"]
            //,Picture = (byte[])rdr["Picture"]
            ,
                                Picture = rdr["Picture"] == DBNull.Value ? default(byte[]) : (byte[])rdr["Picture"]
                            };
                            Vwcategoriess.Add(vwcategories);
                        }
                        con.Close();
                        cmd.Dispose();
                    }
                    return Vwcategoriess;

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
        public string SelectedCategories { get; set; }
        public List<CategoriesSelect> CategoriesSelect
        {
            get
            {
                var all = GetAllCategoriess()
                    .Select(a => new CategoriesSelect() { CategoryID = a.CategoryID, CategoryName = a.CategoryName.ToString(), CategoryNameIsSelected = false })
                    .ToList();
                List<CategoriesSelect> CategoriesSelect = new List<CategoriesSelect>();
                foreach (var a in all)
                {
                    CategoriesSelect.Add(new CategoriesSelect { CategoryName = a.CategoryName, CategoryID = a.CategoryID });
                }
                return CategoriesSelect;
            }
        }

        public IEnumerable<string> SelectedCategoriess { get; set; }

        public IEnumerable<SelectListItem> Categoriess
        {
            get
            {
                List<SelectListItem> CategoriessSelectListItems = new List<SelectListItem>();

                foreach (CategoriesSingle categories in GetAllCategoriess().ToList())
                {
                    SelectListItem selectList = new SelectListItem()
                    {
                        Text = categories.CategoryName.ToString(),
                        Value = categories.CategoryID.ToString(),
                        Selected = false
                    };
                    CategoriessSelectListItems.Add(selectList);
                }
                return CategoriessSelectListItems;
            }
        }


        //END - LookUps List
    }
    //BEGIN - LookUps Class

    //public class CategoriessViewModel
    //{
    //	public IEnumerable<string> SelectedCategoriess { get; set; }
    //	public IEnumerable<SelectListItem> Categoriess { get; set; }
    //}

    public class CategoriesSelect
    {
        public bool CategoryNameIsSelected { set; get; }
        public string CategoryName { set; get; }
        public int CategoryID { set; get; }
    }
}
//END - LookUps Class
