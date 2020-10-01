//
// BusinessTier:  business logic, acting as interface between UI and data store.
//
// <<Justin Donayre>>
// U. of Illinois, Chicago
// CS341, Spring 2018
// Final Project
//

using System;
using System.Collections.Generic;
using System.Data;


namespace BusinessTier
{

  //
  // Business:
  //
  public class Business
  {
    //
    // Fields:
    //
    private string _DBFile;
    private DataAccessTier.Data dataTier;


    //
    // Constructor:
    //
    public Business(string DatabaseFilename)
    {
      _DBFile = DatabaseFilename;

      dataTier = new DataAccessTier.Data(DatabaseFilename);
    }


    //
    // TestConnection:
    //
    // Returns true if we can establish a connection to the database, false if not.
    //
    public bool TestConnection()
    {
      return dataTier.TestConnection();
    }


    //
    //  GetUser:
    //
    //  Retrieves  User  object  based  on  USER  ID;  returns  null  if  user  is  not
    //  found.
    //
    //  NOTE:  if  the  user  exists  in  the  Users  table,  then  a  meaningful  name  and  
    //  occupation  are  returned  in  the  User  object.    If  the  user  does  not  exist  
    //  in  the  Users  table,  then  the  user  id  has  to  be  looked  up  in  the  Reviews  
    //  table  to  see  if  he/she  has  submitted  1  or  more  reviews  as  an  "anonymous"
    //  user.    If the id  is  found  in  the Reviews  table,  then the  user  is  an
    //  "anonymous"  user,  so  a  User  object  with  name  =  "<UserID>"  and  no  occupation
    //  ("")  is  returned.    In  other  words,  name  =  the  user’s  id  surrounded  by  <  >.
    //
    public User GetUser(int UserID)
    {
            BusinessTier.User User = null;

            string sql = string.Format(@"SELECT UserName FROM Users WHERE UserID = {0};", UserID);
            object UserNameQuery = dataTier.ExecuteScalarQuery(sql);    // Query that returns a UserName

            if (UserNameQuery == null)
            {
                sql = string.Format(@"SELECT (*) FROM Reviews WHERE UserID = {0};", UserID);
                UserNameQuery = dataTier.ExecuteScalarQuery(sql);    // Query that returns a UserName
                if (UserNameQuery != null)
                    User = new BusinessTier.User(UserID, "<UserID>", "");
            }

            sql = string.Format(@"SELECT Occupation FROM Users WHERE UserID = {0};", UserID);
            object OccupationQuery = dataTier.ExecuteScalarQuery(sql);  // Query that returns an Occupation

            string UserName = UserNameQuery.ToString();
            string Occupation = OccupationQuery.ToString();

            User = new BusinessTier.User( UserID, UserName, Occupation);
            
            return User;
    }

    //
    // GetNamedUser:
    //
    // Retrieves User object based on USER NAME; returns null if user is not
    // found.
    //
    // NOTE: there are "named" users from the Users table, and anonymous users
    // that only exist in the Reviews table.  This function only looks up "named"
    // users from the Users table.
    //
    public User GetNamedUser(string UserName)
    {
            string sql = string.Format(@"SELECT UserID FROM Users WHERE UserName = '{0}';", UserName.Replace("'","''"));
            object UserIDQuery = dataTier.ExecuteScalarQuery(sql);    // Query that returns a UserName
            int UserID = Convert.ToInt32(UserIDQuery.ToString());

            if (UserIDQuery == null)
                return null;

            sql = string.Format(@"SELECT Occupation FROM Users WHERE UserID = {0};", UserID);
            object OccupationQuery = dataTier.ExecuteScalarQuery(sql);  // Query that returns an Occupation
            string Occupation = OccupationQuery.ToString();

            UserName.Replace("''", "'");
            BusinessTier.User User = new BusinessTier.User(UserID, UserName, Occupation);

            return User;
        }


    //
    // GetAllNamedUsers:
    //
    // Returns a list of all the users in the Users table ("named" users), sorted 
    // by user name.
    //
    // NOTE: the database also contains lots of "anonymous" users, which this 
    // function does not return.
    //
    public IReadOnlyList<User> GetAllNamedUsers()
    {
            List<User> users = new List<User>();

            string sql = string.Format(@"SELECT DISTINCT UserName FROM Users ORDER BY UserName;");
            DataSet usersList = dataTier.ExecuteNonScalarQuery(sql);
      
            foreach(DataRow row in usersList.Tables["TABLE"].Rows)
            {
                users.Add(GetNamedUser((row["UserName"]).ToString()));
            }

            return users;
    }


