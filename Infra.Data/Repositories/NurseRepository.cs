using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Data.Context;


namespace Infra.Data.Repositories
{
    public class NurseRepository : RepositoryBase<Nurse>, INurseRepository
    {
        public NurseRepository(HospContext _context) : base(_context)
        {
        }
        public HospContext HospContext
        {
            get { return Db as HospContext; }
        }
    }
}