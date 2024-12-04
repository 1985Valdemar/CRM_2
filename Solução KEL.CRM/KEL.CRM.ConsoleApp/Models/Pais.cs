using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEL.CRM.ConsoleApp.Models
{
    public class Pais: BaseModel
    {
        public string Nome { get; set; }
        public int Populacao { get; set; }
        public string Idioma { get; set; }

        public override string ToString()
        {
            return $"Nome Pais: {this.Nome}; População: {this.Populacao}; Idioma: {this.Idioma}";
        }
    }
}
