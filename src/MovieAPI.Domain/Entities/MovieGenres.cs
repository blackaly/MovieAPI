﻿namespace MovieAPI.src.MovieAPI.Domain.Entities
{
    public class MovieGenres
    {
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }  

    }
}
