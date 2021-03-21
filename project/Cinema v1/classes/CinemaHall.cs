using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_v1
{
    class CinemaHall
    {

        //Object Database
        private DbCinemaDataContext db;
        //Object Database Helper
        private CinemaDatabase dbHelper;

        public CinemaHall(DbCinemaDataContext database)
        {
            //Filling object
            this.db = database;
            dbHelper = new CinemaDatabase(database);
        }

        public int Create(int seats)
        {
            //Creating Object
            Hall h = new Hall();

            //Filling Object
            h.hAmountSeats = seats;
            this.db.Halls.InsertOnSubmit(h);

            //Updating Database
            dbHelper.SubmitChanges();

            //Returning Hall ID
            return h.hId;
        }

        public bool Delete(int id)
        {
            //Selecting Object
            Hall h = (from u in db.Halls where u.hId == id select u).FirstOrDefault();

            //Deleting Object
            this.db.Halls.DeleteOnSubmit(h);

            //Updating Database
            return dbHelper.SubmitChanges();
        }
        public int Edit(int id, int seats)
        {
            //Selecting Object
            Hall h = (from u in db.Halls where u.hId == id select u).FirstOrDefault();

            //Filling Object
            h.hAmountSeats = seats;

            //Updating Database
            dbHelper.SubmitChanges();

            //Returning Hall ID
            return h.hId;
        }
        public Hall ReadOne(int id)
        {
            //Returning Selected Object
            return (from u in this.db.Halls where u.hId == id select u).FirstOrDefault();
        }

        public List<Hall> ReadAll()
        {
            //Returning All Object
            return this.db.Halls.ToList();
        }
    }
}
