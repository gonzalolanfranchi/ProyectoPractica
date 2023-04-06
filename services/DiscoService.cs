using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Security.Cryptography.X509Certificates;
using System.Net.Configuration;

namespace services
{
    public class DiscoService
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
                comando.CommandText = "Select D.Id, D.Titulo, D.FechaLanzamiento, D.CantidadCanciones, D.UrlImagenTapa, E.Descripcion Genero, TE.Descripcion Formato, D.IdEstilo, D.IdTipoEdicion From DISCOS D, ESTILOS E, TIPOSEDICION TE Where D.IdEstilo = E.Id AND TE.Id = D.IdTipoEdicion AND D.Activo = 1";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Disco aux = new Disco();
                    aux.IdDisco = (int)lector["Id"];
                    aux.Titulo = (string)lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)lector["CantidadCanciones"];
                    aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];
                    aux.Genero = new Estilo();
                    aux.Genero.IdEstilo = (int)lector["IdEstilo"];
                    aux.Genero.Descripcion = (string)lector["Genero"];
                    aux.Formato = new TipoEdicion();
                    aux.Formato.IdTipoEdicion = (int)lector["IdTipoEdicion"];
                    aux.Formato.Descripcion = (string)lector["Formato"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void agregar(Disco nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into DISCOS (Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, IdEstilo, IdTipoEdicion) values (@titulo, @fechaLanzamiento, @cantidadCanciones, @urlImagenTapa, @idEstilo, @idTipoEdicion)");
                datos.setearParametro("@titulo", nuevo.Titulo);
                datos.setearParametro("@fechaLanzamiento", nuevo.FechaLanzamiento);
                datos.setearParametro("@cantidadCanciones", nuevo.CantidadCanciones);
                datos.setearParametro("@urlImagenTapa", nuevo.UrlImagenTapa);
                datos.setearParametro("@idEstilo", nuevo.Genero.IdEstilo);
                datos.setearParametro("@idTipoEdicion", nuevo.Formato.IdTipoEdicion);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Disco disc)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update DISCOS set Titulo = @titulo, FechaLanzamiento = @fechaLanzamiento, CantidadCanciones = @cantidadCanciones, UrlImagenTapa = @urlImagenTapa, IdEstilo = @idEstilo, IdTipoEdicion = @idTipoEdicion Where Id = @id");
                datos.setearParametro("@titulo", disc.Titulo);
                datos.setearParametro("@fechaLanzamiento", disc.FechaLanzamiento);
                datos.setearParametro("@cantidadCanciones", disc.CantidadCanciones);
                datos.setearParametro("@urlImagenTapa", disc.UrlImagenTapa);
                datos.setearParametro("@idEstilo", disc.Genero.IdEstilo);
                datos.setearParametro("@idTipoEdicion", disc.Formato.IdTipoEdicion);
                datos.setearParametro("@id", disc.IdDisco);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("Delete from DISCOS where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarLogico(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("update DISCOS set Activo = 0 where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Disco> filtrar(string campo, string criterio, string filtro)
        {
            List<Disco> lista = new List<Disco>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "Select D.Id, D.Titulo, D.FechaLanzamiento, D.CantidadCanciones, D.UrlImagenTapa, E.Descripcion Genero, TE.Descripcion Formato, D.IdEstilo, D.IdTipoEdicion From DISCOS D, ESTILOS E, TIPOSEDICION TE Where D.IdEstilo = E.Id AND TE.Id = D.IdTipoEdicion AND D.Activo = 1 AND ";

                switch (campo)
                {
                    case "Cantidad de canciones":
                        switch (criterio)
                        {
                            case "Mayor que":
                                consulta += "D.CantidadCanciones > " + filtro;
                                break;

                            case "Menor que":
                                consulta += "D.CantidadCanciones < " + filtro;
                                break;

                            default:
                                consulta += "D.CantidadCanciones = " + filtro;
                                break;
                        }
                        break;

                    case "Genero":
                        switch (criterio)
                        {
                            case "Contiene":
                                consulta += "E.Descripcion like '%" + filtro + "%'";
                                break;

                            case "Termina con":
                                consulta += "E.Descripcion like '%" + filtro + "'";
                                break;

                            default: //Empieza con
                                consulta += "E.Descripcion like '" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Formato":
                        switch (criterio)
                        {
                            case "Contiene":
                                consulta += "TE.Descripcion like '%" + filtro + "%'";
                                break;

                            case "Termina con":
                                consulta += "TE.Descripcion like '%" + filtro + "'";
                                break;

                            default: //Empieza con
                                consulta += "TE.Descripcion like '" + filtro + "%'";
                                break;
                        }
                        break;

                    default: // nombre
                        switch (criterio)
                        {
                            case "Contiene":
                                consulta += "D.Titulo like '%" + filtro + "%'";
                                break;

                            case "Termina con":
                                consulta += "D.Titulo like '%" + filtro + "'";
                                break;

                            default: //Empieza con
                                consulta += "D.Titulo like '" + filtro + "%'";
                                break;
                        }
                        break;
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Disco aux = new Disco();
                    aux.IdDisco = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)datos.Lector["CantidadCanciones"];
                    aux.UrlImagenTapa = (string)datos.Lector["UrlImagenTapa"];
                    aux.Genero = new Estilo();
                    aux.Genero.IdEstilo = (int)datos.Lector["IdEstilo"];
                    aux.Genero.Descripcion = (string)datos.Lector["Genero"];
                    aux.Formato = new TipoEdicion();
                    aux.Formato.IdTipoEdicion = (int)datos.Lector["IdTipoEdicion"];
                    aux.Formato.Descripcion = (string)datos.Lector["Formato"];

                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

