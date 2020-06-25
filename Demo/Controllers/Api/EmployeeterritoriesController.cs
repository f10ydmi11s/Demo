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
    public class EmployeeterritoriesController : ApiController
    {
        // GET: api/Employeeterritories
        [ExceptionHandler]
        public IHttpActionResult Get()
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    EmployeeterritoriesBusinessModelLayers employeeterritoriesBusinessModelLayers = new EmployeeterritoriesBusinessModelLayers();
                    List<BusinessModelLayer.EmployeeterritoriesSingle> employeeterritoriess = employeeterritoriesBusinessModelLayers.GetAllEmployeeterritoriess();
                    return Ok(employeeterritoriess);
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

        // GET: api/Employeeterritories/?EmployeeID=5
        [ExceptionHandler]
        public IHttpActionResult Get(int EmployeeID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    EmployeeterritoriesBusinessModelLayers employeeterritoriesBusinessModelLayers = new EmployeeterritoriesBusinessModelLayers();
                    List<BusinessModelLayer.EmployeeterritoriesSingle> employeeterritoriess = employeeterritoriesBusinessModelLayers.GetAllEmployeeterritoriess().FindAll(x => x.EmployeeID == EmployeeID);

                    //BusinessModelLayer.EmployeeterritoriesSingle employeeterritoriess = employeeterritoriesBusinessModelLayers.GetEmployeeterritoriesData(EmployeeID);
                    return Ok(employeeterritoriess);
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

        // GET: api/Employeeterritories/?EmployeeID=5&TerritoryID=5
        [ExceptionHandler]
        public IHttpActionResult Get(int EmployeeID, string TerritoryID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    EmployeeterritoriesBusinessModelLayers employeeterritoriesBusinessModelLayers = new EmployeeterritoriesBusinessModelLayers();

                    BusinessModelLayer.EmployeeterritoriesSingle employeeterritoriess = new EmployeeterritoriesSingle();

                    if (TerritoryID == null)
                    {
                        employeeterritoriess = employeeterritoriesBusinessModelLayers.GetAllEmployeeterritoriess().FirstOrDefault(x => x.EmployeeID == EmployeeID);
                    }
                    else
                    {
                        employeeterritoriess = employeeterritoriesBusinessModelLayers.GetAllEmployeeterritoriess().FirstOrDefault(x => x.EmployeeID == EmployeeID && x.TerritoryID == TerritoryID);
                    }

                    return Ok(employeeterritoriess);
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

        // POST: api/Employeeterritories
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

        // PUT: api/Employeeterritories/5
        public void Put(int EmployeeID, [FromBody] string value)
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

        // DELETE: api/Employeeterritories/5
        public void Delete(int EmployeeID)
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

