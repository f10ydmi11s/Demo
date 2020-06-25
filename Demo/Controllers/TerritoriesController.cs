
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
    public class TerritoriesController : Controller
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

                    RegionBusinessModelLayers regionLUBusinessModelLayers = new RegionBusinessModelLayers();
                    ViewBag.Regions = new SelectList(regionLUBusinessModelLayers.RegionSelect, "RegionID", "RegionDescription");
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


                    RegionBusinessModelLayers regionLUBusinessModelLayers = new RegionBusinessModelLayers();
                    ViewBag.Regions = new SelectList(regionLUBusinessModelLayers.RegionSelect, "RegionID", "RegionDescription");

                    TerritoriesBusinessModelLayers territoriesBusinessModelLayers = new TerritoriesBusinessModelLayers();
                    BusinessModelLayer.TerritoriesSingle territories = new BusinessModelLayer.TerritoriesSingle();
                    TryUpdateModel(territories);
                    if (ModelState.IsValid)
                    {
                        //mm
                        territoriesBusinessModelLayers.AddTerritories(territories);
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
        public ActionResult Edit(string TerritoryID, string sortOrder, string currentFilter, string searchString, int? page, string PgeSize)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    RegionBusinessModelLayers regionLUBusinessModelLayers = new RegionBusinessModelLayers();
                    ViewBag.Regions = new SelectList(regionLUBusinessModelLayers.RegionSelect, "RegionID", "RegionDescription");

                    ViewBag.CurrentSort = sortOrder;
                    ViewBag.TerritoryID = TerritoryID;

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

                    //TERRITORIES TABLE MASTER
                    BusinessModelLayer.Territories.TerritoriesMasterDetailModel pageModel = new BusinessModelLayer.Territories.TerritoriesMasterDetailModel();
                    TerritoriesBusinessModelLayers territoriesBusinessModelLayers = new TerritoriesBusinessModelLayers();
                    Territories.TerritoriesMasterDetailModel territoriesMasterDetailModel = new Territories.TerritoriesMasterDetailModel();

                    pageModel.Territories = territoriesBusinessModelLayers.GetAllTerritoriess().FirstOrDefault(x => x.TerritoryID == TerritoryID);

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;

                    int pageNumber = (page ?? 1);


                    //EMPLOYEETERRITORIES DETAIL BEGIN

                    ViewBag.TerritoryIDSortParm = String.IsNullOrEmpty(sortOrder) ? "TerritoryID_desc" : "";
                    EmployeeterritoriesBusinessModelLayers employeeterritoriesBusinessModelLayers = new EmployeeterritoriesBusinessModelLayers();

                    List<BusinessModelLayer.Vwemployeeterritories> employeeterritoriess = employeeterritoriesBusinessModelLayers.GetAllVwemployeeterritoriess().FindAll(x => x.TerritoryID == TerritoryID).ToList();

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        employeeterritoriess = employeeterritoriess.Where(s => s.TerritoryID == TerritoryID && s.TerritoryID.ToString().ToLower().Contains(searchString.ToLower())).ToList();
                    }

                    switch (sortOrder)
                    {
                        case "TerritoryID_desc":
                            employeeterritoriess = employeeterritoriess.OrderByDescending(s => s.TerritoryID).ToList();
                            break;
                        default:  // TerritoryID ascending 
                            employeeterritoriess = employeeterritoriess.OrderBy(s => s.TerritoryID).ToList();
                            break;
                    }
                    pageModel.EmployeeterritoriesVwDetl = employeeterritoriess.ToPagedList(pageNumber, pageSize);

                    //EMPLOYEETERRITORIES DETAIL END
                    return View(pageModel);
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
        public ActionResult Edit_Post(TerritoriesSingle territories, string sortOrder, string currentFilter, string searchString, int? page, string PgeSize)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    TerritoriesBusinessModelLayers territoriesBusinessModelLayers = new TerritoriesBusinessModelLayers();
                    if (ModelState.IsValid)
                    {
                        //mm
                        territoriesBusinessModelLayers.UpdateTerritories(territories);
                        return RedirectToAction("List");
                    }

                    ViewBag.CurrentSort = sortOrder;
                    ViewBag.TerritoryID = territories.TerritoryID;

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

                    //TERRITORIES TABLE MASTER

                    BusinessModelLayer.Territories.TerritoriesMasterDetailModel pageModel = new BusinessModelLayer.Territories.TerritoriesMasterDetailModel
                    {
                        Territories = territoriesBusinessModelLayers.GetAllTerritoriess().Single(x => x.TerritoryID == territories.TerritoryID)
                    };

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;

                    int pageNumber = (page ?? 1);

                    //EMPLOYEETERRITORIES DETAIL BEGIN
                    ViewBag.TerritoryIDSortParm = String.IsNullOrEmpty(sortOrder) ? "TerritoryID_desc" : "";
                    EmployeeterritoriesBusinessModelLayers employeeterritoriesBusinessModelLayers = new EmployeeterritoriesBusinessModelLayers();
                    pageModel.EmployeeterritoriesVwDetl = employeeterritoriesBusinessModelLayers.GetAllVwemployeeterritoriess().FindAll(x => x.TerritoryID == territories.TerritoryID).ToList().ToPagedList(pageNumber, pageSize);

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        pageModel.EmployeeterritoriesVwDetl = pageModel.EmployeeterritoriesVwDetl.Where(s => s.TerritoryID.ToString().ToLower().Contains(searchString.ToLower())).ToList().ToPagedList(pageNumber, pageSize);
                    }

                    switch (sortOrder)
                    {
                        case "TerritoryID_desc":
                            pageModel.EmployeeterritoriesVwDetl = pageModel.EmployeeterritoriesVwDetl.OrderByDescending(s => s.TerritoryID).ToList().ToPagedList(pageNumber, pageSize);
                            break;
                        default:  // TerritoryID ascending 
                            pageModel.EmployeeterritoriesVwDetl = pageModel.EmployeeterritoriesVwDetl.OrderBy(s => s.TerritoryID).ToList().ToPagedList(pageNumber, pageSize);
                            break;
                    }
                    //EMPLOYEETERRITORIES DETAIL END
                    return View(pageModel);
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
        public ActionResult Delete(string TerritoryID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    RegionBusinessModelLayers regionLUBusinessModelLayers = new RegionBusinessModelLayers();
                    ViewBag.Regions = new SelectList(regionLUBusinessModelLayers.RegionSelect, "RegionID", "RegionDescription");

                    TerritoriesBusinessModelLayers territoriesBusinessModelLayers = new TerritoriesBusinessModelLayers();

                    BusinessModelLayer.TerritoriesSingle territories = territoriesBusinessModelLayers.GetAllTerritoriess().FirstOrDefault(x => x.TerritoryID == TerritoryID);

                    return View(territories);
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
        public ActionResult Delete_Post(string TerritoryID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    TerritoriesBusinessModelLayers territoriesBusinessModelLayers = new TerritoriesBusinessModelLayers();

                    //mm
                    territoriesBusinessModelLayers.DeleteTerritories(TerritoryID);


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
        public ActionResult Details(string TerritoryID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    RegionBusinessModelLayers regionLUBusinessModelLayers = new RegionBusinessModelLayers();
                    ViewBag.Regions = new SelectList(regionLUBusinessModelLayers.RegionSelect, "RegionID", "RegionDescription");

                    TerritoriesBusinessModelLayers territoriesBusinessModelLayers = new TerritoriesBusinessModelLayers();

                    BusinessModelLayer.TerritoriesSingle territories = territoriesBusinessModelLayers.GetAllTerritoriess().FirstOrDefault(x => x.TerritoryID == TerritoryID);

                    return View(territories);
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
                    ViewBag.TerritoryDescriptionSortParm = String.IsNullOrEmpty(sortOrder) ? "TerritoryDescription_desc" : "";

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

                    TerritoriesBusinessModelLayers territoriesBusinessModelLayers = new TerritoriesBusinessModelLayers();
                    List<BusinessModelLayer.Vwterritories> vwterritoriess = territoriesBusinessModelLayers.GetAllVwterritoriess();

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        vwterritoriess = vwterritoriess.Where(s => s.TerritoryDescription.ToString().ToLower().Contains(searchString.ToLower())).ToList();
                    }

                    switch (sortOrder)
                    {
                        case "TerritoryDescription_desc":
                            vwterritoriess = vwterritoriess.OrderByDescending(s => s.TerritoryDescription).ToList();
                            break;
                        //case "!!!":
                        //	vwterritoriess = vwterritoriess.OrderBy(s => s.!!!).ToList();
                        //	break;
                        //case "!!!_desc":
                        //	vwterritoriess = vwterritoriess.OrderByDescending(s => s.!!!).ToList();
                        //	break;
                        default:  // TerritoryDescription ascending 
                            vwterritoriess = vwterritoriess.OrderBy(s => s.TerritoryDescription).ToList();
                            break;
                    }

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;
                    int pageNumber = (page ?? 1);
                    return View(vwterritoriess.ToPagedList(pageNumber, pageSize));
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
