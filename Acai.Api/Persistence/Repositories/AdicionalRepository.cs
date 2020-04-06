using System.Collections.Generic;
using System.Linq;
using Acai.Api.Domain.Models;
using Acai.Api.Domain.Repositories;
using Acai.Api.Models.Input;
using Acai.Api.Persistence.Contexts;

namespace Acai.Api.Persistence.Repositories
{
    public class AdicionalRepository : BaseRepository, IAdicionalRepository
    {
         public AdicionalRepository(AppDbContext context) : base(context){ }
        public Adicional AddAdicional(InputAdicional adicional)
        {
            Adicional entidadeAdicional = new Adicional();
            entidadeAdicional.Descricao = adicional.Descricao;
            entidadeAdicional.TempoMinutos = adicional.TempoMinutos;
            entidadeAdicional.Valor = adicional.Valor;
            var resultado =  _context.Adicionals.Add(entidadeAdicional);
            _context.SaveChanges();
            return resultado.Entity;
        }

        public bool AdicionalExists(int id)
        {
            return _context.Adicionals.Any(p => p.Id == id);
        }

        public void DeleteAdicional(int id)
        {
             _context.Adicionals.Remove(GetByIdAdicional(id));
            _context.SaveChanges();
        }

        public IEnumerable<Adicional> GetAllAdicionais()
        {
             return _context.Adicionals.ToList();
        }

        public Adicional GetByIdAdicional(int id)
        {
           return _context.Adicionals.Find(id);
        }

        public void UpdateAdicional(InputAdicional adicional)
        {
           var model = _context.Adicionals.Where(p => p.Id.Equals(adicional.Id)).FirstOrDefault();;

            model.Descricao = adicional.Descricao;
            model.TempoMinutos = adicional.TempoMinutos; 
            model.Valor = adicional.Valor;
            _context.SaveChanges(); 
        }
    }
}