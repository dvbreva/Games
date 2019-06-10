using ApplicationServices.DTOs;
using ApplicationServices.Implementations;
using GamesWebAPI.Messages;
using System.Web.Http;

namespace GamesWebAPI.Controllers
{
    public class BrandsController : ApiController
    {
        public BrandService service = new BrandService();


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
        public IHttpActionResult Save(BrandDto brandDto)
        {
            if (brandDto.Name == null || brandDto.Description == null)
            {
                return Json(new ResponseMessage { Code = 500, Error = "Your data is not valid." });
            }

            ResponseMessage response = new ResponseMessage();

            if (service.Save(brandDto))
            {
                response.Code = 200;
                response.Body = "Brand was saved.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Brand was not saved.";
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
