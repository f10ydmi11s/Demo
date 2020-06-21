using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessLayer
{
    public class Validation
    {
        public bool IsDate(DateTime? tempDate)
        {
            DateTime fromDateValue;
            if (tempDate == DateTime.MinValue)
            {
                return false;
            }
            else
            {
                if (DateTime.TryParse(tempDate.ToString(), out fromDateValue) == true)
                    return true;
                else
                    return false;
            }
        }
        public List<SelectListItem> PageSize()
        {
            List<SelectListItem> PgeSizes = new List<SelectListItem>()
            {
                new SelectListItem { Text = "5", Value = "5" },
                new SelectListItem { Text = "10", Value = "10" },
                new SelectListItem { Text = "25", Value = "25" },
                new SelectListItem { Text = "50", Value = "50" },
                new SelectListItem { Text = "100", Value = "100" },

            };
            return PgeSizes;
        }


        }
}
