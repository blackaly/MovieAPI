namespace MovieAPI.src.MovieAPI.Domain.Entities
{
    public class SeriesActor
    {
        public int SeriesActorId { get; set; }
        public int SeriesId { get; set; }
        public virtual Series Series { get; set; } 
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }

    }
}
