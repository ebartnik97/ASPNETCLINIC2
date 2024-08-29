using System.ComponentModel.DataAnnotations;

namespace ASPNETCLINIC.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string PatientSurname { get; set; }

        public long PESEL { get; set; }
        
        //Wspoldzielone dane

        public virtual ICollection<Event> Events { get; set; }

    }
}
