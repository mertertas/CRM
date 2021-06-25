﻿using Business.Abstract;
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
    public class DepartmentController : ControllerBase
    {
        private IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost("add")]
        public IActionResult Add(Department department)
        {
            var result = _departmentService.Add(department);
            if (result.Success)
            {
                return Ok();

            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Department department)
        {
            var result = _departmentService.Update(department);
            if (result.Success)
            {
                return Ok();

            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Department department)
        {
            var result = _departmentService.Delete(department);
            if (result.Success)
            {
                return Ok();

            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _departmentService.GetAll();
            if (result.Success)
            {
                return Ok();

            }
            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int departmentId)
        {
            var result = _departmentService.GetById(departmentId);
            if (result.Success)
            {
                return Ok();

            }
            return BadRequest(result);
        }
    }
}
