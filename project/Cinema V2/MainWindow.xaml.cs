using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cinema_V2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DbCinemaDataContext db;
        private classes.CinemaMovie movieHelper;
        private classes.CinemaSession SessionHelper;
        private classes.CinemaReservation reservationHelper;
        private classes.CinemaUser userHelper;
        private List<MovieList> movieLists;
        private List<models.SessionList> SessionLists;

        public MainWindow()
        {
            InitializeComponent();

            db = new DbCinemaDataContext();
            movieHelper = new classes.CinemaMovie(db);
            reservationHelper = new classes.CinemaReservation(db);
            SessionHelper = new classes.CinemaSession(db);
            userHelper = new classes.CinemaUser(db); // Maak globale connectie naar database 

            movieLists = new List<MovieList>();

            foreach (Movie m in movieHelper.ReadAll()) {
                MovieList ml = new MovieList();
                ml.Image = @"C:\Users\thijs\source\repos\ThijsVerkade\cinema\project\Cinema V2\images" + m.mPictureUrl;  //Fix this 
                ml.Name = m.mTitle;
                ml.Genre = m.mGenre;
                ml.Id = m.mId;
                movieLists.Add(ml);
            }

            lvMovies.ItemsSource = movieLists;
        }

        private void lvMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MovieList ml = (MovieList)lvMovies.SelectedItem;
            Movie temp = movieHelper.ReadOne(ml.Id);
            lblTitle.Content = temp.mTitle;

            gdHome.Visibility = Visibility.Hidden;

            SessionLists = new List<models.SessionList>();
            foreach (Session s in SessionHelper.ReadOnMovie(ml.Id))
            {
                models.SessionList sl = new models.SessionList();
                sl.Date = s.sDate;
                sl.Id = s.sId;
                sl.Hall = s.Hall;
                SessionLists.Add(sl);
            }
            cmbSessions.ItemsSource = SessionLists.ToList();


            lblMovieDate.Content = temp.mDate.ToString();
            lblMovieDuration.Content = temp.mMinutes.ToString() + " Minuten";
            lblMovieGenre.Content = temp.mGenre.ToString();
            lblMovieTitle.Content = temp.mTitle.ToString();
            lblMovieDescription.Content = temp.mDescription;
            Uri resourceUri = new Uri(@"C:\Users\thijs\source\repos\ThijsVerkade\cinema\project\Cinema V2\" + temp.mPictureUrl.ToString());
            imgMoviePicture.Source = new BitmapImage(resourceUri);

            gdMovie.Visibility = Visibility.Visible;
        }

        private void btnReservateSession_Click(object sender, RoutedEventArgs e)
        {
            string seats = txtSeats.Text;

            int n;
            bool isNumeric = int.TryParse(seats, out n);
            if (isNumeric)
            {
                models.SessionList mSl = (models.SessionList)cmbSessions.SelectedItem;
                reservationHelper.Create(Convert.ToInt32(seats), mSl.Id, new DateTime());
            }
            else {
                MessageBox.Show("Please enter a valid number");
                txtSeats.Text = "";
            }
        }

        private void cmbSessions_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            gdReservate.Visibility = Visibility.Visible;
            LoginHome.Visibility = Visibility.Hidden;

            models.SessionList mSl = (models.SessionList)cmbSessions.SelectedItem;
            int takeSeats = reservationHelper.ReadReservationSeats(mSl.Id);
            lblReservationSeats.Content = mSl.Hall.hAmoutSeats.ToString() + takeSeats;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            gdHome.Visibility = Visibility.Hidden;
            LoginHome.Visibility = Visibility.Visible;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string checkUsername = txtUsername.Text; // capture input van de velden
            string checkPassword = txtPassword.Text;


            if (userHelper.Readone(checkUsername, checkPassword) == true) // checkt of de waarde van de velden kloppen
            {

                MainWindow mw = new MainWindow();
                mw.Close();

                AdminInlog adminInlog = new AdminInlog();
                adminInlog.Show();

            }
            else
            {
                MessageBox.Show("Username or password Incorrect! ");
            }
        }

    }
}
