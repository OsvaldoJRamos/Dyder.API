using Dyder.Domain.Entities;
using Dyder.Repository.Repositories.Interfaces;

namespace Dyder.Repository.Repositories
{
    public class EstabelecimentoRepository : RepositoryBase<Estabelecimento, long>, IEstabelecimentoRepository
    {
        private readonly ApplicationDbContext _context;
        public EstabelecimentoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
