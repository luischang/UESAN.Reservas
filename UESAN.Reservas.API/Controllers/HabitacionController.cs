using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Reservas.Core.Interfaces;
using UESAN.Reservas.Infrastructure;
using UESAN.Reservas.Core.DTOs;


namespace UESAN.Reservas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase

    {
        private readonly IHabitacionRepository _habitacionRepository;

        public HabitacionController(IHabitacionRepository habitacionRepository)
        {
            _habitacionRepository=habitacionRepository;
        }
       // [HttpGet]
       /* public async Task<IActionResult> GetAll()
        {
            //var habitaciones= await _habitacionRepository.GetHabitaciones();
            return Ok(habitaciones);
        }*/
    }
}
