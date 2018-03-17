using System;

namespace WebSite.Entities
{
    public class Paginas
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }

        public Paginas()
        {

        }

        public Paginas(int Id)
        {
            this.Id = Id;
        }

        public Paginas(int Id, string Titulo, string Texto, DateTime DataCriacao, bool Ativo)
        {
            this.Id = Id;
            this.Titulo = Titulo;
            this.Texto = Texto;
            this.DataCriacao = DataCriacao;
            this.Ativo = Ativo;
        }
    }
}
