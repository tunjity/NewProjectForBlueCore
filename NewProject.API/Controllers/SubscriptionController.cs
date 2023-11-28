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
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _productService;

        private readonly IMapper _mapper;
        public SubscriptionController(ISubscriptionService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost("Add")]
        [ProducesResponseType(200, Type = typeof(ReturnObject))]
        public async Task<IActionResult> Add(SubscriptionFm param)
        {
            var emp = _mapper.Map<Subscription>(param);
            emp.UniqueId = Guid.NewGuid().ToString();
            var response = _productService.Post(emp);
            return Ok(response);
        }
        [HttpPut("Update/{id}")]
        [ProducesResponseType(200, Type = typeof(ReturnObject))]
        public async Task<IActionResult> Update([FromBody]SubscriptionFmUpdate param, [FromRoute]int id)
        {
            var response =  _productService.Update(param,id);
            return Ok(response);
        }
        [HttpPost("All")]
        [ProducesResponseType(200, Type = typeof(ReturnObject))]
        public async Task<IActionResult> GetAllByCoyIdBymarketerIdBytranxid([FromBody] SubscriptionFormModel obj)
        {
            var response = await _productService.GetAllByCoyIdBymarketerIdBytranxid(obj.CoyId,obj.marketerId,obj.tranxid);
            return Ok(response);
        }
       
    }
}
