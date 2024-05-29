using Dominio.DTO;
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
        private string codigoUnico;
        private FornecedorTransacaoType tipo;
        private int quantidade;
        private float valor;
        private string data;
        private string? fornecedor;
        private string? cliente;
        private int numeroFatura;
        private string motivo;

        public Movimento(
            int codigo,
            string codigoUnico,
            FornecedorTransacaoType tipo,
            int quantidade,
            float valor,
            string data,
            string? fornecedor,
            string? cliente,
            int numeroFatura,
            string motivo)
        {
            if (codigo < 1) throw new ArgumentException("Código inválido");
            if (quantidade < 0) throw new ArgumentException("Quantidade inválida");
            if (valor < 0) throw new ArgumentException("Valor inválido");
            if (string.IsNullOrEmpty(data)) throw new ArgumentException("Data inválida");
            if (string.IsNullOrEmpty(fornecedor) && string.IsNullOrEmpty(cliente)) {
                throw new ArgumentException("A movimentação deve possuir um fornecedor ou cliente");
            }
            if (numeroFatura < 1) throw new ArgumentException("Número da fatura inválido");
            if (string.IsNullOrEmpty(motivo)) throw new ArgumentException("Motivo inválido");

            this.codigo = codigo;
            this.codigoUnico = codigoUnico;
            this.tipo = tipo;
            this.quantidade = quantidade;
            this.valor = valor;
            this.data = data;
            this.fornecedor = fornecedor;
            this.cliente = cliente;
            this.numeroFatura = numeroFatura;
            this.motivo = motivo;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string CodigoUnico { get => codigoUnico; set => codigoUnico = value; }
        public FornecedorTransacaoType Tipo { get => tipo; set => tipo = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public float Valor { get => valor; set => valor = value; }
        public string Data { get => data; set => data = value; }
        public string? Fornecedor { get => fornecedor; set => fornecedor = value; }
        public string? Cliente { get => cliente; set => cliente = value; }
        public int NumeroFatura { get => numeroFatura; set => numeroFatura = value; }
        public string Motivo { get => motivo; set => motivo = value; }
    }
}