    //
    // GetMovie:
    //
    // Retrieves Movie object based on MOVIE ID; returns null if movie is not
    // found.
    //
    public Movie GetMovie(int MovieID)
    {
            string sql = string.Format(@"SELECT MovieName FROM Movies WHERE MovieID = {0};", MovieID);

            object query = dataTier.ExecuteScalarQuery(sql); // Query returns object with MovieName

            if (query == null)
               return null;

            string MovieName = query.ToString(); // Turns object to string
      
            BusinessTier.Movie Movie = new BusinessTier.Movie(MovieID, MovieName); // Creates new Movie object needed to return

            return Movie;      
    }


    //
    // GetMovie:
    //
    // Retrieves Movie object based on MOVIE NAME; returns null if movie is not
    // found.
    //
    public Movie GetMovie(string MovieName)
    {
            string sql = string.Format(@"SELECT MovieID FROM Movies WHERE MovieName = '{0}';", MovieName.Replace("'","''"));
      
            object query = dataTier.ExecuteScalarQuery(sql);

            if (query == null)
               return null;

            string MovieID = query.ToString();
          
            MovieName.Replace("''","'");
            BusinessTier.Movie Movie = new BusinessTier.Movie(Int32.Parse(MovieID), MovieName);

            return Movie;
    }


    public IReadOnlyList<Movie> GetAllMovies()
    {
            List<Movie> movies = new List<Movie>();

            string sql = string.Format(@"SELECT DISTINCT MovieName FROM Movies ORDER BY MovieName ASC;");
            DataSet query = dataTier.ExecuteNonScalarQuery(sql);

            foreach (DataRow row in query.Tables["TABLE"].Rows)
            {
                movies.Add(GetMovie(row["MovieName"].ToString()));
                sql = row.ToString();
            }

            return movies;
    }

