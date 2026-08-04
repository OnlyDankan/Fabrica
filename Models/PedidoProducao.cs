using System;

namespace Fabrica.Models
{
    public class PedidoProducao
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public string Prioridade { get; set; }
        public string Status { get; set; }
    }
}