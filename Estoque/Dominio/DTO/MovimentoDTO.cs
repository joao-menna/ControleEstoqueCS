using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO
{
    public class MovimentoDTO
    {
        public int codigo;
        public string? codigoUnico;
        public FornecedorTransacaoType tipo;
        public int quantidade;
        public float valor;
        public string? data;
        public string? fornecedor;
        public string? cliente;
        public int numeroFatura;
        public string? motivo;
    }
}
