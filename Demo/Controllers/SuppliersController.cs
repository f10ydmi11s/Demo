
using BusinessModelLayer;
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
    public class SuppliersController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }



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

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {



                    SuppliersBusinessModelLayers suppliersBusinessModelLayers = new SuppliersBusinessModelLayers();
                    BusinessModelLayer.SuppliersSingle suppliers = new BusinessModelLayer.SuppliersSingle();
                    TryUpdateModel(suppliers);
                    if (ModelState.IsValid)
                    {
                        //mm
                        suppliersBusinessModelLayers.AddSuppliers(suppliers);
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


        [HttpGet]
        public ActionResult Edit(int SupplierID, string sortOrder, string currentFilter, string searchString, int? page, string PgeSize)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {



                    ViewBag.CurrentSort = sortOrder;
                    ViewBag.SupplierID = SupplierID;

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

                    //SUPPLIERS TABLE MASTER
                    BusinessModelLayer.Suppliers.SuppliersMasterDetailModel pageModel = new BusinessModelLayer.Suppliers.SuppliersMasterDetailModel();
                    SuppliersBusinessModelLayers suppliersBusinessModelLayers = new SuppliersBusinessModelLayers();
                    Suppliers.SuppliersMasterDetailModel suppliersMasterDetailModel = new Suppliers.SuppliersMasterDetailModel();

                    pageModel.Suppliers = suppliersBusinessModelLayers.GetAllSupplierss().FirstOrDefault(x => x.SupplierID == SupplierID);

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;

                    int pageNumber = (page ?? 1);


                    //PRODUCTS DETAIL BEGIN

                    ViewBag.SupplierIDSortParm = String.IsNullOrEmpty(sortOrder) ? "SupplierID_desc" : "";
                    ProductsBusinessModelLayers productsBusinessModelLayers = new ProductsBusinessModelLayers();

                    List<BusinessModelLayer.Vwproducts> productss = productsBusinessModelLayers.GetAllVwproductss().FindAll(x => x.SupplierID == SupplierID).ToList();

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        productss = productss.Where(s => s.SupplierID == SupplierID && s.ProductName.ToString().ToLower().Contains(searchString.ToLower())).ToList();
                    }

                    switch (sortOrder)
                    {
                        case "SupplierID_desc":
                            productss = productss.OrderByDescending(s => s.SupplierID).ToList();
                            break;
                        default:  // SupplierID ascending 
                            productss = productss.OrderBy(s => s.SupplierID).ToList();
                            break;
                    }
                    pageModel.ProductsVwDetl = productss.ToPagedList(pageNumber, pageSize);

                    //PRODUCTS DETAIL END
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

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(SuppliersSingle suppliers, string sortOrder, string currentFilter, string searchString, int? page, string PgeSize)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    SuppliersBusinessModelLayers suppliersBusinessModelLayers = new SuppliersBusinessModelLayers();
                    if (ModelState.IsValid)
                    {
                        //mm
                        suppliersBusinessModelLayers.UpdateSuppliers(suppliers);
                        return RedirectToAction("List");
                    }

                    ViewBag.CurrentSort = sortOrder;
                    ViewBag.SupplierID = suppliers.SupplierID;

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

                    //SUPPLIERS TABLE MASTER

                    BusinessModelLayer.Suppliers.SuppliersMasterDetailModel pageModel = new BusinessModelLayer.Suppliers.SuppliersMasterDetailModel
                    {
                        Suppliers = suppliersBusinessModelLayers.GetAllSupplierss().Single(x => x.SupplierID == suppliers.SupplierID)
                    };

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;

                    int pageNumber = (page ?? 1);

                    //PRODUCTS DETAIL BEGIN
                    ViewBag.ProductNameSortParm = String.IsNullOrEmpty(sortOrder) ? "ProductName_desc" : "";
                    ProductsBusinessModelLayers productsBusinessModelLayers = new ProductsBusinessModelLayers();
                    pageModel.ProductsVwDetl = productsBusinessModelLayers.GetAllVwproductss().FindAll(x => x.SupplierID == suppliers.SupplierID).ToList().ToPagedList(pageNumber, pageSize);

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        pageModel.ProductsVwDetl = pageModel.ProductsVwDetl.Where(s => s.ProductName.ToString().ToLower().Contains(searchString.ToLower())).ToList().ToPagedList(pageNumber, pageSize);
                    }

                    switch (sortOrder)
                    {
                        case "ProductName_desc":
                            pageModel.ProductsVwDetl = pageModel.ProductsVwDetl.OrderByDescending(s => s.ProductName).ToList().ToPagedList(pageNumber, pageSize);
                            break;
                        default:  // ProductName ascending 
                            pageModel.ProductsVwDetl = pageModel.ProductsVwDetl.OrderBy(s => s.ProductName).ToList().ToPagedList(pageNumber, pageSize);
                            break;
                    }
                    //PRODUCTS DETAIL END
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

        [HttpGet]
        public ActionResult Delete(int SupplierID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {



                    SuppliersBusinessModelLayers suppliersBusinessModelLayers = new SuppliersBusinessModelLayers();

                    BusinessModelLayer.SuppliersSingle suppliers = suppliersBusinessModelLayers.GetAllSupplierss().FirstOrDefault(x => x.SupplierID == SupplierID);

                    return View(suppliers);
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

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int SupplierID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    SuppliersBusinessModelLayers suppliersBusinessModelLayers = new SuppliersBusinessModelLayers();

                    //mm
                    suppliersBusinessModelLayers.DeleteSuppliers(SupplierID);


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

        [HttpGet]
        public ActionResult Details(int SupplierID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {



                    SuppliersBusinessModelLayers suppliersBusinessModelLayers = new SuppliersBusinessModelLayers();

                    BusinessModelLayer.SuppliersSingle suppliers = suppliersBusinessModelLayers.GetAllSupplierss().FirstOrDefault(x => x.SupplierID == SupplierID);

                    return View(suppliers);
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
                    ViewBag.ContactNameSortParm = String.IsNullOrEmpty(sortOrder) ? "ContactName_desc" : "";

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

                    SuppliersBusinessModelLayers suppliersBusinessModelLayers = new SuppliersBusinessModelLayers();
                    List<BusinessModelLayer.Vwsuppliers> vwsupplierss = suppliersBusinessModelLayers.GetAllVwsupplierss();

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        vwsupplierss = vwsupplierss.Where(s => s.ContactName.ToString().ToLower().Contains(searchString.ToLower())).ToList();
                    }

                    switch (sortOrder)
                    {
                        case "ContactName_desc":
                            vwsupplierss = vwsupplierss.OrderByDescending(s => s.ContactName).ToList();
                            break;
                        //case "!!!":
                        //	vwsupplierss = vwsupplierss.OrderBy(s => s.!!!).ToList();
                        //	break;
                        //case "!!!_desc":
                        //	vwsupplierss = vwsupplierss.OrderByDescending(s => s.!!!).ToList();
                        //	break;
                        default:  // ContactName ascending 
                            vwsupplierss = vwsupplierss.OrderBy(s => s.ContactName).ToList();
                            break;
                    }

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;
                    int pageNumber = (page ?? 1);
                    return View(vwsupplierss.ToPagedList(pageNumber, pageSize));
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
