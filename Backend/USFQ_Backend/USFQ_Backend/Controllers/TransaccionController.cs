using Microsoft.AspNetCore.Mvc;
using USFQ_Backend.Models;
using USFQ_Backend.Servicios;

namespace USFQ_Backend.Controllers
{
    public class TransaccionController:Controller
    {
        private readonly IRepositorioTransaccion repositorioTransaccion;

        public TransaccionController(IRepositorioTransaccion repositorioTransaccion)
        {
            this.repositorioTransaccion = repositorioTransaccion;
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Transaccion transaccion)
        {
            await repositorioTransaccion.Crear(transaccion);

            return RedirectToAction("Listar");
        }

        public async Task<IActionResult> Listar()
        {
            var contactos = await repositorioTransaccion.Obtener();

            return View(contactos);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var transaccion = await repositorioTransaccion.ObtenerPorId(id);

            if (transaccion is null)
            {
                return RedirectToAction("Listar");
            }

            return View(transaccion);
        }

        [HttpPost]
        public async Task<ActionResult> Editar(Transaccion transaccion)
        {
            await repositorioTransaccion.Actualizar(transaccion);

            return RedirectToAction("Listar");
        }
    }
}
