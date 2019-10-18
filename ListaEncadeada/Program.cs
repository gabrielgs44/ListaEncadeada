using ListaEncadeada.Comum.Enums;
using ListaEncadeada.Entities;
using ListaEncadeada.Extensions;
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
            do
            {
                Console.Write("Digite o codigo do boleto: ");
                var cod = int.Parse(Console.ReadLine());
                Console.Write("Digite o valor do boleto: ");
                var valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Digite a data de vencimento (dd/mm/yyyy): ");
                var dataVencimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var boleto = new Boleto(cod, valor, dataVencimento);
                list.Inserir(new Node(boleto));

                Console.Write("Continue? (S ou N): ");
                var opcao = Char.Parse(Console.ReadLine().ToUpper());

                continuar = opcao == 'S';

            } while (continuar);

            Console.Clear();
            list.Imprimir();

            Console.Write("Infomer o saldo disponível para realizar os pagamentos: ");
            var saldo = double.Parse(Console.ReadLine());

            saldo = list.RealizarPagamentos(saldo);

            Console.WriteLine();
            Console.WriteLine("Contas que não foram pagas: ");
            list.Imprimir(StatusPagamento.NaoPago);
            Console.WriteLine($"Seu saldo atual: {saldo}");
            var valorQueFalta = list.CalcularValorQueFalta(saldo);
            Console.WriteLine($"valor à acrescentar para efetuar os pagamentos: {valorQueFalta}");
        }
    }
}

