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
        private classes.CinemaUser userHelper;

        public MainWindow()
        {
            InitializeComponent();

            db = new DbCinemaDataContext();
            movieHelper = new classes.CinemaMovie(db);
            userHelper = new classes.CinemaUser(db); // maak globale connectie naar database 


            List<MovieList> mylist = new List<MovieList>();

            foreach (Movie m in movieHelper.ReadAll()) {
                MovieList ml = new MovieList();
                ml.Image = @"C:\Users\Darren\source\repos\ThijsVerkade\cinema\project\Cinema V2\" + m.mPictureUrl;  //Fix this 
                ml.Name = m.mTitle;
                ml.Genre = m.mGenre;
                ml.Id = m.mId;

                mylist.Add(ml);
            }
            lvMovies.ItemsSource = mylist;
        }

        private void lvMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MovieList ml = (MovieList)lvMovies.SelectedItem;
            Movie temp = movieHelper.ReadOne(ml.Id);
            lblTitle.Content = temp.mTitle;

            gdHome.Visibility = Visibility.Hidden;

            lblMovieDate.Content = temp.mDate.ToString();
            lblMovieDuration.Content = temp.mMinutes.ToString() + " Minuten";
            lblMovieGenre.Content = temp.mGenre.ToString();
            lblMovieTitle.Content = temp.mTitle.ToString();
            lblMovieDescription.Content = temp.mDescription;
            Uri resourceUri = new Uri(@"C:\Users\Darren\source\repos\ThijsVerkade\cinema\project\Cinema V2\" + temp.mPictureUrl.ToString());
            imgMoviePicture.Source = new BitmapImage(resourceUri);

            gdMovie.Visibility = Visibility.Visible;
        }

        private void btnReservateSession_Click(object sender, RoutedEventArgs e)
        {

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
            
            
            if(userHelper.Readone(checkUsername,checkPassword) == true) // checkt of de waarde van de velden kloppen
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
