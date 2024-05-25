using Bogus;
using Bogus.DataSets;
using Dominio;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Builders;

namespace Teste
{
    public class FornecedorTeste
    {
        private int _codigo;
        private string _nome;
        private string _endereco;
        private string _email;
        private string _telefone;
        private string _termoPagamento;
        private List<FornecedorTransacao> _historicoTransacoes;

        public FornecedorTeste()
        {
            Faker faker = new();

            _codigo = faker.Random.Int(min: 1, max: 10000);
            _nome = faker.Person.FullName;
            _endereco = faker.Address.FullAddress();
            _email = faker.Person.Email;
            _telefone = faker.Person.Phone;
            _termoPagamento = faker.Random.Words(3);

            _historicoTransacoes = new();

            for (int i = 0; i < 5; i++)
            {
                Random random = new();
                Array values = Enum.GetValues(typeof(FornecedorTransacaoType));
                FornecedorTransacaoType randomTransacaoType =
                    (FornecedorTransacaoType)values.GetValue(random.Next(values.Length))!;

                _historicoTransacoes.Add(
                    new FornecedorTransacao(i, _codigo, 100.50 * i, randomTransacaoType)
                );
            }
        }

        [Fact]
        public void Should_CriarFornecedor()
        {
            Fornecedor fornecedor = new(
                _codigo,
                _nome,
                _endereco,
                _email,
                _telefone,
                _termoPagamento,
                _historicoTransacoes
            );

            var fornecedorEsperado = new
            {
                Codigo = _codigo,
                Nome = _nome,
                Email = _email,
                Telefone = _telefone,
                TermoPagamento = _termoPagamento,
                HistoricoTransacoes = _historicoTransacoes
            }.ToExpectedObject();

            fornecedorEsperado.ShouldMatch(fornecedor);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Should_CriarComCodigo(int codigo)
        {
            Assert.Throws<ArgumentException>(
                () =>
                {
                    FornecedorBuilder.Novo().ComCodigo(codigo).Criar();
                }
            );
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_CriarComNome(string nome)
        {
            Assert.Throws<ArgumentException>(
                () =>
                {
                    FornecedorBuilder.Novo().ComNome(nome).Criar();
                }
            );
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_CriarComEndereco(string endereco)
        {
            Assert.Throws<ArgumentException>(
                () =>
                {
                    FornecedorBuilder.Novo().ComEndereco(endereco).Criar();
                }
            );
        }

        [Theory]
        [InlineData("ze")]
        [InlineData("ze@")]
        [InlineData("@colmeia.com.br")]
        public void Should_CriarComEmail(string email)
        {
            Assert.Throws<ArgumentException>(
                () =>
                {
                    FornecedorBuilder.Novo().ComEmail(email).Criar();
                }
            );
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_CriarComTelefone(string telefone)
        {
            Assert.Throws<ArgumentException>(
                () =>
                {
                    FornecedorBuilder.Novo().ComTelefone(telefone).Criar();
                }
            );
        }
    }
}
