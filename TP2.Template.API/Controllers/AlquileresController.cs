﻿using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
                return BadRequest();
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

        // GET: api/Alquileres/5
        [HttpGet("{id}")]
        public IActionResult GetAlquiler(int id)
        {
            try
            {
                return new JsonResult(_service.GetById(id)) { StatusCode = 201 };
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
                if (Validacion.ValidarFecha(alquiler.FechaAlquiler)|| Validacion.ValidarFecha(alquiler.FechaReserva))
                {
                    AlquilerResponse alquilerresponse = _service.CreateAlquiler(alquiler);
                    if (alquilerresponse == null)
                    {
                        throw new Exception();
                    }
                }
                
               
                return Created("Created", alquiler);
            }
            catch
            { 
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult PutAlquiler(int clienteid, string isbn)
        {           
            try
            {
                _service.UpdateById(clienteid, isbn);
                return  Ok();
            }
            catch
            {
                return BadRequest();
            } 
        
        }

    }
}