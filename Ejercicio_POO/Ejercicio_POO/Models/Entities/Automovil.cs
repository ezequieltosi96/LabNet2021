using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejercicio_POO.Models.Entities
{
    public class Automovil : Transporte
    {
        public Automovil(int id, int pasajeros, int capacidad) : base(id, pasajeros, capacidad)
        {
        }

        public override string Avanzar()
        {
            return $"El automóvil #{this.Id - 5} esta avanzando.";
        }

        public override string Detenerse()
        {
            return $"El automóvil #{this.Id - 5} se detuvo.";
        }
    }
}