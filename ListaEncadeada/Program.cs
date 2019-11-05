using ListaEncadeada.Entities;
using System;
using System.Globalization;

namespace ListaEncadeada
{
    class Program
    {
        static void Main(string[] args)
        {
            var continuar = true;
            ListaBoleto list = ListaBoleto.Criar();
            var cod = 0;
            do
            {
                Console.Write("Digite o valor do boleto: ");
                var valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Digite a data de vencimento (dd/mm/yyyy): ");
                var dataVencimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var boleto = new Boleto(cod, valor, dataVencimento);
                list.Inserir(boleto);

                Console.Write("Continue? (S ou N): ");
                var opcao = Char.Parse(Console.ReadLine().ToUpper());

                cod++;
                continuar = opcao == 'S';

            } while (continuar);

            Console.Clear();
            list.Imprimir();

            Console.Write("Infomer o saldo disponível para realizar os pagamentos: ");
            var saldo = double.Parse(Console.ReadLine());

            saldo = list.RealizarPagamentos(saldo);

            Console.WriteLine();
            Console.WriteLine("Contas que não foram pagas: ");
            list.Imprimir();
            var valorTotal = list.CalcularValorTotal();
            Console.WriteLine($"Valor total a pagar: {valorTotal}");
            Console.WriteLine($"Saldo Restante: {saldo}");

        }
    }
}

