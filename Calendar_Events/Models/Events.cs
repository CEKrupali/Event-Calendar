using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar_Events.Models
{
    public class Events
    {
        [Key]
        public int EventID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public System.DateTime Start { get; set; }
        public Nullable<System.DateTime> End { get; set; }
        public string ThemeColor { get; set; }
        public bool IsFullDay { get; set; }
        [NotMapped]
        public string strStartDate { get; set; }
        [NotMapped]
        public string strEndDate { get; set; }
    }
}
