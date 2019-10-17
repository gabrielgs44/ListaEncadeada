using ListaEncadeada.Entities;

namespace ListaEncadeada.Services
{
    class ListaBoletoService
    {
        protected ListaBoletoService()
        {
        }

        public static bool VerificarQualEMaior(Node last, Node node)
        {
            int diaAtual = last.Atual.DataVencimento.Day;
            int mesAtual = last.Atual.DataVencimento.Month;

            int diaNext = node.Atual.DataVencimento.Day;
            int mesNext = node.Atual.DataVencimento.Month;

            if (mesAtual >= mesNext)
            {
                return diaAtual > diaNext;
            }
            else
            {
                return false;
            }
        }
    }
}
