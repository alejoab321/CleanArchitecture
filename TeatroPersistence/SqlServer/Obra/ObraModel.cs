using System;
using System.Collections.Generic;
using System.Text;

namespace TeatroPersistence.SqlServer.Obra
{
    public class ObraModel
    {
        public int IdObra { get; set; }
        public string Nombre { get; set; }
        public int Hora { get; set; }
        public int IdTeatro { get; set; }
    }
}
