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
        private double _valor;
        private FornecedorTransacaoType _tipoTransacao;

        public FornecedorTransacao(int codigo, int codigoFornecedor, double valor, FornecedorTransacaoType tipoTransacao)
        {
            _codigo = codigo;
            _codigoFornecedor = codigoFornecedor;
            _valor = valor;
            _tipoTransacao = tipoTransacao;
        }

        public int Codigo { get => _codigo; set => _codigo = value; }
        public int CodigoFornecedor { get => _codigoFornecedor; set => _codigoFornecedor = value; }
        public double Valor { get => _valor; set => _valor = value; }
        public FornecedorTransacaoType TipoTransacao { get => _tipoTransacao; set => _tipoTransacao = value; }
    }
}
