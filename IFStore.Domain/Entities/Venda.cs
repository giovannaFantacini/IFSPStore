using IFStore.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IFStore.Domain.Entities
{
    public class Venda : BaseEntity<int>
    {
        public Venda()
        {
            items = new List<VendaItem>();
        }
        public DateTime data { get; set; }
        public float valorTotal { get; set; }
        public Usuario usuario { get; set; }
        public Cliente cliente { get; set; }
        public List<VendaItem> items { get; set; }
    }

    public class VendaItem : BaseEntity<int>
    {
        public Produto produto { get; set; }
        public int quantidade { get; set; }
        public float valorUnitario { get; set; }    
        public float valorTotal { get; set; }
        [JsonIgnore]
        public Venda venda { get; set; }
    }
}
