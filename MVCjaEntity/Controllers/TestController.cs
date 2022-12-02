using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCjaEntity.Controllers
{
    public class TestController : ApiController
    {
        static List<string> nimed = new List<string>
        {
            "Henn", "Ants", "Peeter"
        };


        // GET: api/Test
        public IEnumerable<string> Get()
        {
            return nimed;
        }

        // GET: api/Test/5
        public string Get(int id)
        {
            return nimed[id];
        }

        // POST: api/Test
        public void Post([FromBody]string value)
        {
            nimed.Add(value);
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
            nimed[id] = value;
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
            nimed.RemoveAt(id);
        }
    }
}
