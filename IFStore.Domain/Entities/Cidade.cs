using IFStore.Domain.Base;

namespace IFStore.Domain.Entities
{
    public class Cidade : BaseEntity<int>
    {
        public string nome { get; set; }
        public string estado { get; set; }

    }
}