namespace RestApi.Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    
        public Usuario()
        {        
        }

        public Usuario(int prId, string prLogin, string prSenha)
        {
            Id = prId;
            Login = prLogin;
            Senha = prSenha;
        }
    }
}