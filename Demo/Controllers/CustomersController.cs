
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
			public class CustomersController : Controller
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


	
					CustomersBusinessModelLayers customersBusinessModelLayers = new CustomersBusinessModelLayers();
					BusinessModelLayer.CustomersSingle customers = new BusinessModelLayer.CustomersSingle();
					TryUpdateModel(customers);
					if (ModelState.IsValid)
					{
					//mm
						customersBusinessModelLayers.AddCustomers(customers);
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
	public ActionResult Edit(string CustomerID, string sortOrder, string currentFilter, string searchString, int? page, string PgeSize)
	{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {


	
			ViewBag.CurrentSort = sortOrder;
			ViewBag.CustomerID = CustomerID;
			List<SelectListItem> PgeSizes = new List<SelectListItem>()
			{
				new SelectListItem { Text = "5", Value = "5" },
				new SelectListItem { Text = "10", Value = "10" },
				new SelectListItem { Text = "25", Value = "25" },
				new SelectListItem { Text = "50", Value = "50" },
				new SelectListItem { Text = "100", Value = "100" },

			};
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

			//CUSTOMERS TABLE MASTER
			BusinessModelLayer.Customers.CustomersMasterDetailModel pageModel = new BusinessModelLayer.Customers.CustomersMasterDetailModel();
			CustomersBusinessModelLayers customersBusinessModelLayers = new CustomersBusinessModelLayers();
			Customers.CustomersMasterDetailModel customersMasterDetailModel = new Customers.CustomersMasterDetailModel();

			pageModel.Customers = customersBusinessModelLayers.GetAllCustomerss().FirstOrDefault(x => x.CustomerID == CustomerID);

			int pageSize = 10;
			if (PgeSize != null)
			{ Int32.TryParse(PgeSize, out pageSize); }
			ViewBag.PgeSize = pageSize;

			int pageNumber = (page ?? 1);

		
			//ORDERS DETAIL BEGIN

			ViewBag.CustomerIDSortParm = String.IsNullOrEmpty(sortOrder) ? "CustomerID_desc" : "";
			OrdersBusinessModelLayers ordersBusinessModelLayers = new OrdersBusinessModelLayers();
			
			List<BusinessModelLayer.Vworders> orderss = ordersBusinessModelLayers.GetAllVworderss().FindAll(x => x.CustomerID == CustomerID).ToList();
			
			if (!String.IsNullOrEmpty(searchString))
			{
				orderss = orderss.Where(s => s.CustomerID == CustomerID && s.CustomerID.ToString().ToLower().Contains(searchString.ToLower())).ToList();
			}

			switch (sortOrder)
			{
				case "CustomerID_desc":
					orderss = orderss.OrderByDescending(s => s.CustomerID).ToList();
					break;
				default:  // CustomerID ascending 
					orderss = orderss.OrderBy(s => s.CustomerID).ToList();
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
    catch(Exception) 
    {
        throw;
    }

	}

	[HttpPost]
	[ActionName("Edit")]
	public ActionResult Edit_Post(CustomersSingle customers, string sortOrder, string currentFilter, string searchString, int? page, string PgeSize)
	{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {

		CustomersBusinessModelLayers customersBusinessModelLayers = new CustomersBusinessModelLayers();
		if (ModelState.IsValid)
		{
		//mm
			customersBusinessModelLayers.UpdateCustomers(customers);
			return RedirectToAction("List");
		}

		ViewBag.CurrentSort = sortOrder;
		ViewBag.CustomerID = customers.CustomerID;
		List<SelectListItem> PgeSizes = new List<SelectListItem>()
		{
			new SelectListItem { Text = "5", Value = "5" },
			new SelectListItem { Text = "10", Value = "10" },
			new SelectListItem { Text = "25", Value = "25" },
			new SelectListItem { Text = "50", Value = "50" },
			new SelectListItem { Text = "100", Value = "100" },

		};
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

		//CUSTOMERS TABLE MASTER

		BusinessModelLayer.Customers.CustomersMasterDetailModel pageModel = new BusinessModelLayer.Customers.CustomersMasterDetailModel
		{
			Customers = customersBusinessModelLayers.GetAllCustomerss().Single(x => x.CustomerID == customers.CustomerID)
		};

			int pageSize = 10;
			if (PgeSize != null)
			{ Int32.TryParse(PgeSize, out pageSize); }
			ViewBag.PgeSize = pageSize;

			int pageNumber = (page ?? 1);

				//ORDERS DETAIL BEGIN
		ViewBag.CustomerIDSortParm = String.IsNullOrEmpty(sortOrder) ? "CustomerID_desc" : "";
		OrdersBusinessModelLayers ordersBusinessModelLayers = new OrdersBusinessModelLayers();
		pageModel.OrdersVwDetl = ordersBusinessModelLayers.GetAllVworderss().FindAll(x => x.CustomerID == customers.CustomerID).ToList().ToPagedList(pageNumber, pageSize);

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
    catch(Exception) 
    {
        throw;
    }

	}

				[HttpGet]
				public ActionResult Delete(string CustomerID)
				{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {


	
					CustomersBusinessModelLayers customersBusinessModelLayers = new CustomersBusinessModelLayers();
					
											BusinessModelLayer.CustomersSingle customers = customersBusinessModelLayers.GetAllCustomerss().FirstOrDefault(x => x.CustomerID == CustomerID);					
						
					return View(customers);
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
				public ActionResult Delete_Post(string CustomerID)
				{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {


					CustomersBusinessModelLayers customersBusinessModelLayers = new CustomersBusinessModelLayers();
					
					//mm
						customersBusinessModelLayers.DeleteCustomers(CustomerID);					
											
										
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
				public ActionResult Details(string CustomerID)
				{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {


	
					CustomersBusinessModelLayers customersBusinessModelLayers = new CustomersBusinessModelLayers();
			
											BusinessModelLayer.CustomersSingle customers = customersBusinessModelLayers.GetAllCustomerss().FirstOrDefault(x => x.CustomerID == CustomerID);					
											
					return View(customers);
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
					ViewBag.ContactNameSortParm = String.IsNullOrEmpty(sortOrder) ? "ContactName_desc" : "";
					List<SelectListItem> PgeSizes = new List<SelectListItem>()
					{
						new SelectListItem { Text = "5", Value = "5" },
						new SelectListItem { Text = "10", Value = "10" },
						new SelectListItem { Text = "25", Value = "25" },
						new SelectListItem { Text = "50", Value = "50" },
						new SelectListItem { Text = "100", Value = "100" },

					};
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

					CustomersBusinessModelLayers customersBusinessModelLayers = new CustomersBusinessModelLayers();
					List<BusinessModelLayer.Vwcustomers> vwcustomerss = customersBusinessModelLayers.GetAllVwcustomerss();
					
					if (!String.IsNullOrEmpty(searchString))
					{
						vwcustomerss = vwcustomerss.Where(s => s.ContactName.ToString().ToLower().Contains(searchString.ToLower())).ToList();
					}

					switch (sortOrder)
					{
						case "ContactName_desc":
							vwcustomerss = vwcustomerss.OrderByDescending(s => s.ContactName).ToList();
							break;
						//case "!!!":
						//	vwcustomerss = vwcustomerss.OrderBy(s => s.!!!).ToList();
						//	break;
						//case "!!!_desc":
						//	vwcustomerss = vwcustomerss.OrderByDescending(s => s.!!!).ToList();
						//	break;
						default:  // ContactName ascending 
							vwcustomerss = vwcustomerss.OrderBy(s => s.ContactName).ToList();
							break;
					}

					int pageSize = 10;
					if (PgeSize != null)
					{ Int32.TryParse(PgeSize, out pageSize); }
					ViewBag.PgeSize = pageSize;
					int pageNumber = (page ?? 1);
					return View(vwcustomerss.ToPagedList(pageNumber, pageSize));
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
