using ASPNETCLINIC.Models;

namespace ASPNETCLINIC.Data
{
    public interface IDAL
    {
        public List<Event> GetEvents();
        public List<Event> GetMyEvents(string userid);
        public Event GetEvent(int id);
        public void UpdateEvent(IFormCollection form);
        public void CreateEvent(IFormCollection form);
        public void DeleteEvent(int id);
        public List<Patient> GetPatients();
        public Patient GetPatient(int id);
        public void CreatePatient(Patient patient);
        public void CreateLocation(Doctor location);
        public List<Doctor> GetLocations();
        public Doctor GetLocation(int id);

    }
    public class DAL : IDAL
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public DAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Event> GetEvents()
        {
            return db.Events.ToList();
        }
        public List<Event> GetMyEvents(string userid)
        {
            return db.Events.Where(x => x.User.Id == userid).ToList();
        }
        public Event GetEvent(int id)
        {
            return db.Events.FirstOrDefault(x => x.Id == id);

        }
     
        public void CreateEvent(IFormCollection form)
        {
            var locname = form["Patient"].ToString();
            var newevent = new Event(form, db.Patients.FirstOrDefault(x => x.Name == locname));
      
            db.Events.Add(newevent);
            db.SaveChanges();

        }
        public void UpdateEvent(IFormCollection form)
        {
            var locname = form["Patient"].ToString();
            var eventid = int.Parse(form["Event.Id"]);
            var myevent = db.Events.FirstOrDefault(x => x.Id == eventid);
            var patient = db.Patients.FirstOrDefault(x => x.Name == form["Name"]);
            myevent.UpdateEvent(form, patient);
            db.Entry(myevent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteEvent(int id)
        {
            var myevent = db.Events.Find(id);
            db.Events.Remove(myevent);
            db.SaveChanges();
        }
        public List<Patient> GetPatients()
        {
            return db.Patients.ToList();

        }
        public Patient GetPatient(int id)
        {
            return db.Patients.Find(id);

        }
        public void CreatePatient(Patient patient)
        {
            db.Patients.Add(patient);
            db.SaveChanges();
        }
        public List<Doctor> GetLocations()
        {
            return db.Locations.ToList();
        }

        public Doctor GetLocation(int id)
        {
            return db.Locations.Find(id);
        }

        public void CreateLocation(Doctor location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
        }
    }
}
