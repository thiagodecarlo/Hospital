using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Data.Context;


namespace Infra.Data.Repositories
{
    public class HospitalRepository : RepositoryBase<Hospital>, IHospitalRepository
    {
        public HospitalRepository(HospContext _context) : base(_context)
        {
        }
        public HospContext HospContext
        {
            get { return Db as HospContext; }
        }
    }
}