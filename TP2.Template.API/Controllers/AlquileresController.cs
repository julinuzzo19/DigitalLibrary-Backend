using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TP2.Template.Application.Services;
using TP2.Template.Domain.DTOs;

namespace TP2.Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlquileresController : ControllerBase
    {
        private readonly IAlquilerService _service;

        public AlquileresController(IAlquilerService service)
        {
            _service = service;
        }


        [HttpGet("cliente/{id}")]
        public IActionResult GetLibrosByCliente(int id)
        {
            try
            {
                List<AlquilerResponse> alquilerResponse = _service.GetLibrosByCliente(id);

                return new JsonResult(alquilerResponse) { StatusCode = 201 };
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: api/Alquileres
        [HttpGet]
        public IActionResult GetAlquileres([FromQuery] int estado)
        {
            try
            {
                return new JsonResult(_service.GetAll(estado)) { StatusCode = 201 };
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Alquileres       
        [HttpPost]
        public IActionResult PostAlquiler(AlquilerDto alquiler)
        {
            try
            {
                if (Validacion.ValidarFecha(alquiler.FechaAlquiler) || Validacion.ValidarFecha(alquiler.FechaReserva))
                {
                    AlquilerResponse alquilerresponse = _service.CreateAlquiler(alquiler);
                    if (alquilerresponse == null)
                    {
                        throw new Exception();
                    }

                }
                else { throw new Exception(); }
                
                return Created("Created", alquiler);

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult PutAlquiler(UpdateAlquilerBody alquiler)
        {
            try
            {
                _service.UpdateById(alquiler);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

    }
}
