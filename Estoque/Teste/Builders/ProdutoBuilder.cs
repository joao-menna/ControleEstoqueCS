using Bogus;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Builders
{
    public class ProdutoBuilder
    {
        private int _codigo;
        private string _descricao;
        private string _codigoBarras;
        private float _precoCompra;
        private float _precoVenda;
        private int _quantidadeEstoque;
        private string _categoria;
        private string _fornecedor;

        private ProdutoBuilder()
        {
            Faker faker = new();

            _codigo = faker.Random.Int(1, 10000);
            _descricao = faker.Random.Words(5);
            _codigoBarras = faker.Random.Int(1_000_000, 9_999_999).ToString();
            _precoCompra = faker.Random.Float() % 100f;
            _precoVenda = faker.Random.Float() % 100f;
            _quantidadeEstoque = faker.Random.Int(1, 10000);
            _categoria = faker.Random.Word();
            _fornecedor = faker.Random.Words(2);
        }

        public static ProdutoBuilder Novo()
        {
            return new ProdutoBuilder();
        }

        public Produto Criar()
        {
            return new Produto(
                _codigo,
                _descricao,
                _codigoBarras,
                _precoCompra,
                _precoVenda,
                _quantidadeEstoque,
                _categoria,
                _fornecedor
            );
        }

        public ProdutoBuilder ComCodigo(int atributo)
        {
            _codigo = atributo;
            return this;
        }

        public ProdutoBuilder ComDescricao(string atributo)
        {
            _descricao = atributo;
            return this;
        }

        public ProdutoBuilder ComCodigoBarras(string atributo)
        {
            _codigoBarras = atributo;
            return this;
        }

        public ProdutoBuilder ComPrecoCompra(float atributo)
        {
            _precoCompra = atributo;
            return this;
        }

        public ProdutoBuilder ComPrecoVenda(float atributo)
        {
            _precoVenda = atributo;
            return this;
        }

        public ProdutoBuilder ComQuantidadeEstoque(int atributo)
        {
            _quantidadeEstoque = atributo;
            return this;
        }

        public ProdutoBuilder ComCategoria(string atributo)
        {
            _categoria = atributo;
            return this;
        }

        public ProdutoBuilder ComFornecedor(string atributo)
        {
            _fornecedor = atributo;
            return this;
        }
    }
}
