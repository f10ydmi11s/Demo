
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
			public class CustomercustomerdemoController : Controller
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

					CustomersBusinessModelLayers customersLUBusinessModelLayers = new CustomersBusinessModelLayers();
				ViewBag.Customerss = new SelectList(customersLUBusinessModelLayers.CustomersSelect, "CustomerID", "CompanyName");
					CustomerdemographicsBusinessModelLayers customerdemographicsLUBusinessModelLayers = new CustomerdemographicsBusinessModelLayers();
				ViewBag.CustomerDemographicss = new SelectList(customerdemographicsLUBusinessModelLayers.CustomerdemographicsSelect, "CustomerTypeID", "CustomerDesc");
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


					CustomersBusinessModelLayers customersLUBusinessModelLayers = new CustomersBusinessModelLayers();
				ViewBag.Customerss = new SelectList(customersLUBusinessModelLayers.CustomersSelect, "CustomerID", "CompanyName");
					CustomerdemographicsBusinessModelLayers customerdemographicsLUBusinessModelLayers = new CustomerdemographicsBusinessModelLayers();
				ViewBag.CustomerDemographicss = new SelectList(customerdemographicsLUBusinessModelLayers.CustomerdemographicsSelect, "CustomerTypeID", "CustomerDesc");
	
					CustomercustomerdemoBusinessModelLayers customercustomerdemoBusinessModelLayers = new CustomercustomerdemoBusinessModelLayers();
					BusinessModelLayer.CustomercustomerdemoSingle customercustomerdemo = new BusinessModelLayer.CustomercustomerdemoSingle();
					TryUpdateModel(customercustomerdemo);
					if (ModelState.IsValid)
					{
					//mm
						customercustomerdemoBusinessModelLayers.AddCustomercustomerdemo(customercustomerdemo);
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
				public ActionResult Edit(string CustomerID, string CustomerTypeID)
				{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {


					CustomersBusinessModelLayers customersLUBusinessModelLayers = new CustomersBusinessModelLayers();
				ViewBag.Customerss = new SelectList(customersLUBusinessModelLayers.CustomersSelect, "CustomerID", "CompanyName");
					CustomerdemographicsBusinessModelLayers customerdemographicsLUBusinessModelLayers = new CustomerdemographicsBusinessModelLayers();
				ViewBag.CustomerDemographicss = new SelectList(customerdemographicsLUBusinessModelLayers.CustomerdemographicsSelect, "CustomerTypeID", "CustomerDesc");
	
					CustomercustomerdemoBusinessModelLayers customercustomerdemoBusinessModelLayers = new CustomercustomerdemoBusinessModelLayers();
					
											BusinessModelLayer.CustomercustomerdemoSingle customercustomerdemo;
						if (CustomerTypeID == null)
						{
							customercustomerdemo = customercustomerdemoBusinessModelLayers.GetAllCustomercustomerdemos().FirstOrDefault(x => x.CustomerID == CustomerID);
						} else
						{
							customercustomerdemo = customercustomerdemoBusinessModelLayers.GetAllCustomercustomerdemos().FirstOrDefault(x => x.CustomerID == CustomerID && x.CustomerTypeID == CustomerTypeID);
						}	
									
					return View(customercustomerdemo);
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
				public ActionResult Edit_Post(string CustomerID, string CustomerTypeID)
				{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {


					CustomercustomerdemoBusinessModelLayers customercustomerdemoBusinessModelLayers = new CustomercustomerdemoBusinessModelLayers();
					
											BusinessModelLayer.CustomercustomerdemoSingle customercustomerdemo;
						if (CustomerTypeID == null)
						{
							customercustomerdemo = customercustomerdemoBusinessModelLayers.GetAllCustomercustomerdemos().Single(x => x.CustomerID == CustomerID);
						} else
						{
							customercustomerdemo = customercustomerdemoBusinessModelLayers.GetAllCustomercustomerdemos().Single(x => x.CustomerID == CustomerID && x.CustomerTypeID == CustomerTypeID);
						}	
					

					UpdateModel<CustomercustomerdemoSingle>(customercustomerdemo);
					if (ModelState.IsValid)
					{
//mm
						customercustomerdemoBusinessModelLayers.UpdateCustomercustomerdemo(customercustomerdemo);
						return RedirectToAction("List");
					}

					return View(customercustomerdemo);
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
				public ActionResult Delete(string CustomerID, string CustomerTypeID)
				{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {


					CustomersBusinessModelLayers customersLUBusinessModelLayers = new CustomersBusinessModelLayers();
				ViewBag.Customerss = new SelectList(customersLUBusinessModelLayers.CustomersSelect, "CustomerID", "CompanyName");
					CustomerdemographicsBusinessModelLayers customerdemographicsLUBusinessModelLayers = new CustomerdemographicsBusinessModelLayers();
				ViewBag.CustomerDemographicss = new SelectList(customerdemographicsLUBusinessModelLayers.CustomerdemographicsSelect, "CustomerTypeID", "CustomerDesc");
	
					CustomercustomerdemoBusinessModelLayers customercustomerdemoBusinessModelLayers = new CustomercustomerdemoBusinessModelLayers();
					
											BusinessModelLayer.CustomercustomerdemoSingle customercustomerdemo;
						if (CustomerTypeID == null)
						{
							customercustomerdemo = customercustomerdemoBusinessModelLayers.GetAllCustomercustomerdemos().FirstOrDefault(x => x.CustomerID == CustomerID);
						} else
						{
							customercustomerdemo = customercustomerdemoBusinessModelLayers.GetAllCustomercustomerdemos().FirstOrDefault(x => x.CustomerID == CustomerID && x.CustomerTypeID == CustomerTypeID);
						}	
					
					return View(customercustomerdemo);
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
				public ActionResult Delete_Post(string CustomerID, string CustomerTypeID)
				{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {


					CustomercustomerdemoBusinessModelLayers customercustomerdemoBusinessModelLayers = new CustomercustomerdemoBusinessModelLayers();
					
											if (CustomerTypeID == null)
						{
//mm
							customercustomerdemoBusinessModelLayers.DeleteCustomercustomerdemo(CustomerID);
						} else
						{
						//mm
							customercustomerdemoBusinessModelLayers.EXE_sql("DELETE FROM [CustomerCustomerDemo] WHERE (CustomerID = " + "N'" + CustomerID.ToString() + "'" + ") AND (CustomerTypeID = " + "N'" + CustomerTypeID.ToString() + "'" + ")");
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
    catch(Exception) 
    {
        throw;
    }

				}

				[HttpGet]
				public ActionResult Details(string CustomerID, string CustomerTypeID)
				{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {


					CustomersBusinessModelLayers customersLUBusinessModelLayers = new CustomersBusinessModelLayers();
				ViewBag.Customerss = new SelectList(customersLUBusinessModelLayers.CustomersSelect, "CustomerID", "CompanyName");
					CustomerdemographicsBusinessModelLayers customerdemographicsLUBusinessModelLayers = new CustomerdemographicsBusinessModelLayers();
				ViewBag.CustomerDemographicss = new SelectList(customerdemographicsLUBusinessModelLayers.CustomerdemographicsSelect, "CustomerTypeID", "CustomerDesc");
	
					CustomercustomerdemoBusinessModelLayers customercustomerdemoBusinessModelLayers = new CustomercustomerdemoBusinessModelLayers();
			
											BusinessModelLayer.CustomercustomerdemoSingle customercustomerdemo;
						if (CustomerTypeID == null)
						{
							customercustomerdemo = customercustomerdemoBusinessModelLayers.GetAllCustomercustomerdemos().FirstOrDefault(x => x.CustomerID == CustomerID);
						} else
						{
							customercustomerdemo = customercustomerdemoBusinessModelLayers.GetAllCustomercustomerdemos().FirstOrDefault(x => x.CustomerID == CustomerID && x.CustomerTypeID == CustomerTypeID);
						}	
										
					return View(customercustomerdemo);
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

					CustomercustomerdemoBusinessModelLayers customercustomerdemoBusinessModelLayers = new CustomercustomerdemoBusinessModelLayers();
					List<BusinessModelLayer.Vwcustomercustomerdemo> vwcustomercustomerdemos = customercustomerdemoBusinessModelLayers.GetAllVwcustomercustomerdemos();
					
					if (!String.IsNullOrEmpty(searchString))
					{
						vwcustomercustomerdemos = vwcustomercustomerdemos.Where(s => s.CustomerID.ToString().ToLower().Contains(searchString.ToLower())).ToList();
					}

					switch (sortOrder)
					{
						case "CustomerID_desc":
							vwcustomercustomerdemos = vwcustomercustomerdemos.OrderByDescending(s => s.CustomerID).ToList();
							break;
						//case "!!!":
						//	vwcustomercustomerdemos = vwcustomercustomerdemos.OrderBy(s => s.!!!).ToList();
						//	break;
						//case "!!!_desc":
						//	vwcustomercustomerdemos = vwcustomercustomerdemos.OrderByDescending(s => s.!!!).ToList();
						//	break;
						default:  // CustomerID ascending 
							vwcustomercustomerdemos = vwcustomercustomerdemos.OrderBy(s => s.CustomerID).ToList();
							break;
					}

					int pageSize = 10;
					if (PgeSize != null)
					{ Int32.TryParse(PgeSize, out pageSize); }
					ViewBag.PgeSize = pageSize;
					int pageNumber = (page ?? 1);
					return View(vwcustomercustomerdemos.ToPagedList(pageNumber, pageSize));
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
