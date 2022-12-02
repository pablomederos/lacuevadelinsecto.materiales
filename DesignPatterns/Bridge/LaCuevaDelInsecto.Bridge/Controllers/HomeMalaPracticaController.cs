using LaCuevaDelInsecto.Bridge.DBServices.MalaPractica;
using LaCuevaDelInsecto.Bridge.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LaCuevaDelInsecto.Bridge.Controllers
{
    public class HomeMalaPracticaController : Controller
    {
        private readonly PostgresPersonaService _postgresPersonaService;
        public HomeMalaPracticaController()
        {
            _postgresPersonaService = new PostgresPersonaService();
        }

        public IActionResult Index()
        {
            return View("HomeMalaPractica");
        }

        public IActionResult Get()
        {
            _postgresPersonaService.Get(1);

            ViewData["result"] = "Obtenido";

            return View("HomeMalaPractica");
        }

        public IActionResult Save()
        {
            new PostgresPersonaService().Save(new Persona
            {
                Nombre = "Gabriel",
                Apellido = "Mederos"
            });

            ViewData["result"] = "Guardado";

            return View("HomeMalaPractica");
        }

        public IActionResult Update()
        {
            new PostgresPersonaService.Update(new Persona
            {
                idPersona = 1,
                Nombre = "Gabriel",
                Apellido = "Mederos"
            });

            ViewData["result"] = "Actualizado";

            return View("HomeMalaPractica");
        }

        public IActionResult Delete()
        {
            _postgresPersonaService.Delete(1);

            ViewData["result"] = "Eliminado";

            return View("HomeMalaPractica");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}