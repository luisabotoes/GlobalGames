using System;

namespace Global.Dados.Entidades
{
    public class Inscricao
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Apelido { get; set; }

        public string ImageUrl { get; set; }

        public string Morada { get; set; }

        public string Localidade { get; set; }

        public string CartaoCidadao { get; set; }

        public DateTime DataNascimento { get; set; }

        public User User { get; set; }

    }
}
