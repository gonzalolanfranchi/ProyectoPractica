using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoPractica
{
    internal class DiscoService
    {
        public List<Disco> listar()
        {
            List<Disco> lista = new List<Disco>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select D.Titulo, D.FechaLanzamiento 'Fecha de Lanzamiento', D.CantidadCanciones 'Cantidad de Canciones', D.UrlImagenTapa, E.Descripcion Genero, TE.Descripcion Formato From DISCOS D, ESTILOS E, TIPOSEDICION TE Where D.IdEstilo = E.Id AND TE.Id = D.IdTipoEdicion\r\n";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Titulo = (string)lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)lector["Fecha de Lanzamiento"];
                    aux.CantidadCanciones = (int)lector["Cantidad de Canciones"];
                    aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];
                    aux.Genero = new Estilo();
                    aux.Genero.Descripcion = (string)lector["Genero"];
                    aux.Formato = new TipoEdicion();
                    aux.Formato.Descripcion = (string)lector["Formato"];

                    lista.Add(aux);


                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conexion.Close(); }
        }
    }
}
