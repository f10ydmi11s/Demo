
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
			public class RegionController : Controller
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


	
					RegionBusinessModelLayers regionBusinessModelLayers = new RegionBusinessModelLayers();
					BusinessModelLayer.RegionSingle region = new BusinessModelLayer.RegionSingle();
					TryUpdateModel(region);
					if (ModelState.IsValid)
					{
					//mm
						regionBusinessModelLayers.AddRegion(region);
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
	public ActionResult Edit(int RegionID, string sortOrder, string currentFilter, string searchString, int? page, string PgeSize)
	{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {


	
			ViewBag.CurrentSort = sortOrder;
			ViewBag.RegionID = RegionID;
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

			//REGION TABLE MASTER
			BusinessModelLayer.Region.RegionMasterDetailModel pageModel = new BusinessModelLayer.Region.RegionMasterDetailModel();
			RegionBusinessModelLayers regionBusinessModelLayers = new RegionBusinessModelLayers();
			Region.RegionMasterDetailModel regionMasterDetailModel = new Region.RegionMasterDetailModel();

			pageModel.Region = regionBusinessModelLayers.GetAllRegions().FirstOrDefault(x => x.RegionID == RegionID);

			int pageSize = 10;
			if (PgeSize != null)
			{ Int32.TryParse(PgeSize, out pageSize); }
			ViewBag.PgeSize = pageSize;

			int pageNumber = (page ?? 1);

		
			//TERRITORIES DETAIL BEGIN

			ViewBag.RegionIDSortParm = String.IsNullOrEmpty(sortOrder) ? "RegionID_desc" : "";
			TerritoriesBusinessModelLayers territoriesBusinessModelLayers = new TerritoriesBusinessModelLayers();
			
			List<BusinessModelLayer.Vwterritories> territoriess = territoriesBusinessModelLayers.GetAllVwterritoriess().FindAll(x => x.RegionID == RegionID).ToList();
			
			if (!String.IsNullOrEmpty(searchString))
			{
				territoriess = territoriess.Where(s => s.RegionID == RegionID && s.TerritoryDescription.ToString().ToLower().Contains(searchString.ToLower())).ToList();
			}

			switch (sortOrder)
			{
				case "RegionID_desc":
					territoriess = territoriess.OrderByDescending(s => s.RegionID).ToList();
					break;
				default:  // RegionID ascending 
					territoriess = territoriess.OrderBy(s => s.RegionID).ToList();
					break;
			}
			pageModel.TerritoriesVwDetl = territoriess.ToPagedList(pageNumber, pageSize);

			//TERRITORIES DETAIL END
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
	public ActionResult Edit_Post(RegionSingle region, string sortOrder, string currentFilter, string searchString, int? page, string PgeSize)
	{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {

		RegionBusinessModelLayers regionBusinessModelLayers = new RegionBusinessModelLayers();
		if (ModelState.IsValid)
		{
		//mm
			regionBusinessModelLayers.UpdateRegion(region);
			return RedirectToAction("List");
		}

		ViewBag.CurrentSort = sortOrder;
		ViewBag.RegionID = region.RegionID;
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

		//REGION TABLE MASTER

		BusinessModelLayer.Region.RegionMasterDetailModel pageModel = new BusinessModelLayer.Region.RegionMasterDetailModel
		{
			Region = regionBusinessModelLayers.GetAllRegions().Single(x => x.RegionID == region.RegionID)
		};

			int pageSize = 10;
			if (PgeSize != null)
			{ Int32.TryParse(PgeSize, out pageSize); }
			ViewBag.PgeSize = pageSize;

			int pageNumber = (page ?? 1);

				//TERRITORIES DETAIL BEGIN
		ViewBag.TerritoryDescriptionSortParm = String.IsNullOrEmpty(sortOrder) ? "TerritoryDescription_desc" : "";
		TerritoriesBusinessModelLayers territoriesBusinessModelLayers = new TerritoriesBusinessModelLayers();
		pageModel.TerritoriesVwDetl = territoriesBusinessModelLayers.GetAllVwterritoriess().FindAll(x => x.RegionID == region.RegionID).ToList().ToPagedList(pageNumber, pageSize);

		if (!String.IsNullOrEmpty(searchString))
		{
			pageModel.TerritoriesVwDetl = pageModel.TerritoriesVwDetl.Where(s => s.TerritoryDescription.ToString().ToLower().Contains(searchString.ToLower())).ToList().ToPagedList(pageNumber, pageSize);
		}

		switch (sortOrder)
		{
			case "TerritoryDescription_desc":
				pageModel.TerritoriesVwDetl = pageModel.TerritoriesVwDetl.OrderByDescending(s => s.TerritoryDescription).ToList().ToPagedList(pageNumber, pageSize);
				break;
			default:  // TerritoryDescription ascending 
				pageModel.TerritoriesVwDetl = pageModel.TerritoriesVwDetl.OrderBy(s => s.TerritoryDescription).ToList().ToPagedList(pageNumber, pageSize);
				break;
		}
		//TERRITORIES DETAIL END
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
				public ActionResult Delete(int RegionID)
				{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {


	
					RegionBusinessModelLayers regionBusinessModelLayers = new RegionBusinessModelLayers();
					
											BusinessModelLayer.RegionSingle region = regionBusinessModelLayers.GetAllRegions().FirstOrDefault(x => x.RegionID == RegionID);					
						
					return View(region);
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
				public ActionResult Delete_Post(int RegionID)
				{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {


					RegionBusinessModelLayers regionBusinessModelLayers = new RegionBusinessModelLayers();
					
					//mm
						regionBusinessModelLayers.DeleteRegion(RegionID);					
											
										
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
				public ActionResult Details(int RegionID)
				{
    try // handle exogenous exceptions
    {  
            try // log all exceptions
            {


	
					RegionBusinessModelLayers regionBusinessModelLayers = new RegionBusinessModelLayers();
			
											BusinessModelLayer.RegionSingle region = regionBusinessModelLayers.GetAllRegions().FirstOrDefault(x => x.RegionID == RegionID);					
											
					return View(region);
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
					ViewBag.RegionDescriptionSortParm = String.IsNullOrEmpty(sortOrder) ? "RegionDescription_desc" : "";
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

					RegionBusinessModelLayers regionBusinessModelLayers = new RegionBusinessModelLayers();
					List<BusinessModelLayer.Vwregion> vwregions = regionBusinessModelLayers.GetAllVwregions();
					
					if (!String.IsNullOrEmpty(searchString))
					{
						vwregions = vwregions.Where(s => s.RegionDescription.ToString().ToLower().Contains(searchString.ToLower())).ToList();
					}

					switch (sortOrder)
					{
						case "RegionDescription_desc":
							vwregions = vwregions.OrderByDescending(s => s.RegionDescription).ToList();
							break;
						//case "!!!":
						//	vwregions = vwregions.OrderBy(s => s.!!!).ToList();
						//	break;
						//case "!!!_desc":
						//	vwregions = vwregions.OrderByDescending(s => s.!!!).ToList();
						//	break;
						default:  // RegionDescription ascending 
							vwregions = vwregions.OrderBy(s => s.RegionDescription).ToList();
							break;
					}

					int pageSize = 10;
					if (PgeSize != null)
					{ Int32.TryParse(PgeSize, out pageSize); }
					ViewBag.PgeSize = pageSize;
					int pageNumber = (page ?? 1);
					return View(vwregions.ToPagedList(pageNumber, pageSize));
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
