using JwtAuthApi.Infrastructure.Domain;

namespace JwtAuthApi.Abstractions.Interfaces.Repos
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario GetByLogin(string login);
        bool ExistsByLoginOrEmail(string login, string email);
    }
}
