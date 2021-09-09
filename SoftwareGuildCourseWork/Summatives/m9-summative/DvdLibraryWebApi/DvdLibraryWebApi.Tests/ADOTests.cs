using NUnit.Framework;
using DvdLibraryWebApi.Data.ADO;
using DvdLibraryWebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DvdLibraryWebApi.Tests
{
    [TestFixture]
    public class ADOTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DvdLibaryDbReset";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanLoadAllDvds()
        {
            var repo = new DvdRepositoryADO();
            var dvds = repo.GetAll();

            Assert.AreEqual(6, dvds.Count);
            Assert.AreEqual("The Grand Budapest Hotel", dvds[0].Title);
            Assert.AreEqual(2014, dvds[0].ReleaseYear);
            Assert.AreEqual("Wes Anderson", dvds[0].Director);
            Assert.AreEqual("R", dvds[0].Rating);
            Assert.AreEqual("Comedy-Drama", dvds[0].Notes);
        }

        [Test]
        public void CanAddDvd()
        {
            Dvd dvdToAdd = new Dvd();
            var repo = new DvdRepositoryADO();

            dvdToAdd.Title = "Moana";
            dvdToAdd.ReleaseYear = 2016;
            dvdToAdd.Director = "Ron Clements & John Musker";
            dvdToAdd.Rating = "PG";
            dvdToAdd.Notes = "Animation";

            repo.Insert(dvdToAdd);

            Assert.AreEqual(7, dvdToAdd.Id);
        }

        [Test]
        public void CanUpdateDvd()
        {
            Dvd dvdToAdd = new Dvd();
            var repo = new DvdRepositoryADO();

            dvdToAdd.Title = "Moana";
            dvdToAdd.ReleaseYear = 2016;
            dvdToAdd.Director = "Ron Clements & John Musker";
            dvdToAdd.Rating = "PG";
            dvdToAdd.Notes = "Animation";

            repo.Insert(dvdToAdd);

            dvdToAdd.Title = "The Gentlemen";
            dvdToAdd.ReleaseYear = 2019;
            dvdToAdd.Director = "Guy Ritchie";
            dvdToAdd.Rating = "R";
            dvdToAdd.Notes = "Crime. Class.";

            repo.Update(dvdToAdd);

            var updatedDvd = repo.GetById(7);

            Assert.AreEqual("The Gentlemen", updatedDvd.Title);
            Assert.AreEqual(2019, updatedDvd.ReleaseYear);
            Assert.AreEqual("Guy Ritchie", updatedDvd.Director);
            Assert.AreEqual("R", updatedDvd.Rating);
            Assert.AreEqual("Crime. Class.", updatedDvd.Notes);
        }

        [Test]
        public void CanDeleteDvd()
        {
            Dvd dvdToAdd = new Dvd();
            var repo = new DvdRepositoryADO();

            dvdToAdd.Title = "Moana";
            dvdToAdd.ReleaseYear = 2016;
            dvdToAdd.Director = "Ron Clements & John Musker";
            dvdToAdd.Rating = "PG";
            dvdToAdd.Notes = "Animation";

            repo.Insert(dvdToAdd);

            var loaded = repo.GetById(7);
            Assert.IsNotNull(loaded);

            repo.Delete(7);
            loaded = repo.GetById(7);

            Assert.IsNull(loaded);
        }

        [Test]
        public void CanGetDvdById()
        {
            var repo = new DvdRepositoryADO();

            var found = repo.GetById(2);

            Assert.AreEqual("2001: A Space Odyssey", found.Title);
            Assert.AreEqual(2001, found.ReleaseYear);
            Assert.AreEqual("Stanley Kubrick", found.Director);
            Assert.AreEqual("G", found.Rating);
            Assert.AreEqual("Science Fiction", found.Notes);
        }

        [Test]
        public void NoDvdFoundReturnsNull()
        {
            var repo = new DvdRepositoryADO();
            var found = repo.GetById(100000);

            Assert.IsNull(found);
        }

        [Test]
        public void CanSearchOnDirector()
        {
            var repo = new DvdRepositoryADO();

            var found = repo.GetByDirector("Tim Burton");

            Assert.AreEqual(2, found.Count());
        }

        [Test]
        public void CanSearchOnRating()
        {
            var repo = new DvdRepositoryADO();

            var found = repo.GetByRating("G");
            Assert.AreEqual(1, found.Count());

            found = repo.GetByRating("PG");
            Assert.AreEqual(1, found.Count());

            found = repo.GetByRating("PG-13");
            Assert.AreEqual(2, found.Count());

            found = repo.GetByRating("R");
            Assert.AreEqual(2, found.Count());

            found = repo.GetByRating("NC-17");
            Assert.AreEqual(0, found.Count());
        }

        [Test]
        public void CanSearchOnReleaseYear()
        {
            var repo = new DvdRepositoryADO();

            var found = repo.GetByReleaseYear(2014);

            Assert.AreEqual(3, found.Count());
        }

        [Test]
        public void CanSearchOnTitle()
        {
            var repo = new DvdRepositoryADO();

            var found = repo.GetByTitle("The");

            Assert.AreEqual(2, found.Count());
        }
    }
}
