
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
    public class CategoriesController : Controller
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



                    CategoriesBusinessModelLayers categoriesBusinessModelLayers = new CategoriesBusinessModelLayers();
                    BusinessModelLayer.CategoriesSingle categories = new BusinessModelLayer.CategoriesSingle();
                    TryUpdateModel(categories);
                    if (ModelState.IsValid)
                    {
                        //mm
                        categoriesBusinessModelLayers.AddCategories(categories);
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
        public ActionResult Edit(int CategoryID, string sortOrder, string currentFilter, string searchString, int? page, string PgeSize)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {



                    ViewBag.CurrentSort = sortOrder;
                    ViewBag.CategoryID = CategoryID;

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

                    //CATEGORIES TABLE MASTER
                    BusinessModelLayer.Categories.CategoriesMasterDetailModel pageModel = new BusinessModelLayer.Categories.CategoriesMasterDetailModel();
                    CategoriesBusinessModelLayers categoriesBusinessModelLayers = new CategoriesBusinessModelLayers();
                    Categories.CategoriesMasterDetailModel categoriesMasterDetailModel = new Categories.CategoriesMasterDetailModel();

                    pageModel.Categories = categoriesBusinessModelLayers.GetAllCategoriess().FirstOrDefault(x => x.CategoryID == CategoryID);

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;

                    int pageNumber = (page ?? 1);


                    //PRODUCTS DETAIL BEGIN

                    ViewBag.CategoryIDSortParm = String.IsNullOrEmpty(sortOrder) ? "CategoryID_desc" : "";
                    ProductsBusinessModelLayers productsBusinessModelLayers = new ProductsBusinessModelLayers();

                    List<BusinessModelLayer.Vwproducts> productss = productsBusinessModelLayers.GetAllVwproductss().FindAll(x => x.CategoryID == CategoryID).ToList();

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        productss = productss.Where(s => s.CategoryID == CategoryID && s.ProductName.ToString().ToLower().Contains(searchString.ToLower())).ToList();
                    }

                    switch (sortOrder)
                    {
                        case "CategoryID_desc":
                            productss = productss.OrderByDescending(s => s.CategoryID).ToList();
                            break;
                        default:  // CategoryID ascending 
                            productss = productss.OrderBy(s => s.CategoryID).ToList();
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

        [ExceptionHandler]
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(CategoriesSingle categories, string sortOrder, string currentFilter, string searchString, int? page, string PgeSize)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    CategoriesBusinessModelLayers categoriesBusinessModelLayers = new CategoriesBusinessModelLayers();
                    if (ModelState.IsValid)
                    {
                        //mm
                        categoriesBusinessModelLayers.UpdateCategories(categories);
                        return RedirectToAction("List");
                    }

                    ViewBag.CurrentSort = sortOrder;
                    ViewBag.CategoryID = categories.CategoryID;

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

                    //CATEGORIES TABLE MASTER

                    BusinessModelLayer.Categories.CategoriesMasterDetailModel pageModel = new BusinessModelLayer.Categories.CategoriesMasterDetailModel
                    {
                        Categories = categoriesBusinessModelLayers.GetAllCategoriess().Single(x => x.CategoryID == categories.CategoryID)
                    };

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;

                    int pageNumber = (page ?? 1);

                    //PRODUCTS DETAIL BEGIN
                    ViewBag.ProductNameSortParm = String.IsNullOrEmpty(sortOrder) ? "ProductName_desc" : "";
                    ProductsBusinessModelLayers productsBusinessModelLayers = new ProductsBusinessModelLayers();
                    pageModel.ProductsVwDetl = productsBusinessModelLayers.GetAllVwproductss().FindAll(x => x.CategoryID == categories.CategoryID).ToList().ToPagedList(pageNumber, pageSize);

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


        [ExceptionHandler]
        [HttpGet]
        public ActionResult Delete(int CategoryID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {



                    CategoriesBusinessModelLayers categoriesBusinessModelLayers = new CategoriesBusinessModelLayers();

                    BusinessModelLayer.CategoriesSingle categories = categoriesBusinessModelLayers.GetAllCategoriess().FirstOrDefault(x => x.CategoryID == CategoryID);

                    return View(categories);
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
        public ActionResult Delete_Post(int CategoryID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    CategoriesBusinessModelLayers categoriesBusinessModelLayers = new CategoriesBusinessModelLayers();

                    //mm
                    categoriesBusinessModelLayers.DeleteCategories(CategoryID);


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
        public ActionResult Details(int CategoryID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {



                    CategoriesBusinessModelLayers categoriesBusinessModelLayers = new CategoriesBusinessModelLayers();

                    BusinessModelLayer.CategoriesSingle categories = categoriesBusinessModelLayers.GetAllCategoriess().FirstOrDefault(x => x.CategoryID == CategoryID);

                    return View(categories);
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
                    ViewBag.CategoryNameSortParm = String.IsNullOrEmpty(sortOrder) ? "CategoryName_desc" : "";

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

                    CategoriesBusinessModelLayers categoriesBusinessModelLayers = new CategoriesBusinessModelLayers();
                    List<BusinessModelLayer.Vwcategories> vwcategoriess = categoriesBusinessModelLayers.GetAllVwcategoriess();

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        vwcategoriess = vwcategoriess.Where(s => s.CategoryName.ToString().ToLower().Contains(searchString.ToLower())).ToList();
                    }

                    switch (sortOrder)
                    {
                        case "CategoryName_desc":
                            vwcategoriess = vwcategoriess.OrderByDescending(s => s.CategoryName).ToList();
                            break;
                        //case "!!!":
                        //	vwcategoriess = vwcategoriess.OrderBy(s => s.!!!).ToList();
                        //	break;
                        //case "!!!_desc":
                        //	vwcategoriess = vwcategoriess.OrderByDescending(s => s.!!!).ToList();
                        //	break;
                        default:  // CategoryName ascending 
                            vwcategoriess = vwcategoriess.OrderBy(s => s.CategoryName).ToList();
                            break;
                    }

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;
                    int pageNumber = (page ?? 1);
                    return View(vwcategoriess.ToPagedList(pageNumber, pageSize));
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
