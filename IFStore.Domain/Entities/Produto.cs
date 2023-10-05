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
        public string Nome { get; set; }
        public float Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCompra { get; set; }
        public string UnidadeVenda { get; set; }
        public Grupo Grupo { get; set; }

    }
}
