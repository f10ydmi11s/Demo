using BusinessModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.Controllers.Api
{
    public class CategoriesController : ApiController
    {
        // GET: api/Categories
        public IHttpActionResult Get()
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    CategoriesBusinessModelLayers categoriesBusinessModelLayers = new CategoriesBusinessModelLayers();
                    List<BusinessModelLayer.CategoriesSingle> categoriess = categoriesBusinessModelLayers.GetAllCategoriess();
                    return Ok(categoriess);
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

        // GET: api/Categories/?CategoryID=5
        public IHttpActionResult Get(int CategoryID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    CategoriesBusinessModelLayers categoriesBusinessModelLayers = new CategoriesBusinessModelLayers();
                    List<BusinessModelLayer.CategoriesSingle> categoriess = categoriesBusinessModelLayers.GetAllCategoriess().FindAll(x => x.CategoryID == CategoryID);

                    //BusinessModelLayer.CategoriesSingle categoriess = categoriesBusinessModelLayers.GetCategoriesData(CategoryID);
                    return Ok(categoriess);
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


        // POST: api/Categories
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

        // PUT: api/Categories/5
        public void Put(int CategoryID, [FromBody] string value)
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

        // DELETE: api/Categories/5
        public void Delete(int CategoryID)
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

