using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Area
    {
        public static ML.Result AreaGetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySP = "AreaGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = querySP;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        DataTable areaTable = new DataTable();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        sqlDataAdapter.Fill(areaTable);
                        if (areaTable.Rows.Count > 0)

                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in areaTable.Rows)
                            {
                                ML.Area area = new ML.Area();

                                area.IdArea = int.Parse(row[0].ToString());
                                area.Nombre = row[1].ToString();

                                result.Objects.Add(area);

                                

                               
                            }



                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct=false;
                result.ex = ex;
                result.Message = "ocurrio un error al insertar area" + result.ex;

            }
            return result;
                
        }
    }
}
