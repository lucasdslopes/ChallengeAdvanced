namespace InovaXSprint.Models
{
    public class PessoaFisica : Usuario
    {
        public string CPF { get; set; }
        public int RG { get; set; }


        //1..1        
        public int? EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }

        //1..1        
        public int? TelefoneId { get; set; }
        public Telefone? Telefone { get; set; }




    }
}
