using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter
{
    public class Funcionario
    {
       private string nome, cargo;
     
       public TimeSpan horaLivre;


        public Funcionario(string nome, string cargo)
        {
            this.Nome = nome;
            this.Cargo = cargo;
        
        }



        public string Nome { get { return nome; } set { nome = value; } }
        public string Cargo { get { return cargo; } set { cargo = value; } }
       

   
    }


}
