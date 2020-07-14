namespace RestApi.Domain.Models
{
    public class Carro
    {
        public int Id { get; set; }        
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public Carro()
        {            
        }

        public Carro(int prId, string prNome, string prMarca, string prModelo)
        {
            Id = prId;
            Nome = prNome;
            Marca = prMarca;
            Modelo = prModelo;
        }
    }
}