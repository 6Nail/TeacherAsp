using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CW_05.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set;}
    }
}