
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
    public class ProductsController : Controller
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

                    CategoriesBusinessModelLayers categoriesLUBusinessModelLayers = new CategoriesBusinessModelLayers();
                    ViewBag.Categoriess = new SelectList(categoriesLUBusinessModelLayers.CategoriesSelect, "CategoryID", "CategoryName");
                    SuppliersBusinessModelLayers suppliersLUBusinessModelLayers = new SuppliersBusinessModelLayers();
                    ViewBag.Supplierss = new SelectList(suppliersLUBusinessModelLayers.SuppliersSelect, "SupplierID", "CompanyName");
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


                    CategoriesBusinessModelLayers categoriesLUBusinessModelLayers = new CategoriesBusinessModelLayers();
                    ViewBag.Categoriess = new SelectList(categoriesLUBusinessModelLayers.CategoriesSelect, "CategoryID", "CategoryName");
                    SuppliersBusinessModelLayers suppliersLUBusinessModelLayers = new SuppliersBusinessModelLayers();
                    ViewBag.Supplierss = new SelectList(suppliersLUBusinessModelLayers.SuppliersSelect, "SupplierID", "CompanyName");

                    ProductsBusinessModelLayers productsBusinessModelLayers = new ProductsBusinessModelLayers();
                    BusinessModelLayer.ProductsSingle products = new BusinessModelLayer.ProductsSingle();
                    TryUpdateModel(products);
                    if (ModelState.IsValid)
                    {
                        //mm
                        productsBusinessModelLayers.AddProducts(products);
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
        public ActionResult Edit(int ProductID, string sortOrder, string currentFilter, string searchString, int? page, string PgeSize)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    CategoriesBusinessModelLayers categoriesLUBusinessModelLayers = new CategoriesBusinessModelLayers();
                    ViewBag.Categoriess = new SelectList(categoriesLUBusinessModelLayers.CategoriesSelect, "CategoryID", "CategoryName");
                    SuppliersBusinessModelLayers suppliersLUBusinessModelLayers = new SuppliersBusinessModelLayers();
                    ViewBag.Supplierss = new SelectList(suppliersLUBusinessModelLayers.SuppliersSelect, "SupplierID", "CompanyName");

                    ViewBag.CurrentSort = sortOrder;
                    ViewBag.ProductID = ProductID;

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

                    //PRODUCTS TABLE MASTER
                    BusinessModelLayer.Products.ProductsMasterDetailModel pageModel = new BusinessModelLayer.Products.ProductsMasterDetailModel();
                    ProductsBusinessModelLayers productsBusinessModelLayers = new ProductsBusinessModelLayers();
                    Products.ProductsMasterDetailModel productsMasterDetailModel = new Products.ProductsMasterDetailModel();

                    pageModel.Products = productsBusinessModelLayers.GetAllProductss().FirstOrDefault(x => x.ProductID == ProductID);

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;

                    int pageNumber = (page ?? 1);


                    //ORDER_DETAILS DETAIL BEGIN

                    ViewBag.ProductIDSortParm = String.IsNullOrEmpty(sortOrder) ? "ProductID_desc" : "";
                    Order_DetailsBusinessModelLayers order_detailsBusinessModelLayers = new Order_DetailsBusinessModelLayers();

                    List<BusinessModelLayer.Vworder_details> order_detailss = order_detailsBusinessModelLayers.GetAllVworder_detailss().FindAll(x => x.ProductID == ProductID).ToList();

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        order_detailss = order_detailss.Where(s => s.ProductID == ProductID && s.ProductID.ToString().ToLower().Contains(searchString.ToLower())).ToList();
                    }

                    switch (sortOrder)
                    {
                        case "ProductID_desc":
                            order_detailss = order_detailss.OrderByDescending(s => s.ProductID).ToList();
                            break;
                        default:  // ProductID ascending 
                            order_detailss = order_detailss.OrderBy(s => s.ProductID).ToList();
                            break;
                    }
                    pageModel.Order_DetailsVwDetl = order_detailss.ToPagedList(pageNumber, pageSize);

                    //ORDER_DETAILS DETAIL END
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
        public ActionResult Edit_Post(ProductsSingle products, string sortOrder, string currentFilter, string searchString, int? page, string PgeSize)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    ProductsBusinessModelLayers productsBusinessModelLayers = new ProductsBusinessModelLayers();
                    if (ModelState.IsValid)
                    {
                        //mm
                        productsBusinessModelLayers.UpdateProducts(products);
                        return RedirectToAction("List");
                    }

                    ViewBag.CurrentSort = sortOrder;
                    ViewBag.ProductID = products.ProductID;

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

                    //PRODUCTS TABLE MASTER

                    BusinessModelLayer.Products.ProductsMasterDetailModel pageModel = new BusinessModelLayer.Products.ProductsMasterDetailModel
                    {
                        Products = productsBusinessModelLayers.GetAllProductss().Single(x => x.ProductID == products.ProductID)
                    };

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;

                    int pageNumber = (page ?? 1);

                    //ORDER_DETAILS DETAIL BEGIN
                    ViewBag.OrderIDSortParm = String.IsNullOrEmpty(sortOrder) ? "OrderID_desc" : "";
                    Order_DetailsBusinessModelLayers order_detailsBusinessModelLayers = new Order_DetailsBusinessModelLayers();
                    pageModel.Order_DetailsVwDetl = order_detailsBusinessModelLayers.GetAllVworder_detailss().FindAll(x => x.ProductID == products.ProductID).ToList().ToPagedList(pageNumber, pageSize);

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        pageModel.Order_DetailsVwDetl = pageModel.Order_DetailsVwDetl.Where(s => s.OrderID.ToString().ToLower().Contains(searchString.ToLower())).ToList().ToPagedList(pageNumber, pageSize);
                    }

                    switch (sortOrder)
                    {
                        case "OrderID_desc":
                            pageModel.Order_DetailsVwDetl = pageModel.Order_DetailsVwDetl.OrderByDescending(s => s.OrderID).ToList().ToPagedList(pageNumber, pageSize);
                            break;
                        default:  // OrderID ascending 
                            pageModel.Order_DetailsVwDetl = pageModel.Order_DetailsVwDetl.OrderBy(s => s.OrderID).ToList().ToPagedList(pageNumber, pageSize);
                            break;
                    }
                    //ORDER_DETAILS DETAIL END
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
        public ActionResult Delete(int ProductID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    CategoriesBusinessModelLayers categoriesLUBusinessModelLayers = new CategoriesBusinessModelLayers();
                    ViewBag.Categoriess = new SelectList(categoriesLUBusinessModelLayers.CategoriesSelect, "CategoryID", "CategoryName");
                    SuppliersBusinessModelLayers suppliersLUBusinessModelLayers = new SuppliersBusinessModelLayers();
                    ViewBag.Supplierss = new SelectList(suppliersLUBusinessModelLayers.SuppliersSelect, "SupplierID", "CompanyName");

                    ProductsBusinessModelLayers productsBusinessModelLayers = new ProductsBusinessModelLayers();

                    BusinessModelLayer.ProductsSingle products = productsBusinessModelLayers.GetAllProductss().FirstOrDefault(x => x.ProductID == ProductID);

                    return View(products);
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
        public ActionResult Delete_Post(int ProductID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    ProductsBusinessModelLayers productsBusinessModelLayers = new ProductsBusinessModelLayers();

                    //mm
                    productsBusinessModelLayers.DeleteProducts(ProductID);


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
        public ActionResult Details(int ProductID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    CategoriesBusinessModelLayers categoriesLUBusinessModelLayers = new CategoriesBusinessModelLayers();
                    ViewBag.Categoriess = new SelectList(categoriesLUBusinessModelLayers.CategoriesSelect, "CategoryID", "CategoryName");
                    SuppliersBusinessModelLayers suppliersLUBusinessModelLayers = new SuppliersBusinessModelLayers();
                    ViewBag.Supplierss = new SelectList(suppliersLUBusinessModelLayers.SuppliersSelect, "SupplierID", "CompanyName");

                    ProductsBusinessModelLayers productsBusinessModelLayers = new ProductsBusinessModelLayers();

                    BusinessModelLayer.ProductsSingle products = productsBusinessModelLayers.GetAllProductss().FirstOrDefault(x => x.ProductID == ProductID);

                    return View(products);
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
                    ViewBag.ProductNameSortParm = String.IsNullOrEmpty(sortOrder) ? "ProductName_desc" : "";

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

                    ProductsBusinessModelLayers productsBusinessModelLayers = new ProductsBusinessModelLayers();
                    List<BusinessModelLayer.Vwproducts> vwproductss = productsBusinessModelLayers.GetAllVwproductss();

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        vwproductss = vwproductss.Where(s => s.ProductName.ToString().ToLower().Contains(searchString.ToLower())).ToList();
                    }

                    switch (sortOrder)
                    {
                        case "ProductName_desc":
                            vwproductss = vwproductss.OrderByDescending(s => s.ProductName).ToList();
                            break;
                        //case "!!!":
                        //	vwproductss = vwproductss.OrderBy(s => s.!!!).ToList();
                        //	break;
                        //case "!!!_desc":
                        //	vwproductss = vwproductss.OrderByDescending(s => s.!!!).ToList();
                        //	break;
                        default:  // ProductName ascending 
                            vwproductss = vwproductss.OrderBy(s => s.ProductName).ToList();
                            break;
                    }

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;
                    int pageNumber = (page ?? 1);
                    return View(vwproductss.ToPagedList(pageNumber, pageSize));
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
