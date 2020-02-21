using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
namespace Domain.Interfaces.Repositories
{
    public interface ISkillRepository : IRepositoryBase<Skill>
    {
        new Task<Skill> GetByIdAsync(int id);
        Task<IEnumerable<Skill>> GetAllAsync(int _usercompanyId);
        Task<Skill> FindByNameAndDescAsync(string _name, string _description);
        Task<IEnumerable<Skill>> getskillsbycycleareasubarea(int? cycleId, int? areaId, int? subAreaId, int userCompanyId);
    }
}