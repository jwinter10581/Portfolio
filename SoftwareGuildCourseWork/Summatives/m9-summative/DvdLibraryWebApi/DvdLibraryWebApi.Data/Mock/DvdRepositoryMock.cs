using DvdLibraryWebApi.Data.Interfaces;
using DvdLibraryWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibraryWebApi.Data.Mock
{
    public class DvdRepositoryMock : IDvdRepository
    {
        private static List<Dvd> _dvds = new List<Dvd>
        {
            new Dvd
            { Id = 1, Title = "The Grand Budapest Hotel", ReleaseYear = 2014, Director = "Wes Anderson", Rating = "R", Notes = "Comedy-Drama" },
            new Dvd
            { Id = 2, Title = "2001: A Space Odyssey", ReleaseYear = 2001, Director = "Stanley Kubrick", Rating = "G", Notes = "Science Fiction" },
            new Dvd
            { Id = 3, Title = "Psycho", ReleaseYear = 1960, Director = "Alfred Hitchcock", Rating = "R", Notes = "Horror" },
            new Dvd
            { Id = 4, Title = "Interstellar", ReleaseYear = 2014, Director = "Christopher Nolan", Rating = "PG-13", Notes = "Science Fiction" },
            new Dvd
            { Id = 5, Title = "Big Eyes", ReleaseYear = 2014, Director = "Tim Burton", Rating = "PG-13", Notes = "Comedy-Drama" },
            new Dvd
            { Id = 6, Title = "The Nightmare Before Christmas", ReleaseYear = 1993, Director = "Tim Burton", Rating = "PG", Notes = "Animation" }
        };

        public void Delete(int id)
        {
            _dvds.RemoveAll(m => m.Id == id);
        }

        public void Insert(Dvd newDvd)
        {
            if(_dvds.Any())
            {
                newDvd.Id = _dvds.Max(m => m.Id) + 1;
            }
            else
            {
                newDvd.Id = 0;
            }
            _dvds.Add(newDvd);
        }

        public void Update(Dvd updatedDvd)
        {
            var found = _dvds.FirstOrDefault(m => m.Id == updatedDvd.Id);

            if (found != null)
            {
                //found = updatedDvd;
                _dvds.RemoveAll(m => m.Id == updatedDvd.Id);
                _dvds.Add(updatedDvd);
            }
        }
        
        public List<Dvd> GetAll()
        {
            return _dvds;
        }

        public Dvd GetById(int id)
        {
            return _dvds.FirstOrDefault(m => m.Id == id);
        }

        public List<Dvd> GetByTitle(string title)
        {
            var listOfDvds = new List<Dvd>();

            foreach (var dvd in _dvds)
            {
                if (dvd.Title.ToLower().Contains(title.ToLower()))
                {
                    listOfDvds.Add(dvd);
                }
            }

            return listOfDvds;
        }

        public List<Dvd> GetByReleaseYear(int releaseYear)
        {
            var listOfDvds = new List<Dvd>();

            foreach (var dvd in _dvds)
            {
                if (dvd.ReleaseYear == releaseYear)
                {
                    listOfDvds.Add(dvd);
                }
            }

            return listOfDvds;
        }

        public List<Dvd> GetByDirector(string director)
        {
            var listOfDvds = new List<Dvd>();

            foreach (var dvd in _dvds)
            {
                if (dvd.Director.ToLower().Contains(director.ToLower()))
                {
                    listOfDvds.Add(dvd);
                }
            }

            return listOfDvds;
        }

        public List<Dvd> GetByRating(string rating)
        {
            var listOfDvds = new List<Dvd>();

            foreach (var dvd in _dvds)
            {
                if (dvd.Rating.ToLower() == rating.ToLower())
                {
                    listOfDvds.Add(dvd);
                }
            }

            return listOfDvds;
        }
    }
}
