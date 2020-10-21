using Domain.Entities.Person;
using System;
using System.Collections.Generic;
using System.Text;


namespace Domain.Entities
{
    public class Teatro
    {
        public int IdTeatro { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }

        public Teatro(string nombre)
        {
            Nombre = nombre;
            Capacidad = Constantes.CapacidadInicial;
        }

        public bool VenderBoleta(Obra obra,Espectador espectador)
        {
            Capacidad++;
            if (Capacidad <= Constantes.CapacidadMaxima)
            {               
                obra.Espectadores.Add(espectador);
                obra.Recaudo += espectador.ComprarBoleta(obra);
                return Constantes.CupoDisponible;
            }
            Console.WriteLine("EL Teatro está lleno");
            return Constantes.CupoNoDisponible;
        }
    }
}
