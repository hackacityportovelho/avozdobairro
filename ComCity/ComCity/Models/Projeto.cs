using System;
using System.Collections.Generic;

namespace ComCity.Models
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime? PrevisaoDeInicio { get; set; }
        public DateTime? PrevisaoDeConclusao { get; set; }

        public string CEP { get; set; }
        public string Numero { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public EnumSituacaoProjeto Situacao { get; set; }
        public ICollection<Enquete> Enquetes {get;set;}
        public Area Area { get; set; }
    }
}