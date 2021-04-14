using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    class Pedido
    {
        public int Id { get; set; }

        public int IdLanche { get; set; }

        public int Quantidade { get; set; }

        public decimal Valor { get; set; }
    }
}
