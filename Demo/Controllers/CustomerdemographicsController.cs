
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
    public class CustomerdemographicsController : Controller
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



                    CustomerdemographicsBusinessModelLayers customerdemographicsBusinessModelLayers = new CustomerdemographicsBusinessModelLayers();
                    BusinessModelLayer.CustomerdemographicsSingle customerdemographics = new BusinessModelLayer.CustomerdemographicsSingle();
                    TryUpdateModel(customerdemographics);
                    if (ModelState.IsValid)
                    {
                        //mm
                        customerdemographicsBusinessModelLayers.AddCustomerdemographics(customerdemographics);
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
        public ActionResult Edit(string CustomerTypeID, string sortOrder, string currentFilter, string searchString, int? page, string PgeSize)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {



                    ViewBag.CurrentSort = sortOrder;
                    ViewBag.CustomerTypeID = CustomerTypeID;

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

                    //CUSTOMERDEMOGRAPHICS TABLE MASTER
                    BusinessModelLayer.Customerdemographics.CustomerdemographicsMasterDetailModel pageModel = new BusinessModelLayer.Customerdemographics.CustomerdemographicsMasterDetailModel();
                    CustomerdemographicsBusinessModelLayers customerdemographicsBusinessModelLayers = new CustomerdemographicsBusinessModelLayers();
                    Customerdemographics.CustomerdemographicsMasterDetailModel customerdemographicsMasterDetailModel = new Customerdemographics.CustomerdemographicsMasterDetailModel();

                    pageModel.Customerdemographics = customerdemographicsBusinessModelLayers.GetAllCustomerdemographicss().FirstOrDefault(x => x.CustomerTypeID == CustomerTypeID);

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;

                    int pageNumber = (page ?? 1);


                    //CUSTOMERCUSTOMERDEMO DETAIL BEGIN

                    ViewBag.CustomerTypeIDSortParm = String.IsNullOrEmpty(sortOrder) ? "CustomerTypeID_desc" : "";
                    CustomercustomerdemoBusinessModelLayers customercustomerdemoBusinessModelLayers = new CustomercustomerdemoBusinessModelLayers();

                    List<BusinessModelLayer.Vwcustomercustomerdemo> customercustomerdemos = customercustomerdemoBusinessModelLayers.GetAllVwcustomercustomerdemos().FindAll(x => x.CustomerTypeID == CustomerTypeID).ToList();

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        customercustomerdemos = customercustomerdemos.Where(s => s.CustomerTypeID == CustomerTypeID && s.CustomerTypeID.ToString().ToLower().Contains(searchString.ToLower())).ToList();
                    }

                    switch (sortOrder)
                    {
                        case "CustomerTypeID_desc":
                            customercustomerdemos = customercustomerdemos.OrderByDescending(s => s.CustomerTypeID).ToList();
                            break;
                        default:  // CustomerTypeID ascending 
                            customercustomerdemos = customercustomerdemos.OrderBy(s => s.CustomerTypeID).ToList();
                            break;
                    }
                    pageModel.CustomercustomerdemoVwDetl = customercustomerdemos.ToPagedList(pageNumber, pageSize);

                    //CUSTOMERCUSTOMERDEMO DETAIL END
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
        public ActionResult Edit_Post(CustomerdemographicsSingle customerdemographics, string sortOrder, string currentFilter, string searchString, int? page, string PgeSize)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    CustomerdemographicsBusinessModelLayers customerdemographicsBusinessModelLayers = new CustomerdemographicsBusinessModelLayers();
                    if (ModelState.IsValid)
                    {
                        //mm
                        customerdemographicsBusinessModelLayers.UpdateCustomerdemographics(customerdemographics);
                        return RedirectToAction("List");
                    }

                    ViewBag.CurrentSort = sortOrder;
                    ViewBag.CustomerTypeID = customerdemographics.CustomerTypeID;

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

                    //CUSTOMERDEMOGRAPHICS TABLE MASTER

                    BusinessModelLayer.Customerdemographics.CustomerdemographicsMasterDetailModel pageModel = new BusinessModelLayer.Customerdemographics.CustomerdemographicsMasterDetailModel
                    {
                        Customerdemographics = customerdemographicsBusinessModelLayers.GetAllCustomerdemographicss().Single(x => x.CustomerTypeID == customerdemographics.CustomerTypeID)
                    };

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;

                    int pageNumber = (page ?? 1);

                    //CUSTOMERCUSTOMERDEMO DETAIL BEGIN
                    ViewBag.CustomerIDSortParm = String.IsNullOrEmpty(sortOrder) ? "CustomerID_desc" : "";
                    CustomercustomerdemoBusinessModelLayers customercustomerdemoBusinessModelLayers = new CustomercustomerdemoBusinessModelLayers();
                    pageModel.CustomercustomerdemoVwDetl = customercustomerdemoBusinessModelLayers.GetAllVwcustomercustomerdemos().FindAll(x => x.CustomerTypeID == customerdemographics.CustomerTypeID).ToList().ToPagedList(pageNumber, pageSize);

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        pageModel.CustomercustomerdemoVwDetl = pageModel.CustomercustomerdemoVwDetl.Where(s => s.CustomerID.ToString().ToLower().Contains(searchString.ToLower())).ToList().ToPagedList(pageNumber, pageSize);
                    }

                    switch (sortOrder)
                    {
                        case "CustomerID_desc":
                            pageModel.CustomercustomerdemoVwDetl = pageModel.CustomercustomerdemoVwDetl.OrderByDescending(s => s.CustomerID).ToList().ToPagedList(pageNumber, pageSize);
                            break;
                        default:  // CustomerID ascending 
                            pageModel.CustomercustomerdemoVwDetl = pageModel.CustomercustomerdemoVwDetl.OrderBy(s => s.CustomerID).ToList().ToPagedList(pageNumber, pageSize);
                            break;
                    }
                    //CUSTOMERCUSTOMERDEMO DETAIL END
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
        public ActionResult Delete(string CustomerTypeID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {



                    CustomerdemographicsBusinessModelLayers customerdemographicsBusinessModelLayers = new CustomerdemographicsBusinessModelLayers();

                    BusinessModelLayer.CustomerdemographicsSingle customerdemographics = customerdemographicsBusinessModelLayers.GetAllCustomerdemographicss().FirstOrDefault(x => x.CustomerTypeID == CustomerTypeID);

                    return View(customerdemographics);
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
        public ActionResult Delete_Post(string CustomerTypeID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    CustomerdemographicsBusinessModelLayers customerdemographicsBusinessModelLayers = new CustomerdemographicsBusinessModelLayers();

                    //mm
                    customerdemographicsBusinessModelLayers.DeleteCustomerdemographics(CustomerTypeID);


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
        public ActionResult Details(string CustomerTypeID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {



                    CustomerdemographicsBusinessModelLayers customerdemographicsBusinessModelLayers = new CustomerdemographicsBusinessModelLayers();

                    BusinessModelLayer.CustomerdemographicsSingle customerdemographics = customerdemographicsBusinessModelLayers.GetAllCustomerdemographicss().FirstOrDefault(x => x.CustomerTypeID == CustomerTypeID);

                    return View(customerdemographics);
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
                    ViewBag.CustomerDescSortParm = String.IsNullOrEmpty(sortOrder) ? "CustomerDesc_desc" : "";

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

                    CustomerdemographicsBusinessModelLayers customerdemographicsBusinessModelLayers = new CustomerdemographicsBusinessModelLayers();
                    List<BusinessModelLayer.Vwcustomerdemographics> vwcustomerdemographicss = customerdemographicsBusinessModelLayers.GetAllVwcustomerdemographicss();

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        vwcustomerdemographicss = vwcustomerdemographicss.Where(s => s.CustomerDesc.ToString().ToLower().Contains(searchString.ToLower())).ToList();
                    }

                    switch (sortOrder)
                    {
                        case "CustomerDesc_desc":
                            vwcustomerdemographicss = vwcustomerdemographicss.OrderByDescending(s => s.CustomerDesc).ToList();
                            break;
                        //case "!!!":
                        //	vwcustomerdemographicss = vwcustomerdemographicss.OrderBy(s => s.!!!).ToList();
                        //	break;
                        //case "!!!_desc":
                        //	vwcustomerdemographicss = vwcustomerdemographicss.OrderByDescending(s => s.!!!).ToList();
                        //	break;
                        default:  // CustomerDesc ascending 
                            vwcustomerdemographicss = vwcustomerdemographicss.OrderBy(s => s.CustomerDesc).ToList();
                            break;
                    }

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;
                    int pageNumber = (page ?? 1);
                    return View(vwcustomerdemographicss.ToPagedList(pageNumber, pageSize));
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
