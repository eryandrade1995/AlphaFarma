using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaFarma.Models
{
    class Produtos
    {
        public long id { get; set; }
        public string tipo { get; set; }
        public string nomenclatura { get; set; }
        public int unidade_caixa { get; set; }
        public double peso { get; set; }   
    }
}
