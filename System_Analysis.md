# Entities:

- User
- Movie
- Series
- Genre
- Actor
- Director
- Review
- Rating
- Watchlist
- Recommendation
- Subscription
- Relationships:

---

1. User can have many Watchlists (1 to many relationship)
2. Watchlist can have many Movies or Series (many to many relationship)
3. Movie can have many Genres (many to many relationship)
4. Series can have many Genres (many to many relationship)
5. Movie can have many Actors (many to many relationship)
6. Series can have many Actors (many to many relationship)
7. Movie can have many Directors (many to many relationship)
8. Series can have many Directors (many to many relationship)
9. User can write many Reviews (1 to many relationship)
10. Movie can have many Reviews (1 to many relationship)
11. Series can have many Reviews (1 to many relationship)
12. User can rate many Movies and Series (many to many relationship)
13. Movie can have many Ratings (1 to many relationship)
14. Series can have many Ratings (1 to many relationship)
15. User can make many Recommendations (1 to many relationship)
16. Movie can have many Recommendations (1 to many relationship)
17. Series can have many Recommendations (1 to many relationship)
18. User can have many Subscriptions (1 to many relationship)

---

* A User can have many Watchlists. Each Watchlist is a collection of Movies or Series that the user wants to watch.
* A Watchlist can contain many Movies or Series, and each Movie or Series can be in many Watchlists.
* Each Movie can have many Genres, and each Genre can be associated with many Movies.
* Each Series can have many Genres, and each Genre can be associated with many Series.
* Each Movie can have many Actors, and each Actor can be associated with many Movies.
* Each Series can have many Actors, and each Actor can be associated with many Series.
* Each Movie can have many Directors, and each Director can be associated with many Movies.
* Each Series can have many Directors, and each Director can be associated with