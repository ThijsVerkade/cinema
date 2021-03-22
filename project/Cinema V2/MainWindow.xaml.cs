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

        public MainWindow()
        {
            InitializeComponent();

            db = new DbCinemaDataContext();
            movieHelper = new classes.CinemaMovie(db);

            List<MovieList> mylist = new List<MovieList>();

            foreach (Movie m in movieHelper.ReadAll()) {
                MovieList ml = new MovieList();
                ml.Image = @"C:\Users\thijs\source\repos\ThijsVerkade\cinema\project\Cinema V2\images" + m.mPictureUrl;  //Fix this 
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
            Uri resourceUri = new Uri(@"C:\Users\thijs\source\repos\ThijsVerkade\cinema\project\Cinema V2\" + temp.mPictureUrl.ToString());
            imgMoviePicture.Source = new BitmapImage(resourceUri);

            gdMovie.Visibility = Visibility.Visible;
        }

        private void btnReservateSession_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
