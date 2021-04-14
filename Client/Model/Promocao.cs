using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    class Promocao
    {
        public int IdIngrediente { get; set; }

        public int IdIngredienteSem { get; set; }

        public string Nome { get; set; }

        public int Quantidade { get; set; }

        public int PorcaoDesconto { get; set; }

        public decimal PorcentagemDesconto { get; set; }
    }
}
