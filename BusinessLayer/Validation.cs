using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
