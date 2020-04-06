using System.Collections.Generic;
using Acai.Api.Domain.Models;
using Acai.Api.Domain.Repositories;
using Acai.Api.Domain.Services;
using Acai.Api.Models.Input;

namespace Acai.Api.Services
{
    public class AdicionalService : IAdicionalService
    {
        private readonly IAdicionalRepository _adicionalRepository;

        public AdicionalService(IAdicionalRepository adicionalRepository){
            _adicionalRepository = adicionalRepository;
        }
        public Adicional AddAdicional(InputAdicional adicional)
        {
            return _adicionalRepository.AddAdicional(adicional);
        }

        public bool AdicionalExists(int id)
        {
            return _adicionalRepository.AdicionalExists(id);
        }

        public void DeleteAdicional(int id)
        {
            _adicionalRepository.DeleteAdicional(id);
        }

        public IEnumerable<Adicional> GetAllAdicionais()
        {
            return _adicionalRepository.GetAllAdicionais();
        }

        public Adicional GetByIdAdicional(int id)
        {
           return _adicionalRepository.GetByIdAdicional(id);
        }

        public void UpdateAdicional(InputAdicional adicional)
        {
            _adicionalRepository.UpdateAdicional(adicional);
        }
    }
}