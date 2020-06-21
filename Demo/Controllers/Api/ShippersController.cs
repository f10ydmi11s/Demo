using BusinessModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.Controllers.Api
{
    public class ShippersController : ApiController
    {
        // GET: api/Shippers
        public IHttpActionResult Get()
        {
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {

            ShippersBusinessModelLayers shippersBusinessModelLayers = new ShippersBusinessModelLayers();
            List<BusinessModelLayer.ShippersSingle> shipperss = shippersBusinessModelLayers.GetAllShipperss();
            return Ok(shipperss);
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

        // GET: api/Shippers/?ShipperID=5
        public IHttpActionResult Get(int ShipperID)
        {
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {

            ShippersBusinessModelLayers shippersBusinessModelLayers = new ShippersBusinessModelLayers();
            List<BusinessModelLayer.ShippersSingle> shipperss = shippersBusinessModelLayers.GetAllShipperss().FindAll(x => x.ShipperID == ShipperID);
			
			//BusinessModelLayer.ShippersSingle shipperss = shippersBusinessModelLayers.GetShippersData(ShipperID);
            return Ok(shipperss);
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


        // POST: api/Shippers
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

        // PUT: api/Shippers/5
        public void Put(int ShipperID, [FromBody]string value)
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

        // DELETE: api/Shippers/5
        public void Delete(int ShipperID)
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

