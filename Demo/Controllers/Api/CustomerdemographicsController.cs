using BusinessModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.Controllers.Api
{
    public class CustomerdemographicsController : ApiController
    {
        // GET: api/Customerdemographics
        public IHttpActionResult Get()
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    CustomerdemographicsBusinessModelLayers customerdemographicsBusinessModelLayers = new CustomerdemographicsBusinessModelLayers();
                    List<BusinessModelLayer.CustomerdemographicsSingle> customerdemographicss = customerdemographicsBusinessModelLayers.GetAllCustomerdemographicss();
                    return Ok(customerdemographicss);
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

        // GET: api/Customerdemographics/?CustomerTypeID=5
        public IHttpActionResult Get(string CustomerTypeID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    CustomerdemographicsBusinessModelLayers customerdemographicsBusinessModelLayers = new CustomerdemographicsBusinessModelLayers();
                    List<BusinessModelLayer.CustomerdemographicsSingle> customerdemographicss = customerdemographicsBusinessModelLayers.GetAllCustomerdemographicss().FindAll(x => x.CustomerTypeID == CustomerTypeID);

                    //BusinessModelLayer.CustomerdemographicsSingle customerdemographicss = customerdemographicsBusinessModelLayers.GetCustomerdemographicsData(CustomerTypeID);
                    return Ok(customerdemographicss);
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


        // POST: api/Customerdemographics
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

        // PUT: api/Customerdemographics/5
        public void Put(string CustomerTypeID, [FromBody] string value)
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

        // DELETE: api/Customerdemographics/5
        public void Delete(string CustomerTypeID)
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

