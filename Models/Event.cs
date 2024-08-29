using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCLINIC.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        //Dzielone dane

        public virtual Patient Patients { get; set; }
        public virtual AppUsers User { get; set; }

        public Event(IFormCollection form, Patient patient)
        {
    
            Name = form["Event.Name"].ToString();
            Description = form["Event.Description"].ToString();
            StartTime = DateTime.Parse(form["Event.StartTime"].ToString());
            EndTime = DateTime.Parse(form["Event.EndTime"].ToString());
            Patients = patient;
        }
        public void UpdateEvent(IFormCollection form, Patient patient)
        {
 
            Name = form["Event.Name"].ToString();
            Description = form["Event.Description"].ToString();
            StartTime = DateTime.Parse(form["Event.StartTime"].ToString());
            EndTime = DateTime.Parse(form["Event.EndTime"].ToString());
            Patients = patient;
        }
        public Event()
        {

        }
    }

}
