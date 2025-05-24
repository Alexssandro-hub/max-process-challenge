using JwtAuthApi.Infrastructure.Domain;

namespace JwtAuthApi.Core.Interfaces
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        Usuario GetByLogin(string login);
        bool ExistsByLoginOrEmail(string login, string email);
    }
}
