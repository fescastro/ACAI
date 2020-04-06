using Acai.Api.Persistence.Contexts;

namespace Acai.Api.Persistence.Repositories
{
    //Classe responsável de expor o context para os repositórios associados as tabelas
    public class BaseRepository
    {
        protected readonly AppDbContext _context;
        
        public  BaseRepository(AppDbContext context){
            _context = context;
        }
    }
}