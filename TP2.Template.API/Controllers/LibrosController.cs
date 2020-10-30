using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP.Template.AccessData;
using TP2.Template.Application.Services;
using TP2.Template.Domain.DTOs;
using TP2.Template.Domain.Entities;

namespace TP2.Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
     public class LibrosController : ControllerBase
    {
        private readonly ILibroService _service;

        public LibrosController(ILibroService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetLibros([FromQuery]bool? stock, [FromQuery] string autor, [FromQuery] string titulo)
        {
            try
            {
                return new JsonResult(_service.GetAllLibros(stock,autor,titulo)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{Id?}")]
        public IActionResult GetById(string Id)
        {
            ResponseLibro libro = _service.GetLibroById(Id);
            try
            {
                return new JsonResult(libro) { StatusCode = 200 };
            }
            catch (Exception)
            {

                return BadRequest();
            }
           
        }

        [HttpPost]
        public IActionResult Post(LibroDto libro)
        {
            try
            {
                return new JsonResult(_service.CreateLibro(libro)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
