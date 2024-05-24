using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Movimento
    {
        private int codigo;
        private FornecedorTransacaoType tipo;
        private int quantidade;
        private float valorCompra;
        private string dataEntrada;
        private string? fornecedor;
        private string? cliente;
        private int numeroFatura;
        private string motivoEntrada;

        public Movimento(int codigo, FornecedorTransacaoType tipo, int quantidade, float valorCompra, string dataEntrada, string? fornecedor, string? cliente, int numeroFatura, string motivoEntrada)
        {
            this.codigo = codigo;
            this.tipo = tipo;
            this.quantidade = quantidade;
            this.valorCompra = valorCompra;
            this.dataEntrada = dataEntrada;
            this.fornecedor = fornecedor;
            this.cliente = cliente;
            this.numeroFatura = numeroFatura;
            this.motivoEntrada = motivoEntrada;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public FornecedorTransacaoType Tipo { get => tipo; set => tipo = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public float ValorCompra { get => valorCompra; set => valorCompra = value; }
        public string DataEntrada { get => dataEntrada; set => dataEntrada = value; }
        public string? Fornecedor { get => fornecedor; set => fornecedor = value; }
        public string? Cliente { get => cliente; set => cliente = value; }
        public int NumeroFatura { get => numeroFatura; set => numeroFatura = value; }
        public string MotivoEntrada { get => motivoEntrada; set => motivoEntrada = value; }
    }
}
