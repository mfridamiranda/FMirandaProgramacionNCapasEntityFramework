﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IOperaciones
    {
        [OperationContract]
        int Sumar(int numero1, int numero2);

        [OperationContract]
        int Restar(int numero1, int numero2);

        [OperationContract]
        int Multiplicar(int numero1, int numero2);

        [OperationContract]
        int Dividir(int numero1, int numero2);



        // TODO: Add your service operations here
    }


    
}
