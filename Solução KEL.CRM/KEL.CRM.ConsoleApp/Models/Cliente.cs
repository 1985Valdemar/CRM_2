using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEL.CRM.ConsoleApp.Models
{
    public class Cliente:BaseModel
    {
        //DECLARANDO PROPRIEDADE PARA USAR
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
    }
}
