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
        
        [DisplayName("�rea")]
        public int AreaId { get; set; }

        [DisplayName("Nome do Projeto")]
        public string Nome { get; set; }

        [DisplayName("Descri��o")]
        public string Descricao { get; set; }
        
        public decimal Valor { get; set; }

        [DisplayName("Previs�o De Inicio"), DataType(DataType.Date)]
        public DateTime? PrevisaoDeInicio { get; set; }

        [DisplayName("Previs�o De FConclus�o"), DataType(DataType.Date)]
        public DateTime? PrevisaoDeConclusao { get; set; }

        [DisplayName("Cep")]
        public string CEP { get; set; }

        [DisplayName("N�mero")]
        public string Numero { get; set; }

        [DisplayName("Imagem do Projeto")]
        public byte[] Imagem { get; set; }
        
        public string Rua { get; set; }
        
        public string Bairro { get; set; }
        
        public string Cidade { get; set; }
        
        public string Estado { get; set; }

        public EnumSituacaoProjeto Situacao { get; set; }
        
        public ICollection<Enquete> Enquetes {get;set;}
        
        public Area Area { get; set; }
    }
}