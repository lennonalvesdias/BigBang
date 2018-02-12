using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace BigBang.Aplicacao.ViewModels
{
    public class Login
    {
        public SecurityKey Chave { get; }
        public SigningCredentials Credenciais { get; }

        public Login()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Chave = new RsaSecurityKey(provider.ExportParameters(true));
            }

            Credenciais = new SigningCredentials(Chave, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}