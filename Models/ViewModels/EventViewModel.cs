using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNETCLINIC.Models.ViewModels
{
    public class EventViewModel
    {
        public Event Event { get; set; }

        public List<SelectListItem> Patient = new List<SelectListItem>();
        public string Name { get; set; }

        public EventViewModel(Event myevent, List<Event> patients )
        {
            Event = myevent;
            Name = myevent.Patients.Name;

        foreach (var pat in patients )
            {
                Patient.Add(new SelectListItem() { Text = pat.Name });
            }
        }

        public EventViewModel(List<Patient> patients)
        {
            foreach (var pat in patients)
            {
                Patient.Add(new SelectListItem() { Text = pat.Name });
            }
        }

        public EventViewModel()
        {
        }
    }
}
