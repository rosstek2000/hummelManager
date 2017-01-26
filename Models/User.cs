using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hummelManager.Models
{
    public class User
    {
        public int contactId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}