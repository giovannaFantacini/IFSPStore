using IFStore.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFStore.Domain.Entities
{
    public class Usuario : BaseEntity<int>
    {
        public string nome { get; set; }
        public string senha { get; set; }
        public string login { get; set; }
        public string email { get; set; }   
        public DateTime dataCadastro { get; set; }
        public DateTime dataLogin { get; set; }
        public bool ativo { get; set; }

    }
}
