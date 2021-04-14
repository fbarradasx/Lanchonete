using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    class ListaPedido
    {
        public int ID_PEDIDO { get; set; }

        public int ID_LANCHE { get; set; }

        public string NM_LANCHE { get; set; }

        public int QT_LANCHE { get; set; }

        public decimal VL_TOTAL { get; set; }
    }
}
