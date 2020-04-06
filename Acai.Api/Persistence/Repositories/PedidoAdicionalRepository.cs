using System.Collections.Generic;
using System.Linq;
using Acai.Api.Domain.Models;
using Acai.Api.Domain.Repositories;
using Acai.Api.Persistence.Contexts;

namespace Acai.Api.Persistence.Repositories
{
    public class PedidoAdicionalRepository : BaseRepository, IPedidoAdicionalRepository
    {
        public PedidoAdicionalRepository(AppDbContext context) : base(context){}

        public IEnumerable<PedidoAdicional> GetAllPedidoAdicional()
        {
            return _context.PedidosAdicionais.ToList();
        }
    }
}