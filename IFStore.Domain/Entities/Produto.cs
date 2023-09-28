using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFStore.Domain.Base;

namespace IFStore.Domain.Entities
{
    public class Produto : BaseEntity<int>
    {
        public string nome { get; set; }
        public float preco { get; set; }
        public int quantidade { get; set; }
        public DateTime dataCompra { get; set; }
        public string unidadeVenda { get; set; }    

        public Grupo Grupo { get; set; }

    }
}
