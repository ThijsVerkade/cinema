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
using System.Windows.Shapes;

namespace Cinema_V2
{
    /// <summary>
    /// Interaction logic for AdminInlog.xaml
    /// </summary>
    public partial class AdminInlog : Window
    {

        private DbCinemaDataContext db;
        private classes.CinemaMovie movieHelper;

        public AdminInlog()
        {
            InitializeComponent();
            db = new DbCinemaDataContext();
            movieHelper = new classes.CinemaMovie(db);


            List<MovieList> myList = new List<MovieList>();

            foreach (Movie m in movieHelper.ReadAll())
            {
                MovieList ml = new MovieList();
                ml.Name = m.mTitle;
                ml.Genre = m.mGenre;
                ml.MovieDate = m.mDate;
                ml.Description = m.mDescription;

                myList.Add(ml);
            }
            DataGridAdmin.ItemsSource = myList;
        }

        private void DataGridAdmin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            db.SubmitChanges();
        }
    }
}