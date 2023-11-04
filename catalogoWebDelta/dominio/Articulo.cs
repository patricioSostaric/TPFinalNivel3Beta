using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
     public class Articulo
    {
        private int id;
        private string codigo;
        private string nombre;
        private string descripcion;
        private string imagenUrl;
        private decimal precio;
        private Marca marca;
        private Categoria categoria;

        public int Id { get => id; set => id = value; }
        [DisplayName("Código")]
        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        [DisplayName("Descripción")]
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string ImagenUrl { get => imagenUrl; set => imagenUrl = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public Marca Marca { get => marca; set => marca = value; }
        [DisplayName("Categoría")]
        public Categoria Categoria { get => categoria; set => categoria = value; }
    }
}
