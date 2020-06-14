using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLayer
{
    public class ExceptionLogging
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        public String exepurl;
        public void SendExcepToDB(Exception exdb)
        {
            exepurl = HttpContext.Current.Request.Url.ToString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddTbl_Exceptionloggingtodatabase", con)
                {
                    CommandType = CommandType.StoredProcedure
                };


                SqlParameter paramExceptionMsg = new SqlParameter
                {
                    ParameterName = "@ExceptionMsg",
                    Value = exdb.Message.ToString()
                };
                cmd.Parameters.Add(paramExceptionMsg);

                SqlParameter paramExceptionType = new SqlParameter
                {
                    ParameterName = "@ExceptionType",
                    Value = exdb.GetType().Name.ToString()
                };
                cmd.Parameters.Add(paramExceptionType);

                SqlParameter paramExceptionSource = new SqlParameter
                {
                    ParameterName = "@ExceptionSource",
                    Value = exdb.StackTrace.ToString()
                };
                cmd.Parameters.Add(paramExceptionSource);

                SqlParameter paramExceptionURL = new SqlParameter
                {
                    ParameterName = "@ExceptionURL",
                    Value = exepurl
                };
                cmd.Parameters.Add(paramExceptionURL);

                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

        }
    }
}
