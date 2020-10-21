using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Person
{
    public class Abonado : Espectador
    {
        public Abonado(string nombre) : base(nombre)
        {
        }

        public override long ComprarBoleta(Obra obra)
        {
            int precioBoleta = Constantes.PrecioBoletaAbonado;
            if (obra.Hora > 9)
            {
                return CobrarRecargoExtra(precioBoleta);
            }
            
            return precioBoleta;
        }
    }
}
