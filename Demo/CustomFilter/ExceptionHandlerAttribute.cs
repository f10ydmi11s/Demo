
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.CustomFilter
{
    public class ExceptionHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {

                BusinessLayer.ExceptionLogging exlog = new BusinessLayer.ExceptionLogging();
                exlog.SendExcepToDB(filterContext.Exception);

                filterContext.ExceptionHandled = true;
                throw new Exception("A Technical Error occurred, Please visit after some time.");
            }
        }
    }
}