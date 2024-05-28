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
    public class FornecedorTransacaoTeste
    {
        private int _codigo;
        private int _codigoFornecedor;
        private float _valor;
        private FornecedorTransacaoType _tipoTransacao;

        public FornecedorTransacaoTeste()
        {
            Faker faker = new();

            _codigo = faker.Random.Int(1);
            _codigoFornecedor = faker.Random.Int(1);
            _valor = faker.Random.Float() % 100;

            Random random = new();
            Array values = Enum.GetValues(typeof(FornecedorTransacaoType));
            FornecedorTransacaoType randomTransacaoType =
                (FornecedorTransacaoType)values.GetValue(random.Next(values.Length))!;

            _tipoTransacao = randomTransacaoType;
        }

        [Fact]
        public void Should_CriarFornecedorTransacao()
        {
            var fornecedorTransacao = new FornecedorTransacao(
                _codigo,
                _codigoFornecedor,
                _valor,
                _tipoTransacao);

            var fornecedorTransacaoEsperado = new
            {
                Codigo = _codigo,
                CodigoFornecedor = _codigoFornecedor,
                Valor = _valor,
                TipoTransacao = _tipoTransacao,
            }.ToExpectedObject();

            fornecedorTransacaoEsperado.ShouldMatch(fornecedorTransacao);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_CriarComCodigo(int codigo)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FornecedorTransacaoBuilder.Novo().ComCodigo(codigo).Criar();
            });
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_CriarComCodigoFornecedor(int codigoFornecedor)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FornecedorTransacaoBuilder.Novo().ComCodigoFornecedor(codigoFornecedor).Criar();
            });
        }

        [Theory]
        [InlineData(-1f)]
        public void Should_CriarComValor(float valor)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FornecedorTransacaoBuilder.Novo().ComValor(valor).Criar();
            });
        }
    }
}
