using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    public class FornecedorTransacao
    {
        private int _codigo;
        private int _codigoFornecedor;
        private float _valor;
        private FornecedorTransacaoType _tipoTransacao;

        public FornecedorTransacao(int codigo, int codigoFornecedor, float valor, FornecedorTransacaoType tipoTransacao)
        {
            if (codigo < 1) throw new ArgumentException("Código inválido");
            if (codigoFornecedor < 1) throw new ArgumentException("Código Fornecedor inválido");
            if (valor < 0) throw new ArgumentException("Valor inválido");

            _codigo = codigo;
            _codigoFornecedor = codigoFornecedor;
            _valor = valor;
            _tipoTransacao = tipoTransacao;
        }

        public int Codigo { get => _codigo; set => _codigo = value; }
        public int CodigoFornecedor { get => _codigoFornecedor; set => _codigoFornecedor = value; }
        public float Valor { get => _valor; set => _valor = value; }
        public FornecedorTransacaoType TipoTransacao { get => _tipoTransacao; set => _tipoTransacao = value; }
    }
}
