using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Produto
    {
        private int codigo;
        private string descricao;
        private string codigoBarras;
        private float precoCompra;
        private float precoVenda;
        private int quantidadeEstoque;
        private string categoria;
        private string fornecedor;

        public Produto(int codigo, string descricao, string codigoBarras, float precoCompra, float precoVenda, int quantidadeEstoque, string categoria, string fornecedor)
        {
            this.codigo = codigo;
            this.descricao = descricao;
            this.codigoBarras = codigoBarras;
            this.precoCompra = 0;
            this.precoVenda = precoVenda;
            this.quantidadeEstoque = 0;
            this.categoria = categoria;
            this.fornecedor = fornecedor;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string CodigoBarras { get => codigoBarras; set => codigoBarras = value; }
        public float PrecoCompra { get => precoCompra; set => precoCompra = value; }
        public float PrecoVenda { get => precoVenda; set => precoVenda = value; }
        public int QuantidadeEstoque { get => quantidadeEstoque; set => quantidadeEstoque = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Fornecedor { get => fornecedor; set => fornecedor = value; }
    }
}
