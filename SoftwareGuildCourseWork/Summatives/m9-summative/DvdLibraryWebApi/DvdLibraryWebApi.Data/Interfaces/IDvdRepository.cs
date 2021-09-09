using DvdLibraryWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibraryWebApi.Data.Interfaces
{
    public interface IDvdRepository
    {
        Dvd GetById(int id);
        List<Dvd> GetAll();
        List<Dvd> GetByTitle(string title);
        List<Dvd> GetByReleaseYear(int releaseYear);
        List<Dvd> GetByDirector(string director);
        List<Dvd> GetByRating(string rating);
        void Insert(Dvd newDvd);
        void Update(Dvd updatedDvd);
        void Delete(int id);
    }
}
