
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
    public class Tbl_ExceptionloggingtodatabaseController : Controller
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



                    Tbl_ExceptionloggingtodatabaseBusinessModelLayers tbl_exceptionloggingtodatabaseBusinessModelLayers = new Tbl_ExceptionloggingtodatabaseBusinessModelLayers();
                    BusinessModelLayer.Tbl_ExceptionloggingtodatabaseSingle tbl_exceptionloggingtodatabase = new BusinessModelLayer.Tbl_ExceptionloggingtodatabaseSingle();
                    TryUpdateModel(tbl_exceptionloggingtodatabase);
                    if (ModelState.IsValid)
                    {
                        //mm
                        tbl_exceptionloggingtodatabaseBusinessModelLayers.AddTbl_Exceptionloggingtodatabase(tbl_exceptionloggingtodatabase);
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
        public ActionResult Edit(long Logid)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {



                    Tbl_ExceptionloggingtodatabaseBusinessModelLayers tbl_exceptionloggingtodatabaseBusinessModelLayers = new Tbl_ExceptionloggingtodatabaseBusinessModelLayers();

                    BusinessModelLayer.Tbl_ExceptionloggingtodatabaseSingle tbl_exceptionloggingtodatabase = tbl_exceptionloggingtodatabaseBusinessModelLayers.GetAllTbl_Exceptionloggingtodatabases().FirstOrDefault(x => x.Logid == Logid);

                    return View(tbl_exceptionloggingtodatabase);
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
        public ActionResult Edit_Post(long Logid)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    Tbl_ExceptionloggingtodatabaseBusinessModelLayers tbl_exceptionloggingtodatabaseBusinessModelLayers = new Tbl_ExceptionloggingtodatabaseBusinessModelLayers();

                    BusinessModelLayer.Tbl_ExceptionloggingtodatabaseSingle tbl_exceptionloggingtodatabase = tbl_exceptionloggingtodatabaseBusinessModelLayers.GetAllTbl_Exceptionloggingtodatabases().Single(x => x.Logid == Logid);


                    UpdateModel<Tbl_ExceptionloggingtodatabaseSingle>(tbl_exceptionloggingtodatabase);
                    if (ModelState.IsValid)
                    {
                        //mm
                        tbl_exceptionloggingtodatabaseBusinessModelLayers.UpdateTbl_Exceptionloggingtodatabase(tbl_exceptionloggingtodatabase);
                        return RedirectToAction("List");
                    }

                    return View(tbl_exceptionloggingtodatabase);
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
        public ActionResult Delete(long Logid)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {



                    Tbl_ExceptionloggingtodatabaseBusinessModelLayers tbl_exceptionloggingtodatabaseBusinessModelLayers = new Tbl_ExceptionloggingtodatabaseBusinessModelLayers();

                    BusinessModelLayer.Tbl_ExceptionloggingtodatabaseSingle tbl_exceptionloggingtodatabase = tbl_exceptionloggingtodatabaseBusinessModelLayers.GetAllTbl_Exceptionloggingtodatabases().FirstOrDefault(x => x.Logid == Logid);

                    return View(tbl_exceptionloggingtodatabase);
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
        public ActionResult Delete_Post(long Logid)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    Tbl_ExceptionloggingtodatabaseBusinessModelLayers tbl_exceptionloggingtodatabaseBusinessModelLayers = new Tbl_ExceptionloggingtodatabaseBusinessModelLayers();

                    //mm
                    tbl_exceptionloggingtodatabaseBusinessModelLayers.DeleteTbl_Exceptionloggingtodatabase(Logid);


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
        public ActionResult Details(long Logid)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {



                    Tbl_ExceptionloggingtodatabaseBusinessModelLayers tbl_exceptionloggingtodatabaseBusinessModelLayers = new Tbl_ExceptionloggingtodatabaseBusinessModelLayers();

                    BusinessModelLayer.Tbl_ExceptionloggingtodatabaseSingle tbl_exceptionloggingtodatabase = tbl_exceptionloggingtodatabaseBusinessModelLayers.GetAllTbl_Exceptionloggingtodatabases().FirstOrDefault(x => x.Logid == Logid);

                    return View(tbl_exceptionloggingtodatabase);
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
                    ViewBag.ExceptionMsgSortParm = String.IsNullOrEmpty(sortOrder) ? "ExceptionMsg_desc" : "";

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

                    Tbl_ExceptionloggingtodatabaseBusinessModelLayers tbl_exceptionloggingtodatabaseBusinessModelLayers = new Tbl_ExceptionloggingtodatabaseBusinessModelLayers();
                    List<BusinessModelLayer.Vwtbl_exceptionloggingtodatabase> vwtbl_exceptionloggingtodatabases = tbl_exceptionloggingtodatabaseBusinessModelLayers.GetAllVwtbl_exceptionloggingtodatabases();

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        vwtbl_exceptionloggingtodatabases = vwtbl_exceptionloggingtodatabases.Where(s => s.ExceptionMsg.ToString().ToLower().Contains(searchString.ToLower())).ToList();
                    }

                    switch (sortOrder)
                    {
                        case "ExceptionMsg_desc":
                            vwtbl_exceptionloggingtodatabases = vwtbl_exceptionloggingtodatabases.OrderByDescending(s => s.ExceptionMsg).ToList();
                            break;
                        //case "!!!":
                        //	vwtbl_exceptionloggingtodatabases = vwtbl_exceptionloggingtodatabases.OrderBy(s => s.!!!).ToList();
                        //	break;
                        //case "!!!_desc":
                        //	vwtbl_exceptionloggingtodatabases = vwtbl_exceptionloggingtodatabases.OrderByDescending(s => s.!!!).ToList();
                        //	break;
                        default:  // ExceptionMsg ascending 
                            vwtbl_exceptionloggingtodatabases = vwtbl_exceptionloggingtodatabases.OrderBy(s => s.ExceptionMsg).ToList();
                            break;
                    }

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;
                    int pageNumber = (page ?? 1);
                    return View(vwtbl_exceptionloggingtodatabases.ToPagedList(pageNumber, pageSize));
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
