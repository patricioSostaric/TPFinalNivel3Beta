using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar(string id = "")
        {
            List<Articulo> listaArticulos1 = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select A.Id,Codigo,Nombre,A.Descripcion,Precio,M.Descripcion as marca,C.Descripcion as categoria, ImagenUrl,IdMarca,IdCategoria, M.Id, C.Id from ARTICULOS A,MARCAS M, CATEGORIAS C WHERE IdMarca = M.Id and IdCategoria = C.Id");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Categoria = new Categoria();
                    aux.Marca = new Marca();

                    aux.Id = (int)datos.Lector["id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];


                    aux.Marca.Id1 = (int)datos.Lector["IdMarca"];//IdMarca tabla Articulos
                    aux.Marca.Descripcion1 = (string)datos.Lector["marca"];
                    aux.Categoria.Id1 = (int)datos.Lector["IdCategoria"];//IdCategoria tabla Articulos
                    aux.Categoria.Descripcion1 = (string)datos.Lector["categoria"];
                    aux.Precio = Math.Truncate((decimal)datos.Lector["Precio"] * 100) / 100;


                    listaArticulos1.Add(aux);
                }
                return listaArticulos1;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrar();
            }


        }

        public List<Articulo> listar()
        {
            List<Articulo> listaArticulos = new List<Articulo>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select A.Id,Codigo,Nombre,A.Descripcion,Precio,M.Descripcion as marca,C.Descripcion as categoria, ImagenUrl,IdMarca,IdCategoria, M.Id, C.Id from ARTICULOS A,MARCAS M, CATEGORIAS C WHERE IdMarca = M.Id and IdCategoria = C.Id");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Categoria = new Categoria();
                    aux.Marca = new Marca();

                    aux.Id = (int)datos.Lector["id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];


                    aux.Marca.Id1 = (int)datos.Lector["IdMarca"];//IdMarca tabla Articulos
                    aux.Marca.Descripcion1 = (string)datos.Lector["marca"];
                    aux.Categoria.Id1 = (int)datos.Lector["IdCategoria"];//IdCategoria tabla Articulos
                    aux.Categoria.Descripcion1 = (string)datos.Lector["categoria"];
                    aux.Precio = Math.Truncate((decimal)datos.Lector["Precio"] * 100) / 100;


                    listaArticulos.Add(aux);
                }
                return listaArticulos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrar();
            }

        }

        public void agregar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, Precio, ImagenUrl, IdMarca, IdCategoria) values('" + art.Codigo + "','" + art.Nombre + "','" + art.Descripcion + "', @Precio, @ImagenUrl, @IdMarca, @IdCategoria)");
                datos.setearParametros("@Precio", art.Precio);
                datos.setearParametros("@ImagenUrl", art.ImagenUrl);
                datos.setearParametros("@IdMarca", art.Marca.Id1);
                datos.setearParametros("@IdCategoria", art.Categoria.Id1);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrar();
            }

        }
        public void modificar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCat, ImagenUrl = @img, Precio = @precio WHERE Id = @id");
                datos.setearParametros("@codigo", art.Codigo);
                datos.setearParametros("@nombre", art.Nombre);
                datos.setearParametros("@descripcion", art.Descripcion);
                datos.setearParametros("@idMarca", art.Marca.Id1);
                datos.setearParametros("@idCat", art.Categoria.Id1);
                datos.setearParametros("@img", art.ImagenUrl);
                datos.setearParametros("@precio", art.Precio);
                datos.setearParametros("@id", art.Id);


                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrar();
            }
        }
        public void eliminar(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete from Articulos Where Id = @id");
                datos.setearParametros("@id", Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Articulo> filtrarLista(string campo, string criterio, string filtro)
        {
            List<Articulo> listaFiltrada = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "Select A.Id,Codigo,Nombre,A.Descripcion,Precio,M.Descripcion as marca,C.Descripcion as categoria, ImagenUrl,IdMarca,IdCategoria, M.Id, C.Id from ARTICULOS A,MARCAS M, CATEGORIAS C WHERE IdMarca = M.Id and IdCategoria = C.Id and ";

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a ":
                            consulta += "Precio > " + filtro;
                            break;
                        case "Menor a ":
                            consulta += "Precio < " + filtro;
                            break;

                        default:
                            consulta += "Precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con ":
                            consulta += "Nombre Like '" + filtro + "%'";
                            break;
                        case "Termina con ":
                            consulta += "Nombre Like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre Like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Código")
                {
                    switch (criterio)
                    {
                        case "Comienza con ":
                            consulta += "Codigo like '" + filtro + "%'";
                            break;
                        case "Termina con ":
                            consulta += "Codigo like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Codigo like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con ":
                            consulta += "A.Descripcion Like '" + filtro + "%'";
                            break;
                        case "Termina con ":
                            consulta += "A.Descripcion Like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "A.Descripcion Like '%" + filtro + "%'";
                            break;
                    }
                }
                datos.setearConsulta(consulta);
                datos.EjecutarLectura();
                //datos.ejecutarAccion();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Categoria = new Categoria();
                    aux.Marca = new Marca();

                    aux.Id = (int)datos.Lector["id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    aux.Marca.Id1 = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion1 = (string)datos.Lector["marca"];
                    aux.Categoria.Id1 = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion1 = (string)datos.Lector["categoria"];
                    aux.Precio = Math.Truncate((decimal)datos.Lector["Precio"] * 100) / 100;
                    //aux.Precio = (decimal)datos.Lector["Precio"];



                    listaFiltrada.Add(aux);
                }
                return listaFiltrada;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}