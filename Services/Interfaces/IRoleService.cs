using Models;

namespace Services.Interfaces
{
    public interface IRoleService : IMainService<Role>
    {
        Role GetByCode(string code);
    }
}