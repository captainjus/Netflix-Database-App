//
// Netflix Database Application using N-Tier Design
//
// <<Justin Donayre>>
// U. of Illinois, Chicago
// CS341,Spring 2018
// Project 08
//

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void MovieListDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filename = this.connection.Text;
            string curItem = MovieListDisplay.SelectedItem.ToString();  

            BusinessTier.Business b = new BusinessTier.Business(filename);

            // 2. Movies -> ID AND AVG RATING -------------------------------------
            int id = (b.GetMovie(curItem)).MovieID;
            this.topMovieText.Text = string.Format("Movie ID: {0}", id);
            this.bottomMovieText.Text = string.Format("Avg Rating: {0}", Math.Round(b.GetMovieDetail(id).AvgRating,1));
            // --------------------------------------------------------------------

            // 4. Get Movie Review ------------------------------------------------
            this.MovieReviewList.Items.Clear();
            this.MovieReviewTitle.Text = string.Format("Reviews for: {0}", curItem);
            var reviews = b.GetMovieDetail(id).Reviews;
            foreach(var review in reviews)
            {
                MovieReviewList.Items.Add(string.Format(@"{0}: {1}", 
                    review.UserID, review.Rating));
            }

            // 7. Each Rating -----------------------------------------------------
            this.EachRatingList.Items.Clear();
            this.EachRating.Text = curItem;

            int fiveStar, fourStar, threeStar, twoStar, oneStar;
            fiveStar = fourStar = threeStar = twoStar = oneStar = 0;

            var reviewList = b.GetMovieDetail(id).Reviews; // ALL THE REVIEWS WE WILL SIFT THROUGH
            foreach(var review in reviewList)
            {
                switch (review.Rating)
                {
                    case 1: oneStar++; break;
                    case 2: twoStar++; break;
                    case 3: threeStar++; break;
                    case 4: fourStar++; break;
                    case 5: fiveStar++; break;
                    default: break;
                }
            }

            this.EachRatingList.Items.Add(string.Format("5: {0}", fiveStar));
            this.EachRatingList.Items.Add(string.Format("4: {0}", fourStar));
            this.EachRatingList.Items.Add(string.Format("3: {0}", threeStar));
            this.EachRatingList.Items.Add(string.Format("2: {0}", twoStar));
            this.EachRatingList.Items.Add(string.Format("1: {0}", oneStar));
            this.EachRatingList.Items.Add("");
            this.EachRatingList.Items.Add(string.Format("Total: {0}", reviewList.Count));

            // --------------------------------------------------------------------

        }

        private void Movies_Click(object sender, EventArgs e) // 2. Movies
        {
            this.MovieListDisplay.Items.Clear();

            string filename = this.connection.Text;
            BusinessTier.Business b = new BusinessTier.Business(filename);

            var movies = b.GetAllMovies();

            foreach (BusinessTier.Movie movie in movies)
            {
                MovieListDisplay.Items.Add(movie.MovieName);
            }

            this.MovieListDisplay.SelectedIndex = 0;
        }

        private void Users_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filename = this.connection.Text;
            string curItem = UsersDisplay.SelectedItem.ToString();

            BusinessTier.Business b = new BusinessTier.Business(filename);

            int id = (b.GetNamedUser(curItem)).UserID;
            string occupation = (b.GetNamedUser(curItem)).Occupation;

            // 3. All Users -------------------------------------------------------
            this.topUserText.Text = string.Format("User ID: {0}", id);
            this.bottomUserText.Text = string.Format("Occupation: {0}", occupation);
            // --------------------------------------------------------------------

            // 6. Get User Reviews ------------------------------------------------
            this.UserReviewList.Items.Clear();
            var reviews = (b.GetUserDetail(id)).Reviews; // object of user
            this.UserReviewer.Text = b.GetUser(id).UserName;
            foreach(var review in reviews)
            {
                UserReviewList.Items.Add(string.Format(@"{0} -> {1}", b.GetMovie(review.MovieID).MovieName, review.Rating));
            }
            // --------------------------------------------------------------------
        }

        private void AllUsers_Click(object sender, EventArgs e) // 3. All users
        {
            string filename = this.connection.Text;

            BusinessTier.Business b = new BusinessTier.Business(filename);
            var users = b.GetAllNamedUsers();

            foreach(var user in users)
            {
                UsersDisplay.Items.Add(user.UserName);
            }
            this.UsersDisplay.SelectedIndex = 0;
        }

        private void addReview_Click(object sender, EventArgs e)
        {
            string filename = this.connection.Text;
            BusinessTier.Business b = new BusinessTier.Business(filename);

            try
            {
                var movieID = b.GetMovie(this.MovieIDSub.Text).MovieID;
                var userID = b.GetNamedUser(this.UserIDSub.Text).UserID;
                var rating = Convert.ToInt32(this.RatingSub.Text);
       

                // CHECKS IF WE HAVE INVALID VALUES ----------------------
                if (b.GetMovie(movieID) == null)
                {
                    MessageBox.Show("Invalid Movie ID!"); return;
                }
                else if (b.GetUser(userID) == null)
                {
                    MessageBox.Show("Invalid User ID!"); return;
                }
                else if (rating > 5 || rating < 1)
                {
                    MessageBox.Show("Rating must be from 1 to 5!"); return;
                }
                else
                {
                    b.AddReview(movieID, userID, rating);
                    MessageBox.Show("Successfully Submitted!");
                }
                // -------------------------------------------------------

                // RESET THE SUBMISSION TEXT -----------
                this.MovieIDSub.Text = "Movie Title";
                this.UserIDSub.Text = "User Name";
                this.RatingSub.Text = "Rating";
                // -------------------------------------
            }
            catch
            {
                MessageBox.Show("Please input proper values!");
            }
        }

        private void TopN_Click(object sender, EventArgs e)
        {
            string filename = this.connection.Text;

            BusinessTier.Business b = new BusinessTier.Business(filename);
            try
            {
                // 8. Top-N Movies by Average Rating -----
                this.TopNList.Items.Clear();
                var topN = b.GetTopMoviesByAvgRating(Convert.ToInt32(this.TextN.Text));

                foreach (var movie in topN)
                {
                    TopNList.Items.Add(string.Format(@"{0}: {1}", movie.MovieName, Math.Round(b.GetMovieDetail(movie.MovieID).AvgRating,4)));
                }
                // ---------------------------------------
            }
            catch
            {
                MessageBox.Show("Invalid value. Please enter an integer");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
    }
}
