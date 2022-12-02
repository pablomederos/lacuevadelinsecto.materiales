using LaCuevaDelInsecto.Bridge.Models;
using LaCuevaDelInsecto.Bridge.Services.Bridge.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LaCuevaDelInsecto.Bridge.Controllers
{
    /// <summary>
    /// Principio de Inversión de Dependencias:
    /// Las clases de alto nivel no deben depender de clases de
    /// bajo nivel. Ambas deben depender de Abstracciones.
    /// Las abstracciones no deben depender de los detalles.
    /// Los detalles deben depender de las abstracciones.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IPersonaService _personaService;

        // Inyección de dependencias utilizando método Patrón BRIDGE
        // Con la ayuda de .Net

        // Ahora el código cliente depende de abstacciones y no de
        // implementaciones
        public HomeController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Get()
        {
            _personaService.Get(1);

            ViewData["result"] = "Obtenido";

            return View("Index");
        }

        public IActionResult Save()
        {
            _personaService.Save(new Persona
            {
                Nombre = "Gabriel",
                Apellido = "Mederos"
            });

            ViewData["result"] = "Guardado";

            return View("Index");
        }

        public IActionResult Update()
        {
            _personaService.Update(new Persona
            {
                idPersona = 1,
                Nombre = "Gabriel",
                Apellido = "Mederos"
            });

            ViewData["result"] = "Actualizado";

            return View("Index");
        }

        public IActionResult Delete()
        {
            _personaService.Delete(1);

            ViewData["result"] = "Eliminado";

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}