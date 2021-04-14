using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    class LancheIngrediente
    {
        public int idLanche { get; set; }

        public int idIngrediente { get; set; }

        public string NomeIngrediente { get; set; }

        public int QtPorcao { get; set; }

        public decimal ValorIngrediente { get; set; }
    }
}
