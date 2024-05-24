using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste;

namespace Dominio
{
    public class Fornecedor
    {
        private int _codigo;
        private string _nome;
        private string _endereco;
        private string _email;
        private string _telefone;
        private string _termoPagamento;
        private List<FornecedorTransacao> _historicoTransacoes;

        public Fornecedor(int codigo, string nome, string endereco, string email, string telefone, string termoPagamento, List<FornecedorTransacao> historicoTransacoes)
        {
            Codigo = codigo;
            Nome = nome;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            TermoPagamento = termoPagamento;
            HistoricoTransacoes = historicoTransacoes;
        }

        public int Codigo { get => _codigo; set => _codigo = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Email { get => _email; set => _email = value; }
        public string Telefone { get => _telefone; set => _telefone = value; }
        public string TermoPagamento { get => _termoPagamento; set => _termoPagamento = value; }
        public List<FornecedorTransacao> HistoricoTransacoes { get => _historicoTransacoes; set => _historicoTransacoes = value; }
        public string Endereco { get => _endereco; set => _endereco = value; }
    }
}
