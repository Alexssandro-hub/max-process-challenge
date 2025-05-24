using JwtAuthApi.Infrastructure.Domain;

namespace JwtAuthApi.Infrastructure.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario GetByLogin(string login);
        bool ExistsByLoginOrEmail(string login, string email);
    }
}
