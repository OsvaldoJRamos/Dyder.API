using Microsoft.AspNetCore.Identity;

namespace Dyder.Domain.Entities
{
    public class Endereco
    {
        public int Id { get; private set; }
        public string Logradouro { get; private set; }
        public int Numero { get; private set; }
        public string CEP { get; private set; }
        public string Cidade { get; private set; }

        private int UsuarioId;
        public virtual IdentityUser Usuario { get; private set; }

        private int BairroId;
        public virtual Bairro Bairro { get; private set; }

        public Endereco(int id, string logradouro, int numero, string cEP, string cidade, int usuarioId, IdentityUser usuario, int bairroId, Bairro bairro)
        {
            Id = id;
            Logradouro = logradouro;
            Numero = numero;
            CEP = cEP;
            Cidade = cidade;
            UsuarioId = usuarioId;
            Usuario = usuario;
            BairroId = bairroId;
            Bairro = bairro;
        }
    }
}
