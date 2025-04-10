namespace MovieAPI.src.MovieAPI.Domain.Entities
{
    public class MovieActors
    {   
        public int MovieActorsId { get; set; }
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
