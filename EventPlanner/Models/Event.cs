namespace EventPlanner.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime HappeningDate { get; set; }
        public List<Teilnehmer>? Teilnehmer { get; set; }
    }
}
