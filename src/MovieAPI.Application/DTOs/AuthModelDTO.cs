namespace MovieAPI.src.MovieAPI.Application.DTOs
{
    public class AuthModelDTO
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
        public List<string> Roles { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}

