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
    public class ProductsController : ApiController
    {
        // GET: api/Products
        [ExceptionHandler]
        public IHttpActionResult Get()
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    ProductsBusinessModelLayers productsBusinessModelLayers = new ProductsBusinessModelLayers();
                    List<BusinessModelLayer.ProductsSingle> productss = productsBusinessModelLayers.GetAllProductss();
                    return Ok(productss);
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

        // GET: api/Products/?ProductID=5
        [ExceptionHandler]
        public IHttpActionResult Get(int ProductID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    ProductsBusinessModelLayers productsBusinessModelLayers = new ProductsBusinessModelLayers();
                    List<BusinessModelLayer.ProductsSingle> productss = productsBusinessModelLayers.GetAllProductss().FindAll(x => x.ProductID == ProductID);

                    //BusinessModelLayer.ProductsSingle productss = productsBusinessModelLayers.GetProductsData(ProductID);
                    return Ok(productss);
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


        // POST: api/Products
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

        // PUT: api/Products/5
        public void Put(int ProductID, [FromBody] string value)
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

        // DELETE: api/Products/5
        public void Delete(int ProductID)
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

