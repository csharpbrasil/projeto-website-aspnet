using System;

namespace WebSite.Entities
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }

        public Usuarios()
        {

        }

        public Usuarios(int Id)
        {
            this.Id = Id;
        }

        public Usuarios(string Login)
        {
            this.Login = Login;
        }

        public Usuarios(string Login, string Senha)
        {
            this.Login = Login;
            this.Senha = Senha;
        }

        public Usuarios(int Id, string Nome, string Email, string Login, string Senha, bool Ativo)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Email = Email;
            this.Login = Login;
            this.Senha = Senha;
            this.Ativo = Ativo;
        }
    }
}
