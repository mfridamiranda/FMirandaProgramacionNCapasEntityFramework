using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ProductoController : Controller
    {
        //GET: Carrito
        [HttpGet]
       public ActionResult GetAll()
       {
          
            ML.Producto producto = new ML.Producto();
            producto.Departamento = new ML.Departamento();

            ML.Result result = BL.Producto.GetAllEF(producto);

            ML.Result resultDepartamento = BL.Departamento.GetAllEF();

            producto.Departamento.Departamentos = resultDepartamento.Objects;
            producto.Productos = result.Objects;
            //result = BL.Producto.GetAllEF();

            return View(producto);

         
       }

        [HttpPost]

        public ActionResult GetAll(ML.Producto producto)
        {
            producto.ProductoNombre = (producto.ProductoNombre == null) ? "" : producto.ProductoNombre;

            producto.Departamento.IdDepartamento = producto.Departamento.IdDepartamento == null  ? 0 : producto.Departamento.IdDepartamento; //se pone 0 en donde van las comillas por que el valor que es entero

            ML.Result result = BL.Producto.GetAllEF(producto);
            producto.Productos = result.Objects;

            ML.Result resultDepartamento = BL.Departamento.GetAllEF();
            producto.Departamento.Departamentos = resultDepartamento.Objects;

            return View(producto);
        }






    }
}