using JwtAuthApi.Infrastructure.Domain;

namespace JwtAuthApi.Abstractions.Interfaces.Services
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        Usuario GetByLogin(string login);
        bool ExistsByLoginOrEmail(string login, string email);
    }
}
