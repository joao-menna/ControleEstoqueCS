using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO
{
    public class ProdutoDTO
    {
        public int codigo;
        public string? descricao;
        public string? codigoBarras;
        public float precoCompra;
        public float precoVenda;
        public int quantidadeEstoque;
        public string? categoria;
        public string? fornecedor;
    }
}
