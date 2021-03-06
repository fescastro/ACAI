using System.Collections.Generic;
using Acai.Api.Domain.Models;
using Acai.Api.Models.Input;

namespace Acai.Api.Domain.Repositories
{
    public interface ITamanhoRepository
    {
         Tamanho AddTamanho(InputTamanho tamanho);
         IEnumerable<Tamanho> GetAllTamanhos();
         Tamanho GetByIdTamanho(int id);
         void DeleteTamanho(int id);
         bool TamanhoExists(int id);
         void UpdateTamanho(InputTamanho tamanho);
    }
}