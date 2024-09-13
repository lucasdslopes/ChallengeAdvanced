namespace InovaXSprint.Models
{
    public class Avaliacao
    {            
        public int IdAvaliacao { get; set; }      
        public DateTime DataAvaliacao { get; set; }
        public string Texto { get; set; }

        //1..N
        public int IdProduto { get; set; }
        public Produto? Produto { get; set; }

        //1..N
        public int IdServico { get; set; }
        public Servico? Servico { get; set; }


    }
}
