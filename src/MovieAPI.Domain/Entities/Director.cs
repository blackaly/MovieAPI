namespace MovieAPI.src.MovieAPI.Domain.Entities
{
    public class Director
    {
        public int DirectorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Country { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Bio { get; set; }
        public ICollection<SeriesDirectors> SeriesDirectors { get; set; }
    }
}
