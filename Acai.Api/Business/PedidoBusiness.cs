using System.Collections.Generic;
using System.Linq;
using Acai.Api.Business.Interface;
using Acai.Api.Domain.Models;
using Acai.Api.Domain.Repositories;
using Acai.Api.Domain.Services;
using Acai.Api.Models.Input;
using Acai.Api.Models.Output;

namespace Acai.Api.Business
{
    public class PedidoBusiness : IPedidoBusiness
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ITamanhoService _tamanhoService;
        private readonly ISaborService _saborService;
        private readonly IAdicionalService _adicionalService;
        private readonly IPedidoAdicionalService _pedidoAdicionalService;

        public PedidoBusiness (IPedidoRepository pedidoRepository, ITamanhoService tamanhoService, ISaborService saborService,
                               IAdicionalService adicionalService, IPedidoAdicionalService pedidoAdicionalService){
            _pedidoRepository = pedidoRepository;
            _tamanhoService = tamanhoService;
            _saborService = saborService;
            _adicionalService = adicionalService;
            _pedidoAdicionalService = pedidoAdicionalService;

        }

        //Registra o pedido do cliente
        public Pedido AddPedido(InputPedido pedido)
        {
            var total = CalcularValorTotal(pedido);
            return _pedidoRepository.AddPedido(pedido,total);
        }

        //Altera informações do pedido caso cliente necessite 
        public Pedido AlterPedido(InputPedido pedido)
        {
            var total = CalcularValorTotal(pedido);
            return _pedidoRepository.AlterPedido(pedido,total);
        }

        //Calcula o valor total do pedido
        private decimal CalcularValorTotal(InputPedido pedido)
        {
            decimal valorTotal = 0m;
            valorTotal += pedido.Tamanho.Valor;
            foreach (var adicional in pedido.Adicionais)
            {
                valorTotal += adicional.Valor;
            }

            return valorTotal;
        }

        //Calcula o tempo de preparo total do pedido
        private int CalcularTempoPreparoTotal(IEnumerable<Adicional> adicionais){
            int tempoTotalAdicionais = 0;
            foreach (var adicional in adicionais)
            {
                tempoTotalAdicionais += adicional.TempoMinutos;
            }

            return tempoTotalAdicionais;
        }

        public OutputPedido ResumoPedido(Pedido pedido){
            var modelPedido = new OutputPedido();

            //Recupera o registro da tabala tamanho deste pedido
            var modelTamanho = _tamanhoService.GetByIdTamanho(pedido.TamanhoId);
            //Recupera o registro da tabala sabor deste pedido
            var modelSabor = _saborService.GetByIdSabor(pedido.SaborId);
            //Recupera os Ids da tabala Adiconal deste pedido
            var IdsAdicional = _pedidoAdicionalService.GetAllPedidoAdicional().Where(p => p.PedidoId == pedido.Id).Select(p => p.AdicionalId);
            //Recupera o registro da tabala adicional deste pedido        
            var modelAdicional = _adicionalService.GetAllAdicionais().Where(p => IdsAdicional.Contains(p.Id));
            //Registra o tempo de preparo toal do pedido
            modelPedido.TempoTotalPreparo = modelTamanho.TempoMinutos + modelSabor.TempoMinutos + CalcularTempoPreparoTotal(modelAdicional);
            //registra o valor total do pedido
            modelPedido.ValorTotalPedido = pedido.ValorTotalPedido;
            //Detalha o tamanho e o sabor sabor do pedido
            modelPedido.DescricaoTamanhoSabor = $"Açai de {modelSabor.Descricao} - tamanho {modelTamanho.Descricao}({modelTamanho.Ml}Ml).";
            //detalha os adicionais(Personalizações) do pedido
            modelPedido.DescricaoAdicional = $"Adicionais:{string.Join(", ", modelAdicional.Select(p => p.Descricao))}.";

            return modelPedido;
        }
    }
}