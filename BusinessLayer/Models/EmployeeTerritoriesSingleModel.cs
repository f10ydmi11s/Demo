using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace BusinessModelLayer
{
    public class EmployeeterritoriesSingle
    {
        [Key]
        [Required(ErrorMessage = "EmployeeID is required")]
        [DisplayName("EmployeeID")]
        public int EmployeeID { get; set; }
        [Key]
        [Required(ErrorMessage = "TerritoryID is required")]
        [DisplayName("TerritoryID")]
        public string TerritoryID { get; set; }
    }
}
