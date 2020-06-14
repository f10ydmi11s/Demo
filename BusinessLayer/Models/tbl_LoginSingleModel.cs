using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace BusinessModelLayer
{
    public class Tbl_LoginSingle
    {
        [Key]
        [Required(ErrorMessage = "Username is required")]
        [DisplayName("Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DisplayName("Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Roles is required")]
        [DataType(DataType.MultilineText)]
        [DisplayName("Roles")]
        public string Roles { get; set; }
        [Required(ErrorMessage = "ActiveStatus is required")]
        [DisplayName("ActiveStatus")]
        public bool ActiveStatus { get; set; }
    }
}
