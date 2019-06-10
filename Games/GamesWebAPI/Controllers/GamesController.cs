using ApplicationServices.DTOs;
using ApplicationServices.Implementations;
using GamesWebAPI.Messages;
using System.Web.Http;

namespace GamesWebAPI.Controllers
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
                response.Body = "Type was saved.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Type was not saved.";
            }

            return Json(response);
        }

        [HttpDelete]
        public IHttpActionResult DeleteType(int id)
        {
            return Json(service.Delete(id));
        }

    }
}
