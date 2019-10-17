using System;

namespace ListaEncadeada.Entities.Exceptions
{
    public class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException(string message) : base(message)
        {

        }
    }
}
