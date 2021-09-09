using DvdLibraryWebApi.Data.Factories;
using DvdLibraryWebApi.Data.Interfaces;
using DvdLibraryWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DvdLibraryWebApi.UI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdController : ApiController
    {
        [Route("dvds/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            var repo = DvdRepositoryFactory.GetRepository();
            return Ok(repo.GetAll());
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetById(int id)
        {
            var repo = DvdRepositoryFactory.GetRepository();

            Dvd found = repo.GetById(id);

            if(found == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(found);
            }
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Insert(Dvd newDvd)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            repo.Insert(newDvd);

            return Created($"dvd/{newDvd.Id}", newDvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Update(Dvd updatedDvd)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            Dvd found = repo.GetById(updatedDvd.Id);
            
            if (found == null)
            {
                return new System.Web.Http.Results.ResponseMessageResult(Request.CreateErrorResponse((HttpStatusCode)422, new HttpError("Library does not contain that DVD.")));
            }
            else
            {
                repo.Update(updatedDvd);
                return Ok(updatedDvd);
            }
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int id)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            Dvd found = repo.GetById(id);

            if (found == null)
            {
                return new System.Web.Http.Results.ResponseMessageResult(Request.CreateErrorResponse((HttpStatusCode)422, new HttpError("Library does not contain that DVD.")));
            }
            else
            {
                repo.Delete(id);
                return Ok();
            }
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByTitle(string title)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            return Ok(repo.GetByTitle(title));
        }

        [Route("dvds/year/{year}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByReleaseYear(int year)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            return Ok(repo.GetByReleaseYear(year));
        }

        [Route("dvds/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByDirector(string director)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            return Ok(repo.GetByDirector(director));
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByRating(string rating)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            return Ok(repo.GetByRating(rating));
        }
    }
}
