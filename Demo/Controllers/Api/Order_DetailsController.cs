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
    public class Order_DetailsController : ApiController
    {
        // GET: api/Order_Details
        [ExceptionHandler]
        public IHttpActionResult Get()
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    Order_DetailsBusinessModelLayers order_detailsBusinessModelLayers = new Order_DetailsBusinessModelLayers();
                    List<BusinessModelLayer.Order_DetailsSingle> order_detailss = order_detailsBusinessModelLayers.GetAllOrder_Detailss();
                    return Ok(order_detailss);
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

        // GET: api/Order_Details/?OrderID=5
        [ExceptionHandler]
        public IHttpActionResult Get(int OrderID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    Order_DetailsBusinessModelLayers order_detailsBusinessModelLayers = new Order_DetailsBusinessModelLayers();
                    List<BusinessModelLayer.Order_DetailsSingle> order_detailss = order_detailsBusinessModelLayers.GetAllOrder_Detailss().FindAll(x => x.OrderID == OrderID);

                    //BusinessModelLayer.Order_DetailsSingle order_detailss = order_detailsBusinessModelLayers.GetOrder_DetailsData(OrderID);
                    return Ok(order_detailss);
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

        // GET: api/Order_Details/?OrderID=5&ProductID=5
        [ExceptionHandler]
        public IHttpActionResult Get(int OrderID, int? ProductID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    Order_DetailsBusinessModelLayers order_detailsBusinessModelLayers = new Order_DetailsBusinessModelLayers();

                    BusinessModelLayer.Order_DetailsSingle order_detailss = new Order_DetailsSingle();

                    if (ProductID == null)
                    {
                        order_detailss = order_detailsBusinessModelLayers.GetAllOrder_Detailss().FirstOrDefault(x => x.OrderID == OrderID);
                    }
                    else
                    {
                        order_detailss = order_detailsBusinessModelLayers.GetAllOrder_Detailss().FirstOrDefault(x => x.OrderID == OrderID && x.ProductID == ProductID);
                    }

                    return Ok(order_detailss);
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

        // POST: api/Order_Details
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

        // PUT: api/Order_Details/5
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

        // DELETE: api/Order_Details/5
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

