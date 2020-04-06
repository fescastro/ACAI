
using System.Collections.Generic;

namespace Acai.Api.Domain.Models
{
    public class Tamanho
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Ml { get; set; }
        public int TempoMinutos { get; set; }
        public decimal Valor { get; set; }
        public IEnumerable<Pedido> Pedidos { get; set; }
    }
}