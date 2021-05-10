using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_V2.classes
{
    class CinemaUser
    {
        private DbCinemaDataContext db;

        //Object Database Helper
        private CinemaDatabase dbHelper;

        public CinemaUser(DbCinemaDataContext database)
        {
            //Filling object
            this.db = database;
            dbHelper = new CinemaDatabase(database);
        }
       
        public bool Readone(string Username, string Password)
        {
            // query om te data van de database op te halen.
            User Query = (from User in db.Users where User.Username == Username && User.Password == Password select User).FirstOrDefault();

            if(Query == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
