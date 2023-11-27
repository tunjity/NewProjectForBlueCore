using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewProject.Domain;
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
        public async Task<IActionResult> Add(ProductFm param)
        {
            var emp = _mapper.Map<Product>(param);
            emp.UniqueId = Guid.NewGuid().ToString();
            var response = _productService.Post(emp);
            return Ok(response);
        }
        [HttpPut("Update/{id}")]
        [ProducesResponseType(200, Type = typeof(ReturnObject))]
        public async Task<IActionResult> Update([FromBody]ProductFm param, [FromRoute]int id)
        {
            var response =  _productService.Update(param,id);
            return Ok(response);
        }
        [HttpPost("All")]
        [ProducesResponseType(200, Type = typeof(ReturnObject))]
        public async Task<IActionResult> GetAll([FromBody] ProductFormModel obj)
        {
            var response = await _productService.GetAllByCoyIdByProductIdByMarketerId(obj.CoyId,obj.ProductId,obj.MarketerId);
            return Ok(response);
        }
       
    }
}
