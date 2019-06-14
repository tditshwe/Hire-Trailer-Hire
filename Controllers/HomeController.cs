﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HireTrailer;
using HireTrailer.Models;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;

namespace HireTrailer.Controllers
{
    [EnableCors(origins: "http://localhost:8000", headers: "*", methods: "*")]
    public class HomeController : ApiController
    {
        class ListCollection
        {
            public List<Trailer> Trailers { get; set; }
            public List<Client> Clients { get; set; }
            public List<Rental> Rentals { get; set; }
        }

        private readonly AppContext Context;

        public HomeController()
        {
            Context = new AppContext();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(new ListCollection
            {
                Clients = Context.Clients.ToList(),
                Trailers = Context.Trailers.ToList(),
                Rentals = Context.Rentals.ToList()
            });
        }
    }
}