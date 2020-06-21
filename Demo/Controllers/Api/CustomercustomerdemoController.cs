using BusinessModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.Controllers.Api
{
    public class CustomercustomerdemoController : ApiController
    {
        // GET: api/Customercustomerdemo
        public IHttpActionResult Get()
        {
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {

            CustomercustomerdemoBusinessModelLayers customercustomerdemoBusinessModelLayers = new CustomercustomerdemoBusinessModelLayers();
            List<BusinessModelLayer.CustomercustomerdemoSingle> customercustomerdemos = customercustomerdemoBusinessModelLayers.GetAllCustomercustomerdemos();
            return Ok(customercustomerdemos);
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

        // GET: api/Customercustomerdemo/?CustomerID=5
        public IHttpActionResult Get(string CustomerID)
        {
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {

            CustomercustomerdemoBusinessModelLayers customercustomerdemoBusinessModelLayers = new CustomercustomerdemoBusinessModelLayers();
            List<BusinessModelLayer.CustomercustomerdemoSingle> customercustomerdemos = customercustomerdemoBusinessModelLayers.GetAllCustomercustomerdemos().FindAll(x => x.CustomerID == CustomerID);
			
			//BusinessModelLayer.CustomercustomerdemoSingle customercustomerdemos = customercustomerdemoBusinessModelLayers.GetCustomercustomerdemoData(CustomerID);
            return Ok(customercustomerdemos);
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

        // GET: api/Customercustomerdemo/?CustomerID=5&CustomerTypeID=5
        public IHttpActionResult Get(string CustomerID, string CustomerTypeID)
        {
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {

            CustomercustomerdemoBusinessModelLayers customercustomerdemoBusinessModelLayers = new CustomercustomerdemoBusinessModelLayers();
            
			BusinessModelLayer.CustomercustomerdemoSingle customercustomerdemos = new CustomercustomerdemoSingle();

			if (CustomerTypeID == null)
			{
				customercustomerdemos = customercustomerdemoBusinessModelLayers.GetAllCustomercustomerdemos().FirstOrDefault(x => x.CustomerID == CustomerID);
			} else
			{			
				customercustomerdemos = customercustomerdemoBusinessModelLayers.GetAllCustomercustomerdemos().FirstOrDefault(x => x.CustomerID == CustomerID && x.CustomerTypeID == CustomerTypeID);
			}

			return Ok(customercustomerdemos);
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

        // POST: api/Customercustomerdemo
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

        // PUT: api/Customercustomerdemo/5
        public void Put(string CustomerID, [FromBody]string value)
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

        // DELETE: api/Customercustomerdemo/5
        public void Delete(string CustomerID)
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

