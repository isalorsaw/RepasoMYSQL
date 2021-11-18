using System;
using System.Collections.Generic;
using System.Text;

namespace RepasoMYSQL.Clases
{
    public class Empleado
    {
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }

        public string nombrec => $"{nombre} {apellido}";
    }
}
