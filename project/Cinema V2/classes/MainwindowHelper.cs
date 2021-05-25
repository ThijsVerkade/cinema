using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_V2.classes
{
    class MainwindowHelper
    {

        public static List<MovieList> FillMovie(List<MovieList> movieLists, CinemaMovie movieHelper) {
            foreach (Movie m in movieHelper.ReadAll())
            {
                MovieList ml = new MovieList();
                ml.Image = @"C:\Users\thijs\source\repos\ThijsVerkade\cinema\project\Cinema V2\images" + m.mPictureUrl;  //Fix this 
                ml.Name = m.mTitle;
                ml.Genre = m.mGenre;
                ml.Id = m.mId;
                movieLists.Add(ml);
            }

            return movieLists;

        }

        public static List<models.SessionList> FillSession( CinemaSession SessionHelper, int mId)
        {
            List<models.SessionList> SessionLists = new List<models.SessionList>();
            foreach (Session s in SessionHelper.ReadOnMovie(mId))
            {
                models.SessionList sl = new models.SessionList();
                sl.Date = s.sDate;
                sl.Id = s.sId;
                sl.Hall = s.Hall;
                SessionLists.Add(sl);
            }

            return SessionLists;
        }

    }
}
