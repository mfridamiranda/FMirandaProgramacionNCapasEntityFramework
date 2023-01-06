using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IOperaciones
    {
        public int Sumar(int numero1, int numero2)
        {
            return numero1 + numero2;
        }
        public int Restar(int numero1, int numero2)
        {
            return numero1 - numero2;
        }
        public int Multiplicar(int numero1, int numero2)
        {
            return numero1 * numero2;
        }
        public int Dividir(int numero1, int numero2)
        {
            return numero1 / numero2;
        }


    }
}
