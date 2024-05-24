using Bogus;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    public class FornecedorBuilder
    {
        private int _codigo;
        private string _nome;
        private string _endereco;
        private string _email;
        private string _telefone;
        private string _termoPagamento;
        private List<FornecedorTransacao> _historicoTransacoes;

        private FornecedorBuilder()
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

        public static FornecedorBuilder Novo()
        {
            return new FornecedorBuilder();
        }

        public Fornecedor Criar()
        {
            return new Fornecedor(
                _codigo,
                _nome,
                _endereco,
                _email,
                _telefone,
                _termoPagamento,
                _historicoTransacoes
            );
        }

        public FornecedorBuilder ComCodigo(int codigo)
        {
            _codigo = codigo;
            return this;
        }

        public FornecedorBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public FornecedorBuilder ComEndereco(string endereco)
        {
            _endereco = endereco;
            return this;
        }

        public FornecedorBuilder ComEmail(string email)
        {
            _email = email;
            return this;
        }

        public FornecedorBuilder ComTelefone(string telefone)
        {
            _telefone = telefone;
            return this;
        }

        public FornecedorBuilder ComTermoPagamento(string termoPagamento)
        {
            _termoPagamento = termoPagamento;
            return this;
        }

        public FornecedorBuilder ComHistoricoTransacoes(List<FornecedorTransacao> transacoes)
        {
            _historicoTransacoes = transacoes;
            return this;
        }
    }
}
