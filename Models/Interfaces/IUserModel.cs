using GestionBoutiqueC.Core;
using GestionBoutiqueC.Entities;


namespace GestionBoutiqueC.Models.Interfaces
{
    public interface IUserModel : IModel<User>
    {
        Task<User> FindByLogin(string telephone);
        Task<User> FindByEmail(string telephone);
        IEnumerable<User> GetUsers();
        Task<PaginationModel<User>> GetUsersByPaginate(int page, int pageSize);

    }
}
