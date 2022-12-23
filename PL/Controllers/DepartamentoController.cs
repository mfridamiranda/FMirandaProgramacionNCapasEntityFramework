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
            //ML.Result result = BL.Departamento.GetAll(); //se invoca al metodo de GetAll en la capa BL SqlClient
            ML.Area area = new ML.Area();
            ML.Result result = BL.Departamento.GetAllEF(); //se invoca al metodo de GetAll en la capa BL Entity

            ML.Departamento departamento = new ML.Departamento(); //instancia de mi objeto departamento
            

            if (result.Correct)
            {
                departamento.Departamentos = result.Objects;//departamento devuelve la lista de objetos 
                //departamento.Area.Areas = result.Objects;
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
            ML.Result resultArea = BL.Area.GetAllEF();
            ML.Departamento departamento = new ML.Departamento();

            departamento.Area = new ML.Area();

            if (IdDepartamento == null)
            {
                departamento.Area.Areas = resultArea.Objects;

                return View(departamento);


            }
            else
            {

                //GetById
                /*ML.Result result = BL.Departamento.GetById(IdDepartamento.Value);*///se invoca al metodo de GetById en la capa BL SqlClient
                ML.Result result = BL.Departamento.GetByIdEF(IdDepartamento.Value);//se invoca al metodo de GetById en la capa BL Entity Framework
                //ML.Departamento departamento = new ML.Departamento();
                if (result.Correct)
                {
                    departamento = (ML.Departamento)result.Object;

                    departamento.Area.Areas = resultArea.Objects.ToList();
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
            //ML.Result result = new ML.Result(); 
            if (departamento.IdDepartamento == 0)
            {

                /*ML.Result result = BL.Departamento.Add(departamento);*///se invoca al metodo de GetById en la capa BL SqlClient
                ML.Result result = BL.Departamento.AddEF(departamento);//se invoca al metodo de GetById en la capa BL Entity Framework

                if (result.Correct)
                {
                    ViewBag.Message = "Se agrego un departamento correctamente";
                }
                else
                {
                    ViewBag.Message = "Error: " + result.Message;
                }

            }
            else
            {
                /*ML.Result result = BL.Departamento.Update(departamento);*///se invoca al metodo de GetById en la capa BL SqlClient
                ML.Result result = BL.Departamento.UpdateEF(departamento);//se invoca al metodo de GetById en la capa BL Entity Framework

                if (result.Correct)
                {
                    ViewBag.Message ="Se actualizo el departamento";
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
            //ML.Result result = BL.Departamento.Delete(departamento);/ se invoca al metodo de GetById en la capa BL SqlClient
            ML.Result result = BL.Departamento.DeleteEF(departamento);//se invoca al metodo de GetById en la capa BL Entity Framework

            if (departamento != null)
            {
                if (result.Correct)
                {
                    ViewBag.Message = "Se elimino el Departamento correctamente";

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