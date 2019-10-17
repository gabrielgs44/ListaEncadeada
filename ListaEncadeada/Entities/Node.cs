namespace ListaEncadeada.Entities
{
    public class Node
    {
        public Boleto Atual { get; set; }
        public Node Next { get; set; }

        public Node(Boleto atual)
        {
            Atual = atual;
        }
    }
}
