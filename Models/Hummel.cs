using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hummelManager.Models
{
    public class Hummel
    {
        public int hummelId { get; set; }
        public string name { get; set; }
        public string trademark { get; set; }
        public string description { get; set; }
        public string fileLoc { get; set; }
        public string copyright { get; set; }
        public string measurement { get; set; }
        public bool active { get; set; }
    }
}