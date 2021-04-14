using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppApi.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        public int IdLanche { get; set; }

        public int Quantidade { get; set; }

        public decimal Valor { get; set; }
    }
}