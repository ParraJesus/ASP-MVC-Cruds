using Microsoft.AspNetCore.Mvc;
using CRUDCORE.Data;
using CRUDCORE.Models;

namespace CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos();

        public IActionResult Listar()
        {
            //Mostrar una lista de contactos en la vista
            var oLista = _ContactoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Abre la vista de guardar
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModelo oContacto)
        {
            //Recibe un objeto para poder guardarlo en la BD
            var answer = _ContactoDatos.Guardar(oContacto);

            if (answer) return RedirectToAction("Listar");
            else return View();
        }
    }
}
