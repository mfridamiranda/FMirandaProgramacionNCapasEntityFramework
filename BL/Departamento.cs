using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Departamento
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection (DL.Conexion.GetConexion()))
                {
                    string query = "DepartamentoGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        DataTable departamentoTable = new DataTable();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        sqlDataAdapter.Fill(departamentoTable);

                        if (departamentoTable.Rows.Count >0)
                        {
                            result.Objects = new List<object>();//Inicia la lista de objetos 

                            foreach (DataRow row in departamentoTable.Rows)
                            {
                                 
                                ML.Departamento departamento = new ML.Departamento();
                                //revisar numeracion dentro de []
                                departamento.IdDepartamento = int.Parse(row[0].ToString());
                                departamento.Nombre = row[1].ToString();

                                departamento.Area = new ML.Area();
                                departamento.Area.IdArea = int.Parse(row[2].ToString());

                                result.Objects.Add(departamento);//trae la lista de objetos
                            }
                        }

                    }
                       

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ex = ex;
                result.Message = "Ocurrio un error al insertar el departamento" + result.ex;
            }
            return result;
        }

        public static ML.Result Add(ML.Departamento departamento)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "DepartamentoAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = departamento.Nombre;
                        collection[1] = new SqlParameter("IdArea", SqlDbType.TinyInt);
                        collection[1].Value = departamento.Area.IdArea;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se agrego el departamento correctamente";

                        }
                    }


                }
                result.Correct = true;

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ex = ex;
                result.Message = "Ocurrio un error al insertar el departamento" + result.ex;

            }
            return result;

        }

        public static ML.Result GetById(int IdDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySP = "DepartamentoGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = contex;
                        cmd.CommandText = querySP;
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        contex.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[0].Value = IdDepartamento;

                        cmd.Parameters.AddRange(collection);

                        DataTable departamentoTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(departamentoTable);
                        if (departamentoTable.Rows.Count > 0)
                        {
                            DataRow row = departamentoTable.Rows[0];

                            ML.Departamento departamento = new ML.Departamento();

                            departamento.IdDepartamento = int.Parse(row[0].ToString());
                            departamento.Nombre = row[1].ToString();

                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = int.Parse(row[2].ToString());

                            result.Object = departamento;

                        }
                            

                    }
                }
                result.Correct = true;

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ex = ex;
                result.Message = "Ocurrio un error al insertar el depratamento" + result.ex;

            }
            return result;

        }


        public static ML.Result Update(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "DepartamentoUpdate";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter [] collection = new SqlParameter[2];

                        //collection[0] = new SqlParameter("IdDepartartamento", SqlDbType.Int);
                        //collection[0].Value = departamento.IdDepartamento;

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = departamento.Nombre;

                        collection[1] = new SqlParameter("IdArea", SqlDbType.Int);
                        collection[1].Value = departamento.Area.IdArea;

                        cmd.Parameters.AddRange(collection);

                        int rowsAfected = cmd.ExecuteNonQuery();

                        if(rowsAfected >= 1)
                        {
                            result.Message = "Se modifico el departamento correctamente";

                        }

                    }
                }
                result.Correct = true;
                    
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ex = ex;
                result.Message = "Ocurrio un error al modificar el departamento" + result.ex;
                Console.ReadKey();



            }
            return result;
        }

        public static ML.Result Delete(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "DepartamentoDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdDepartamento", SqlDbType.Int);

                        collection[0].Value = departamento.IdDepartamento;

                        //collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        //collection[0].Value = departamento.Nombre;

                        //collection[1] = new SqlParameter("IdArea", SqlDbType.Int);
                        //collection[1].Value = departamento.Area.IdArea;


                        cmd.Parameters.AddRange(collection);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Sea elimino el departamento correctamente";

                            Console.ReadLine();
                        }
                        
                    } 
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ex = ex;
                result.Message = "Ocurrio un error al eliminar el Departamento" + result.ex;
                
            }
            return result;
        }


    }
}
