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

            return View(contacto);
        }

        public IActionResult Listar()
        {
            return View();
        }
    }
}
