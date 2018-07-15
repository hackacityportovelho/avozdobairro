using System.Collections.Generic;

namespace ComCity.Models
{
    public class Enquete
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public Projeto Projeto { get; set; }
    }
}