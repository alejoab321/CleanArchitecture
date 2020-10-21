using Domain.Entities.Person;
using System;
using System.Collections.Generic;
using System.Text;


namespace Domain.Entities
{
    public class Obra
    {
        private long recaudo;
        public string Titulo { get; set; }
        public List<Espectador> Espectadores { get; set ; }
        public int Hora { get; set; }
        public long Recaudo 
        {
            get
            {
                return recaudo;
            }
            set
            {
                recaudo = value;
            }
        }
           

        public Obra(string titulo, int hora)
        {
            Espectadores = new List<Espectador>();
            Titulo = titulo;
            Hora = hora;
        }

        public void MostrarAbonados()
        {
            ClasificarEspectadores(1);
        }

        public void MostrarOcasional()
        {
            ClasificarEspectadores(0);
        }

        private void ClasificarEspectadores(int accion) 
        {
            string nombresAbonados = "----- Lista de Abonados ----- \n";
            string nombresOcacionales = "----- Lista de Ocacionales ----- \n";
            foreach (var espectador in Espectadores)
            {
                if (typeof(Abonado).IsInstanceOfType(espectador))
                {
                    Abonado abonado = (Abonado)espectador;
                    nombresAbonados += "nombre :" + $"{abonado.Nombre}" + "\n";
                }
                else if (typeof(Ocacional).IsInstanceOfType(espectador))
                {
                    Ocacional ocacional = (Ocacional)espectador;
                    nombresOcacionales += "nombre :" + $"{ocacional.Nombre}" + "\n";

                }

            }
            switch (accion)
            {
                case Constantes.Ocasional:
                    Console.WriteLine(nombresOcacionales);
                    break;
                case Constantes.Abonado:
                    Console.WriteLine(nombresAbonados);
                    break;
                default:
                    break;
            }
        }


    }
}
