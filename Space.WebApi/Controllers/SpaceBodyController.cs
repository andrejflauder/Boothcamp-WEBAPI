using Space.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Space.WebApi.Controllers
{
    public class SpaceBodyController : ApiController
    {
        List<Star> spacebody = new List<Star>();

        public SpaceBodyController()
        {
            spacebody.Add(new Star { Id = 1, Name = "Sun", Location = "Milky Way" });
            spacebody.Add(new Star { Id = 2, Name = "Proxima Centauri", Location = "Milky Way" });
            spacebody.Add(new Star { Id = 3, Name = "UY Scuti", Location = "Milky Way" });
        }

        [Route("api/SpaceBody/GetNames/{userId:int}")]
        [HttpGet]
        public List<string> GetNames(int userId)
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
        public Star Get(int id)
        {
            return spacebody.Where(x => x.Id == id).FirstOrDefault();
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
    }
}
