using System.Collections.Generic;
using Acai.Api.Business.Interface;
using Acai.Api.Domain.Models;
using Acai.Api.Domain.Repositories;
using Acai.Api.Domain.Services;
using Acai.Api.Models.Input;

namespace Acai.Api.Services

{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoBusiness _pedidoBusiness;

        public PedidoService(IPedidoRepository pedidoRepository, IPedidoBusiness pedidoBusiness){
            _pedidoRepository = pedidoRepository;
            _pedidoBusiness = pedidoBusiness;
        }

        public Pedido AddPedido(InputPedido pedido)
        {
            return _pedidoBusiness.AddPedido(pedido);
        }

        public Pedido AlterPedido(InputPedido pedido)
        {
           return _pedidoBusiness.AlterPedido(pedido);
        }

        public void CancelPedido(int id)
        {
            _pedidoRepository.CancelPedido(id);
        }

        public IEnumerable<Pedido> GetAllPedidos()
        {
            return _pedidoRepository.GetAllPedidos();
        }

        public Pedido GetByIdPedido(int id)
        {
           return _pedidoRepository.GetByIdPedido(id);
        }

        public bool PedidoExists(int id)
        {
           return _pedidoRepository.PedidoExists(id);
        }
       
    }
}