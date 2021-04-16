using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ejercicio_POO.Models.Entities;

namespace Ejercicio_POO.Controllers
{
    public class TransportesController : Controller
    {
        private List<Transporte> _transportes;

        public TransportesController()
        {
            if (this._transportes == null)
            {
                this._transportes = new List<Transporte>();
                this.InicializarTransportes();
            }
        }

        // GET: Transportes
        public ActionResult Index(string vbMensaje = null)
        {
            ViewBag.Mensaje = vbMensaje;

            return View(this._transportes.OrderBy(t => t.Id));
        }

        public ActionResult Avanzar(int id)
        {
            var transporte = this._transportes.FirstOrDefault(t => t.Id == id);
            if (transporte == null) return RedirectToAction("Index");

            var mensaje = transporte.Avanzar();
            return RedirectToAction("Index", new { vbMensaje = mensaje });
        }

        public ActionResult Detener(int id)
        {
            var transporte = this._transportes.FirstOrDefault(t => t.Id == id);
            if (transporte == null) return RedirectToAction("Index");

            var mensaje = transporte.Detenerse();
            return RedirectToAction("Index", new { vbMensaje = mensaje });
        }

        public ActionResult Despegar(int id)
        {
            var transporte = this._transportes.FirstOrDefault(t => t.Id == id);
            if (transporte == null || transporte.GetType().Equals(typeof(Automovil))) return RedirectToAction("Index");

            var mensaje = ((Avion)transporte).Despegar();
            return RedirectToAction("Index", new { vbMensaje = mensaje });
        }

        /// <summary>
        /// Inicializa la lista de Transportes con 5 Aviones y 5 Automoviles
        /// </summary>
        private void InicializarTransportes()
        {
            // Aviones
            this._transportes.Add(new Avion(1, 120, 150));
            this._transportes.Add(new Avion(2, 90, 100));
            this._transportes.Add(new Avion(3, 18, 50));
            this._transportes.Add(new Avion(4, 210, 350));
            this._transportes.Add(new Avion(5, 380, 400));

            // Automoviles
            this._transportes.Add(new Automovil(6, 1, 2));
            this._transportes.Add(new Automovil(7, 2, 2));
            this._transportes.Add(new Automovil(8, 2, 5));
            this._transportes.Add(new Automovil(9, 1, 5));
            this._transportes.Add(new Automovil(10, 4, 5));
        }
    }
}