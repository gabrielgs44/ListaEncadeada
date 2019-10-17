namespace ListaEncadeada.Entities
{
    public class ListaBoleto
    {
        public Node Head { get; set; }

        private ListaBoleto()
        {
            Head = null;
        }

        public static ListaBoleto Criar()
        {
            return new ListaBoleto();
        }
    }
}
