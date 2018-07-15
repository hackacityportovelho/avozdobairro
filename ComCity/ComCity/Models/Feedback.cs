namespace ComCity.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public bool Positivo { get; set; }
        public string Observacao { get; set; }
        public string Justificativa { get; set; }
        public Enquete Enquete { get; set; }
    }
}