    //
    // AddReview:
    //
    // Adds review based on MOVIE ID, returning a Review object containing
    // the review, review's id, etc.  If the add failed, null is returned.
    //
    public Review AddReview(int MovieID, int UserID, int Rating)
    {
            string sql = string.Format(@"INSERT INTO Reviews (MovieID,UserID,Rating) VALUES ({0}, {1}, {2});
SELECT ReviewID FROM Reviews WHERE ReviewID = SCOPE_IDENTITY();
", MovieID, UserID, Rating);
            object query = dataTier.ExecuteScalarQuery(sql);
            if (query == null)
                return null;
            else
            {
                return new BusinessTier.Review(Convert.ToInt32(query.ToString()), MovieID, UserID, Rating);
            }
    }


    //
    // GetMovieDetail:
    //
    // Given a MOVIE ID, returns detailed information about this movie --- all
    // the reviews, the total number of reviews, average rating, etc.  If the 
    // movie cannot be found, null is returned.
    //
    public MovieDetail GetMovieDetail(int MovieID)
    {
            // MOVIE OBJECT ----------------------------------------------------------------------------
            BusinessTier.Movie Movie = GetMovie(MovieID);
            // -----------------------------------------------------------------------------------------

            // AVG RATING ------------------------------------------------------------------------------
            double avgRating;
            string sql = string.Format(@"SELECT AVG(CAST(Rating as float)) FROM Reviews WHERE MovieID = {0};", MovieID);
            object query = dataTier.ExecuteScalarQuery(sql);
            if (query.ToString() != "")
                avgRating = Convert.ToDouble(query.ToString());
            else
                avgRating = 0.0;
            // -----------------------------------------------------------------------------------------

            // NUM OF REVIEWS --------------------------------------------------------------------------
            sql = string.Format(@"SELECT Count(MovieID) FROM Reviews WHERE MovieID = {0};", MovieID);
            query = dataTier.ExecuteScalarQuery(sql);
            int numReviews = Convert.ToInt32(query.ToString());
            // -----------------------------------------------------------------------------------------

            // BUILDING LIST OF REVIEWS ----------------------------------------------------------------
            List<Review> reviews = new List<Review>();

                  // HARVESTS ALL DATA WE NEED EXCEPT MOVIEID (ALREADY HAVE) 
            sql = string.Format(@"SELECT DISTINCT ReviewID, Rating, UserID FROM Reviews WHERE MovieID = {0} ORDER BY Rating DESC, ReviewID ASC;", MovieID);
            DataSet reviewsSet = dataTier.ExecuteNonScalarQuery(sql);

            foreach (DataRow row in reviewsSet.Tables["TABLE"].Rows)
            {
                reviews.Add(new BusinessTier.Review(Convert.ToInt32(row["ReviewID"]), 
                    MovieID, 
                    Convert.ToInt32(row["UserID"]), 
                    Convert.ToInt32(row["Rating"])));
            }
            // -----------------------------------------------------------------------------------------
            

            BusinessTier.MovieDetail MovieDetail = new BusinessTier.MovieDetail(Movie, avgRating, numReviews, reviews);

            return MovieDetail;
    }


    //
    // GetUserDetail:
    //
    // Given a USER ID, returns detailed information about this user --- all
    // the reviews submitted by this user, the total number of reviews, average 
    // rating given, etc.  If the user cannot be found, null is returned.
    //
    public UserDetail GetUserDetail(int UserID)
    {
            // USER OBJECT -----------------------------------------------------------------------------
            BusinessTier.User User = GetUser(UserID);
            // -----------------------------------------------------------------------------------------

            // AVG RATING ------------------------------------------------------------------------------
            double avgRating;
            string sql = string.Format(@"SELECT AVG(CAST(Rating as float)) FROM Reviews WHERE UserID = {0};", UserID);
            object query = dataTier.ExecuteScalarQuery(sql);
            if (query.ToString() != "")
                avgRating = Convert.ToDouble(query.ToString());
            else
                avgRating = 0.0;
            // -----------------------------------------------------------------------------------------

            // NUM OF REVIEWS --------------------------------------------------------------------------
            sql = string.Format(@"SELECT Count(UserID) FROM Reviews WHERE UserID = {0};", UserID);
            query = dataTier.ExecuteScalarQuery(sql);
            int numReviews = Convert.ToInt32(query.ToString());
            // -----------------------------------------------------------------------------------------

            // BUILDING LIST OF REVIEWS ----------------------------------------------------------------
            List<Review> reviews = new List<Review>();

                  // HARVESTS ALL DATA WE NEED EXCEPT MOVIEID (ALREADY HAVE) 
            sql = string.Format(@"SELECT DISTINCT ReviewID, Rating, MovieID FROM Reviews WHERE UserID = {0} ORDER BY Rating DESC, ReviewID ASC;", UserID);
            DataSet reviewsSet = dataTier.ExecuteNonScalarQuery(sql);

            foreach (DataRow row in reviewsSet.Tables["TABLE"].Rows)
            {
                reviews.Add(new BusinessTier.Review(Convert.ToInt32(row["ReviewID"]),
                    Convert.ToInt32(row["MovieID"]),
                    UserID,
                    Convert.ToInt32(row["Rating"])));
            }
            // -----------------------------------------------------------------------------------------

            BusinessTier.UserDetail UserDetail = new BusinessTier.UserDetail(User, avgRating, numReviews, reviews);

            return UserDetail;
    }


    //
    // GetTopMoviesByAvgRating:
    //
    // Returns the top N movies in descending order by average rating.  If two
    // movies have the same rating, the movies are presented in ascending order
    // by name.  If N < 1, an EMPTY LIST is returned.
    //
    public IReadOnlyList<Movie> GetTopMoviesByAvgRating(int N)
    {
            List<Movie> movies = new List<Movie>();
            
            string sql = string.Format(@"SELECT TOP {0} AVG(Cast(Rating as float)) as Averages, MovieID FROM Reviews GROUP BY MovieID ORDER BY Averages DESC", N);
            DataSet moviesList = dataTier.ExecuteNonScalarQuery(sql);

            foreach (DataRow row in moviesList.Tables["TABLE"].Rows)
            {
                movies.Add(GetMovie(Convert.ToInt32(row["MovieID"].ToString())));
            }
            
            return movies;
    }


  }//class
}//namespace
