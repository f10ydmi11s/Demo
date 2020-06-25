using BusinessModelLayer;
using Demo.CustomFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.Controllers.Api
{
    public class CustomersController : ApiController
    {
        // GET: api/Customers
        [ExceptionHandler]
        public IHttpActionResult Get()
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    CustomersBusinessModelLayers customersBusinessModelLayers = new CustomersBusinessModelLayers();
                    List<BusinessModelLayer.CustomersSingle> customerss = customersBusinessModelLayers.GetAllCustomerss();
                    return Ok(customerss);
                }
                catch (Exception ex)
                {
                    BusinessLayer.ExceptionLogging exlog = new BusinessLayer.ExceptionLogging();
                    exlog.SendExcepToDB(ex);
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        // GET: api/Customers/?CustomerID=5
        [ExceptionHandler]
        public IHttpActionResult Get(string CustomerID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    CustomersBusinessModelLayers customersBusinessModelLayers = new CustomersBusinessModelLayers();
                    List<BusinessModelLayer.CustomersSingle> customerss = customersBusinessModelLayers.GetAllCustomerss().FindAll(x => x.CustomerID == CustomerID);

                    //BusinessModelLayer.CustomersSingle customerss = customersBusinessModelLayers.GetCustomersData(CustomerID);
                    return Ok(customerss);
                }
                catch (Exception ex)
                {
                    BusinessLayer.ExceptionLogging exlog = new BusinessLayer.ExceptionLogging();
                    exlog.SendExcepToDB(ex);
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }


        // POST: api/Customers
        public void Post([FromBody] string value)
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
            catch (Exception)
            {
                throw;
            }

        }

        // PUT: api/Customers/5
        public void Put(string CustomerID, [FromBody] string value)
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
            catch (Exception)
            {
                throw;
            }

        }

        // DELETE: api/Customers/5
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
            catch (Exception)
            {
                throw;
            }

        }
    }
}

