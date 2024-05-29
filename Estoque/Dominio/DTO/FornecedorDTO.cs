using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste;

namespace Dominio.DTO
{
    public class FornecedorDTO
    {
        public int codigo;
        public string? nome;
        public string? endereco;
        public string? email;
        public string? telefone;
        public string? termoPagamento;
        public List<FornecedorTransacao>? historicoTransacoes;
    }
}
