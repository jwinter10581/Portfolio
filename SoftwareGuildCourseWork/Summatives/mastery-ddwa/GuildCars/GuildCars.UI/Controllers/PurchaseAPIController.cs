using GuildCars.Data.Factories;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.UI.Controllers
{
    public class PurchaseAPIController : ApiController
    {
        [Route("api/purchase/sales")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Sales(int? employeeId, string fromDate, string toDate)
        {
            try
            {
                var parameters = new PurchaseSearchParameters()
                {
                    EmployeeId = employeeId,
                    FromText = fromDate,
                    ToText = toDate
                };

                var repo = PurchaseRepositoryFactory.GetRepository();
                var result = repo.Search(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
