using System.Text.RegularExpressions;
using Cadastro_Pessoa.Interfaces;

namespace Cadastro_Pessoa.Classes
{
    //classe pessoa juridica herda da superclasse
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        //atributos da classe pessoa juridica
        public string? RazaoSocial { get; set; }
        public string? Cnpj { get; set; }

        public override float PagarImposto(float rendimento)
        {
            if (rendimento <= 3000)
            {
                return rendimento * 0.03f;
            }
            else if (rendimento >= 3001 && rendimento <= 6000)
            {
                return rendimento * 0.05f;
            }
            else if (rendimento >= 6001 && rendimento <= 10000)
            {
                return rendimento * 0.07f;
            }
            else
            {
                return rendimento * 0.09f;
            }
        }

        //22.658.312/0001-77 : 18 caracteres
        //22658312000177 : 14 caracteres
        public bool ValidarCnpj(string cnpj)
        {
            if(Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(^\d{14})$)"))
            {
              if(cnpj.Length == 18)
              {
                if(cnpj.Substring(11, 4) == "0001")
                {
                    return true;
                }
              } 
              else if(cnpj.Length == 14)
              {
                if(cnpj.Substring(8, 4) == "0001")
                {
                    return true;
                }
              } 
            }
            return false;
            
        }
    }
}

