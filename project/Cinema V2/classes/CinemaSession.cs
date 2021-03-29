using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_V2.classes
{
    class CinemaSession
    {
        //Object Database
        private DbCinemaDataContext db;
        //Object Database Helper
        private CinemaDatabase dbHelper;

        public CinemaSession(DbCinemaDataContext database)
        {
            //Filling object
            this.db = database;
            dbHelper = new CinemaDatabase(database);
        }

        public int Create(int hId, int mId)
        {
            //Creating Object
            Session r = new Session();

            //Filling Object
            r.hId = hId;
            r.mId = mId;
            this.db.Sessions.InsertOnSubmit(r);

            //Updating Database
            dbHelper.SubmitChanges();

            //Returning Session ID
            return r.sId;
        }

        public bool Delete(int id)
        {
            //Selecting Object
            Session r = (from u in db.Sessions where u.sId == id select u).FirstOrDefault();

            //Deleting Object
            this.db.Sessions.DeleteOnSubmit(r);

            //Updating Database
            return dbHelper.SubmitChanges();
        }
        public int Edit(int sId, int hId, int mId,string sDate)
        {
            //Selecting Object
            Session r = (from u in db.Sessions where u.sId == sId select u).FirstOrDefault();

            //Filling Object
            r.sId = sId;
            r.hId = hId;
            r.mId = mId;
            r.sDate = Convert.ToDateTime(sDate);

            //Updating Database
            dbHelper.SubmitChanges();

            //Returning Session ID
            return r.sId;
        }

        public Session ReadOneDate(string date)
        {
            //Returning Selected Object
            return (from u in this.db.Sessions where u.sDate == Convert.ToDateTime(date) select u).FirstOrDefault();
        }
        

        public Session ReadOne(int id)
        {
            //Returning Selected Object
            return (from u in this.db.Sessions where u.sId == id && u.hId == id select u).FirstOrDefault();
        }

        public List<Session> ReadOnMovie(int mId)
        {
            //Returning Selected Object
            return (from u in this.db.Sessions where u.mId == mId select u).ToList();
        }

        public List<Session> ReadAll()
        {
            //Returning All Object
            return this.db.Sessions.ToList();
        }
    }
}
