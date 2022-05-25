using Dyder.Domain.Entities;
using Dyder.Repository.Repositories.Interfaces;
using Dyder.Repository.Repositories.Base;

namespace Dyder.Repository.Repositories
{
    public class EstabelecimentoRepository : RepositoryBase<Estabelecimento, long>, IEstabelecimentoRepository
    {
        public EstabelecimentoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
