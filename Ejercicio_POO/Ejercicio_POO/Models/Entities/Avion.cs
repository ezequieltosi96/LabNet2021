using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ejercicio_POO.Models.Interfaces;

namespace Ejercicio_POO.Models.Entities
{
    public class Avion : Transporte, IAvion
    {
        public Avion(int id, int pasajeros, int capacidad) : base(id, pasajeros, capacidad)
        {
        }

        public override string Avanzar()
        {
            return $"El avión #{this.Id} esta avanzando por la pista.";
        }

        public override string Detenerse()
        {
            return $"El avión #{this.Id} se detuvo y espera instrucciones de torre de contról.";
        }

        public string Despegar()
        {
            return $"El avión #{this.Id} despegó exitosamente.";
        }
    }
}