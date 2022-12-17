using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        public static string GetConexion()
        {
            return ConfigurationManager.ConnectionStrings["FMirandaProgramacionNcapas"].ConnectionString;

            //Data Source =.; Initial Catalog = FMirandaProgramacionNcapas; User ID = sa; Password = ***********


        }


    }

}

