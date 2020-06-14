using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace BusinessModelLayer
{
    public class EmployeesSingle
    {
        [Key]
        [Required(ErrorMessage = "EmployeeID is required")]
        [DisplayName("EmployeeID")]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        [DisplayName("LastName")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        [DisplayName("FirstName")]
        public string FirstName { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Title")]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("TitleOfCourtesy")]
        public string TitleOfCourtesy { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("BirthDate")]
        public System.DateTime? BirthDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("HireDate")]
        public System.DateTime? HireDate { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Address")]
        public string Address { get; set; }
        [DisplayName("City")]
        public string City { get; set; }
        [DisplayName("Region")]
        public string Region { get; set; }
        [DisplayName("PostalCode")]
        public string PostalCode { get; set; }
        [DisplayName("Country")]
        public string Country { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("HomePhone")]
        public string HomePhone { get; set; }
        [DisplayName("Extension")]
        public string Extension { get; set; }
        [DisplayName("Photo")]
        public byte[] Photo { get; set; }
        [DisplayName("Notes")]
        public string Notes { get; set; }
        [DisplayName("ReportsTo")]
        public int? ReportsTo { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("PhotoPath")]
        public string PhotoPath { get; set; }
    }
}
