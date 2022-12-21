using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class DepartamentoController : Controller
    {
        // GET: Departamento
        public ActionResult GetAll()//Metodo
        {
            ML.Result result = BL.Departamento.GetAll(); //se invoca al metodo de GetAll en la capa BL

            ML.Departamento departamento = new ML.Departamento(); //instancia de mi objeto departamento

            if (result.Correct)
            {
                departamento.Departamentos = result.Objects;//departamento devuelve la lista de objetos 
            }
            else
            {
                ViewBag.Message = "OCURRIO UN ERROR AL REALIZAR LA CONSULTA";
                //error
            }

            
            return View(departamento);//guarda la lista de objetos 
        }

       

        //form 
        [HttpGet] 
        public ActionResult Form(int? IdDepartamento) 
        
        {
            if (IdDepartamento == null)
            {
                return View();
            }
            else
            {

                //GetById
                ML.Result result = BL.Departamento.GetById(IdDepartamento.Value);
                ML.Departamento departamento = new ML.Departamento();
                if (result.Correct)
                {
                    departamento = (ML.Departamento)result.Object;
                }
                else
                {

                    ViewBag.Message = "Ocurrio un error al consultar el departamneto seleccionado";

                }
                return View(departamento);
            }
        }





        [HttpPost]
        public ActionResult Form(ML.Departamento departamento)
        {

            if (departamento.IdDepartamento == 0)
            {

                ML.Result result = BL.Departamento.Add(departamento);

                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Error: " + result.Message;
                }

            }
            else
            {
                ML.Result result = BL.Departamento.Update(departamento);

                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message ="Error:" + result.Message;
                }

            }


            return PartialView("Modal");

        }

        public ActionResult Delete(ML.Departamento departamento)
        {
            ML.Result result = BL.Departamento.Delete(departamento);
            //if (departamento != null)
            {
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;

                }
                else
                {
                    ViewBag.Message = "Error:" + result.Message;
                }
            }
           
            return PartialView("Modal");
        }
           
       


    }
}