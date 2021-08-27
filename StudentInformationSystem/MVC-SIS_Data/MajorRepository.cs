using MVC_SIS_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_SIS_Data
{
    public static class MajorRepository
    {
        private static List<Major> _majors;

        static MajorRepository()
        {
            // sample data
            _majors = new List<Major>
                {
                    new Major { MajorId=1, MajorName="Art" },
                    new Major { MajorId=2, MajorName="Business" },
                    new Major { MajorId=3, MajorName="Computer Science" }
                };
        }

        public static IEnumerable<Major> GetAll()
        {
            return _majors;
        }

        public static Major Get(int majorId)
        {
            return _majors.FirstOrDefault(c => c.MajorId == majorId);
        }

        public static void Add(string majorName)
        {
            Major major = new Major();
            major.MajorName = majorName;
            major.MajorId = _majors.Max(c => c.MajorId) + 1; // Check if any, if so, do this, or id = 1

            _majors.Add(major);
        }

        public static void Edit(Major major)
        {
            var selectedMajor = _majors.First(c => c.MajorId == major.MajorId);

            selectedMajor.MajorName = major.MajorName;
        }

        public static void Delete(int majorId)
        {
            _majors.RemoveAll(c => c.MajorId == majorId);
        }
    }
}
