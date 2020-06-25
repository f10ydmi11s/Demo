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
    public class Tbl_ExceptionloggingtodatabaseController : ApiController
    {
        // GET: api/Tbl_Exceptionloggingtodatabase
        [ExceptionHandler]
        public IHttpActionResult Get()
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    Tbl_ExceptionloggingtodatabaseBusinessModelLayers tbl_exceptionloggingtodatabaseBusinessModelLayers = new Tbl_ExceptionloggingtodatabaseBusinessModelLayers();
                    List<BusinessModelLayer.Tbl_ExceptionloggingtodatabaseSingle> tbl_exceptionloggingtodatabases = tbl_exceptionloggingtodatabaseBusinessModelLayers.GetAllTbl_Exceptionloggingtodatabases();
                    return Ok(tbl_exceptionloggingtodatabases);
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

        // GET: api/Tbl_Exceptionloggingtodatabase/?Logid=5
        [ExceptionHandler]
        public IHttpActionResult Get(long Logid)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    Tbl_ExceptionloggingtodatabaseBusinessModelLayers tbl_exceptionloggingtodatabaseBusinessModelLayers = new Tbl_ExceptionloggingtodatabaseBusinessModelLayers();
                    List<BusinessModelLayer.Tbl_ExceptionloggingtodatabaseSingle> tbl_exceptionloggingtodatabases = tbl_exceptionloggingtodatabaseBusinessModelLayers.GetAllTbl_Exceptionloggingtodatabases().FindAll(x => x.Logid == Logid);

                    //BusinessModelLayer.Tbl_ExceptionloggingtodatabaseSingle tbl_exceptionloggingtodatabases = tbl_exceptionloggingtodatabaseBusinessModelLayers.GetTbl_ExceptionloggingtodatabaseData(Logid);
                    return Ok(tbl_exceptionloggingtodatabases);
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


        // POST: api/Tbl_Exceptionloggingtodatabase
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

        // PUT: api/Tbl_Exceptionloggingtodatabase/5
        public void Put(long Logid, [FromBody] string value)
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

        // DELETE: api/Tbl_Exceptionloggingtodatabase/5
        public void Delete(long Logid)
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

