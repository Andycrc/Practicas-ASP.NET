using L01_2020CR602.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L01_2020CR602.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class clientesController : ControllerBase
    {
        private readonly Entidades _EntidadesContexto3;
        public clientesController(Entidades entidadesContexto)
        {
            _EntidadesContexto3 = entidadesContexto;
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult ObtenerEquipos()
        {
            List<clientes> ListadoClientes = (from e in _EntidadesContexto3.clientes
                                            select e).ToList();

            if (ListadoClientes.Count == 0)
            {
                return NotFound();
            }

            return Ok(ListadoClientes);
        }

        //gregar
        [HttpPost]
        [Route("add")]
        public IActionResult Crear([FromBody] clientes motoNuevo)
        {
            try
            {
                _EntidadesContexto3.clientes.Add(motoNuevo);
                _EntidadesContexto3.SaveChanges();

                return Ok(motoNuevo);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Modificar
        [HttpPut]
        [Route("actualizar/{id}")]
        public IActionResult actualizar(int id, [FromBody] clientes MotoModificar)
        {
            clientes? clienteExitente = (from e in _EntidadesContexto3.clientes
                                     where e.clienteId == id
                                     select e).FirstOrDefault();
            if (clienteExitente == null)
                return NotFound();

            clienteExitente.nombreCliente = MotoModificar.nombreCliente;
            clienteExitente.direccion = MotoModificar.direccion;


            _EntidadesContexto3.Entry(clienteExitente).State = EntityState.Modified;
            _EntidadesContexto3.SaveChanges();

            return Ok(clienteExitente);
        }

        //Borrar
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult eliminarEquipos(int id)
        {
            clientes? ClienteExiste = (from e in _EntidadesContexto3.clientes
                                   where e.clienteId == id
                                   select e).FirstOrDefault();

            if (ClienteExiste == null) return NotFound();

            _EntidadesContexto3.clientes.Attach(ClienteExiste);
            _EntidadesContexto3.clientes.Remove(ClienteExiste);
            _EntidadesContexto3.SaveChanges();

            return Ok(ClienteExiste);
        }


        //Funcion Extra

        [HttpGet]
        [Route("find")]
        public IActionResult buscar(string filtro)
        {
            List<clientes> equiposList = (from e in _EntidadesContexto3.clientes
                                        where e.direccion.Contains(filtro)

                                        select e).ToList();

            if (equiposList.Any())
            {
                return Ok(equiposList);
            }
            return NotFound();

        }


    }
}
