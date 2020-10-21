using System;
using System.Collections.Generic;
using System.Text;

namespace TeatroPersistence.SqlServer.Persona
{
    public class PersonaModel
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public int IdClasificado { get; set; }
    }
}
