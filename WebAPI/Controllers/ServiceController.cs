using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        ISrvService _srvService;

        public ServiceController(ISrvService srvService)
        {
            _srvService = srvService;
        }

        [HttpPost("add")]
        public IActionResult Add(Service service)
        {
            var result = _srvService.Add(service);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Service service)
        {
            var result = _srvService.Update(service);
            if (result.Success)
            {
                return Ok();

            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Service service)
        {
            var result = _srvService.Delete(service);
            if (result.Success)
            {
                return Ok();

            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _srvService.GetAll();
            if (result.Success)
            {
                return Ok();

            }
            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int serviceId)
        {
            var result = _srvService.GetById(serviceId);
            if (result.Success)
            {
                return Ok();

            }
            return BadRequest(result);
        }
    }
}
