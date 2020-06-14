
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
			public class EmployeesController : Controller
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

					EmployeesBusinessModelLayers employeesLUBusinessModelLayers = new EmployeesBusinessModelLayers();
				ViewBag.Employeess = new SelectList(employeesLUBusinessModelLayers.EmployeesSelect, "EmployeeID", "LastName");
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


					EmployeesBusinessModelLayers employeesLUBusinessModelLayers = new EmployeesBusinessModelLayers();
				ViewBag.Employeess = new SelectList(employeesLUBusinessModelLayers.EmployeesSelect, "EmployeeID", "LastName");
	
					EmployeesBusinessModelLayers employeesBusinessModelLayers = new EmployeesBusinessModelLayers();
					BusinessModelLayer.EmployeesSingle employees = new BusinessModelLayer.EmployeesSingle();
					TryUpdateModel(employees);
					if (ModelState.IsValid)
					{
					//mm
						employeesBusinessModelLayers.AddEmployees(employees);
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
	public ActionResult Edit(int EmployeeID, string sortOrder, string currentFilter, string searchString, int? page, string PgeSize)
	{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {


					EmployeesBusinessModelLayers employeesLUBusinessModelLayers = new EmployeesBusinessModelLayers();
				ViewBag.Employeess = new SelectList(employeesLUBusinessModelLayers.EmployeesSelect, "EmployeeID", "LastName");
	
			ViewBag.CurrentSort = sortOrder;
			ViewBag.EmployeeID = EmployeeID;
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

			//EMPLOYEES TABLE MASTER
			BusinessModelLayer.Employees.EmployeesMasterDetailModel pageModel = new BusinessModelLayer.Employees.EmployeesMasterDetailModel();
			EmployeesBusinessModelLayers employeesBusinessModelLayers = new EmployeesBusinessModelLayers();
			Employees.EmployeesMasterDetailModel employeesMasterDetailModel = new Employees.EmployeesMasterDetailModel();

			pageModel.Employees = employeesBusinessModelLayers.GetAllEmployeess().FirstOrDefault(x => x.EmployeeID == EmployeeID);

			int pageSize = 10;
			if (PgeSize != null)
			{ Int32.TryParse(PgeSize, out pageSize); }
			ViewBag.PgeSize = pageSize;

			int pageNumber = (page ?? 1);

		
			//EMPLOYEETERRITORIES DETAIL BEGIN

			ViewBag.EmployeeIDSortParm = String.IsNullOrEmpty(sortOrder) ? "EmployeeID_desc" : "";
			EmployeeterritoriesBusinessModelLayers employeeterritoriesBusinessModelLayers = new EmployeeterritoriesBusinessModelLayers();
			
			List<BusinessModelLayer.Vwemployeeterritories> employeeterritoriess = employeeterritoriesBusinessModelLayers.GetAllVwemployeeterritoriess().FindAll(x => x.EmployeeID == EmployeeID).ToList();
			
			if (!String.IsNullOrEmpty(searchString))
			{
				employeeterritoriess = employeeterritoriess.Where(s => s.EmployeeID == EmployeeID && s.TerritoryID.ToString().ToLower().Contains(searchString.ToLower())).ToList();
			}

			switch (sortOrder)
			{
				case "EmployeeID_desc":
					employeeterritoriess = employeeterritoriess.OrderByDescending(s => s.EmployeeID).ToList();
					break;
				default:  // EmployeeID ascending 
					employeeterritoriess = employeeterritoriess.OrderBy(s => s.EmployeeID).ToList();
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
    catch(Exception) 
    {
        throw;
    }

	}

	[HttpPost]
	[ActionName("Edit")]
	public ActionResult Edit_Post(EmployeesSingle employees, string sortOrder, string currentFilter, string searchString, int? page, string PgeSize)
	{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {

		EmployeesBusinessModelLayers employeesBusinessModelLayers = new EmployeesBusinessModelLayers();
		if (ModelState.IsValid)
		{
		//mm
			employeesBusinessModelLayers.UpdateEmployees(employees);
			return RedirectToAction("List");
		}

		ViewBag.CurrentSort = sortOrder;
		ViewBag.EmployeeID = employees.EmployeeID;
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

		//EMPLOYEES TABLE MASTER

		BusinessModelLayer.Employees.EmployeesMasterDetailModel pageModel = new BusinessModelLayer.Employees.EmployeesMasterDetailModel
		{
			Employees = employeesBusinessModelLayers.GetAllEmployeess().Single(x => x.EmployeeID == employees.EmployeeID)
		};

			int pageSize = 10;
			if (PgeSize != null)
			{ Int32.TryParse(PgeSize, out pageSize); }
			ViewBag.PgeSize = pageSize;

			int pageNumber = (page ?? 1);

				//EMPLOYEETERRITORIES DETAIL BEGIN
		ViewBag.TerritoryIDSortParm = String.IsNullOrEmpty(sortOrder) ? "TerritoryID_desc" : "";
		EmployeeterritoriesBusinessModelLayers employeeterritoriesBusinessModelLayers = new EmployeeterritoriesBusinessModelLayers();
		pageModel.EmployeeterritoriesVwDetl = employeeterritoriesBusinessModelLayers.GetAllVwemployeeterritoriess().FindAll(x => x.EmployeeID == employees.EmployeeID).ToList().ToPagedList(pageNumber, pageSize);

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
    catch(Exception) 
    {
        throw;
    }

	}

				[HttpGet]
				public ActionResult Delete(int EmployeeID)
				{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {


					EmployeesBusinessModelLayers employeesLUBusinessModelLayers = new EmployeesBusinessModelLayers();
				ViewBag.Employeess = new SelectList(employeesLUBusinessModelLayers.EmployeesSelect, "EmployeeID", "LastName");
	
					EmployeesBusinessModelLayers employeesBusinessModelLayers = new EmployeesBusinessModelLayers();
					
											BusinessModelLayer.EmployeesSingle employees = employeesBusinessModelLayers.GetAllEmployeess().FirstOrDefault(x => x.EmployeeID == EmployeeID);					
						
					return View(employees);
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
				public ActionResult Delete_Post(int EmployeeID)
				{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {


					EmployeesBusinessModelLayers employeesBusinessModelLayers = new EmployeesBusinessModelLayers();
					
					//mm
						employeesBusinessModelLayers.DeleteEmployees(EmployeeID);					
											
										
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
				public ActionResult Details(int EmployeeID)
				{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {


					EmployeesBusinessModelLayers employeesLUBusinessModelLayers = new EmployeesBusinessModelLayers();
				ViewBag.Employeess = new SelectList(employeesLUBusinessModelLayers.EmployeesSelect, "EmployeeID", "LastName");
	
					EmployeesBusinessModelLayers employeesBusinessModelLayers = new EmployeesBusinessModelLayers();
			
											BusinessModelLayer.EmployeesSingle employees = employeesBusinessModelLayers.GetAllEmployeess().FirstOrDefault(x => x.EmployeeID == EmployeeID);					
											
					return View(employees);
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
					ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "LastName_desc" : "";
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

					EmployeesBusinessModelLayers employeesBusinessModelLayers = new EmployeesBusinessModelLayers();
					List<BusinessModelLayer.Vwemployees> vwemployeess = employeesBusinessModelLayers.GetAllVwemployeess();
					
					if (!String.IsNullOrEmpty(searchString))
					{
						vwemployeess = vwemployeess.Where(s => s.LastName.ToString().ToLower().Contains(searchString.ToLower())).ToList();
					}

					switch (sortOrder)
					{
						case "LastName_desc":
							vwemployeess = vwemployeess.OrderByDescending(s => s.LastName).ToList();
							break;
						//case "!!!":
						//	vwemployeess = vwemployeess.OrderBy(s => s.!!!).ToList();
						//	break;
						//case "!!!_desc":
						//	vwemployeess = vwemployeess.OrderByDescending(s => s.!!!).ToList();
						//	break;
						default:  // LastName ascending 
							vwemployeess = vwemployeess.OrderBy(s => s.LastName).ToList();
							break;
					}

					int pageSize = 10;
					if (PgeSize != null)
					{ Int32.TryParse(PgeSize, out pageSize); }
					ViewBag.PgeSize = pageSize;
					int pageNumber = (page ?? 1);
					return View(vwemployeess.ToPagedList(pageNumber, pageSize));
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
