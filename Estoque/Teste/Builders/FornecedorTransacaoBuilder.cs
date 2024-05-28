using Bogus;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Builders
{
    public class FornecedorTransacaoBuilder
    {
        private int _codigo;
        private int _codigoFornecedor;
        private float _valor;
        private FornecedorTransacaoType _tipoTransacao;

        private FornecedorTransacaoBuilder()
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

        public static FornecedorTransacaoBuilder Novo()
        {
            return new FornecedorTransacaoBuilder();
        }

        public FornecedorTransacao Criar()
        {
            return new FornecedorTransacao(
                _codigo,
                _codigoFornecedor,
                _valor,
                _tipoTransacao);
        }

        public FornecedorTransacaoBuilder ComCodigo(int atributo)
        {
            _codigo = atributo;
            return this;
        }

        public FornecedorTransacaoBuilder ComCodigoFornecedor(int atributo)
        {
            _codigoFornecedor = atributo;
            return this;
        }

        public FornecedorTransacaoBuilder ComValor(float atributo)
        {
            _valor = atributo;
            return this;
        }

        public FornecedorTransacaoBuilder ComTipoTransacao(FornecedorTransacaoType atributo)
        {
            _tipoTransacao = atributo;
            return this;
        }
    }
}
