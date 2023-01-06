using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result GetAllEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            
            try
            {
                using(DL_EF.FMirandaProgramacionNcapasEntities1 context = new DL_EF.FMirandaProgramacionNcapasEntities1())
                {
                    //producto.Departamento.IdDepartamento = (producto.Departamento.IdDepartamento == null) ? 0 : producto.Departamento.IdDepartamento;

                    var query = context.ProductoGetAll(producto.ProductoNombre,producto.Departamento.IdDepartamento).ToList();
                    //result.Objects = new List<object>();

                    if (query != null)
                    {
                       result.Objects = new List<object>();
                        foreach (var row in query)
                        {
                            //ML.Producto producto = new ML.Producto();

                            producto.IdProducto = row.IdProducto;
                            producto.ProductoNombre = row.ProductoNombre;
                            producto.PrecioUnitario = row.PrecioUnitario;
                            producto.Stock = row.Stock;
                            producto.Descipcion = row.Descripcion;
                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = row.IdDepartamento;

                            result.Objects.Add(producto);
                            

                        }
                    }

                    
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ex = ex;
                result.Message = "Ocurrio un error al mostrar los productos" + result.ex;

            }
            return result;  
        }



    }
}
