
using System.ComponentModel.DataAnnotations;

namespace ComCity.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public int EnqueteId { get; set; }
        public bool Aprovado { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        public string Observacao { get; set; }

        public string Justificativa { get; set; }
        
        public Enquete Enquete { get; set; }
        
    }
}