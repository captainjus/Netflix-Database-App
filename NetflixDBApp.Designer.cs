namespace WindowsFormsApp3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.connection = new System.Windows.Forms.TextBox();
            this.MovieListDisplay = new System.Windows.Forms.ListBox();
            this.Movies = new System.Windows.Forms.Button();
            this.AllUsers = new System.Windows.Forms.Button();
            this.topMovieText = new System.Windows.Forms.TextBox();
            this.bottomMovieText = new System.Windows.Forms.TextBox();
            this.UsersDisplay = new System.Windows.Forms.ListBox();
            this.topUserText = new System.Windows.Forms.TextBox();
            this.bottomUserText = new System.Windows.Forms.TextBox();
            this.MovieReviewTitle = new System.Windows.Forms.TextBox();
            this.MovieReviewList = new System.Windows.Forms.ListBox();
            this.UserReviewList = new System.Windows.Forms.ListBox();
            this.UserReviewer = new System.Windows.Forms.TextBox();
            this.addReview = new System.Windows.Forms.Button();
            this.RatingSub = new System.Windows.Forms.TextBox();
            this.MovieIDSub = new System.Windows.Forms.TextBox();
            this.UserIDSub = new System.Windows.Forms.TextBox();
            this.EachRatingList = new System.Windows.Forms.ListBox();
            this.EachRating = new System.Windows.Forms.TextBox();
            this.TopN = new System.Windows.Forms.Button();
            this.TopNList = new System.Windows.Forms.ListBox();
            this.TextN = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // connection
            // 
            this.connection.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.connection.Location = new System.Drawing.Point(12, 405);
            this.connection.Name = "connection";
            this.connection.Size = new System.Drawing.Size(167, 20);
            this.connection.TabIndex = 0;
            this.connection.Text = "netflix-200k.mdf";
            // 
            // MovieListDisplay
            // 
            this.MovieListDisplay.FormattingEnabled = true;
            this.MovieListDisplay.Location = new System.Drawing.Point(507, 138);
            this.MovieListDisplay.Name = "MovieListDisplay";
            this.MovieListDisplay.Size = new System.Drawing.Size(338, 251);
            this.MovieListDisplay.TabIndex = 1;
            this.MovieListDisplay.SelectedIndexChanged += new System.EventHandler(this.MovieListDisplay_SelectedIndexChanged);
            // 
            // Movies
            // 
            this.Movies.Location = new System.Drawing.Point(507, 22);
            this.Movies.Name = "Movies";
            this.Movies.Size = new System.Drawing.Size(338, 51);
            this.Movies.TabIndex = 2;
            this.Movies.Text = "Movies";
            this.Movies.UseVisualStyleBackColor = true;
            this.Movies.Click += new System.EventHandler(this.Movies_Click);
            // 
            // AllUsers
            // 
            this.AllUsers.Location = new System.Drawing.Point(12, 22);
            this.AllUsers.Name = "AllUsers";
            this.AllUsers.Size = new System.Drawing.Size(167, 51);
            this.AllUsers.TabIndex = 3;
            this.AllUsers.Text = "All Users";
            this.AllUsers.UseVisualStyleBackColor = true;
            this.AllUsers.Click += new System.EventHandler(this.AllUsers_Click);
            // 
            // topMovieText
            // 
            this.topMovieText.Location = new System.Drawing.Point(507, 79);
            this.topMovieText.Name = "topMovieText";
            this.topMovieText.ReadOnly = true;
            this.topMovieText.Size = new System.Drawing.Size(338, 20);
            this.topMovieText.TabIndex = 4;
            this.topMovieText.Text = "Movie ID:";
            // 
            // bottomMovieText
            // 
            this.bottomMovieText.Location = new System.Drawing.Point(507, 105);
            this.bottomMovieText.Name = "bottomMovieText";
            this.bottomMovieText.ReadOnly = true;
            this.bottomMovieText.Size = new System.Drawing.Size(338, 20);
            this.bottomMovieText.TabIndex = 5;
            this.bottomMovieText.Text = "Avg Rating:";
            // 
            // UsersDisplay
            // 
            this.UsersDisplay.FormattingEnabled = true;
            this.UsersDisplay.Location = new System.Drawing.Point(12, 138);
            this.UsersDisplay.Name = "UsersDisplay";
            this.UsersDisplay.Size = new System.Drawing.Size(167, 251);
            this.UsersDisplay.TabIndex = 6;
            this.UsersDisplay.SelectedIndexChanged += new System.EventHandler(this.Users_SelectedIndexChanged);
            // 
            // topUserText
            // 
            this.topUserText.Location = new System.Drawing.Point(12, 79);
            this.topUserText.Name = "topUserText";
            this.topUserText.ReadOnly = true;
            this.topUserText.Size = new System.Drawing.Size(167, 20);
            this.topUserText.TabIndex = 7;
            this.topUserText.Text = "User ID:";
            // 
            // bottomUserText
            // 
            this.bottomUserText.Location = new System.Drawing.Point(12, 105);
            this.bottomUserText.Name = "bottomUserText";
            this.bottomUserText.ReadOnly = true;
            this.bottomUserText.Size = new System.Drawing.Size(167, 20);
            this.bottomUserText.TabIndex = 8;
            this.bottomUserText.Text = "Occupation:";
            // 
            // MovieReviewTitle
            // 
            this.MovieReviewTitle.Location = new System.Drawing.Point(851, 22);
            this.MovieReviewTitle.Name = "MovieReviewTitle";
            this.MovieReviewTitle.ReadOnly = true;
            this.MovieReviewTitle.Size = new System.Drawing.Size(228, 20);
            this.MovieReviewTitle.TabIndex = 10;
            this.MovieReviewTitle.Text = "MovieReviewTitle";
            // 
            // MovieReviewList
            // 
            this.MovieReviewList.FormattingEnabled = true;
            this.MovieReviewList.Location = new System.Drawing.Point(851, 40);
            this.MovieReviewList.Name = "MovieReviewList";
            this.MovieReviewList.Size = new System.Drawing.Size(228, 134);
            this.MovieReviewList.TabIndex = 11;
            // 
            // UserReviewList
            // 
            this.UserReviewList.FormattingEnabled = true;
            this.UserReviewList.Location = new System.Drawing.Point(185, 40);
            this.UserReviewList.Name = "UserReviewList";
            this.UserReviewList.Size = new System.Drawing.Size(306, 134);
            this.UserReviewList.TabIndex = 13;
            // 
            // UserReviewer
            // 
            this.UserReviewer.Location = new System.Drawing.Point(185, 22);
            this.UserReviewer.Name = "UserReviewer";
            this.UserReviewer.ReadOnly = true;
            this.UserReviewer.Size = new System.Drawing.Size(306, 20);
            this.UserReviewer.TabIndex = 12;
            this.UserReviewer.Text = "UserReviewer";
            // 
            // addReview
            // 
            this.addReview.Location = new System.Drawing.Point(368, 339);
            this.addReview.Name = "addReview";
            this.addReview.Size = new System.Drawing.Size(123, 46);
            this.addReview.TabIndex = 14;
            this.addReview.Text = "Submit Review";
            this.addReview.UseVisualStyleBackColor = true;
            this.addReview.Click += new System.EventHandler(this.addReview_Click);
            // 
            // RatingSub
            // 
            this.RatingSub.Location = new System.Drawing.Point(185, 365);
            this.RatingSub.Name = "RatingSub";
            this.RatingSub.Size = new System.Drawing.Size(177, 20);
            this.RatingSub.TabIndex = 15;
            this.RatingSub.Text = "Rating";
            // 
            // MovieIDSub
            // 
            this.MovieIDSub.Location = new System.Drawing.Point(185, 313);
            this.MovieIDSub.Name = "MovieIDSub";
            this.MovieIDSub.Size = new System.Drawing.Size(306, 20);
            this.MovieIDSub.TabIndex = 16;
            this.MovieIDSub.Text = "Movie Title";
            // 
            // UserIDSub
            // 
            this.UserIDSub.Location = new System.Drawing.Point(185, 339);
            this.UserIDSub.Name = "UserIDSub";
            this.UserIDSub.Size = new System.Drawing.Size(177, 20);
            this.UserIDSub.TabIndex = 17;
            this.UserIDSub.Text = "User Name";
            // 
            // EachRatingList
            // 
            this.EachRatingList.FormattingEnabled = true;
            this.EachRatingList.Location = new System.Drawing.Point(851, 225);
            this.EachRatingList.Name = "EachRatingList";
            this.EachRatingList.Size = new System.Drawing.Size(228, 134);
            this.EachRatingList.TabIndex = 19;
            // 
            // EachRating
            // 
            this.EachRating.Location = new System.Drawing.Point(851, 207);
            this.EachRating.Name = "EachRating";
            this.EachRating.ReadOnly = true;
            this.EachRating.Size = new System.Drawing.Size(228, 20);
            this.EachRating.TabIndex = 18;
            this.EachRating.Text = "Ratings";
            // 
            // TopN
            // 
            this.TopN.Location = new System.Drawing.Point(416, 180);
            this.TopN.Name = "TopN";
            this.TopN.Size = new System.Drawing.Size(75, 60);
            this.TopN.TabIndex = 20;
            this.TopN.Text = "Top N Movies by Avg";
            this.TopN.UseVisualStyleBackColor = true;
            this.TopN.Click += new System.EventHandler(this.TopN_Click);
            // 
            // TopNList
            // 
            this.TopNList.FormattingEnabled = true;
            this.TopNList.Location = new System.Drawing.Point(185, 180);
            this.TopNList.Name = "TopNList";
            this.TopNList.Size = new System.Drawing.Size(225, 108);
            this.TopNList.TabIndex = 21;
            // 
            // TextN
            // 
            this.TextN.Location = new System.Drawing.Point(417, 247);
            this.TextN.Name = "TextN";
            this.TextN.Size = new System.Drawing.Size(74, 20);
            this.TextN.TabIndex = 22;
            this.TextN.Text = "N";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 444);
            this.Controls.Add(this.TextN);
            this.Controls.Add(this.TopNList);
            this.Controls.Add(this.TopN);
            this.Controls.Add(this.EachRatingList);
            this.Controls.Add(this.EachRating);
            this.Controls.Add(this.UserIDSub);
            this.Controls.Add(this.MovieIDSub);
            this.Controls.Add(this.RatingSub);
            this.Controls.Add(this.addReview);
            this.Controls.Add(this.UserReviewList);
            this.Controls.Add(this.UserReviewer);
            this.Controls.Add(this.MovieReviewList);
            this.Controls.Add(this.MovieReviewTitle);
            this.Controls.Add(this.bottomUserText);
            this.Controls.Add(this.topUserText);
            this.Controls.Add(this.UsersDisplay);
            this.Controls.Add(this.bottomMovieText);
            this.Controls.Add(this.topMovieText);
            this.Controls.Add(this.AllUsers);
            this.Controls.Add(this.Movies);
            this.Controls.Add(this.MovieListDisplay);
            this.Controls.Add(this.connection);
            this.Name = "Form1";
            this.Text = "Netflix Database App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox connection;
        private System.Windows.Forms.ListBox MovieListDisplay;
        private System.Windows.Forms.Button Movies;
        private System.Windows.Forms.Button AllUsers;
        private System.Windows.Forms.TextBox topMovieText;
        private System.Windows.Forms.TextBox bottomMovieText;
        private System.Windows.Forms.ListBox UsersDisplay;
        private System.Windows.Forms.TextBox topUserText;
        private System.Windows.Forms.TextBox bottomUserText;
        private System.Windows.Forms.TextBox MovieReviewTitle;
        private System.Windows.Forms.ListBox MovieReviewList;
        private System.Windows.Forms.ListBox UserReviewList;
        private System.Windows.Forms.TextBox UserReviewer;
        private System.Windows.Forms.Button addReview;
        private System.Windows.Forms.TextBox RatingSub;
        private System.Windows.Forms.TextBox MovieIDSub;
        private System.Windows.Forms.TextBox UserIDSub;
        private System.Windows.Forms.ListBox EachRatingList;
        private System.Windows.Forms.TextBox EachRating;
        private System.Windows.Forms.Button TopN;
        private System.Windows.Forms.ListBox TopNList;
        private System.Windows.Forms.TextBox TextN;
    }
}

