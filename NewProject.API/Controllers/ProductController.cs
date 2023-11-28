using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewProject.Domain;
using NewProject.Utility;
using NewProject.Domain.Models;
using NewProject.Domain.Models.FormModel;
using NewProject.Repository.Services;
using static NewProject.Utility.AllEnum;

namespace NewProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost("Add")]
        [ProducesResponseType(200, Type = typeof(ReturnObject))]
        public async Task<IActionResult> Add([FromForm]ProductFm param)
        {
            string image = Helper.GetBase64StringForImage(param.ProductImage);
            var emp = _mapper.Map<Product>(param);
            emp.UniqueId = Guid.NewGuid().ToString();
            emp.Pictures = image;                       
            var response = _productService.Post(emp);
            return Ok(response);
        }
        [HttpPut("Update/{id}")]
        [ProducesResponseType(200, Type = typeof(ReturnObject))]
        public async Task<IActionResult> Update([FromBody]ProductFmUpdate param, [FromRoute]int id)
        {
            var response =  _productService.Update(param,id);
            return Ok(response);
        }
        [HttpPost("All")]
        [ProducesResponseType(200, Type = typeof(ReturnObject))]
        public async Task<IActionResult> GetAllByCoyIdByProductIdByMarketerId([FromBody] ProductFormModel obj)
        {
            var response = await _productService.GetAllByCoyIdByProductIdByMarketerId(obj.CoyId,obj.ProductId,obj.MarketerId);
            return Ok(response);
        }
       
    }
}
