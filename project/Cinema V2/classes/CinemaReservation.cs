using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_V2.classes
{
    class CinemaReservation
    {
        //Object Database
        private DbCinemaDataContext db;
        //Object Database Helper
        private CinemaDatabase dbHelper;

        public CinemaReservation(DbCinemaDataContext database)
        {
            //Filling object
            this.db = database;
            dbHelper = new CinemaDatabase(database);
        }

        public int Create(int seats, int sId, string date)
        {
            //Creating Object
            Reservation r = new Reservation();
            //Filling Object
            r.rId = db.Reservations.Max(u => u.rId) + 1;
            r.rSeat = seats;
            r.sId = sId;
            //r.rDate = new DateTime();
            this.db.Reservations.InsertOnSubmit(r);

            //Updating Database
            dbHelper.SubmitChanges();

            //Returning Reservation ID
            return r.rId;
        }

        public bool Delete(int id)
        {
            //Selecting Object
            Reservation r = (from u in db.Reservations where u.rId == id select u).FirstOrDefault();

            //Deleting Object
            this.db.Reservations.DeleteOnSubmit(r);

            //Updating Database
            return dbHelper.SubmitChanges();
        }
        public int Edit(int id, int seats, int sId)
        {
            //Selecting Object
            Reservation r = (from u in db.Reservations where u.rId == id select u).FirstOrDefault();

            //Filling Object
            r.rSeat = seats;
            r.sId = sId;

            //Updating Database
            dbHelper.SubmitChanges();

            //Returning Reservation ID
            return r.sId;
        }
        public Reservation ReadOne(int id)
        {
            //Returning Selected Object
            return (from u in this.db.Reservations where u.rId == id select u).FirstOrDefault();
        }

        public List<Reservation> ReadAll()
        {
            //Returning All Object
            return this.db.Reservations.ToList();
        }

        public int ReadReservationSeats(int rId)
        {
            List<Reservation> tr = (from u in this.db.Reservations where u.sId == rId select u).ToList();
            int seats = 0;

            foreach (Reservation item in tr){
                seats = seats + item.rSeat;
            }

            return seats;
        }
    }
}
