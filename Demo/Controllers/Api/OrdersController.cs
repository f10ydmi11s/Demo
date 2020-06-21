using BusinessModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.Controllers.Api
{
    public class OrdersController : ApiController
    {
        // GET: api/Orders
        public IHttpActionResult Get()
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    OrdersBusinessModelLayers ordersBusinessModelLayers = new OrdersBusinessModelLayers();
                    List<BusinessModelLayer.OrdersSingle> orderss = ordersBusinessModelLayers.GetAllOrderss();
                    return Ok(orderss);
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

        // GET: api/Orders/?OrderID=5
        public IHttpActionResult Get(int OrderID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    OrdersBusinessModelLayers ordersBusinessModelLayers = new OrdersBusinessModelLayers();
                    List<BusinessModelLayer.OrdersSingle> orderss = ordersBusinessModelLayers.GetAllOrderss().FindAll(x => x.OrderID == OrderID);

                    //BusinessModelLayer.OrdersSingle orderss = ordersBusinessModelLayers.GetOrdersData(OrderID);
                    return Ok(orderss);
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


        // POST: api/Orders
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

        // PUT: api/Orders/5
        public void Put(int OrderID, [FromBody] string value)
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

        // DELETE: api/Orders/5
        public void Delete(int OrderID)
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

