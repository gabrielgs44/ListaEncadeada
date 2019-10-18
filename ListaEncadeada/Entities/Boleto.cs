using ListaEncadeada.Comum.Enums;
using System;
using System.Globalization;
using System.Text;

namespace ListaEncadeada.Entities
{
    public class Boleto
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public StatusPagamento StatusPagamento { get; private set; }

        public Boleto(int id, double valor, DateTime dataVencimento)
        {
            Id = id;
            Valor = valor;
            DataVencimento = dataVencimento;
            StatusPagamento = StatusPagamento.NaoPago;
        }

        public Double RealizarPagamento(double saldo)
        {
            if(saldo < Valor)
            {
                return saldo;
            }

            StatusPagamento = StatusPagamento.Pago;
            return saldo - Valor;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Codigo: {Id}");
            sb.AppendLine($"Valor: {Valor.ToString("F2", CultureInfo.InvariantCulture)}");
            sb.AppendLine($"Data de vencimento: {DataVencimento.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}");
            return sb.ToString();
        }
    }
}
