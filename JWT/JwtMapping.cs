namespace MovieAPI.JWT
{
    public class JwtMapping
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience {get; set;}
        public string DurationInDays { get; set; }
    }
}
