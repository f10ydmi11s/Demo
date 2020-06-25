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
    public class RegionController : ApiController
    {
        // GET: api/Region
        [ExceptionHandler]
        public IHttpActionResult Get()
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    RegionBusinessModelLayers regionBusinessModelLayers = new RegionBusinessModelLayers();
                    List<BusinessModelLayer.RegionSingle> regions = regionBusinessModelLayers.GetAllRegions();
                    return Ok(regions);
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

        // GET: api/Region/?RegionID=5
        [ExceptionHandler]
        public IHttpActionResult Get(int RegionID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    RegionBusinessModelLayers regionBusinessModelLayers = new RegionBusinessModelLayers();
                    List<BusinessModelLayer.RegionSingle> regions = regionBusinessModelLayers.GetAllRegions().FindAll(x => x.RegionID == RegionID);

                    //BusinessModelLayer.RegionSingle regions = regionBusinessModelLayers.GetRegionData(RegionID);
                    return Ok(regions);
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


        // POST: api/Region
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

        // PUT: api/Region/5
        public void Put(int RegionID, [FromBody] string value)
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

        // DELETE: api/Region/5
        public void Delete(int RegionID)
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

