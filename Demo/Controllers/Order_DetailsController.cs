
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
    public class Order_DetailsController : Controller
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

                    OrdersBusinessModelLayers ordersLUBusinessModelLayers = new OrdersBusinessModelLayers();
                    ViewBag.Orderss = new SelectList(ordersLUBusinessModelLayers.OrdersSelect, "OrderID", "CustomerID");
                    ProductsBusinessModelLayers productsLUBusinessModelLayers = new ProductsBusinessModelLayers();
                    ViewBag.Productss = new SelectList(productsLUBusinessModelLayers.ProductsSelect, "ProductID", "ProductName");
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


                    OrdersBusinessModelLayers ordersLUBusinessModelLayers = new OrdersBusinessModelLayers();
                    ViewBag.Orderss = new SelectList(ordersLUBusinessModelLayers.OrdersSelect, "OrderID", "CustomerID");
                    ProductsBusinessModelLayers productsLUBusinessModelLayers = new ProductsBusinessModelLayers();
                    ViewBag.Productss = new SelectList(productsLUBusinessModelLayers.ProductsSelect, "ProductID", "ProductName");

                    Order_DetailsBusinessModelLayers order_detailsBusinessModelLayers = new Order_DetailsBusinessModelLayers();
                    BusinessModelLayer.Order_DetailsSingle order_details = new BusinessModelLayer.Order_DetailsSingle();
                    TryUpdateModel(order_details);
                    if (ModelState.IsValid)
                    {
                        //mm
                        order_detailsBusinessModelLayers.AddOrder_Details(order_details);
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
        public ActionResult Edit(int OrderID, int? ProductID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    OrdersBusinessModelLayers ordersLUBusinessModelLayers = new OrdersBusinessModelLayers();
                    ViewBag.Orderss = new SelectList(ordersLUBusinessModelLayers.OrdersSelect, "OrderID", "CustomerID");
                    ProductsBusinessModelLayers productsLUBusinessModelLayers = new ProductsBusinessModelLayers();
                    ViewBag.Productss = new SelectList(productsLUBusinessModelLayers.ProductsSelect, "ProductID", "ProductName");

                    Order_DetailsBusinessModelLayers order_detailsBusinessModelLayers = new Order_DetailsBusinessModelLayers();

                    BusinessModelLayer.Order_DetailsSingle order_details;
                    if (ProductID == null)
                    {
                        order_details = order_detailsBusinessModelLayers.GetAllOrder_Detailss().FirstOrDefault(x => x.OrderID == OrderID);
                    }
                    else
                    {
                        order_details = order_detailsBusinessModelLayers.GetAllOrder_Detailss().FirstOrDefault(x => x.OrderID == OrderID && x.ProductID == ProductID);
                    }

                    return View(order_details);
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
        public ActionResult Edit_Post(int OrderID, int? ProductID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    Order_DetailsBusinessModelLayers order_detailsBusinessModelLayers = new Order_DetailsBusinessModelLayers();

                    BusinessModelLayer.Order_DetailsSingle order_details;
                    if (ProductID == null)
                    {
                        order_details = order_detailsBusinessModelLayers.GetAllOrder_Detailss().Single(x => x.OrderID == OrderID);
                    }
                    else
                    {
                        order_details = order_detailsBusinessModelLayers.GetAllOrder_Detailss().Single(x => x.OrderID == OrderID && x.ProductID == ProductID);
                    }


                    UpdateModel<Order_DetailsSingle>(order_details);
                    if (ModelState.IsValid)
                    {
                        //mm
                        order_detailsBusinessModelLayers.UpdateOrder_Details(order_details);
                        return RedirectToAction("List");
                    }

                    return View(order_details);
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
        public ActionResult Delete(int OrderID, int? ProductID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    OrdersBusinessModelLayers ordersLUBusinessModelLayers = new OrdersBusinessModelLayers();
                    ViewBag.Orderss = new SelectList(ordersLUBusinessModelLayers.OrdersSelect, "OrderID", "CustomerID");
                    ProductsBusinessModelLayers productsLUBusinessModelLayers = new ProductsBusinessModelLayers();
                    ViewBag.Productss = new SelectList(productsLUBusinessModelLayers.ProductsSelect, "ProductID", "ProductName");

                    Order_DetailsBusinessModelLayers order_detailsBusinessModelLayers = new Order_DetailsBusinessModelLayers();

                    BusinessModelLayer.Order_DetailsSingle order_details;
                    if (ProductID == null)
                    {
                        order_details = order_detailsBusinessModelLayers.GetAllOrder_Detailss().FirstOrDefault(x => x.OrderID == OrderID);
                    }
                    else
                    {
                        order_details = order_detailsBusinessModelLayers.GetAllOrder_Detailss().FirstOrDefault(x => x.OrderID == OrderID && x.ProductID == ProductID);
                    }

                    return View(order_details);
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
        public ActionResult Delete_Post(int OrderID, int? ProductID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    Order_DetailsBusinessModelLayers order_detailsBusinessModelLayers = new Order_DetailsBusinessModelLayers();

                    if (ProductID == null)
                    {
                        //mm
                        order_detailsBusinessModelLayers.DeleteOrder_Details(OrderID);
                    }
                    else
                    {
                        //mm
                        order_detailsBusinessModelLayers.EXE_sql("DELETE FROM [Order Details] WHERE (OrderID = " + "N'" + OrderID.ToString() + "'" + ") AND (ProductID = " + "N'" + ProductID.ToString() + "'" + ")");
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
        public ActionResult Details(int OrderID, int? ProductID)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    OrdersBusinessModelLayers ordersLUBusinessModelLayers = new OrdersBusinessModelLayers();
                    ViewBag.Orderss = new SelectList(ordersLUBusinessModelLayers.OrdersSelect, "OrderID", "CustomerID");
                    ProductsBusinessModelLayers productsLUBusinessModelLayers = new ProductsBusinessModelLayers();
                    ViewBag.Productss = new SelectList(productsLUBusinessModelLayers.ProductsSelect, "ProductID", "ProductName");

                    Order_DetailsBusinessModelLayers order_detailsBusinessModelLayers = new Order_DetailsBusinessModelLayers();

                    BusinessModelLayer.Order_DetailsSingle order_details;
                    if (ProductID == null)
                    {
                        order_details = order_detailsBusinessModelLayers.GetAllOrder_Detailss().FirstOrDefault(x => x.OrderID == OrderID);
                    }
                    else
                    {
                        order_details = order_detailsBusinessModelLayers.GetAllOrder_Detailss().FirstOrDefault(x => x.OrderID == OrderID && x.ProductID == ProductID);
                    }

                    return View(order_details);
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
                    ViewBag.OrderIDSortParm = String.IsNullOrEmpty(sortOrder) ? "OrderID_desc" : "";

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

                    Order_DetailsBusinessModelLayers order_detailsBusinessModelLayers = new Order_DetailsBusinessModelLayers();
                    List<BusinessModelLayer.Vworder_details> vworder_detailss = order_detailsBusinessModelLayers.GetAllVworder_detailss();

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        vworder_detailss = vworder_detailss.Where(s => s.OrderID.ToString().ToLower().Contains(searchString.ToLower())).ToList();
                    }

                    switch (sortOrder)
                    {
                        case "OrderID_desc":
                            vworder_detailss = vworder_detailss.OrderByDescending(s => s.OrderID).ToList();
                            break;
                        //case "!!!":
                        //	vworder_detailss = vworder_detailss.OrderBy(s => s.!!!).ToList();
                        //	break;
                        //case "!!!_desc":
                        //	vworder_detailss = vworder_detailss.OrderByDescending(s => s.!!!).ToList();
                        //	break;
                        default:  // OrderID ascending 
                            vworder_detailss = vworder_detailss.OrderBy(s => s.OrderID).ToList();
                            break;
                    }

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;
                    int pageNumber = (page ?? 1);
                    return View(vworder_detailss.ToPagedList(pageNumber, pageSize));
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
