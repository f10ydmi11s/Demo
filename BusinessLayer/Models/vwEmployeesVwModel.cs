using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{

    public class Vwemployees
    {
        [DisplayName("Employeeid")]
        public int EmployeeID { get; set; }
        [DisplayName("Lastname")]
        public string LastName { get; set; }
        [DisplayName("Firstname")]
        public string FirstName { get; set; }
        [DisplayName("Title")]
        public string Title { get; set; }
        [DisplayName("Titleofcourtesy")]
        public string TitleOfCourtesy { get; set; }
        [DisplayName("Birthdate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public System.DateTime? BirthDate { get; set; }
        [DisplayName("Hiredate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public System.DateTime? HireDate { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }
        [DisplayName("City")]
        public string City { get; set; }
        [DisplayName("Region")]
        public string Region { get; set; }
        [DisplayName("Postalcode")]
        public string PostalCode { get; set; }
        [DisplayName("Country")]
        public string Country { get; set; }
        [DisplayName("Homephone")]
        public string HomePhone { get; set; }
        [DisplayName("Extension")]
        public string Extension { get; set; }
        [DisplayName("Photo")]
        public byte[] Photo { get; set; }
        [DisplayName("Notes")]
        public string Notes { get; set; }
        [DisplayName("Reportsto")]
        public int? ReportsTo { get; set; }
        [DisplayName("Photopath")]
        public string PhotoPath { get; set; }
    }
}
