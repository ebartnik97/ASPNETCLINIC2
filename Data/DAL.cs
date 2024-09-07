using ASPNETCLINIC.Models;
using Microsoft.AspNetCore.Http;

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
        public void DeletePatient(int id);

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
        public void DeletePatient(int id)
        {
            var patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
            db.SaveChanges();
        }

    }
}
