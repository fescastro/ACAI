using System.Collections.Generic;
using Acai.Api.Domain.Models;
using Acai.Api.Models.Input;

namespace Acai.Api.Domain.Services
{
    public interface ISaborService
    {
        Sabor AddSabor(InputSabor sabor);
        IEnumerable<Sabor> GetAllSabores();
        Sabor GetByIdSabor(int id);
        void DeleteSabor(int id);
        bool SaborExists(int id);
        void UpdateSabor(InputSabor sabor);
    }
}