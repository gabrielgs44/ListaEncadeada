namespace ListaEncadeada.Entities
{
    class ListaBoleto
    {
        public Boleto Head { get; set; }

        protected ListaBoleto()
        {
            Head = null;
        }

        public static ListaBoleto Criar()
        {
            return new ListaBoleto();
        }

        public ListaBoleto Inserir(Boleto newNode)
        {
            if (Head == null)
            {
                Head = newNode;
                return this;
            }
            else
            {
                var aux = Head;

                if (aux.DataVencimento >= newNode.DataVencimento)
                {
                    newNode.Next = aux;
                    Head = newNode;
                    return this;
                }
                else
                {
                    while (aux.Next != null)
                    {
                        if (aux.Next.DataVencimento >= newNode.DataVencimento)
                        {
                            newNode.Next = aux.Next;
                            aux.Next = newNode;
                            return this;
                        }

                        aux = aux.Next;
                    }

                    aux.Next = newNode;
                }

                return this;
            }
        }

        public void Imprimir()
        {
            var aux = Head;
            while (aux != null)
            {
                System.Console.WriteLine(aux);
                aux = aux.Next;

            }
        }

        public ListaBoleto Remover(int codigo)
        {
            var aux = Head;
            if (Head == null)
            {
                return this;
            }
            else
            {
                if (aux.Codigo == codigo)
                {
                    Head = aux.Next == null ? null : aux.Next;
                    return this;
                }
                else
                {
                    while (aux.Next != null)
                    {

                        if (aux.Next.Codigo == codigo)
                        {
                            aux.Next = aux.Next.Next;
                            return this;
                        }

                        aux = aux.Next;
                    }

                    return this;
                }
            }
        }

        public double RealizarPagamentos(double saldo)
        {
            var aux = Head;

            while (aux != null)
            {
                if (saldo >= aux.Valor)
                {
                    saldo -= aux.Valor;
                    Remover(aux.Codigo);
                }

                aux = aux.Next;
            }

            return saldo;
        }

        public double CalcularValorTotal()
        {
            var aux = Head;
            var valorTotal = 0.0;
            while (aux != null)
            {
                valorTotal += aux.Valor;
                aux = aux.Next;
            }

            return valorTotal;
        }
    }
}
