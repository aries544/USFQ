using Microsoft.AspNetCore.Mvc;
using USFQ_Backend.Models;

namespace USFQ_Backend.Controllers
{
    public class ContactoController:Controller
    {
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Contacto contacto )
        {
            return View(contacto);
        }

        public IActionResult Listar()
        {
            return View();
        }
    }
}
