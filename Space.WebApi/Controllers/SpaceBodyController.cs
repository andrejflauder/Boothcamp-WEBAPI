using Space.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;

namespace Space.WebApi.Controllers
{
    public class SpaceBodyController : ApiController
    {
        static List<Star> spacebody = new List<Star>()
        {
            new Star (1, "Sun", "Milky Way" ),
            new Star (2, "Proxima Centauri", "Milky Way" ),
            new Star (3, "UY Scuti", "Milky Way" )
        };
                       

        [Route("api/SpaceBody/GetNames/{Id}")]
        [HttpGet]
        public List<string> GetNames(int Id)
        {
            List<string> output = new List<string>();
            foreach(var name in spacebody)
            {
                output.Add(name.Name);
            }
            return output;
        }
        // GET: api/SpaceBody
        public List<Star> Get()
        {
            return spacebody;
        }

        // GET: api/SpaceBody/5
        //public Star Get(int id)
        //{
        //    return spacebody.Where(x => x.Id == id).FirstOrDefault();
        //}

        [HttpGet()]
        public HttpResponseMessage GetNewspaper(int id)
        {
            var starList = spacebody.Find(c => c.Id == id);
            if (starList == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"There is no star with  id '{id}' at list");
            }
            return Request.CreateResponse(HttpStatusCode.OK, starList); 
        }


        // POST: api/SpaceBody
        public void Post(Star val)
        {
            spacebody.Add(val);
        }


        // PUT: api/SpaceBody/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SpaceBody/5
        
        public void Delete(int id)
        {
        }
        
        [Route("api/SpaceBody/delete/{Id}")]
        [HttpDelete]
        public HttpResponseMessage Remove(int id)
        {
            var specificStar = spacebody.Find(c => c.Id == id);
            spacebody.Remove(specificStar);
            if (specificStar == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"There is no star with  id '{id}' in a list");
            }
            else
            {
                HttpResponseMessage responseMessageOk = Request.CreateResponse(HttpStatusCode.OK, specificStar);
                return Request.CreateResponse(HttpStatusCode.OK, $"You deleted star with id '{specificStar.Id}' from list");
            }
        }
    }
}
