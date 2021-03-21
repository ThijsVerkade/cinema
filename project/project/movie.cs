using System;
using System.Collections.Generic;
using System.Text;

namespace project
{
    class Movie
    {
        private CinemaDatabase db;

        public Movie(CinemaDatabase database) {
            db = database;
        }

        public void Create() {
            

            db.Movie.AddMovieRow()
        
        }
        public void Delete() { 
        
        }
        public void Edit() { 
        
        }
        public void ReadOne() { 
        
        }

        public List<> ReadAll() {
            var test = (from p in db.Movie select p).ToList();


        }
    }
}
