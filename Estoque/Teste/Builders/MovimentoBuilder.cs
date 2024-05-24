using Bogus;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Builders
{
    public class MovimentoBuilder
    {
        private int _codigo;
        private FornecedorTransacaoType _tipo;
        private int _quantidade;
        private float _valorCompra;
        private string _dataEntrada;
        private string? _fornecedor;
        private string? _cliente;
        private int _numeroFatura;
        private string _motivoEntrada;

        private MovimentoBuilder()
        {
            Faker faker = new();
            Random random = new();

            _codigo = faker.Random.Int(1, 10000);
            _quantidade = faker.Random.Int(1, 10000);
            _valorCompra = faker.Random.Float() % 100f;
            _dataEntrada = faker.Date.Recent(5).ToShortDateString();

            // Gerar cliente ou fornecedor aleatorio
            var hasFornecedor = random.NextDouble() >= 0.5d;
            _fornecedor = hasFornecedor ? faker.Person.FullName : null;
            _cliente = !hasFornecedor ? faker.Person.FullName : null;

            _numeroFatura = faker.Random.Int(1, 10000);
            _motivoEntrada = faker.Random.Words(3);

            Array values = Enum.GetValues(typeof(FornecedorTransacaoType));
            FornecedorTransacaoType randomTransacaoType =
                (FornecedorTransacaoType)values.GetValue(random.Next(values.Length))!;

            _tipo = randomTransacaoType;
        }
        
        public static MovimentoBuilder Novo()
        {
            return new MovimentoBuilder();
        }

        public Movimento Criar()
        {
            return new Movimento(
                _codigo,
                _tipo,
                _quantidade,
                _valorCompra,
                _dataEntrada,
                _fornecedor,
                _cliente,
                _numeroFatura,
                _motivoEntrada
            );
        }

        public MovimentoBuilder ComCodigo(int atributo)
        {
            _codigo = atributo;
            return this;
        }

        public MovimentoBuilder ComTipo(FornecedorTransacaoType atributo)
        {
            _tipo = atributo;
            return this;
        }

        public MovimentoBuilder ComQuantidade(int atributo)
        {
            _quantidade = atributo;
            return this;
        }
        
        public MovimentoBuilder ComValorCompra(float atributo)
        {
            _valorCompra = atributo;
            return this;
        }
        
        public MovimentoBuilder ComDataEntrada(string atributo)
        {
            _dataEntrada = atributo;
            return this;
        }
        
        public MovimentoBuilder ComFornecedor(string atributo)
        {
            _fornecedor = atributo;
            return this;
        }

        public MovimentoBuilder ComCliente(string atributo)
        {
            _cliente = atributo;
            return this;
        }

        public MovimentoBuilder ComNumeroFatura(int atributo)
        {
            _numeroFatura = atributo;
            return this;
        }

        public MovimentoBuilder ComMotivoEntrada(string atributo)
        {
            _motivoEntrada = atributo;
            return this;
        }
    }
}
