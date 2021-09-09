using BreadManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadManager.Data
{
    public class BreadRepository
    {
        Bread[] loaves;

        public BreadRepository() // Constructor will create an array of bread and populate with two entries for testing.
        {
            loaves = new Bread[10];  

            Bread bread1 = new Bread();
            bread1.BreadID = 0;
            bread1.BreadType = BreadType.Sourdough;
            bread1.Origin = "Egyptian";
            bread1.Leavened = true;
            bread1.ShelfLife = 4;

            loaves[0] = bread1;

            Bread bread2 = new Bread();
            bread2.BreadID = 1;
            bread2.BreadType = BreadType.Brioche;
            bread2.Origin = "French";
            bread2.Leavened = true;
            bread2.ShelfLife = 5;

            loaves[1] = bread2;
        }

        public Bread CreateBread(Bread bread)
        {
            for (int i = 0; i < loaves.Length; i++)
            {
                if (loaves[i] == null)
                {
                    bread.BreadID = i;

                    loaves[i] = bread;
                    return bread;
                }
            }

            return null;  // If no free spots in loaves array, return null value
        }

        public Bread[] RetrieveAllLoaves()
        {
            return loaves;
        }

        public Bread RetrieveBreadByID(int breadID)
        {
            return loaves[breadID];
        }

        public void DeleteBread(int breadID)
        {
            loaves[breadID] = null;
        }

        public Bread EditBread(Bread staleBread)
        {
            DeleteBread(staleBread.BreadID);
            Bread freshBread = CreateBread(staleBread);
            return freshBread;
        }
    }
}
