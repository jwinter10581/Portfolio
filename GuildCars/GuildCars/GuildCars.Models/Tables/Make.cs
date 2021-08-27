using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Make
    {
        public int MakeId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeEmail { get; set; }
        public string MakeName { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
