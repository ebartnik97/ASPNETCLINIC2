namespace ASPNETCLINIC.Helpers
{
    public static class JSONListHelper
    {
        public static string GetEventListJSONString(List<Models.Event> events)
        {
            var eventlist = new List<Event>();

            foreach (var model in events)
            {
                var myevent = new Event()
                {
                    id = model.Id,
                    start = model.StartTime,
                    end = model.EndTime,
                    resoruceId = model.Patients.Id,
                    description = model.Description,
                    title = model.Name,
                };
                eventlist.Add(myevent);


            }
            return System.Text.Json.JsonSerializer.Serialize(eventlist);
        }
        public static string GetResourceListJSONString(List<Models.Patient> patients)
        {
            var resourcelist = new List<Resource>();
            foreach (var pat in patients)
            {
                var resource = new Resource()
                {
                    id = pat.Id,
                    title = pat.Name
                };
                resourcelist.Add(resource);
            }
            return System.Text.Json.JsonSerializer.Serialize(resourcelist);
        }
    }
        public class Event
        {
            public int id { get; set; }
        public string title { get; set; }
            public DateTime start { get; set; }
            public DateTime end { get; set; }
            public int resoruceId { get; set; }
            public string description { get; set; }


        }
        public class Resource
        {
            public int id { get; set; }
            public string title { get; set; }


        }

    
}

