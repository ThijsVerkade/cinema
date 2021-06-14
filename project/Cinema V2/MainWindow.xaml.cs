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
        private (int, string) dataTuple;


        public MainWindow()
        {
            InitializeComponent();

            db = new DbCinemaDataContext();
            movieHelper = new classes.CinemaMovie(db);
            reservationHelper = new classes.CinemaReservation(db);
            SessionHelper = new classes.CinemaSession(db);
            userHelper = new classes.CinemaUser(db);

            movieLists = new List<MovieList>();
            lvMovies.ItemsSource = classes.MainwindowHelper.FillMovie(movieLists, movieHelper);

            dataTuple = (
                    1, "Username or password Incorrect!"
                );
        }

        private void lvMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gdHome.Visibility = Visibility.Hidden;
            gdSession.Visibility = Visibility.Hidden;
            gdMovie.Visibility = Visibility.Visible;
            LoginHome.Visibility = Visibility.Hidden;

            MovieList ml = (MovieList)lvMovies.SelectedItem;
            Movie temp = movieHelper.ReadOne(ml.Id);
            
            SessionLists = classes.MainwindowHelper.FillSession(SessionHelper, ml.Id);

            if (SessionLists.Count() > 0) {
                gdReservate.Visibility = Visibility.Visible;
            }else{
                gdReservate.Visibility = Visibility.Hidden;
            }

            cmbSessions.ItemsSource = SessionLists.ToList();

            lblMovieDate.Content = temp.mDate.ToString();
            lblMovieDuration.Content = temp.mMinutes.ToString() + " Minuten";
            lblMovieGenre.Content = temp.mGenre.ToString();
            lblMovieTitle.Content = temp.mTitle.ToString();
            lblMovieDescription.Content = temp.mDescription;
            Uri resourceUri = new Uri(@"C:\Users\Thijs\source\repos\ThijsVerkade\cinema\project\Cinema V2\images" + temp.mPictureUrl.ToString());
            imgMoviePicture.Source = new BitmapImage(resourceUri);
        }

        private void btnReservateSession_Click(object sender, RoutedEventArgs e)
        {
            models.SessionList mSl = (models.SessionList)cmbSessions.SelectedItem;

            cinemaHall ch = new cinemaHall(mSl.Id, mSl.Hall, this.db);
            ch.Show();
        }

        private void cmbSessions_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            gdReservate.Visibility = Visibility.Visible;
            LoginHome.Visibility = Visibility.Hidden;
            gdSession.Visibility = Visibility.Visible;

            updateSeatsLabel();
        }

        public void updateSeatsLabel() {
            models.SessionList mSl = (models.SessionList)cmbSessions.SelectedItem;
            if (mSl != null) {
                int takeSeats = reservationHelper.ReadReservationSeats(mSl.Id);

                int seats = Convert.ToInt32(mSl.Hall.hAmoutSeats) - Convert.ToInt32(takeSeats);

                lblReservationSeats.Content = seats;
                gdReservate.Visibility = Visibility.Visible;
            } else {

                gdReservate.Visibility = Visibility.Hidden;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            gdMovie.Visibility = Visibility.Hidden;
            gdHome.Visibility = Visibility.Hidden;
            gdReservate.Visibility = Visibility.Hidden;
            LoginHome.Visibility = Visibility.Visible;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e) {
            string checkUsername = txtUsername.Text; // capture input van de velden
            string checkPassword = txtPassword.Password;

            if (userHelper.Readone(checkUsername, checkPassword) == true) // checkt of de waarde van de velden kloppen
            {
                AdminInlog adminInlog = new AdminInlog();
                adminInlog.Show();
            }
            else
            {
                MessageBox.Show(dataTuple.Item2);
            }
        }

        private void btnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            gdHome.Visibility = Visibility.Visible;
            gdMovie.Visibility = Visibility.Hidden;
            LoginHome.Visibility = Visibility.Hidden;
        }

        private void txtUsername_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvMovies.SelectedIndex = -1;
            lvMovies.ItemsSource = movieHelper.SearchMovie(searchMovie.Text);
        }
    }
}
