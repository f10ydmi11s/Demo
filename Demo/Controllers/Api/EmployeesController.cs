using BusinessModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.Controllers.Api
{
    public class EmployeesController : ApiController
    {
        // GET: api/Employees
        public IHttpActionResult Get()
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    EmployeesBusinessModelLayers employeesBusinessModelLayers = new EmployeesBusinessModelLayers();
                    List<BusinessModelLayer.EmployeesSingle> employeess = employeesBusinessModelLayers.GetAllEmployeess();
                    return Ok(employeess);
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

        // GET: api/Employees/?EmployeeID=5
        public IHttpActionResult Get(int EmployeeID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    EmployeesBusinessModelLayers employeesBusinessModelLayers = new EmployeesBusinessModelLayers();
                    List<BusinessModelLayer.EmployeesSingle> employeess = employeesBusinessModelLayers.GetAllEmployeess().FindAll(x => x.EmployeeID == EmployeeID);

                    //BusinessModelLayer.EmployeesSingle employeess = employeesBusinessModelLayers.GetEmployeesData(EmployeeID);
                    return Ok(employeess);
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


        // POST: api/Employees
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

        // PUT: api/Employees/5
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

        // DELETE: api/Employees/5
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

