using Microsoft.AspNetCore.Mvc;

namespace USFQ_Backend.Controllers
{
    public class ContactoController:Controller
    {
        public IActionResult Crear()
        {
            return View();
        }
    }
}
