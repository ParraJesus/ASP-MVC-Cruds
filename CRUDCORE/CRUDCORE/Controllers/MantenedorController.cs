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

            if (!ModelState.IsValid) 
            {
                return View();
            }
            var answer = _ContactoDatos.Guardar(oContacto);

            if (answer) return RedirectToAction("Listar");
            else return View();
        }

        public IActionResult Editar(int IdContacto)
        {
            //Abre la vista de guardar
            var oContacto = _ContactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModelo oContacto)
        {
            //Recibe un objeto para poder guardarlo en la BD

            if (!ModelState.IsValid)
            {
                return View();
            }
            var answer = _ContactoDatos.Editar(oContacto);

            if (answer) return RedirectToAction("Listar");
            else return View();
        }

        public IActionResult Eliminar(int IdContacto)
        {
            //Abre la vista de eliminar
            var oContacto = _ContactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModelo oContacto)
        {
            //Recibe un objeto para poder eliminarlo en la BD

            var answer = _ContactoDatos.Eliminar(oContacto.IdContacto);

            if (answer) return RedirectToAction("Listar");
            else return View();
        }
    }
}
