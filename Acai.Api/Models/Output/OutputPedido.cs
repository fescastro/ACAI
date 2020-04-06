namespace Acai.Api.Models.Output
{
    public class OutputPedido
    {
        public int TempoTotalPreparo {get; set;}
        public decimal ValorTotalPedido {get; set;}
        public string DescricaoTamanhoSabor {get; set;}
        public string DescricaoAdicional {get; set;}
    }
}