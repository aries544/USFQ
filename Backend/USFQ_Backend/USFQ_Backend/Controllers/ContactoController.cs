using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using USFQ_Backend.Models;
using USFQ_Backend.Servicios;

namespace USFQ_Backend.Controllers
{
    public class ContactoController:Controller
    {
        private readonly IRepositorioContacto repositorioContacto;

        public ContactoController(IRepositorioContacto repositorioContacto)
        {
            this.repositorioContacto = repositorioContacto;
        }
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Contacto contacto )
        {
            await repositorioContacto.Crear(contacto);

            return RedirectToAction("Listar");
        }

        public async Task<IActionResult> Listar()
        {
            var contactos = await repositorioContacto.Obtener();

            return View(contactos);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var contacto = await repositorioContacto.ObtenerPorId(id);

            if(contacto is null)
            {
                return RedirectToAction("Listar");
            }

            return View(contacto);
        }

        [HttpPost]
        public async Task<ActionResult> Editar(Contacto contacto)
        {
            await repositorioContacto.Actualizar(contacto);

            return RedirectToAction("Listar");
        }

    }
}
