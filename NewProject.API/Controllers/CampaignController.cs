using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewProject.Domain.Models.FormModel;
using NewProject.Domain.Models;
using NewProject.Domain;
using NewProject.Repository.Services;
using static NewProject.Utility.AllEnum;

namespace NewProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _productService;

        private readonly IMapper _mapper;
        public CampaignController(ICampaignService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost("Add")]
        [ProducesResponseType(200, Type = typeof(ReturnObject))]
        public async Task<IActionResult> Add(CampaignFm param)
        {
            var emp = _mapper.Map<Campaign>(param);
            emp.UniqueId = Guid.NewGuid().ToString();
            var response = _productService.Post(emp);
            return Ok(response);
        }
        [HttpPut("Update/{id}")]
        [ProducesResponseType(200, Type = typeof(ReturnObject))]
        public async Task<IActionResult> Update([FromBody] CampaignFm param, [FromRoute] int id)
        {
            var response = _productService.Update(param, id);
            return Ok(response);
        }
        [HttpPost("All")]
        [ProducesResponseType(200, Type = typeof(ReturnObject))]
        public async Task<IActionResult> GetAllByCoyIdByProductIdByCamapagnid([FromBody] CampaignFormModel obj)
        {
            var response = await _productService.GetAllByCoyIdByProductIdByCamapagnid(obj.CoyId, obj.ProductId,obj.Camapagnid);
            return Ok(response);
        }

    }
}
