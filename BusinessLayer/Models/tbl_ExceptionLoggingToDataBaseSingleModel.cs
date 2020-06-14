using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace BusinessModelLayer
{
    public class Tbl_ExceptionloggingtodatabaseSingle
    {
        [Key]
        [Required(ErrorMessage = "Logid is required")]
        [DisplayName("Logid")]
        public long Logid { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("ExceptionMsg")]
        public string ExceptionMsg { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("ExceptionType")]
        public string ExceptionType { get; set; }
        [DisplayName("ExceptionSource")]
        public string ExceptionSource { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("ExceptionURL")]
        public string ExceptionURL { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Logdate")]
        public System.DateTime? Logdate { get; set; }
    }
}
