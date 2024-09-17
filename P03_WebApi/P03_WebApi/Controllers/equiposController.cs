﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P03_WebApi.Models;

namespace P03_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class equiposController : ControllerBase
    {
        private readonly equiposContext _equiposContexto;

        public equiposController(equiposContext equiposContext)
        { 
            _equiposContexto = equiposContext;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult Get()
        {
           List<equipos> listadoEquipo = (from e in _equiposContexto.equipos
                                          select e).ToList();

            if(listadoEquipo.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoEquipo);
        }

        /*
        //buscar por id
        
        [HttpGet]
        [Route("getbyid")]
        public IActionResult Get(int id)
        {
            equipos? equipo = _equiposContexto.equipos.Find(id);
            if (equipo == null) { return NotFound(); }
            return Ok(equipo);

        }
        

        //buscar por descripcion
        
        [HttpGet]
        [Route("find")]
        public IActionResult buscar(string filtro)
        {
            List<equipos> equiposList = (from e in _equiposContexto.equipos
                                         where e.nombre.Contains(filtro)
                                         || e.descripcion.Contains(filtro)
                                         select e).ToList();

            if (equiposList.Any())
            {
                return Ok(equiposList);
            }
            return NotFound();

        }
        */
        

        //agregar
        [HttpPost]
        [Route("add")]
        public IActionResult Crear([FromBody] equipos equiposNuevo)
        {
            try
            {
                _equiposContexto.equipos.Add(equiposNuevo);
                _equiposContexto.SaveChanges();

                return Ok(equiposNuevo);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Modificar
        [HttpPut]
        [Route("actualizar/{id}")]
        public IActionResult actualizar(int id, [FromBody] equipos equiposModificar)
        {
            equipos? equiposExiste = (from e in _equiposContexto.equipos
                                      where e.id_equipos == id
                                      select e).FirstOrDefault();
            if (equiposExiste == null)
                return NotFound();

            equiposExiste.nombre = equiposModificar.nombre;
            equiposExiste.descripcion = equiposModificar.descripcion;
            equiposExiste.marca_id  = equiposModificar.marca_id;
            equiposExiste.tipo_equipo_id = equiposModificar.tipo_equipo_id;
            equiposExiste.anio_compra = equiposModificar.anio_compra;
            equiposExiste.costo = equiposModificar.costo;

            _equiposContexto.Entry(equiposExiste).State = EntityState.Modified;
            _equiposContexto.SaveChanges();

            return Ok(equiposExiste);
        }

        //Eliminar
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult eliminarEquipos(int id)
        {
            equipos? equiposExiste = (from e in _equiposContexto.equipos
                                      where e.id_equipos == id
                                      select e).FirstOrDefault();

            if (equiposExiste == null) return NotFound();
            equiposExiste.estado = "E";
            _equiposContexto.Entry(equiposExiste).State = EntityState.Modified;

           // _equiposContexto.equipos.Attach(equiposExiste);
           // _equiposContexto.equipos.Remove(equiposExiste);
            _equiposContexto.SaveChanges();

            return Ok(equiposExiste);
        }




    }



}
