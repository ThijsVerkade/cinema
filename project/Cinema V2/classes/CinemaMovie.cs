using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_V2.classes
{
    class CinemaMovie
    {
        //Object Database
        private DbCinemaDataContext db;
        //Object Database Helper
        private CinemaDatabase dbHelper;

        public CinemaMovie(DbCinemaDataContext database)
        {
            //Filling object
            this.db = database;
            dbHelper = new CinemaDatabase(database);
        }

        public int Create(string title, string description, string pictureUrl, string videoUrl)
        {
            //Creating Object
            Movie m = new Movie();

            //Filling Object
            m.mTitle = title;
            m.mDescription = description;
            m.mPictureUrl = pictureUrl;
            m.mVideoUrl = videoUrl;
            this.db.Movies.InsertOnSubmit(m);

            //Updating Database
            dbHelper.SubmitChanges();

            //Returning Movie ID
            return m.mId;
        }

        public bool Delete(int id)
        {
            //Selecting Object
            Movie m = (from u in db.Movies where u.mId == id select u).FirstOrDefault();

            //Deleting Object
            this.db.Movies.DeleteOnSubmit(m);

            //Updating Database
            return dbHelper.SubmitChanges();
        }
        public int Edit(int id, string title, string description, string pictureUrl, string videoUrl)
        {
            //Selecting Object
            Movie m = (from u in db.Movies where u.mId == id select u).FirstOrDefault();

            //Filling Object
            m.mTitle = title;
            m.mDescription = description;
            m.mPictureUrl = pictureUrl;
            m.mVideoUrl = videoUrl;

            //Updating Database
            dbHelper.SubmitChanges();

            //Returning Movie ID
            return m.mId;
        }
        public Movie ReadOne(int id)
        {
            //Returning Selected Object
            return (from u in this.db.Movies where u.mId == id select u).FirstOrDefault();
        }

        public List<Movie> ReadAll()
        {
            //Returning All Object
            return this.db.Movies.ToList();
        }
    }
}
