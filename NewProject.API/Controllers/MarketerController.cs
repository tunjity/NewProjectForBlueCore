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
    public class MarketerController : ControllerBase
    {
        private readonly IMarketerService _productService;

        private readonly IMapper _mapper;
        public MarketerController(IMarketerService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost("Add")]
        [ProducesResponseType(200, Type = typeof(ReturnObject))]
        public async Task<IActionResult> Add(MarketerFm param)
        {
            var emp = _mapper.Map<Marketer>(param);
            emp.UniqueId = Guid.NewGuid().ToString();
            emp.Status = (int)ApprovalStatus.Pending;
            var response = _productService.Post(emp);
            return Ok(response);
        }
        [HttpPut("Update/{id}")]
        [ProducesResponseType(200, Type = typeof(ReturnObject))]
        public async Task<IActionResult> Update([FromBody]MarketerFm param, [FromRoute]int id)
        {
            var response =  _productService.Update(param,id);
            return Ok(response);
        }
        [HttpPost("All")]
        [ProducesResponseType(200, Type = typeof(ReturnObject))]
        public async Task<IActionResult> GetAllByCoyIdByMemberId([FromBody] MarketerFormModel obj)
        {
            var response = await _productService.GetAllByCoyIdByMemberId(obj.CoyId,obj.MemberId);
            return Ok(response);
        }
       
    }
}
