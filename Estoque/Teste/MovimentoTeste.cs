using Bogus;
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
    public class MovimentoTeste
    {
        private readonly int _codigo;
        private readonly string _codigoUnico;
        private readonly FornecedorTransacaoType _tipo;
        private readonly int _quantidade;
        private readonly float _valor;
        private readonly string _data;
        private readonly string? _fornecedor;
        private readonly string? _cliente;
        private readonly int _numeroFatura;
        private readonly string _motivo;

        public MovimentoTeste()
        {
            Faker faker = new();
            Random random = new();

            _codigo = faker.Random.Int(1, 10000);
            _codigoUnico = faker.Random.Int(1).ToString();
            _quantidade = faker.Random.Int(1, 10000);
            _valor = faker.Random.Float() % 100f;
            _data = faker.Date.Recent(5).ToShortDateString();

            // Gerar cliente ou fornecedor aleatorio
            var hasFornecedor = random.NextDouble() >= 0.5d;
            _fornecedor = hasFornecedor ? faker.Person.FullName : null;
            _cliente = !hasFornecedor ? faker.Person.FullName : null;

            _numeroFatura = faker.Random.Int(1, 10000);
            _motivo = faker.Random.Words(3);

            // Selecionar FornecedorTransacaoType aleatorio
            Array values = Enum.GetValues(typeof(FornecedorTransacaoType));
            FornecedorTransacaoType randomTransacaoType =
                (FornecedorTransacaoType)values.GetValue(random.Next(values.Length))!;

            _tipo = randomTransacaoType;
        }

        [Fact]
        public void Should_CriarProduto()
        {
            Movimento movimento = new(
                _codigo,
                _codigoUnico,
                _tipo,
                _quantidade,
                _valor,
                _data,
                _fornecedor,
                _cliente,
                _numeroFatura,
                _motivo);

            var movimentoEsperado = new
            {
                // Essa sintaxe funciona pois ficaria igual os nomes das propriedades
                // Codigo = movimento.Codigo
                // o C# detecta automaticamente, tipo no JavaScript
                // e sim, eu descobri isso agora
                movimento.Codigo,
                movimento.Tipo,
                movimento.Quantidade,
                movimento.Valor,
                movimento.Data,
                movimento.Fornecedor,
                movimento.Cliente,
                movimento.NumeroFatura,
                movimento.Motivo,
                movimento.CodigoUnico
            }.ToExpectedObject();

            movimentoEsperado.ShouldMatch(movimento);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_CriarComCodigo(int codigo)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                MovimentoBuilder.Novo().ComCodigo(codigo).Criar();
            });
        }


        [Fact]
        public void Should_CriarComQuantidade()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                MovimentoBuilder.Novo().ComQuantidade(-1).Criar();
            });
        }


        // O sufixo "f" no número obriga ele a ser float,
        // da mesma forma que o sufixo "l" obriga a ser long e
        // o sufixo "d" obriga a ser double
        [Fact]
        public void Should_CriarComValor()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                MovimentoBuilder.Novo().ComValor(-1f).Criar();
            });
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_CriarComData(string data)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                MovimentoBuilder.Novo().ComData(data).Criar();
            });
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_CriarComFornecedor(string fornecedor)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                MovimentoBuilder.Novo().ComFornecedor(fornecedor).ComCliente("").Criar();
            });
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_CriarComCliente(string cliente)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                MovimentoBuilder.Novo().ComFornecedor("").ComCliente(cliente).Criar();
            });
        }


        [Fact]
        public void Should_CriarComNumeroFatura()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                MovimentoBuilder.Novo().ComNumeroFatura(-1).Criar();
            });
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_CriarComMotivo(string motivo)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                MovimentoBuilder.Novo().ComMotivo(motivo).Criar();
            });
        }
    }
}
