using BusinessModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.Controllers.Api
{
    public class Tbl_LoginController : ApiController
    {
        // GET: api/Tbl_Login
        public IHttpActionResult Get()
        {
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {

            Tbl_LoginBusinessModelLayers tbl_loginBusinessModelLayers = new Tbl_LoginBusinessModelLayers();
            List<BusinessModelLayer.Tbl_LoginSingle> tbl_logins = tbl_loginBusinessModelLayers.GetAllTbl_Logins();
            return Ok(tbl_logins);
            }
            catch (Exception ex)
            {
                BusinessLayer.ExceptionLogging exlog = new BusinessLayer.ExceptionLogging();
                exlog.SendExcepToDB(ex);
                throw;
            }
    }
    catch(Exception) 
    {
        throw;
    }

        }

        // GET: api/Tbl_Login/?Username=5
        public IHttpActionResult Get(string Username)
        {
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {

            Tbl_LoginBusinessModelLayers tbl_loginBusinessModelLayers = new Tbl_LoginBusinessModelLayers();
            List<BusinessModelLayer.Tbl_LoginSingle> tbl_logins = tbl_loginBusinessModelLayers.GetAllTbl_Logins().FindAll(x => x.Username == Username);
			
			//BusinessModelLayer.Tbl_LoginSingle tbl_logins = tbl_loginBusinessModelLayers.GetTbl_LoginData(Username);
            return Ok(tbl_logins);
            }
            catch (Exception ex)
            {
                BusinessLayer.ExceptionLogging exlog = new BusinessLayer.ExceptionLogging();
                exlog.SendExcepToDB(ex);
                throw;
            }
    }
    catch(Exception) 
    {
        throw;
    }

        }


        // POST: api/Tbl_Login
        public void Post([FromBody]string value)
        {
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {




            }
            catch (Exception ex)
            {
                BusinessLayer.ExceptionLogging exlog = new BusinessLayer.ExceptionLogging();
                exlog.SendExcepToDB(ex);
                throw;
            }
    }
    catch(Exception) 
    {
        throw;
    }

        }

        // PUT: api/Tbl_Login/5
        public void Put(string Username, [FromBody]string value)
        {
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {




            }
            catch (Exception ex)
            {
                BusinessLayer.ExceptionLogging exlog = new BusinessLayer.ExceptionLogging();
                exlog.SendExcepToDB(ex);
                throw;
            }
    }
    catch(Exception) 
    {
        throw;
    }

        }

        // DELETE: api/Tbl_Login/5
        public void Delete(string Username)
        {
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {




            }
            catch (Exception ex)
            {
                BusinessLayer.ExceptionLogging exlog = new BusinessLayer.ExceptionLogging();
                exlog.SendExcepToDB(ex);
                throw;
            }
    }
    catch(Exception) 
    {
        throw;
    }

        }
    }
}

