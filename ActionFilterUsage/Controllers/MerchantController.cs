using ActionFilterUsage.ActionFilters;
using ActionFilterUsage.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActionFilterUsage.Controllers
{
    [Route("api/{merchantCode}/[controller]")]
    [ApiController]

    public class MerchantController : BaseController
    {
        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers([FromQuery] string merchantCode1)
        {
            return Ok($"Users returned for Merchant {merchantCode1}. Page: {Page}, PageSize: {PageSize}");
        }
        [HttpPost]
        [Route("Update")]
        [MerchantCodeActionFilter]
        public IActionResult UpdateMerchant(UpdateMerchantRequestModel requestModel)
        {
            return Ok($"Merchant Updated. Name: {requestModel.Name}, Code: {requestModel.MerchantCode}");
        }
    }
}
