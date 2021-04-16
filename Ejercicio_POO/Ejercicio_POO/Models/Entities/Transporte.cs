using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Ejercicio_POO.Models.Entities
{
    public abstract class Transporte
    {
        private readonly int _id;

        private readonly int _pasajeros;

        private readonly int _capacidad;

        public int Id => this._id;

        [DisplayName("Cantidad de pasajeros")]
        public int Pasajeros => this._pasajeros;

        [DisplayName("Capacidad máxima")]
        public int Capacidad => this._capacidad;

        protected Transporte(int id, int pasajeros, int capacidad)
        {
            _id = id;
            _pasajeros = pasajeros;
            _capacidad = capacidad;
        }

        public abstract string Avanzar();

        public abstract string Detenerse();
    }
}