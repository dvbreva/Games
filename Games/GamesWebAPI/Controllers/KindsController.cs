using ApplicationServices.DTOs;
using ApplicationServices.Implementations;
using GamesWebAPI.Messages;
using System.Web.Http;

namespace GamesWebAPI.Controllers
{
    public class KindsController : ApiController
    {
        public KindService service = new KindService();


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
        public IHttpActionResult Save(KindDto kindDto)
        {
            if (kindDto.Name == null || kindDto.Description == null)
            {
                return Json(new ResponseMessage { Code = 500, Error = "Your data is not valid." });
            }

            ResponseMessage response = new ResponseMessage();

            if (service.Save(kindDto))
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
