using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewProject.Domain.Models.FormModel;
using NewProject.Domain.Models;
using NewProject.Domain;
using NewProject.Repository.Services;

namespace NewProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _productService;
        private readonly IMapper _mapper;
        public ClientController(IClientService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost("Add")]
        [ProducesResponseType(200, Type = typeof(ReturnObject))]
        public async Task<IActionResult> Add(ClientFm param)
        {
            var emp = _mapper.Map<Client>(param);
            emp.UniqueId = Guid.NewGuid().ToString();
            var response = _productService.Post(emp);
            return Ok(response);
        }
        [HttpPut("Update/{id}")]
        [ProducesResponseType(200, Type = typeof(ReturnObject))]
        public async Task<IActionResult> Update([FromBody] ClientFm param, [FromRoute] int id)
        {
            var response = _productService.Update(param, id);
            return Ok(response);
        }
        [HttpPost("All")]
        [ProducesResponseType(200, Type = typeof(ReturnObject))]
        public async Task<IActionResult> GetAllByCoyIdByclientId([FromBody] ClientFormModel obj)
        {
            var response = await _productService.GetAllByCoyIdByclientId(obj.CoyId, obj.ClientId);
            return Ok(response);
        }
    }
}
