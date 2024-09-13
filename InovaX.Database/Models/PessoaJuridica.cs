namespace InovaXSprint.Models

{
    public class PessoaJuridica : Usuario
    {
        public string CNPJ { get; set; }
        public string NomeFantasia { get; set; }
        public string NaturezaJuridica { get; set; }
        public string Situacao { get; set; }


        //1..1        
        public int? EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }


        //1..1        
        public int? TelefoneId { get; set; }
        public Telefone? Telefone { get; set; }


    }
}
