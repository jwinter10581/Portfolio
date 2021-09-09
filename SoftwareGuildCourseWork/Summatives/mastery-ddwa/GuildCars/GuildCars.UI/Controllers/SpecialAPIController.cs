using GuildCars.Data.Factories;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.UI.Controllers
{
    public class SpecialAPIController : ApiController
    {
        [Route("api/special/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteSpecial(int id)
        {
            try
            {
                var repo = SpecialRepositoryFactory.GetRepository();
                Special found = repo.GetById(id);

                if (found == null)
                {
                    return new System.Web.Http.Results.ResponseMessageResult(Request.CreateErrorResponse((HttpStatusCode)422, new HttpError("Special doesn't exist in database.")));
                }
                else
                {
                    repo.Delete(id);
                    return Ok();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Delete Special was unsuccessful.");
            }
        }
    }
}
