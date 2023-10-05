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
            Items = new List<VendaItem>();
        }
        public DateTime Data { get; set; }
        public float ValorTotal { get; set; }
        public Usuario Usuario { get; set; }
        public Cliente Cliente { get; set; }
        public List<VendaItem> Items { get; set; }
    }

    public class VendaItem : BaseEntity<int>
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public float ValorUnitario { get; set; }    
        public float ValorTotal { get; set; }
        [JsonIgnore]
        public Venda Venda { get; set; }
    }
}
