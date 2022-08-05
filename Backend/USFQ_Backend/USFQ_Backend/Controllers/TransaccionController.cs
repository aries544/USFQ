using Microsoft.AspNetCore.Mvc;

namespace USFQ_Backend.Controllers
{
    public class TransaccionController:Controller
    {
        public IActionResult Crear()
        {
            return View();
        }
    }
}
