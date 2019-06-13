using ApplicationServices.DTOs;
using ApplicationServices.Implementations;
using GamesAPI.Messages;
using System.Web.Http;

namespace GamesAPI.Controllers
{
    [RoutePrefix("api/Kinds")]
    public class KindsController : ApiController
    {
        public KindService service = new KindService();

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(service.Get());
        }
        
        [Authorize]
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
                response.Body = "Kind was saved.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Kind was not saved.";
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