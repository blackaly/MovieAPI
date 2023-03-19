using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;

namespace MovieAPI.Model.Domains
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }   
        public string Country { get; set; }
        public string ProfilePicture { get; set; }
        public string Bio { get; set; }
    }
}
