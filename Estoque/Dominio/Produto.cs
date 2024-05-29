using Dominio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Produto
    {
        private static List<ProdutoDTO> bd = new();

        private int codigo;
        private string descricao;
        private string codigoBarras;
        private float precoCompra;
        private float precoVenda;
        private int quantidadeEstoque;
        private string categoria;
        private string fornecedor;

        // Preferi manter o quantidadeEstoque e o precoCompra apesar de nao serem usados
        // pois sera mais facil de mudar caso necessario
        public Produto(int codigo, string descricao, string codigoBarras, float precoCompra, float precoVenda, int quantidadeEstoque, string categoria, string fornecedor)
        {
            if (codigo < 1) throw new ArgumentException("Código inválido");
            if (string.IsNullOrEmpty(descricao)) throw new ArgumentException("Descrição inválida");
            if (string.IsNullOrEmpty(codigoBarras)) throw new ArgumentException("Código de barras inválido");
            if (precoVenda < 0) throw new ArgumentException("Preço de venda inválido");

            this.codigo = codigo;
            this.descricao = descricao;
            this.codigoBarras = codigoBarras;
            this.precoCompra = 0f;
            this.precoVenda = precoVenda;
            this.quantidadeEstoque = 0;
            this.categoria = categoria;
            this.fornecedor = fornecedor;

            bd.Add(new ProdutoDTO
            {
                codigo = codigo,
                descricao = descricao,
                codigoBarras = codigoBarras,
                precoCompra = 0f,
                precoVenda = precoVenda,
                quantidadeEstoque = 0,
                categoria = categoria,
                fornecedor = fornecedor,
            });
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string CodigoBarras { get => codigoBarras; set => codigoBarras = value; }
        public float PrecoCompra { get => precoCompra; set => precoCompra = value; }
        public float PrecoVenda { get => precoVenda; set => precoVenda = value; }
        public int QuantidadeEstoque { get => quantidadeEstoque; set => quantidadeEstoque = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Fornecedor { get => fornecedor; set => fornecedor = value; }


        public static ProdutoDTO? Buscar(string descricao, string codigoBarras, string categoria)
        {
            foreach (var produto in bd)
            {
                if (!string.IsNullOrEmpty(descricao))
                {
                    if (produto.descricao!.Contains(descricao)) return produto;
                }

                if (!string.IsNullOrEmpty(codigoBarras))
                {
                    if (produto.codigoBarras!.Contains(codigoBarras)) return produto;
                }

                if (!string.IsNullOrEmpty(categoria))
                {
                    if (produto.categoria!.Contains(categoria)) return produto;
                }
            }

            return null;
        }
    }
}
