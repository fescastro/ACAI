using System.Collections.Generic;
using Acai.Api.Domain.Models;
using Acai.Api.Models.Input;

namespace Acai.Api.Domain.Services
{
    public interface IAdicionalService
    {
         Adicional AddAdicional(InputAdicional adicional);
         IEnumerable<Adicional> GetAllAdicionais();
         Adicional GetByIdAdicional(int id);
         void DeleteAdicional(int id);
         bool AdicionalExists(int id);
         void UpdateAdicional(InputAdicional adicional);
    }
}