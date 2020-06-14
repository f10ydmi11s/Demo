using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{

    public class Vwtbl_exceptionloggingtodatabase
    {
        [DisplayName("Logid")]
        public long Logid { get; set; }
        [DisplayName("Exceptionmsg")]
        public string ExceptionMsg { get; set; }
        [DisplayName("Exceptiontype")]
        public string ExceptionType { get; set; }
        [DisplayName("Exceptionsource")]
        public string ExceptionSource { get; set; }
        [DisplayName("Exceptionurl")]
        public string ExceptionURL { get; set; }
        [DisplayName("Logdate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public System.DateTime? Logdate { get; set; }
    }
}
