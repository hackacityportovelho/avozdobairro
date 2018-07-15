
using System.ComponentModel.DataAnnotations;

namespace ComCity.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public int EnqueteId { get; set; }
        public bool Aprovado { get; set; }
        
        [Required(ErrorMessage="Campo Obrigatório"), EmailAddress, Display(Name="Qual seu Email?")]
        public string Email { get; set; }

        [Display(Name = "Alguma Observação?")]
        public string Observacao { get; set; }

        [Display(Name = "Por quê?")]
        public string Justificativa { get; set; }
        
        public Enquete Enquete { get; set; }
        
    }
}