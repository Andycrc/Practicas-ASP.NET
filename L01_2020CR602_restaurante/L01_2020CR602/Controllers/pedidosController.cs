using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2020CR602.Model;
using Microsoft.EntityFrameworkCore;


namespace L01_2020CR602.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pedidosController : ControllerBase
    {
        private readonly Entidades _EntidadesContexto;
        public pedidosController(Entidades entidadesContexto)
        {
            _EntidadesContexto = entidadesContexto;
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
            List<Pedidos> Listadopedidos = (from e in _EntidadesContexto.pedidos
                                            select e).ToList();

            if (Listadopedidos.Count == 0)
            {
                return NotFound();
            }

            return Ok(Listadopedidos);
        }
        //gregar
        [HttpPost]
        [Route("add")]
        public IActionResult Crear([FromBody] Pedidos pedidonuevo)
        {
            try
            {
                _EntidadesContexto.pedidos.Add(pedidonuevo);
                _EntidadesContexto.SaveChanges();

                return Ok(pedidonuevo);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("actualizar/{id}")]
        public IActionResult actualizar(int id, [FromBody] Pedidos PedidosModificar)
        {
            Pedidos? platoExitente = (from e in _EntidadesContexto.pedidos
                                      where e.pedidoId == id
                                      select e).FirstOrDefault();
            if (platoExitente == null)
                return NotFound();

            platoExitente.motoristaId = PedidosModificar.motoristaId;
            platoExitente.clienteId = PedidosModificar.clienteId;
            platoExitente.platoId = PedidosModificar.platoId;
            platoExitente.cantidad = PedidosModificar.cantidad;
            platoExitente.precio = PedidosModificar.precio;   

            _EntidadesContexto.Entry(platoExitente).State = EntityState.Modified;
            _EntidadesContexto.SaveChanges();

            return Ok(platoExitente);
        }

        //Borrar
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult eliminarEquipos(int id)
        {
            Pedidos? PlatoExiste = (from e in _EntidadesContexto.pedidos
                                      where e.pedidoId == id
                                      select e).FirstOrDefault();

            if (PlatoExiste == null) return NotFound();

            _EntidadesContexto.pedidos.Attach(PlatoExiste);
            _EntidadesContexto.pedidos.Remove(PlatoExiste);
            _EntidadesContexto.SaveChanges();

            return Ok(PlatoExiste);
        }


        //Funcion extra
        [HttpGet]
        [Route("getbyid/{id}")]  
        public IActionResult Get(int id) {
            Pedidos? listapedidos = (from e in _EntidadesContexto.pedidos
                                where e.pedidoId == id
                                select e).FirstOrDefault();
        
            if(listapedidos == null) { return NotFound(); }
            return Ok(listapedidos);
        }

        [HttpGet]
        [Route("getby/{id}")]
        public IActionResult Get2(int id)
        {
            Pedidos? listapedidos2 = (from e in _EntidadesContexto.pedidos
                                where e.motoristaId == id
                                select e).FirstOrDefault();

            if (listapedidos2 == null) { return NotFound(); }
            return Ok(listapedidos2);
        }



    }
}
