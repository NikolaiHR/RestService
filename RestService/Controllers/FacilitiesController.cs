using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ModelLibrary.Model;
using RestService.DButil;

namespace RestService.Controllers
{
    public class FacilitiesController : ApiController
    {
        private static ManageFacility manager = new ManageFacility();

        // GET: api/Facilities
        public IEnumerable<Facility> Get()
        {
            return manager.Get();
        }

        // GET: api/Facilities/5
        public Facility Get(int id)
        {
            return manager.Get(id);
        }

        // POST: api/Facilities
        public bool Post([FromBody]Facility facility)
        {
            return manager.Post(facility);
        }

        // PUT: api/Facilities/5
        public bool Put(int id, [FromBody]Facility facility)
        {
            return manager.Put(id, facility);
        }

        // DELETE: api/Facilities/5
        public bool Delete(int id)
        {
            return manager.Delete(id);
        }
    }


}
