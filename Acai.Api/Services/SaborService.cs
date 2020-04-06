using System.Collections.Generic;
using System.Threading.Tasks;
using Acai.Api.Domain.Models;
using Acai.Api.Domain.Repositories;
using Acai.Api.Domain.Services;
using Acai.Api.Models.Input;

namespace Acai.Api.Services
{
    public class SaborService : ISaborService
    {
        private readonly ISaborRepository _saborRepository;

        public SaborService(ISaborRepository saborRepository){
            _saborRepository = saborRepository;
        }
        public Sabor AddSabor(InputSabor sabor)
        {
            return _saborRepository.AddSabor(sabor);
        }
        
        public IEnumerable<Sabor> GetAllSabores(){
            return _saborRepository.GetAllSabores();
        }
        public Sabor GetByIdSabor(int id){
            return  _saborRepository.GetByIdSabor(id);
        }

        public void DeleteSabor(int id)
        {
            _saborRepository.DeleteSabor(id);
        }
        public bool SaborExists(int id)
        {
            return _saborRepository.SaborExists(id);
        }

        public void UpdateSabor(InputSabor sabor)
        {
             _saborRepository.UpdateSabor(sabor);
        }
    }
}