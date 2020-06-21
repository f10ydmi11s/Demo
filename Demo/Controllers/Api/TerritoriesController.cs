using BusinessModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.Controllers.Api
{
    public class TerritoriesController : ApiController
    {
        // GET: api/Territories
        public IHttpActionResult Get()
        {
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {

            TerritoriesBusinessModelLayers territoriesBusinessModelLayers = new TerritoriesBusinessModelLayers();
            List<BusinessModelLayer.TerritoriesSingle> territoriess = territoriesBusinessModelLayers.GetAllTerritoriess();
            return Ok(territoriess);
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

        // GET: api/Territories/?TerritoryID=5
        public IHttpActionResult Get(string TerritoryID)
        {
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {

            TerritoriesBusinessModelLayers territoriesBusinessModelLayers = new TerritoriesBusinessModelLayers();
            List<BusinessModelLayer.TerritoriesSingle> territoriess = territoriesBusinessModelLayers.GetAllTerritoriess().FindAll(x => x.TerritoryID == TerritoryID);
			
			//BusinessModelLayer.TerritoriesSingle territoriess = territoriesBusinessModelLayers.GetTerritoriesData(TerritoryID);
            return Ok(territoriess);
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


        // POST: api/Territories
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

        // PUT: api/Territories/5
        public void Put(string TerritoryID, [FromBody]string value)
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

        // DELETE: api/Territories/5
        public void Delete(string TerritoryID)
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

