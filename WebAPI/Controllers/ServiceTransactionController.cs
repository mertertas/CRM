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
    public class ServiceTransactionController : ControllerBase
    {
        IServiceTransactionService _serviceTransactionService;

        public ServiceTransactionController(IServiceTransactionService serviceTransactionService)
        {
            _serviceTransactionService = serviceTransactionService;
        }

        [HttpPost("add")]
        public IActionResult Add(ServiceTransaction serviceTransaction)
        {
            var result = _serviceTransactionService.Add(serviceTransaction);
            if (result.Success)
            {
                return Ok();

            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(ServiceTransaction serviceTransaction)
        {
            var result = _serviceTransactionService.Update(serviceTransaction);
            if (result.Success)
            {
                return Ok();

            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ServiceTransaction serviceTransaction)
        {
            var result = _serviceTransactionService.Delete(serviceTransaction);
            if (result.Success)
            {
                return Ok();

            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _serviceTransactionService.GetAll();
            if (result.Success)
            {
                return Ok();

            }
            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int serviceTransactionId)
        {
            var result = _serviceTransactionService.GetById(serviceTransactionId);
            if (result.Success)
            {
                return Ok();

            }
            return BadRequest(result);
        }
    }
}
