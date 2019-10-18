using ListaEncadeada.Comum.Enums;
using ListaEncadeada.Entities;
using ListaEncadeada.Services;
using System;

namespace ListaEncadeada.Extensions
{
    public static class ListaBoletoExtensions
    {
        public static ListaBoleto Inserir(this ListaBoleto list, Node node)
        {

            if (list.Head == null)
            {
                list.Head = node;
            }
            else
            {
                Node last = list.Head;

                do
                {
                    if (ListaBoletoService.VerificarQualEMaior(last, node))
                    {
                        Node aux = new Node(last.Atual)
                        {
                            Next = last.Next
                        };
                        last = node;
                        last.Next = aux;

                        list.Head = list.Head.Atual.Equals(last.Next.Atual) ? last : list.Head;
                        return list;
                    }

                    if (last.Next != null)
                    {
                        last = last.Next;
                    }

                } while (last.Next != null);

                last.Next = node;

            }

            return list;
        }

        public static void Imprimir(this ListaBoleto list, StatusPagamento? fIltroExibicao = null)
        {
            Node currNode = list.Head;

            while (currNode != null)
            {
                if (fIltroExibicao.HasValue)
                {
                    if (currNode.Atual.StatusPagamento == fIltroExibicao)
                    {
                        Console.WriteLine(currNode.Atual);
                    }
                }
                else
                {
                    Console.WriteLine(currNode.Atual);
                }
                currNode = currNode.Next;
            }

        }

        public static ListaBoleto Remover(this ListaBoleto list, int? id)
        {
            if (id.HasValue)
            {
                var last = list.Head;

                while (last.Next != null)
                {
                    if (last.Next.Atual.Id == id)
                    {
                        last.Next = last.Next.Next;
                        last.Next.Atual.Id--;
                    }
                    else
                    {
                        last = last.Next;
                    }
                }

                return list;
            }

            return list;
        }

        public static double RealizarPagamentos(this ListaBoleto list, double saldo)
        {
            Node currNode = list.Head;

            do
            {
                saldo = currNode.Atual.RealizarPagamento(saldo);
                currNode = currNode.Next;

            } while (currNode != null);

            return saldo;
        }

        public static double CalcularTotalAPagar(this ListaBoleto list, double saldo)
        {
            Node currNode = list.Head;
            double valorTotal = 0;

            do
            {
                if (currNode.Atual.StatusPagamento == StatusPagamento.NaoPago)
                    valorTotal = valorTotal + currNode.Atual.Valor;

                currNode = currNode.Next;

            } while (currNode != null);

            return (valorTotal - saldo) < 0 ? 0 : valorTotal - saldo;
        }
    }
}
