using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstMVCApplication.Models
{
    public class CurrentWeather
    {
        public DateTime Date { get; set; }
        public int High { get; set; }
        public int Low { get; set; }
        public string Description { get; set; } 
    }
}