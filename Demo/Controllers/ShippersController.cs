
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
    public class ShippersController : Controller
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



                    ShippersBusinessModelLayers shippersBusinessModelLayers = new ShippersBusinessModelLayers();
                    BusinessModelLayer.ShippersSingle shippers = new BusinessModelLayer.ShippersSingle();
                    TryUpdateModel(shippers);
                    if (ModelState.IsValid)
                    {
                        //mm
                        shippersBusinessModelLayers.AddShippers(shippers);
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
        public ActionResult Edit(int ShipperID, string sortOrder, string currentFilter, string searchString, int? page, string PgeSize)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {



                    ViewBag.CurrentSort = sortOrder;
                    ViewBag.ShipperID = ShipperID;

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

                    //SHIPPERS TABLE MASTER
                    BusinessModelLayer.Shippers.ShippersMasterDetailModel pageModel = new BusinessModelLayer.Shippers.ShippersMasterDetailModel();
                    ShippersBusinessModelLayers shippersBusinessModelLayers = new ShippersBusinessModelLayers();
                    Shippers.ShippersMasterDetailModel shippersMasterDetailModel = new Shippers.ShippersMasterDetailModel();

                    pageModel.Shippers = shippersBusinessModelLayers.GetAllShipperss().FirstOrDefault(x => x.ShipperID == ShipperID);

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;

                    int pageNumber = (page ?? 1);


                    //ORDERS DETAIL BEGIN

                    ViewBag.ShipViaSortParm = String.IsNullOrEmpty(sortOrder) ? "ShipVia_desc" : "";
                    OrdersBusinessModelLayers ordersBusinessModelLayers = new OrdersBusinessModelLayers();

                    List<BusinessModelLayer.Vworders> orderss = ordersBusinessModelLayers.GetAllVworderss().FindAll(x => x.ShipVia == ShipperID).ToList();

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        orderss = orderss.Where(s => s.ShipVia == ShipperID && s.CustomerID.ToString().ToLower().Contains(searchString.ToLower())).ToList();
                    }

                    switch (sortOrder)
                    {
                        case "ShipVia_desc":
                            orderss = orderss.OrderByDescending(s => s.ShipVia).ToList();
                            break;
                        default:  // ShipVia ascending 
                            orderss = orderss.OrderBy(s => s.ShipVia).ToList();
                            break;
                    }
                    pageModel.OrdersVwDetl = orderss.ToPagedList(pageNumber, pageSize);

                    //ORDERS DETAIL END
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
        public ActionResult Edit_Post(ShippersSingle shippers, string sortOrder, string currentFilter, string searchString, int? page, string PgeSize)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    ShippersBusinessModelLayers shippersBusinessModelLayers = new ShippersBusinessModelLayers();
                    if (ModelState.IsValid)
                    {
                        //mm
                        shippersBusinessModelLayers.UpdateShippers(shippers);
                        return RedirectToAction("List");
                    }

                    ViewBag.CurrentSort = sortOrder;
                    ViewBag.ShipperID = shippers.ShipperID;

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

                    //SHIPPERS TABLE MASTER

                    BusinessModelLayer.Shippers.ShippersMasterDetailModel pageModel = new BusinessModelLayer.Shippers.ShippersMasterDetailModel
                    {
                        Shippers = shippersBusinessModelLayers.GetAllShipperss().Single(x => x.ShipperID == shippers.ShipperID)
                    };

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;

                    int pageNumber = (page ?? 1);

                    //ORDERS DETAIL BEGIN
                    ViewBag.CustomerIDSortParm = String.IsNullOrEmpty(sortOrder) ? "CustomerID_desc" : "";
                    OrdersBusinessModelLayers ordersBusinessModelLayers = new OrdersBusinessModelLayers();
                    pageModel.OrdersVwDetl = ordersBusinessModelLayers.GetAllVworderss().FindAll(x => x.ShipVia == shippers.ShipperID).ToList().ToPagedList(pageNumber, pageSize);

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        pageModel.OrdersVwDetl = pageModel.OrdersVwDetl.Where(s => s.CustomerID.ToString().ToLower().Contains(searchString.ToLower())).ToList().ToPagedList(pageNumber, pageSize);
                    }

                    switch (sortOrder)
                    {
                        case "CustomerID_desc":
                            pageModel.OrdersVwDetl = pageModel.OrdersVwDetl.OrderByDescending(s => s.CustomerID).ToList().ToPagedList(pageNumber, pageSize);
                            break;
                        default:  // CustomerID ascending 
                            pageModel.OrdersVwDetl = pageModel.OrdersVwDetl.OrderBy(s => s.CustomerID).ToList().ToPagedList(pageNumber, pageSize);
                            break;
                    }
                    //ORDERS DETAIL END
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
        public ActionResult Delete(int ShipperID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {



                    ShippersBusinessModelLayers shippersBusinessModelLayers = new ShippersBusinessModelLayers();

                    BusinessModelLayer.ShippersSingle shippers = shippersBusinessModelLayers.GetAllShipperss().FirstOrDefault(x => x.ShipperID == ShipperID);

                    return View(shippers);
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
        public ActionResult Delete_Post(int ShipperID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    ShippersBusinessModelLayers shippersBusinessModelLayers = new ShippersBusinessModelLayers();

                    //mm
                    shippersBusinessModelLayers.DeleteShippers(ShipperID);


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
        public ActionResult Details(int ShipperID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {



                    ShippersBusinessModelLayers shippersBusinessModelLayers = new ShippersBusinessModelLayers();

                    BusinessModelLayer.ShippersSingle shippers = shippersBusinessModelLayers.GetAllShipperss().FirstOrDefault(x => x.ShipperID == ShipperID);

                    return View(shippers);
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
                    ViewBag.CompanyNameSortParm = String.IsNullOrEmpty(sortOrder) ? "CompanyName_desc" : "";

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

                    ShippersBusinessModelLayers shippersBusinessModelLayers = new ShippersBusinessModelLayers();
                    List<BusinessModelLayer.Vwshippers> vwshipperss = shippersBusinessModelLayers.GetAllVwshipperss();

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        vwshipperss = vwshipperss.Where(s => s.CompanyName.ToString().ToLower().Contains(searchString.ToLower())).ToList();
                    }

                    switch (sortOrder)
                    {
                        case "CompanyName_desc":
                            vwshipperss = vwshipperss.OrderByDescending(s => s.CompanyName).ToList();
                            break;
                        //case "!!!":
                        //	vwshipperss = vwshipperss.OrderBy(s => s.!!!).ToList();
                        //	break;
                        //case "!!!_desc":
                        //	vwshipperss = vwshipperss.OrderByDescending(s => s.!!!).ToList();
                        //	break;
                        default:  // CompanyName ascending 
                            vwshipperss = vwshipperss.OrderBy(s => s.CompanyName).ToList();
                            break;
                    }

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;
                    int pageNumber = (page ?? 1);
                    return View(vwshipperss.ToPagedList(pageNumber, pageSize));
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
