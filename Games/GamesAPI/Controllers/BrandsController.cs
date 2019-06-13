using ApplicationServices.DTOs;
using ApplicationServices.Implementations;
using GamesAPI.Messages;
using System.Web.Http;

namespace GamesAPI.Controllers
{
    [RoutePrefix("api/Brands")]
    public class BrandsController : ApiController
    {
        public BrandService service = new BrandService();

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
        public IHttpActionResult Delete(int id)
        {
            return Json(service.Delete(id));
        }

    }
}