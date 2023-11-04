using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using Datos;

namespace Negocio
{
   public  class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id, Descripcion from CATEGORIAS");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria art = new Categoria();
                    art.Id1 = (int)datos.Lector["Id"];
                    art.Descripcion1 = (string)datos.Lector["Descripcion"];
                    listaCategorias.Add(art);

                }
                return listaCategorias;
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
        public bool chequear(List<Categoria> lista, string categoria)
        {
            bool existe = false;

            foreach (var Categoria in lista)
            {
                if (Categoria.Descripcion1.ToUpper() == categoria.ToUpper())
                {
                    existe = true;
                }
            }
            return existe;
        }
        public void agregarCat(Categoria categ)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into CATEGORIAS(Descripcion) VALUES('" + categ.Descripcion1 + "')");
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
        public void eliminarCat(Categoria cat)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Delete from CATEGORIAS where Id = " + cat.Id1);
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
        public bool validarCampos(string campo)
        {
            if (string.IsNullOrEmpty(campo))
            {
                return true;
            }
            return false;
        }
        public bool validarLetras(string campo)
        {
            foreach (char letra in campo)
            {
                if (char.IsNumber(letra))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
