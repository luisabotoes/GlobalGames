

namespace Global.Models
{
    using Global.Dados.Entidades;
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    public class InscricaoViewModel : Inscricao 
    {
        [Display(Name = "Imagem")]
        public IFormFile ImageFile { get; set; }
    }
}
