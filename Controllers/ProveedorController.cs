using Microsoft.AspNetCore.Mvc;
using PROVEEDORES.Models;

namespace PROVEEDORES.Controllers
{
    public class ProveedorController : Controller
    {
        private static List<Proveedor> _proveedores = new List<Proveedor>
        {
            new Proveedor { Id = 1, NombreEmpresa = "Tech Solutions", Contacto = "Carlos Pérez", Telefono = "555-1234", Email = "carlos@techsolutions.com", Activo = true },
            new Proveedor { Id = 2, NombreEmpresa = "Papelería Central", Contacto = "María López", Telefono = "555-5678", Email = "maria@papeleriacentral.com", Activo = true },
            new Proveedor { Id = 3, NombreEmpresa = "Café del Valle", Contacto = "Jorge Ramírez", Telefono = "555-9012", Email = "jorge@cafedelvalle.com", Activo = false }
        };

        public IActionResult Index()
        {
            return View(_proveedores);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Proveedor proveedor)
        {
            proveedor.Id = _proveedores.Max(p => p.Id) + 1;
            _proveedores.Add(proveedor);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var proveedor = _proveedores.FirstOrDefault(p => p.Id == id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return View(proveedor);
        }

        [HttpPost]
        public IActionResult Editar(Proveedor proveedor)
        {
            var existente = _proveedores.FirstOrDefault(p => p.Id == proveedor.Id);
            if (existente == null)
            {
                return NotFound();
            }

            existente.NombreEmpresa = proveedor.NombreEmpresa;
            existente.Contacto = proveedor.Contacto;
            existente.Telefono = proveedor.Telefono;
            existente.Email = proveedor.Email;
            existente.Activo = proveedor.Activo;

            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            var proveedor = _proveedores.FirstOrDefault(p => p.Id == id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return View(proveedor);
        }

        [HttpPost]
        public IActionResult EliminarProveedor(int id)
        {
            var proveedor = _proveedores.FirstOrDefault(p => p.Id == id);
            if (proveedor != null)
            {
                _proveedores.Remove(proveedor);
            }
            return RedirectToAction("Index");
        }
    }
}
