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

       public ActionResult GetAll()
       {
            ML.Departamento departamento = new ML.Departamento();

            ML.Result result = BL.Producto.GetAllEF();

            ML.Producto producto = new ML.Producto();

            if (result.Correct)
            {
                producto.Productos = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
            }
            return View(producto);
       }

        //form

        //[HttpGet]

        //public ActionResult Form(int? IdProducto)
        //{
        //    ML.Result resultDepartamento = BL.Departamento.GetAllEF();
        //    ML.Producto producto = new ML.Producto();

        //    producto.Departamento = new ML.Departamento();
        //    if (IdProducto == null)
        //    {
        //        producto.Departamento.Departamentoes = resultDepartamento.Objects;

        //        return View(producto);
        //    }
           


        //}

    

    }
}