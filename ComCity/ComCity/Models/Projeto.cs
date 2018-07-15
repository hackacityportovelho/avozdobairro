using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ComCity.Models
{
    public class Projeto
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        
        [DisplayName("Área")]
        public int AreaId { get; set; }

        [DisplayName("Nome do Projeto")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        
        public decimal? Valor { get; set; }

        [DisplayName("Previsão De Inicio"), DataType(DataType.Date)]
        public DateTime? PrevisaoDeInicio { get; set; }

        [DisplayName("Previsão De Conclusão"), DataType(DataType.Date)]
        public DateTime? PrevisaoDeConclusao { get; set; }

        [DisplayName("Cep")]
        public string CEP { get; set; }

        [DisplayName("Número")]
        public string Numero { get; set; }

        [DisplayName("URL da Imagem do Projeto")]
        public string UrlImagem { get; set; }

        public string Rua { get; set; }
        
        public string Bairro { get; set; }
        
        public string Cidade { get; set; }
        
        public string Estado { get; set; }

        public EnumSituacaoProjeto Situacao { get; set; }
        
        public ICollection<Enquete> Enquetes {get;set;}
        
        public Area Area { get; set; }       
    }
}