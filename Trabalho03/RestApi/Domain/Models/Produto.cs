namespace RestApi.Domain.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

        public Produto()
        {            
        }

        public Produto(int prId, string prNome, double prPreco)
        {
            Id = prId;
            Nome = prNome;
            Preco = prPreco;
        }
    }
}