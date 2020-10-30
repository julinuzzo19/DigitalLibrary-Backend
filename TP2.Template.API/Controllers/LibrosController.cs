using Microsoft.AspNetCore.Mvc;
using System;
using TP2.Template.Application.Services;
using TP2.Template.Domain.DTOs;

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
        public IActionResult GetLibros([FromQuery] bool? stock, [FromQuery] string autor, [FromQuery] string titulo)
        {
            try
            {
                return new JsonResult(_service.GetAllLibros(stock, autor, titulo)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{Id?}")]
        public IActionResult GetById(string Id)
        {

            try
            {
                ResponseLibro libro = _service.GetLibroById(Id);
                return new JsonResult(libro) { StatusCode = 200 };
            }
            catch (Exception)
            {

                return NotFound();
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
