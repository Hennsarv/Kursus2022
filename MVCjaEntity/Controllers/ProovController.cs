using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCjaEntity.Controllers
{
    public class ProovController : ApiController
    {
        static List<string> ProovNames = new List<string>
        {
            "Henn", "Ants", "Peeter"
        };
        // GET: api/Proov
        public IEnumerable<string> Get()
        {
            return ProovNames.ToArray();
        }

        // GET: api/Proov/5
        public string Get(int id)
        {
            return ProovNames[id];
        }

        // POST: api/Proov
        public void Post([FromBody]string value)
        {
            ProovNames.Add(value);
        }

        // PUT: api/Proov/5
        public void Put(int id, [FromBody]string value)
        {
            ProovNames[id] = value;
        }

        // DELETE: api/Proov/5
        public void Delete(int id)
        {
            ProovNames.RemoveAt(id);
        }
    }
}
