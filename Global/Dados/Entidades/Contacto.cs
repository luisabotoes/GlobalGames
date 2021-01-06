using System.ComponentModel.DataAnnotations;

namespace Global.Dados.Entidades
{
    public class Contacto
    {
        public int Id { get; set; }


        public string Nome { get; set; }


        public string Email { get; set; }


        public string Mensagem { get; set; }

    }
}
