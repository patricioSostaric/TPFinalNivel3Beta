using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
  public   class Categoria
    {
        private int Id;
        private string Descripcion;

        [DisplayName("Id")]
        public int Id1 { get => Id; set => Id = value; }
        [DisplayName("Descripción")]
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }

        //Sobreescribimos metodo
        public override string ToString()
        {
            return Descripcion1;
        }
    }
}
