using System.Collections.Generic;
using System.Linq;
using Acai.Api.Domain.Models;
using Acai.Api.Domain.Repositories;
using Acai.Api.Models.Input;
using Acai.Api.Persistence.Contexts;

namespace Acai.Api.Persistence.Repositories
{
    public class SaborRepository : BaseRepository, ISaborRepository
    {
        public SaborRepository(AppDbContext context) : base(context){ }
    
        public Sabor AddSabor(InputSabor sabor)
        {
            Sabor entidadeSabor = new Sabor();
            entidadeSabor.Descricao = sabor.Descricao;
            entidadeSabor.TempoMinutos = sabor.TempoMinutos;
            var resultado =  _context.Sabores.Add(entidadeSabor);
            _context.SaveChanges();
            return resultado.Entity;
        }

        public IEnumerable<Sabor> GetAllSabores(){           
            return _context.Sabores.ToList();
        }

        public Sabor GetByIdSabor(int id)
        {
             return _context.Sabores.Find(id);
        }

        public void DeleteSabor(int id)
        {            
            _context.Sabores.Remove(GetByIdSabor(id));
            _context.SaveChanges();
        }

        public bool SaborExists(int id)
        {
            return _context.Sabores.Any(p => p.Id == id);
        }

        public void UpdateSabor(InputSabor sabor)
        {
            var model = _context.Sabores.Where(p => p.Id.Equals(sabor.Id)).FirstOrDefault();;

            model.Descricao = sabor.Descricao;
            model.TempoMinutos = sabor.TempoMinutos;  
            _context.SaveChanges();          
        }
    }
}