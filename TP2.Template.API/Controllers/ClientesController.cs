using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetClientes([FromQuery]string nombre,[FromQuery]string apellido, [FromQuery] string dni)
        {
            try
            {
                return new JsonResult(_service.GetAll(nombre,apellido,dni)) { StatusCode = 200 };
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{Id?}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                ClienteDto cliente = _service.GetById(Id);
                if (cliente == null)
                {
                    throw new Exception();
                }

                else { 
                        return new JsonResult(cliente) { StatusCode = 200 };
                    }

            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post(ClienteDto cliente)
        {           
            try
            {
                if (Validacion.ValidarEmail(cliente.Email) && Validacion.ValidarDni(cliente.Dni)&&Validacion.ValidarNombre(cliente.Nombre)&&Validacion.ValidarNombre(cliente.Apellido))
                {
                    return new JsonResult(_service.CreateCliente(cliente)) { StatusCode = 201 };
                }
                else throw new Exception();
                
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
