using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{

    public class Vwemployeeterritories
    {
        [DisplayName("Employeeid")]
        public int EmployeeID { get; set; }
        [DisplayName("Territoryid")]
        public string TerritoryID { get; set; }
    }
}
