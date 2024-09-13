using System.Text.Json.Serialization;

namespace InovaXSprint.Models
{
    public class Distribuidor : Usuario
    {
        public string Tipo { get; set; }
        //1..1        
        public int? EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }

        //1..1        
        public int? TelefoneId { get; set; }
        public Telefone? Telefone { get; set; }

        //Relação muitos-para-muitos com a classe curso
        [JsonIgnore]
        public virtual ICollection<Servico>? Servicos { get; set; }

        //Relação muitos-para-muitos com a classe curso
        [JsonIgnore]
        public virtual ICollection<Produto>? Produtos { get; set; }
    }
}
