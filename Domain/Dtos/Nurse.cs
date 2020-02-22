using System;

namespace Domain.Dtos
{
    public class Nurse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string COREN { get; set; }
        public DateTime BirthDate { get; set; }
        public int HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }
    }
}
