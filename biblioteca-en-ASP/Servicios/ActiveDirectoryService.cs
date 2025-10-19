using System.DirectoryServices.AccountManagement;

namespace biblioteca_en_ASP_NET.Servicios
{
    public class ActiveDirectoryService
    {
        private readonly string _dominio;

        public ActiveDirectoryService(string dominio)
        {
            _dominio = dominio;
        }

        public bool ValidarAD(string usuario, string password)
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, _dominio))
            {
                return pc.ValidateCredentials(usuario, password);
            }
        }
    }
}
