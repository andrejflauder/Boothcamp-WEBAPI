using Space.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Space.WebApi.Controllers
{
    public class BlackHolesController : ApiController
    {
        static List<BlackHoles> blackholes = new List<BlackHoles>()
        {
            new BlackHoles (1, "Ton 618", "Whirpool galaxy" )
        };


        [Route("api/blackholes/GetBHNames/{userId}")]
        [HttpGet]
        public List<string> GetBHNames(int userId)
        {
            List<string> output = new List<string>();
            foreach (var name in blackholes)
            {
                output.Add(name.Name);
            }
            return output;
        }
        // GET: api/SpaceBody
        public List<BlackHoles> Get()
        {
            return blackholes;
        }

        // GET: api/SpaceBody/5
        public BlackHoles Get(int id)
        {
            return blackholes.Where(x => x.Id == id).FirstOrDefault();
        }


        // POST: api/SpaceBody
        public void Post(BlackHoles val)
        {
            blackholes.Add(val);
        }

        // PUT: api/SpaceBody/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/SpaceBody/5
        public void Delete(int id)
        {
        }
    }
}
