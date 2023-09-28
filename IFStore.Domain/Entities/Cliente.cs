using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFStore.Domain.Base;

namespace IFStore.Domain.Entities
{
    public class Cliente : BaseEntity<int>
    {
        public string nome { get; set; }
        public string endereco { get; set; }
        
        public string bairro { get; set; }

        public Cidade cidade { get; set; }
    }
}
