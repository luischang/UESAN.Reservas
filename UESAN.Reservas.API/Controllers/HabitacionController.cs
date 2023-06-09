﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Reservas.Core.Interfaces;
using UESAN.Reservas.Infrastructure;
using UESAN.Reservas.Core.DTOs;
using Microsoft.AspNetCore.Http.Metadata;

namespace UESAN.Reservas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase

    {
        private readonly IHabitacionService _habitacionService;

        public HabitacionController(IHabitacionService habitacionService)
        {
            _habitacionService=habitacionService;
        }
        [HttpPost("CreateHabitacion")]
        public async Task<IActionResult> Insert(HabitacionInsertDTO habitacionInsertDTO)
        {
            var result = await _habitacionService.Insert(habitacionInsertDTO);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var habitaciones = await _habitacionService.GetAll();
            return Ok(habitaciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var habitacion = await  _habitacionService.GetById(id);
            if (habitacion == null)
                return NotFound();
            return Ok(habitacion);
        }

        [HttpPut("{idUpdate}")]
        public async Task<IActionResult> Update(HabitacionUpdateDTO habitacionUpdateDTO)
        {
            var result = await _habitacionService.Update(habitacionUpdateDTO);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _habitacionService.Delete(id);
            if (!result)
                return NotFound();
            return Ok(result);
        }

    }
}
