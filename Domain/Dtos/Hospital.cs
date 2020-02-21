using System.Collections.Generic;

namespace Domain.Entities
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CNPJ { get; set; }
        public virtual ICollection<Nurse> Nurses { get; set; }
    }
}
