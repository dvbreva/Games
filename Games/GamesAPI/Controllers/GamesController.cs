using ApplicationServices.DTOs;
using ApplicationServices.Implementations;
using GamesAPI.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GamesAPI.Controllers
{
    public class GamesController : ApiController
    {
        public GameService service = new GameService();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(service.Get());
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            return Json(service.GetById(id));
        }

        [HttpPost]
        public IHttpActionResult Save(GameDto gameDto)
        {
            if (gameDto.Name == null || gameDto.Description == null)
            {
                return Json(new ResponseMessage { Code = 500, Error = "Your data is not valid." });
            }

            ResponseMessage response = new ResponseMessage();

            if (service.Save(gameDto))
            {
                response.Code = 200;
                response.Body = "Game was saved.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Game was not saved.";
            }

            return Json(response);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Json(service.Delete(id));
        }

    }
}
