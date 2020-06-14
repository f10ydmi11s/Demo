using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace BusinessModelLayer
{
    public class CategoriesSingle
    {
        [Key]
        [Required(ErrorMessage = "CategoryID is required")]
        [DisplayName("CategoryID")]
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "CategoryName is required")]
        [DisplayName("CategoryName")]
        public string CategoryName { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Picture")]
        public byte[] Picture { get; set; }
    }
}
