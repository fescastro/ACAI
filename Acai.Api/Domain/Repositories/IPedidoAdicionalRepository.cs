using System.Collections.Generic;
using Acai.Api.Domain.Models;

namespace Acai.Api.Domain.Repositories
{
    public interface IPedidoAdicionalRepository
    {
        IEnumerable<PedidoAdicional> GetAllPedidoAdicional();
        
    }
}