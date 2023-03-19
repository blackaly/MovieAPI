# Entities:

- User :heavy_check_mark:
- Movie :heavy_check_mark:
- Series :heavy_check_mark:
- Genre :heavy_check_mark:
- Actor :heavy_check_mark:
- Director :heavy_check_mark:
- Review :heavy_check_mark:
- Rating :heavy_check_mark:
- Watchlist :heavy_check_mark:
- Recommendation :heavy_check_mark:
- Subscription :heavy_check_mark:

---
# Relationships:

1. User can have many Watchlists (1 to many relationship) :heavy_check_mark:
2. Watchlist can have many Movies or Series (many to many relationship) :heavy_check_mark:
3. Movie can have many Genres (many to many relationship) :heavy_check_mark:
4. Series can have many Genres (many to many relationship) :heavy_check_mark:
5. Movie can have many Actors (many to many relationship) :heavy_check_mark:
6. Series can have many Actors (many to many relationship) :heavy_check_mark:
7. Movie can have many Directors (many to many relationship) :heavy_check_mark:
8. Series can have many Directors (many to many relationship) :heavy_check_mark:
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
