using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{

    public class Vwtbl_login
    {
        [DisplayName("Username")]
        public string Username { get; set; }
        [DisplayName("Password")]
        public string Password { get; set; }
        [DisplayName("Roles")]
        public string Roles { get; set; }
        [DisplayName("Activestatus")]
        public bool ActiveStatus { get; set; }
    }
}
