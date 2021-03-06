﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ModelLibrary.Model;
using RestService.DButil;

namespace RestService.Controllers
{
    public class HotelsController : ApiController
    {
        private static Imanage<Hotel> manager = new ManageHotelEF();

        // GET: api/Hotels
        public IEnumerable<Hotel> Get()
        {
            return manager.Get();
        }

        // GET: api/Hotels/5
        public Hotel Get(int id)
        {
            return manager.Get(id);
        }

        // POST: api/Hotels
        public bool Post([FromBody] Hotel hotel)
        {
            return manager.Post(hotel);
        }

        // PUT: api/Hotels/5
        public bool Put(int id, [FromBody]Hotel hotel)
        {
            return manager.Put(id, hotel);
        }

        // DELETE: api/Hotels/5
        public bool Delete(int id)
        {
            return manager.Delete(id);
        }
    }
}
