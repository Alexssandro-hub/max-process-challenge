using JwtAuthApi.Core.Interfaces;
using JwtAuthApi.Infrastructure.Domain;
using JwtAuthApi.Infrastructure.Interfaces;

namespace JwtAuthApi.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly EncryptPassService _encryptPassService;

        public UsuarioService(
            IUsuarioRepository repository, EncryptPassService encryptPassService)
        {
            _repository = repository;
            _encryptPassService = encryptPassService;
        }

        public void Create(Usuario entity)
        {
            entity.Senha = _encryptPassService.Encrypt(entity.Senha);
            _repository.Create(entity);
        } 
        public void Delete(Guid id) => _repository.Delete(id); 
        public bool ExistsByLoginOrEmail(string login, string email) => _repository.ExistsByLoginOrEmail(login, email); 
        public IEnumerable<Usuario> GetAll() => _repository.GetAll(); 
        public Usuario GetById(Guid id) => _repository.GetById(id); 
        public Usuario GetByLogin(string login) => _repository.GetByLogin(login); 
        public void Update(Usuario entity)
        {
            entity.Senha = _encryptPassService.Encrypt(entity.Senha);
            _repository.Update(entity); 
        }
    }
}
