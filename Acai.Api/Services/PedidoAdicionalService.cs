using System.Collections.Generic;
using Acai.Api.Domain.Models;
using Acai.Api.Domain.Repositories;
using Acai.Api.Domain.Services;

namespace Acai.Api.Services
{
    public class PedidoAdicionalService : IPedidoAdicionalService
    {
         private readonly IPedidoAdicionalRepository _pedidoAdicionalRepository;

        public PedidoAdicionalService(IPedidoAdicionalRepository pedidoAdicionalRepository){
            _pedidoAdicionalRepository = pedidoAdicionalRepository;
        }
        
        public IEnumerable<PedidoAdicional> GetAllPedidoAdicional()
        {
            return _pedidoAdicionalRepository.GetAllPedidoAdicional();
        }
    }
}