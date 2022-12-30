using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Producto
    {
      
        public int IdProducto { get; set; }

        public List<object> Productos { get; set; }
        public string ProductoNombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Stock { get; set; }
        public string Descipcion { get; set; }
        public ML.Departamento Departamento { get; set; }

        public ML.Provedor Provedor { get; set; }
    }
}
