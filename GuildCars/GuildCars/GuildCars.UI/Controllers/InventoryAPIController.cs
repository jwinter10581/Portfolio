using GuildCars.Data.Factories;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace GuildCars.UI.Controllers
{
    public class InventoryAPIController : ApiController
    {
        [Route("api/inventory/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search (string vehicleTypeName, string quickSearch, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear)
        {
            try
            {
                var parameters = new VehicleSearchParameters()
                {
                    VehicleTypeName = vehicleTypeName,                  
                    QuickSearch = quickSearch,
                    MinPrice = minPrice,
                    MaxPrice = maxPrice,
                    MinYear = minYear,
                    MaxYear = maxYear
                };

                var repo = VehicleRepositoryFactory.GetRepository();
                var result = repo.Search(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/inventory/new")]
        [AcceptVerbs("GET")]
        public IHttpActionResult New()
        {
            try
            {
                var repo = VehicleRepositoryFactory.GetRepository();
                var result = repo.InventoryReport("New");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/inventory/used")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Used()
        {
            try
            {
                var repo = VehicleRepositoryFactory.GetRepository();
                var result = repo.InventoryReport("Used");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/inventory/models")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Models(string makeName)
        {
            try
            {
                var repo = ModelRepositoryFactory.GetRepository().GetAll();
                var result = new System.Web.Mvc.SelectList(repo.Where(m => m.MakeName == makeName), "ModelName", "ModelName");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/inventory/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteVehicle(string id)
        {
            try
            {
                var repo = VehicleRepositoryFactory.GetRepository();
                Vehicle found = repo.GetById(id);
                    
                if (found == null)
                {
                    return new System.Web.Http.Results.ResponseMessageResult(Request.CreateErrorResponse((HttpStatusCode)422, new HttpError("Vehicle doesn't exist in database.")));
                }
                else
                {
                    repo.Delete(id);
                   
                    var filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Images/Vehicle/") + found.ImageFilePath;
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }

                    return Ok();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Delete Vehicle was unsuccessful.");
            }
        }
    }
}