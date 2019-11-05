using System;
using System.Globalization;
using System.Text;

namespace ListaEncadeada.Entities
{
    class Boleto
    {
        public int Codigo { get; set; }
        public double Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public Boleto Next { get; set; }

        public Boleto(int codigo, double valor, DateTime dataVencimento)
        {
            Codigo = codigo;
            Valor = valor;
            DataVencimento = dataVencimento;
            Next = null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Codigo: {Codigo}");
            sb.AppendLine($"Valor: {Valor.ToString("F2", CultureInfo.InvariantCulture)}");
            sb.AppendLine($"Data de vencimento: {DataVencimento.ToString("dd/MM/yyyy")}");
            return sb.ToString();
        }
    }
}
