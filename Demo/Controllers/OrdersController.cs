
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
			public class OrdersController : Controller
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

					ShippersBusinessModelLayers shippersLUBusinessModelLayers = new ShippersBusinessModelLayers();
				ViewBag.Shipperss = new SelectList(shippersLUBusinessModelLayers.ShippersSelect, "ShipperID", "CompanyName");
					EmployeesBusinessModelLayers employeesLUBusinessModelLayers = new EmployeesBusinessModelLayers();
				ViewBag.Employeess = new SelectList(employeesLUBusinessModelLayers.EmployeesSelect, "EmployeeID", "LastName");
					CustomersBusinessModelLayers customersLUBusinessModelLayers = new CustomersBusinessModelLayers();
				ViewBag.Customerss = new SelectList(customersLUBusinessModelLayers.CustomersSelect, "CustomerID", "CompanyName");
						return View();
            }
            catch (Exception ex)
            {
                BusinessLayer.ExceptionLogging exlog = new BusinessLayer.ExceptionLogging();
                exlog.SendExcepToDB(ex);
                throw;
            }
    }
    catch(Exception) 
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


					ShippersBusinessModelLayers shippersLUBusinessModelLayers = new ShippersBusinessModelLayers();
				ViewBag.Shipperss = new SelectList(shippersLUBusinessModelLayers.ShippersSelect, "ShipperID", "CompanyName");
					EmployeesBusinessModelLayers employeesLUBusinessModelLayers = new EmployeesBusinessModelLayers();
				ViewBag.Employeess = new SelectList(employeesLUBusinessModelLayers.EmployeesSelect, "EmployeeID", "LastName");
					CustomersBusinessModelLayers customersLUBusinessModelLayers = new CustomersBusinessModelLayers();
				ViewBag.Customerss = new SelectList(customersLUBusinessModelLayers.CustomersSelect, "CustomerID", "CompanyName");
	
					OrdersBusinessModelLayers ordersBusinessModelLayers = new OrdersBusinessModelLayers();
					BusinessModelLayer.OrdersSingle orders = new BusinessModelLayer.OrdersSingle();
					TryUpdateModel(orders);
					if (ModelState.IsValid)
					{
					//mm
						ordersBusinessModelLayers.AddOrders(orders);
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
    catch(Exception) 
    {
        throw;
    }

				}

					
	[HttpGet]
	public ActionResult Edit(int OrderID, string sortOrder, string currentFilter, string searchString, int? page, string PgeSize)
	{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {


					ShippersBusinessModelLayers shippersLUBusinessModelLayers = new ShippersBusinessModelLayers();
				ViewBag.Shipperss = new SelectList(shippersLUBusinessModelLayers.ShippersSelect, "ShipperID", "CompanyName");
					EmployeesBusinessModelLayers employeesLUBusinessModelLayers = new EmployeesBusinessModelLayers();
				ViewBag.Employeess = new SelectList(employeesLUBusinessModelLayers.EmployeesSelect, "EmployeeID", "LastName");
					CustomersBusinessModelLayers customersLUBusinessModelLayers = new CustomersBusinessModelLayers();
				ViewBag.Customerss = new SelectList(customersLUBusinessModelLayers.CustomersSelect, "CustomerID", "CompanyName");
	
			ViewBag.CurrentSort = sortOrder;
			ViewBag.OrderID = OrderID;

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

			//ORDERS TABLE MASTER
			BusinessModelLayer.Orders.OrdersMasterDetailModel pageModel = new BusinessModelLayer.Orders.OrdersMasterDetailModel();
			OrdersBusinessModelLayers ordersBusinessModelLayers = new OrdersBusinessModelLayers();
			Orders.OrdersMasterDetailModel ordersMasterDetailModel = new Orders.OrdersMasterDetailModel();

			pageModel.Orders = ordersBusinessModelLayers.GetAllOrderss().FirstOrDefault(x => x.OrderID == OrderID);

			int pageSize = 10;
			if (PgeSize != null)
			{ Int32.TryParse(PgeSize, out pageSize); }
			ViewBag.PgeSize = pageSize;

			int pageNumber = (page ?? 1);

		
			//ORDER_DETAILS DETAIL BEGIN

			ViewBag.OrderIDSortParm = String.IsNullOrEmpty(sortOrder) ? "OrderID_desc" : "";
			Order_DetailsBusinessModelLayers order_detailsBusinessModelLayers = new Order_DetailsBusinessModelLayers();
			
			List<BusinessModelLayer.Vworder_details> order_detailss = order_detailsBusinessModelLayers.GetAllVworder_detailss().FindAll(x => x.OrderID == OrderID).ToList();
			
			if (!String.IsNullOrEmpty(searchString))
			{
				order_detailss = order_detailss.Where(s => s.OrderID == OrderID && s.ProductID.ToString().ToLower().Contains(searchString.ToLower())).ToList();
			}

			switch (sortOrder)
			{
				case "OrderID_desc":
					order_detailss = order_detailss.OrderByDescending(s => s.OrderID).ToList();
					break;
				default:  // OrderID ascending 
					order_detailss = order_detailss.OrderBy(s => s.OrderID).ToList();
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
    catch(Exception) 
    {
        throw;
    }

	}

	[HttpPost]
	[ActionName("Edit")]
	public ActionResult Edit_Post(OrdersSingle orders, string sortOrder, string currentFilter, string searchString, int? page, string PgeSize)
	{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {

		OrdersBusinessModelLayers ordersBusinessModelLayers = new OrdersBusinessModelLayers();
		if (ModelState.IsValid)
		{
		//mm
			ordersBusinessModelLayers.UpdateOrders(orders);
			return RedirectToAction("List");
		}

		ViewBag.CurrentSort = sortOrder;
		ViewBag.OrderID = orders.OrderID;

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

		//ORDERS TABLE MASTER

		BusinessModelLayer.Orders.OrdersMasterDetailModel pageModel = new BusinessModelLayer.Orders.OrdersMasterDetailModel
		{
			Orders = ordersBusinessModelLayers.GetAllOrderss().Single(x => x.OrderID == orders.OrderID)
		};

			int pageSize = 10;
			if (PgeSize != null)
			{ Int32.TryParse(PgeSize, out pageSize); }
			ViewBag.PgeSize = pageSize;

			int pageNumber = (page ?? 1);

				//ORDER_DETAILS DETAIL BEGIN
		ViewBag.OrderIDSortParm = String.IsNullOrEmpty(sortOrder) ? "OrderID_desc" : "";
		Order_DetailsBusinessModelLayers order_detailsBusinessModelLayers = new Order_DetailsBusinessModelLayers();
		pageModel.Order_DetailsVwDetl = order_detailsBusinessModelLayers.GetAllVworder_detailss().FindAll(x => x.OrderID == orders.OrderID).ToList().ToPagedList(pageNumber, pageSize);

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
    catch(Exception) 
    {
        throw;
    }

	}

				[HttpGet]
				public ActionResult Delete(int OrderID)
				{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {


					ShippersBusinessModelLayers shippersLUBusinessModelLayers = new ShippersBusinessModelLayers();
				ViewBag.Shipperss = new SelectList(shippersLUBusinessModelLayers.ShippersSelect, "ShipperID", "CompanyName");
					EmployeesBusinessModelLayers employeesLUBusinessModelLayers = new EmployeesBusinessModelLayers();
				ViewBag.Employeess = new SelectList(employeesLUBusinessModelLayers.EmployeesSelect, "EmployeeID", "LastName");
					CustomersBusinessModelLayers customersLUBusinessModelLayers = new CustomersBusinessModelLayers();
				ViewBag.Customerss = new SelectList(customersLUBusinessModelLayers.CustomersSelect, "CustomerID", "CompanyName");
	
					OrdersBusinessModelLayers ordersBusinessModelLayers = new OrdersBusinessModelLayers();
					
											BusinessModelLayer.OrdersSingle orders = ordersBusinessModelLayers.GetAllOrderss().FirstOrDefault(x => x.OrderID == OrderID);					
						
					return View(orders);
            }
            catch (Exception ex)
            {
                BusinessLayer.ExceptionLogging exlog = new BusinessLayer.ExceptionLogging();
                exlog.SendExcepToDB(ex);
                throw;
            }
    }
    catch(Exception) 
    {
        throw;
    }

				}

				[HttpPost]
				[ActionName("Delete")]
				public ActionResult Delete_Post(int OrderID)
				{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {


					OrdersBusinessModelLayers ordersBusinessModelLayers = new OrdersBusinessModelLayers();
					
					//mm
						ordersBusinessModelLayers.DeleteOrders(OrderID);					
											
										
					return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                BusinessLayer.ExceptionLogging exlog = new BusinessLayer.ExceptionLogging();
                exlog.SendExcepToDB(ex);
                throw;
            }
    }
    catch(Exception) 
    {
        throw;
    }

				}

				[HttpGet]
				public ActionResult Details(int OrderID)
				{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {


					ShippersBusinessModelLayers shippersLUBusinessModelLayers = new ShippersBusinessModelLayers();
				ViewBag.Shipperss = new SelectList(shippersLUBusinessModelLayers.ShippersSelect, "ShipperID", "CompanyName");
					EmployeesBusinessModelLayers employeesLUBusinessModelLayers = new EmployeesBusinessModelLayers();
				ViewBag.Employeess = new SelectList(employeesLUBusinessModelLayers.EmployeesSelect, "EmployeeID", "LastName");
					CustomersBusinessModelLayers customersLUBusinessModelLayers = new CustomersBusinessModelLayers();
				ViewBag.Customerss = new SelectList(customersLUBusinessModelLayers.CustomersSelect, "CustomerID", "CompanyName");
	
					OrdersBusinessModelLayers ordersBusinessModelLayers = new OrdersBusinessModelLayers();
			
											BusinessModelLayer.OrdersSingle orders = ordersBusinessModelLayers.GetAllOrderss().FirstOrDefault(x => x.OrderID == OrderID);					
											
					return View(orders);
            }
            catch (Exception ex)
            {
                BusinessLayer.ExceptionLogging exlog = new BusinessLayer.ExceptionLogging();
                exlog.SendExcepToDB(ex);
                throw;
            }
    }
    catch(Exception) 
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
					ViewBag.CustomerIDSortParm = String.IsNullOrEmpty(sortOrder) ? "CustomerID_desc" : "";

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

					OrdersBusinessModelLayers ordersBusinessModelLayers = new OrdersBusinessModelLayers();
					List<BusinessModelLayer.Vworders> vworderss = ordersBusinessModelLayers.GetAllVworderss();
					
					if (!String.IsNullOrEmpty(searchString))
					{
						vworderss = vworderss.Where(s => s.CustomerID.ToString().ToLower().Contains(searchString.ToLower())).ToList();
					}

					switch (sortOrder)
					{
						case "CustomerID_desc":
							vworderss = vworderss.OrderByDescending(s => s.CustomerID).ToList();
							break;
						//case "!!!":
						//	vworderss = vworderss.OrderBy(s => s.!!!).ToList();
						//	break;
						//case "!!!_desc":
						//	vworderss = vworderss.OrderByDescending(s => s.!!!).ToList();
						//	break;
						default:  // CustomerID ascending 
							vworderss = vworderss.OrderBy(s => s.CustomerID).ToList();
							break;
					}

					int pageSize = 10;
					if (PgeSize != null)
					{ Int32.TryParse(PgeSize, out pageSize); }
					ViewBag.PgeSize = pageSize;
					int pageNumber = (page ?? 1);
					return View(vworderss.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                BusinessLayer.ExceptionLogging exlog = new BusinessLayer.ExceptionLogging();
                exlog.SendExcepToDB(ex);
                throw;
            }
    }
    catch(Exception) 
    {
        throw;
    }

				}



			}
		}
