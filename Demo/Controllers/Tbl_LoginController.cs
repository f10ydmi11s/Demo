
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
    public class Tbl_LoginController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        [ExceptionHandler]
        [HttpGet]
        public ActionResult Login()
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    BusinessModelLayer.Tbl_LoginSingle tbl_login = new Tbl_LoginSingle();
                    tbl_login.Username = "admin";
                    tbl_login.Password = "password";

                    return View(tbl_login);
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

        public ActionResult Logout()
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    FormsAuthentication.SignOut();
                    return RedirectToAction("Login");
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
        public ActionResult Verify(string Username, string Password)
        {

            try // handle exogenous exceptions
            {
                try // log all exceptions
                {

                    Tbl_LoginBusinessModelLayers tbl_loginBusinessModelLayers = new Tbl_LoginBusinessModelLayers();

                    BusinessModelLayer.Tbl_LoginSingle tbl_login = tbl_loginBusinessModelLayers.GetAllTbl_Logins().FirstOrDefault(x => x.Username == Username && x.Password == Password);

                    if (tbl_login != null)
                    {
                        UpdateModel<Tbl_LoginSingle>(tbl_login);
                        if (ModelState.IsValid)
                        {
                            FormsAuthentication.SetAuthCookie(tbl_login.Username, false);
                            return RedirectToAction("List", "Orders");
                        }
                    }
                    return View("Error");
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



                    Tbl_LoginBusinessModelLayers tbl_loginBusinessModelLayers = new Tbl_LoginBusinessModelLayers();
                    BusinessModelLayer.Tbl_LoginSingle tbl_login = new BusinessModelLayer.Tbl_LoginSingle();
                    TryUpdateModel(tbl_login);
                    if (ModelState.IsValid)
                    {
                        //mm
                        tbl_loginBusinessModelLayers.AddTbl_Login(tbl_login);
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
        public ActionResult Edit(string Username)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {



                    Tbl_LoginBusinessModelLayers tbl_loginBusinessModelLayers = new Tbl_LoginBusinessModelLayers();

                    BusinessModelLayer.Tbl_LoginSingle tbl_login = tbl_loginBusinessModelLayers.GetAllTbl_Logins().FirstOrDefault(x => x.Username == Username);

                    return View(tbl_login);
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
        public ActionResult Edit_Post(string Username)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    Tbl_LoginBusinessModelLayers tbl_loginBusinessModelLayers = new Tbl_LoginBusinessModelLayers();

                    BusinessModelLayer.Tbl_LoginSingle tbl_login = tbl_loginBusinessModelLayers.GetAllTbl_Logins().Single(x => x.Username == Username);


                    UpdateModel<Tbl_LoginSingle>(tbl_login);
                    if (ModelState.IsValid)
                    {
                        //mm
                        tbl_loginBusinessModelLayers.UpdateTbl_Login(tbl_login);
                        return RedirectToAction("List");
                    }

                    return View(tbl_login);
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
        public ActionResult Delete(string Username)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {



                    Tbl_LoginBusinessModelLayers tbl_loginBusinessModelLayers = new Tbl_LoginBusinessModelLayers();

                    BusinessModelLayer.Tbl_LoginSingle tbl_login = tbl_loginBusinessModelLayers.GetAllTbl_Logins().FirstOrDefault(x => x.Username == Username);

                    return View(tbl_login);
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
        public ActionResult Delete_Post(string Username)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {


                    Tbl_LoginBusinessModelLayers tbl_loginBusinessModelLayers = new Tbl_LoginBusinessModelLayers();

                    //mm
                    tbl_loginBusinessModelLayers.DeleteTbl_Login(Username);


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
        public ActionResult Details(string Username)
        {
            try // handle exogenous exceptions
            {
                try // log all exceptions
                {



                    Tbl_LoginBusinessModelLayers tbl_loginBusinessModelLayers = new Tbl_LoginBusinessModelLayers();

                    BusinessModelLayer.Tbl_LoginSingle tbl_login = tbl_loginBusinessModelLayers.GetAllTbl_Logins().FirstOrDefault(x => x.Username == Username);

                    return View(tbl_login);
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
                    ViewBag.UsernameSortParm = String.IsNullOrEmpty(sortOrder) ? "Username_desc" : "";

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

                    Tbl_LoginBusinessModelLayers tbl_loginBusinessModelLayers = new Tbl_LoginBusinessModelLayers();
                    List<BusinessModelLayer.Vwtbl_login> vwtbl_logins = tbl_loginBusinessModelLayers.GetAllVwtbl_logins();

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        vwtbl_logins = vwtbl_logins.Where(s => s.Username.ToString().ToLower().Contains(searchString.ToLower())).ToList();
                    }

                    switch (sortOrder)
                    {
                        case "Username_desc":
                            vwtbl_logins = vwtbl_logins.OrderByDescending(s => s.Username).ToList();
                            break;
                        //case "!!!":
                        //	vwtbl_logins = vwtbl_logins.OrderBy(s => s.!!!).ToList();
                        //	break;
                        //case "!!!_desc":
                        //	vwtbl_logins = vwtbl_logins.OrderByDescending(s => s.!!!).ToList();
                        //	break;
                        default:  // Username ascending 
                            vwtbl_logins = vwtbl_logins.OrderBy(s => s.Username).ToList();
                            break;
                    }

                    int pageSize = 10;
                    if (PgeSize != null)
                    { Int32.TryParse(PgeSize, out pageSize); }
                    ViewBag.PgeSize = pageSize;
                    int pageNumber = (page ?? 1);
                    return View(vwtbl_logins.ToPagedList(pageNumber, pageSize));
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
