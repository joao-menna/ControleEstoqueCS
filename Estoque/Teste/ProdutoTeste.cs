﻿using Bogus;
using Dominio;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Builders;

namespace Teste
{
    public class ProdutoTeste
    {
        private int _codigo;
        private string _descricao;
        private string _codigoBarras;
        private float _precoVenda;
        private string _categoria;
        private string _fornecedor;

        public ProdutoTeste()
        {
            Faker faker = new();
            
            _codigo = faker.Random.Int(1, 10000);
            _descricao = faker.Random.Words(5);
            _codigoBarras = faker.Random.Int(1_000_000, 9_999_999).ToString();
            _precoVenda = faker.Random.Float() % 100f;
            _categoria = faker.Random.Word();
            _fornecedor = faker.Random.Words(2);
        }

        [Fact]
        public void Should_CriarProduto()
        {
            var produto = new Produto(
                _codigo,
                _descricao,
                _codigoBarras,
                0,
                _precoVenda,
                0,
                _categoria,
                _fornecedor
            );

            var produtoEsperado = new
            {
                Codigo = _codigo,
                Descricao = _descricao,
                CodigoBarras = _codigoBarras,
                PrecoCompra = 0,
                PrecoVenda = _precoVenda,
                QuantidadeEstoque = 0,
                Categoria = _categoria,
                Fornecedor = _fornecedor
            }.ToExpectedObject();

            produtoEsperado.ShouldMatch(produto);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Should_CriarProdutoComCodigo(int codigo)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ProdutoBuilder.Novo().ComCodigo(codigo);
            });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_CriarProdutoComDescricao(string descricao)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ProdutoBuilder.Novo().ComDescricao(descricao);
            });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_CriarProdutoComCodigoBarras(string codigoBarras)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ProdutoBuilder.Novo().ComCodigoBarras(codigoBarras);
            });
        }

        [Fact]
        public void Should_CriarProdutoComQuantidadeEstoque()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ProdutoBuilder.Novo().ComQuantidadeEstoque(-1);
            });
        }
    }
}