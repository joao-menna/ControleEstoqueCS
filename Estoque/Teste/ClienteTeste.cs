using Bogus;
using Bogus.Extensions.Brazil;
using Dominio;
using ExpectedObjects;
using Teste.Builders;

namespace Teste
{
    public class ClienteTeste
    {
        private readonly int _codigo;
        private readonly string _nome;
        private readonly string _endereco;
        private readonly string _telefone;
        private readonly string _cpf;
        private readonly string _email;
        private readonly string _rg;

        public ClienteTeste()
        {
            Faker faker = new();

            _codigo = faker.Random.Int(1);
            _nome = faker.Person.FullName;
            _endereco = faker.Address.FullAddress();
            _telefone = faker.Person.Phone;
            _cpf = faker.Person.Cpf();
            _email = faker.Person.Email;
            _rg = faker.Random.Int(100_000, 999_999).ToString();
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

        [Theory]
        [InlineData("Claudio", null, null)]
        [InlineData(null, "claudio@email.com", null)]
        [InlineData(null, null, "(69) 91234-4567")]
        public void Should_BuscarCliente(string nome, string email, string telefone)
        {
            var cliente = ClienteBuilder
                .Novo()
                .ComNome("Claudio")
                .ComEmail("claudio@email.com")
                .ComTelefone("(69) 91234-4567")
                .Criar();

            var clienteBuscado = Cliente.Buscar(nome, email, telefone);

            Assert.Equal(cliente.Codigo, clienteBuscado!.codigo);
        }
    }
}
