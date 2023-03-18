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

User can have many Watchlists (1 to many relationship)
Watchlist can have many Movies or Series (many to many relationship)
Movie can have many Genres (many to many relationship)
Series can have many Genres (many to many relationship)
Movie can have many Actors (many to many relationship)
Series can have many Actors (many to many relationship)
Movie can have many Directors (many to many relationship)
Series can have many Directors (many to many relationship)
User can write many Reviews (1 to many relationship)
Movie can have many Reviews (1 to many relationship)
Series can have many Reviews (1 to many relationship)
User can rate many Movies and Series (many to many relationship)
Movie can have many Ratings (1 to many relationship)
Series can have many Ratings (1 to many relationship)
User can make many Recommendations (1 to many relationship)
Movie can have many Recommendations (1 to many relationship)
Series can have many Recommendations (1 to many relationship)
User can have many Subscriptions (1 to many relationship)