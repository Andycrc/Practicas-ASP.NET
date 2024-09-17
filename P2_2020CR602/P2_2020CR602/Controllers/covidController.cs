using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using P2_2020CR602.Models;

namespace P2_2020CR602.Controllers
{
    public class covidController : Controller
    {
        private readonly covidDbContext _context;

        public covidController(covidDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //1
            var Departamentos = (from e in _context.departamentos
                                 select e).ToList();
            ViewData["listDepa"] = new SelectList(Departamentos, "id_departamento", "nombre_departamento");

            //2
            var generos = _context.generos.ToList();
            ViewData["listGenero"] = new SelectList(generos, "id_genero", "nombre_genero");

            //3
            var casosPorDepartamentoGenero = (from d in _context.departamentos
                                              join cr in _context.casosReportados on d.id_departamento equals cr.id_departamento
                                              join g in _context.generos on cr.id_genero equals g.id_genero
                                              select new
                                              {
                                                  Departamento = d.nombre_departamento,
                                                  Genero = g.nombre_genero,
                                                  CasosConfirmados = cr.casos_confirmados,
                                                  Recuperados = cr.recuperados,
                                                  Fallecidos = cr.fallecidos
                                              }).ToList();

            ViewBag.CasosPorDepartamentoGenero = casosPorDepartamentoGenero;





            return View();
        }

        public async Task<IActionResult> Create([Bind("id_departamento,id_genero,casos_confirmados,recuperados,fallecidos")] CasosReportados departamentos)
        {
            if (ModelState.IsValid)

            {
              

                _context.Add(departamentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departamentos);
        }


    }
}
