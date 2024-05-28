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
            if (codigo < 1) throw new ArgumentException("Código inválido");
            if (string.IsNullOrEmpty(nome)) throw new ArgumentException("Nome inválido");
            if (string.IsNullOrEmpty(endereco)) throw new ArgumentException("Endereço inválido");
            if (!string.IsNullOrEmpty(email) && !EmailValido(email)) throw new ArgumentException("Email inválido");
            if (string.IsNullOrEmpty(telefone)) throw new ArgumentException("Telefone inválido");

            _codigo = codigo;
            _nome = nome;
            _endereco = endereco;
            _email = email;
            _telefone = telefone;
            _termoPagamento = termoPagamento;
            _historicoTransacoes = historicoTransacoes;
        }

        public int Codigo { get => _codigo; set => _codigo = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Email { get => _email; set => _email = value; }
        public string Telefone { get => _telefone; set => _telefone = value; }
        public string TermoPagamento { get => _termoPagamento; set => _termoPagamento = value; }
        public List<FornecedorTransacao> HistoricoTransacoes { get => _historicoTransacoes; set => _historicoTransacoes = value; }
        public string Endereco { get => _endereco; set => _endereco = value; }

        public bool EmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
