
using System.Text.Json.Serialization;

namespace InovaXSprint.Models
{
public class Servico
    {
        public int IdServico { get; set; }
        public string Nome{ get; set; }
        public string Descricao {  get; set; }
        public string Preco {  get; set; }

        public virtual ICollection<Distribuidor> Distribuidores { get; set; } = new List<Distribuidor>();

    

    }
}
