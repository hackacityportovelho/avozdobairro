using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComCity.Models
{
    public class Enquete
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DisplayName("Projeto")]
        public int ProjetoId { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<Feedback> Feedbacks { get; set; }

        [ScaffoldColumn(false)]
        public Projeto Projeto { get; set; }
    }
}