using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hummelManager.Models
{
    public class Inquiry
    {
        public int inquiryId { get; set; }
        public int hummelId { get; set; }
        public int userId { get; set; }
        public DateTime inquiryDate { get; set; }

    }
}