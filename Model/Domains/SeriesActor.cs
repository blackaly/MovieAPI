namespace MovieAPI.Model.Domains
{
    public class SeriesActor
    {
        public int SeriesId { get; set; }
        public virtual Series Series { get; set; } 
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }

    }
}
