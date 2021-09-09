using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadManager.Models
{
    public class Bread
    {
        public int BreadID { get; set; }
        public BreadType BreadType { get; set; }
        public string Origin { get; set; }
        public bool Leavened { get; set; }
        public int ShelfLife { get; set; }
    }
}
