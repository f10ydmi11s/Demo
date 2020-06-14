using BusinessModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.Controllers.Api
{
    public class SuppliersController : ApiController
    {
        // GET: api/Suppliers
        public IHttpActionResult Get()
        {
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {

            SuppliersBusinessModelLayers suppliersBusinessModelLayers = new SuppliersBusinessModelLayers();
            List<BusinessModelLayer.SuppliersSingle> supplierss = suppliersBusinessModelLayers.GetAllSupplierss();
            return Ok(supplierss);
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

        // GET: api/Suppliers/?SupplierID=5
        public IHttpActionResult Get(int SupplierID)
        {
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {

            SuppliersBusinessModelLayers suppliersBusinessModelLayers = new SuppliersBusinessModelLayers();
            List<BusinessModelLayer.SuppliersSingle> supplierss = suppliersBusinessModelLayers.GetAllSupplierss().FindAll(x => x.SupplierID == SupplierID);
			
			//BusinessModelLayer.SuppliersSingle supplierss = suppliersBusinessModelLayers.GetSuppliersData(SupplierID);
            return Ok(supplierss);
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


        // POST: api/Suppliers
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

        // PUT: api/Suppliers/5
        public void Put(int SupplierID, [FromBody]string value)
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

        // DELETE: api/Suppliers/5
        public void Delete(int SupplierID)
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

