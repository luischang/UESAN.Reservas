using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Entities;
using UESAN.Reservas.Core.Interfaces;

namespace UESAN.Reservas.Core.Services
{
    public class HabitacionService : IHabitacionService
    {
        private readonly IHabitacionRepository _habitacionRepository;
        private readonly ITipoHabitacionRepository _tipoHabitacionRepository;
        public HabitacionService(IHabitacionRepository habitacionRepository, ITipoHabitacionRepository tipoHabitacionRepository)
        {
            _habitacionRepository = habitacionRepository;
            _tipoHabitacionRepository = tipoHabitacionRepository;

        }
        public async Task<IEnumerable<HabitacionTipoHabitacionDTO>> GetAll()
        {
            var habitacion = await _habitacionRepository.GetHabitaciones();
            var habitacionDTO = habitacion.Select(e => new HabitacionTipoHabitacionDTO
            {
                Id_Habitacion = e.IdHabitacion,
                Descripcion = e.Descripcion,
                Capacidad = e.Capacidad,
                Estado = e.Estado,
                Precio = e.Precio,
                Cant_Camas = e.CantCamas,
                TipoHabitacion = new TipoHabitacionDescriptionDTO()
                {
                    Id_TipoHabi = e.IdTipoHabiNavigation.IdTipoHabi,
                    Descripcion = e.IdTipoHabiNavigation.Descripcion,

                }


            });
            return habitacionDTO;

        }
        public async Task<HabitacionTipoHabitacionDTO> GetById(int id)
        {
            var habitacion = await _habitacionRepository.GetHabitacionById(id);
            if (habitacion == null)
                return null;
            var habitacionDTO = new HabitacionTipoHabitacionDTO()
            {
                Id_Habitacion = habitacion.IdHabitacion,
                Descripcion = habitacion.Descripcion,
                Capacidad = habitacion.Capacidad,
                Estado = habitacion.Estado,
                Precio = habitacion.Precio,
                Cant_Camas = habitacion.CantCamas,
                TipoHabitacion = new TipoHabitacionDescriptionDTO()
                {
                    Id_TipoHabi = habitacion.IdTipoHabiNavigation.IdTipoHabi,
                    Descripcion = habitacion.IdTipoHabiNavigation.Descripcion,

                }


            };
            return habitacionDTO;
        }

        public async Task<bool> Insert(HabitacionInsertDTO habitacionInsertDTO)
        {
            var tipoHabitacion = new TipoHabitacionDescriptionDTO()
            {
                Id_TipoHabi = habitacionInsertDTO.TipoHabitacion.Id_TipoHabi,
                Descripcion = habitacionInsertDTO.TipoHabitacion.Descripcion,

            };

            //Traemos el objeto tipo habitación creado
            var th = await _tipoHabitacionRepository.GetTipoHabitacionById(tipoHabitacion.Id_TipoHabi);

            if (th != null)
            {
                //var precioh = 0;
                //if (tipoHabitacion.Descripcion == "Simple")
                //{
                //    precioh = 15;
                //}
                //else if (tipoHabitacion.Descripcion == "Doble")
                //{
                //    precioh = 25;
                //}
                //else if (tipoHabitacion.Descripcion == "Matrimonial")
                //{
                //    precioh = 45;
                //}
                var habitacion = new Habitacion()
                {
                    IdTipoHabi = th.IdTipoHabi,
                    Descripcion = habitacionInsertDTO.Descripcion,
                    Capacidad = habitacionInsertDTO.Capacidad,
                    Estado = true,
                    Precio = habitacionInsertDTO.Precio,
                    CantCamas = habitacionInsertDTO.Cant_Camas,


                };
                return await _habitacionRepository.Insert(habitacion);

            }
            return false;
        }

        public async Task<bool> Update(HabitacionUpdateDTO habitacionUpdateDTO)

        {
            var precioh = 0;
            if (habitacionUpdateDTO.Id_TipoHabi== 1)
            {
                precioh = 15;
            }
            else if (habitacionUpdateDTO.Id_TipoHabi == 2)
            {
                precioh = 25;
            }
            else if (habitacionUpdateDTO.Id_TipoHabi == 3)
            {
                precioh = 45;
            }
            var habitacion = new Habitacion()

            {
                IdHabitacion =habitacionUpdateDTO.Id_Habitacion,
                IdTipoHabi = habitacionUpdateDTO.Id_TipoHabi,
                Capacidad = habitacionUpdateDTO.Capacidad,
                Estado = habitacionUpdateDTO.Estado,
                CantCamas = habitacionUpdateDTO.Cant_Camas,
                Precio = precioh,
                Descripcion = habitacionUpdateDTO.Descripcion,

              
                
                };
                
            return await _habitacionRepository.Update(habitacion);
          
            //if (update)
            //{
            //    var habitacionCreada = await _habitacionRepository.GetHabitacionById(habitacionUpdateDTO.Id_Habitacion);
            //    if (habitacionCreada.IdTipoHabi == 1)
            //    {
            //        precioh = 15;
            //    }
            //    else if (habitacionCreada.IdTipoHabi == 2)
            //    {
            //        precioh = 25;
            //    }
            //    else if (habitacionCreada.IdTipoHabi == 3)
            //    {
            //        precioh = 45;
            //    }
            //    var nuevaHabitacion = new Habitacion()
            //    {
            //        IdHabitacion = habitacionCreada.IdHabitacion,
            //        IdTipoHabi = habitacionCreada.IdTipoHabi,
            //        Capacidad = habitacionCreada.Capacidad,
            //        Estado = habitacionCreada.Estado,
            //        CantCamas = habitacionCreada.CantCamas,
            //        Precio = precioh,
            //        Descripcion = habitacionCreada.Descripcion,
            //    };
            //    return await _habitacionRepository.Update(nuevaHabitacion);
            //}
            //return false;
            
    }

    public async Task<bool> Delete(int id)
    {

        var idHabitacion = await _habitacionRepository.GetHabitacionById(id);
        if (idHabitacion != null)
        {
            return await _habitacionRepository.Delete(idHabitacion.IdHabitacion);
        }
        return false;

    }


}
}
