namespace InovaXSprint.Models
{
    public class Produto
    { 
        public int IdProduto { get; set; }
        public string Nome{ get; set; }
        public string Descricao {  get; set; }
        public string Preco {  get; set; }
        public string Quantidade { get; set; }

        public virtual ICollection<Distribuidor> Distribuidores { get; set; } = new List<Distribuidor>();


    }
}
