using L01_2020CR602.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L01_2020CR602.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class platosController : ControllerBase
    {
        private readonly Entidades _EntidadesContexto1;
        public platosController(Entidades entidadesContexto)
        {
            _EntidadesContexto1 = entidadesContexto;
        }

        /// <summary>
        /// Buscar por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("getall")]
        public IActionResult ObtenerEquipos()
        {
            List<Platos> ListaPlatos = (from e in _EntidadesContexto1.platos
                                            select e).ToList();

            if (ListaPlatos.Count == 0)
            {
                return NotFound();
            }

            return Ok(ListaPlatos);
        }

        //gregar
        [HttpPost]
        [Route("add")]
        public IActionResult Crear([FromBody] Platos platoNuevi)
        {
            try
            {
                _EntidadesContexto1.platos.Add(platoNuevi);
                _EntidadesContexto1.SaveChanges();

                return Ok(platoNuevi);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("actualizar/{id}")]
        public IActionResult actualizar(int id, [FromBody] Platos PlatoModificar)
        {
            Platos? platoExitente = (from e in _EntidadesContexto1.platos
                                      where e.platoId == id
                                      select e).FirstOrDefault();
            if (platoExitente == null)
                return NotFound();

            platoExitente.nombrePlato = PlatoModificar.nombrePlato;
            platoExitente.precio = PlatoModificar.precio;


            _EntidadesContexto1.Entry(platoExitente).State = EntityState.Modified;
            _EntidadesContexto1.SaveChanges();

            return Ok(platoExitente);
        }

        //Borrar
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult eliminarEquipos(int id)
        {
            Platos? PlatoExiste = (from e in _EntidadesContexto1.platos
                                    where e.platoId == id
                                    select e).FirstOrDefault();

            if (PlatoExiste == null) return NotFound();

            _EntidadesContexto1.platos.Attach(PlatoExiste);
            _EntidadesContexto1.platos.Remove(PlatoExiste);
            _EntidadesContexto1.SaveChanges();

            return Ok(PlatoExiste);
        }

        //Funcion Extra

        [HttpGet]
        [Route("find")]
        public IActionResult buscar(string filtro)
        {
            List<Platos> equiposList = (from e in _EntidadesContexto1.platos
                                         where e.nombrePlato.Contains(filtro)
                                         
                                         select e).ToList();

            if (equiposList.Any())
            {
                return Ok(equiposList);
            }
            return NotFound();

        }
    }
}
