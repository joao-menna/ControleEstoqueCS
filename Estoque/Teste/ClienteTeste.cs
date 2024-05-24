using Dominio;
using ExpectedObjects;
using Teste.Builders;

namespace Teste
{
    public class ClienteTeste
    {
        int _codigo;
        string _nome;
        string _endereco;
        string _telefone;
        string _cpf;
        string _email;
        string _rg;

        public ClienteTeste()
        {
            this._codigo = 1;
            this._nome = "Funerária Agrícola";
            this._endereco = "Rua das Cacaia, 12";
            this._telefone = "(47) 3025-8076";
            this._cpf = "222.222.222-22";
            this._email = "zecolmeia@parque.org";
            this._rg = "123";
        }


        [Fact]
        public void CriarObjetoCliente()
        {
            var clienteEsperado = new
            {
                Codigo = _codigo,
                Nome = _nome,
                Endereco = _endereco,
                Telefone = _telefone,
                Cpf = _cpf,
                Email = _email,
                Rg = _rg
            };

            Cliente cli = new Cliente(_codigo, _nome, _endereco, _telefone, _cpf, _email, _rg);

            clienteEsperado.ToExpectedObject().ShouldMatch(cli);
        }


        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        public void ClienteCodigoInvalido(int cod)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ClienteBuilder.Novo().ComCodigo(cod).Criar()
            ) ;
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ClienteNomeInvalido(string nome)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ClienteBuilder.Novo().ComNome(nome).Criar()
            );
        }



        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ClienteEnderecoInvalido(string end)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ClienteBuilder.Novo().ComEndereco(end).Criar()
            );

        }



        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ClienteTelefoneInvalido(string tel)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ClienteBuilder.Novo().ComTelefone(tel).Criar()
            );

        }



        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("111.222.333-44")]
        public void ClienteCpfInvalido(string cpf)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ClienteBuilder.Novo().ComCPF(cpf).Criar()
            );
            
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("ze")]
        [InlineData("ze@")]
        [InlineData("@bol.com.br")]
        public void ClienteEmailInvalido(string email)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ClienteBuilder.Novo().ComEmail(email).Criar()
            );

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ClienteRgInvalido(string rg)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ClienteBuilder.Novo().ComRg(rg).Criar()
            );

        }
    }
}
