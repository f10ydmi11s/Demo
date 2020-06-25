
using BusinessModelLayer;
using Demo.CustomFilter;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
//using Demo.Models;

namespace Demo.Controllers
{
    [Authorize]
    public class EmployeeterritoriesController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }



        [ExceptionHandler]
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    EmployeesBusinessModelLayers employeesLUBusinessModelLayers = new EmployeesBusinessModelLayers();
                    ViewBag.Employeess = new SelectList(employeesLUBusinessModelLayers.EmployeesSelect, "EmployeeID", "LastName");
                    TerritoriesBusinessModelLayers territoriesLUBusinessModelLayers = new TerritoriesBusinessModelLayers();
                    ViewBag.Territoriess = new SelectList(territoriesLUBusinessModelLayers.TerritoriesSelect, "TerritoryID", "TerritoryDescription");
                    return View();
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

        [ExceptionHandler]
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    EmployeesBusinessModelLayers employeesLUBusinessModelLayers = new EmployeesBusinessModelLayers();
                    ViewBag.Employeess = new SelectList(employeesLUBusinessModelLayers.EmployeesSelect, "EmployeeID", "LastName");
                    TerritoriesBusinessModelLayers territoriesLUBusinessModelLayers = new TerritoriesBusinessModelLayers();
                    ViewBag.Territoriess = new SelectList(territoriesLUBusinessModelLayers.TerritoriesSelect, "TerritoryID", "TerritoryDescription");

                    EmployeeterritoriesBusinessModelLayers employeeterritoriesBusinessModelLayers = new EmployeeterritoriesBusinessModelLayers();
                    BusinessModelLayer.EmployeeterritoriesSingle employeeterritories = new BusinessModelLayer.EmployeeterritoriesSingle();
                    TryUpdateModel(employeeterritories);
                    if (ModelState.IsValid)
                    {
                        //mm
                        employeeterritoriesBusinessModelLayers.AddEmployeeterritories(employeeterritories);
                        return RedirectToAction("List");
                    }
                    else
                    {
                        return View();
                    }
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


        [ExceptionHandler]
        [HttpGet]
        public ActionResult Edit(int EmployeeID, string TerritoryID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    EmployeesBusinessModelLayers employeesLUBusinessModelLayers = new EmployeesBusinessModelLayers();
                    ViewBag.Employeess = new SelectList(employeesLUBusinessModelLayers.EmployeesSelect, "EmployeeID", "LastName");
                    TerritoriesBusinessModelLayers territoriesLUBusinessModelLayers = new TerritoriesBusinessModelLayers();
                    ViewBag.Territoriess = new SelectList(territoriesLUBusinessModelLayers.TerritoriesSelect, "TerritoryID", "TerritoryDescription");

                    EmployeeterritoriesBusinessModelLayers employeeterritoriesBusinessModelLayers = new EmployeeterritoriesBusinessModelLayers();

                    BusinessModelLayer.EmployeeterritoriesSingle employeeterritories;
                    if (TerritoryID == null)
                    {
                        employeeterritories = employeeterritoriesBusinessModelLayers.GetAllEmployeeterritoriess().FirstOrDefault(x => x.EmployeeID == EmployeeID);
                    }
                    else
                    {
                        employeeterritories = employeeterritoriesBusinessModelLayers.GetAllEmployeeterritoriess().FirstOrDefault(x => x.EmployeeID == EmployeeID && x.TerritoryID == TerritoryID);
                    }

                    return View(employeeterritories);
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

        [ExceptionHandler]
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int EmployeeID, string TerritoryID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    EmployeeterritoriesBusinessModelLayers employeeterritoriesBusinessModelLayers = new EmployeeterritoriesBusinessModelLayers();

                    BusinessModelLayer.EmployeeterritoriesSingle employeeterritories;
                    if (TerritoryID == null)
                    {
                        employeeterritories = employeeterritoriesBusinessModelLayers.GetAllEmployeeterritoriess().Single(x => x.EmployeeID == EmployeeID);
                    }
                    else
                    {
                        employeeterritories = employeeterritoriesBusinessModelLayers.GetAllEmployeeterritoriess().Single(x => x.EmployeeID == EmployeeID && x.TerritoryID == TerritoryID);
                    }


                    UpdateModel<EmployeeterritoriesSingle>(employeeterritories);
                    if (ModelState.IsValid)
                    {
                        //mm
                        employeeterritoriesBusinessModelLayers.UpdateEmployeeterritories(employeeterritories);
                        return RedirectToAction("List");
                    }

                    return View(employeeterritories);
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

        [ExceptionHandler]
        [HttpGet]
        public ActionResult Delete(int EmployeeID, string TerritoryID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    EmployeesBusinessModelLayers employeesLUBusinessModelLayers = new EmployeesBusinessModelLayers();
                    ViewBag.Employeess = new SelectList(employeesLUBusinessModelLayers.EmployeesSelect, "EmployeeID", "LastName");
                    TerritoriesBusinessModelLayers territoriesLUBusinessModelLayers = new TerritoriesBusinessModelLayers();
                    ViewBag.Territoriess = new SelectList(territoriesLUBusinessModelLayers.TerritoriesSelect, "TerritoryID", "TerritoryDescription");

                    EmployeeterritoriesBusinessModelLayers employeeterritoriesBusinessModelLayers = new EmployeeterritoriesBusinessModelLayers();

                    BusinessModelLayer.EmployeeterritoriesSingle employeeterritories;
                    if (TerritoryID == null)
                    {
                        employeeterritories = employeeterritoriesBusinessModelLayers.GetAllEmployeeterritoriess().FirstOrDefault(x => x.EmployeeID == EmployeeID);
                    }
                    else
                    {
                        employeeterritories = employeeterritoriesBusinessModelLayers.GetAllEmployeeterritoriess().FirstOrDefault(x => x.EmployeeID == EmployeeID && x.TerritoryID == TerritoryID);
                    }

                    return View(employeeterritories);
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

        [ExceptionHandler]
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int EmployeeID, string TerritoryID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    EmployeeterritoriesBusinessModelLayers employeeterritoriesBusinessModelLayers = new EmployeeterritoriesBusinessModelLayers();

                    if (TerritoryID == null)
                    {
                        //mm
                        employeeterritoriesBusinessModelLayers.DeleteEmployeeterritories(EmployeeID);
                    }
                    else
                    {
                        //mm
                        employeeterritoriesBusinessModelLayers.EXE_sql("DELETE FROM [EmployeeTerritories] WHERE (EmployeeID = " + "N'" + EmployeeID.ToString() + "'" + ") AND (TerritoryID = " + "N'" + TerritoryID.ToString() + "'" + ")");
                    }


                    return RedirectToAction("List");
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

        [ExceptionHandler]
        [HttpGet]
        public ActionResult Details(int EmployeeID, string TerritoryID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    EmployeesBusinessModelLayers employeesLUBusinessModelLayers = new EmployeesBusinessModelLayers();
                    ViewBag.Employeess = new SelectList(employeesLUBusinessModelLayers.EmployeesSelect, "EmployeeID", "LastName");
                    TerritoriesBusinessModelLayers territoriesLUBusinessModelLayers = new TerritoriesBusinessModelLayers();
                    ViewBag.Territoriess = new SelectList(territoriesLUBusinessModelLayers.TerritoriesSelect, "TerritoryID", "TerritoryDescription");

                    EmployeeterritoriesBusinessModelLayers employeeterritoriesBusinessModelLayers = new EmployeeterritoriesBusinessModelLayers();

                    BusinessModelLayer.EmployeeterritoriesSingle employeeterritories;
                    if (TerritoryID == null)
                    {
                        employeeterritories = employeeterritoriesBusinessModelLayers.GetAllEmployeeterritoriess().FirstOrDefault(x => x.EmployeeID == EmployeeID);
                    }
                    else
                    {
                        employeeterritories = employeeterritoriesBusinessModelLayers.GetAllEmployeeterritoriess().FirstOrDefault(x => x.EmployeeID == EmployeeID && x.TerritoryID == TerritoryID);
                    }

                    return View(employeeterritories);
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

        [OutputCache(CacheProfile = "CtrlCache")]
        [HttpGet]
        public ViewResult List(string sortOrder, string currentFilter, string searchString, int? page, string PgeSize)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    ViewBag.CurrentSort = sortOrder;
                    ViewBag.TerritoryIDSortParm = String.IsNullOrEmpty(sortOrder) ? "TerritoryID_desc" : "";

                    BusinessLayer.Validation pge = new BusinessLayer.Validation();
                    List<SelectListItem> PgeSizes = pge.PageSize();

                    //Assigning generic list to ViewBag
                    ViewBag.PgeSizeList = PgeSizes;

                    if (searchString != null)
                    {
                        page = 1;
                    }
                    else
                    {
                        searchString = currentFilter;
                    }

                    ViewBag.CurrentFilter = searchString;

                    EmployeeterritoriesBusinessModelLayers employeeterritoriesBusinessModelLayers = new EmployeeterritoriesBusinessModelLayers();
                    List<BusinessModelLayer.Vwemployeeterritories> vwemployeeterritoriess = employeeterritoriesBusinessModelLayers.GetAllVwemployeeterritoriess();

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        vwemployeeterritoriess = vwemployeeterritoriess.Where(s => s.TerritoryID.ToString().ToLower().Contains(searchString.ToLower())).ToList();
                    }

                    switch (sortOrder)
                    {
                        case "TerritoryID_desc":
                            vwemployeeterritoriess = vwemployeeterritoriess.OrderByDescending(s => s.TerritoryID).ToList();
                            break;
                        //case "!!!":
                        //	vwemployeeterritoriess = vwemployeeterritoriess.OrderBy(s => s.!!!).ToList();
                        //	break;
                        //case "!!!_desc":
                        //	vwemployeeterritoriess = vwemployeeterritoriess.OrderByDescending(s => s.!!!).ToList();
                        //	break;
                        default:  // TerritoryID ascending 
                            vwemployeeterritoriess = vwemployeeterritoriess.OrderBy(s => s.TerritoryID).ToList();
                            break;
                    }

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;
                    int pageNumber = (page ?? 1);
                    return View(vwemployeeterritoriess.ToPagedList(pageNumber, pageSize));
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
