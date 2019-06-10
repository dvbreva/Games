﻿using System.Web.Http;

namespace GamesWebAPI.Controllers
{
    public class BaseController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Version()
        {
            return Json("Well hello from base controller! Web API is somewhat successful.");
        }
    }
}
