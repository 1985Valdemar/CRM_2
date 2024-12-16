using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEL.CRM.ConsoleApp.Models
{
    public class Estado : BaseModel
    {
        public string Nome { get; set; }

        public string Sigla { get; set; }
        public int Populacao { get; set; }

        public Pais Pais { get; set; }

        public override string ToString()
        {
            return $"{this.Id};{this.Nome};{this.Populacao};{this.Pais.Id}";
        }

    }
}
