﻿namespace SuperShoes.Backend.Controllers
{
    using Services;
    using System.Collections.Generic;
    using System.Web.Http;

    public class TestController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {

            return Ok(new List<int>() { 1, 2, 3 });
        }
    }
}
