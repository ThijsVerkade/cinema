using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_v1
{
    class CinemaDatabase
    {
        private DbCinemaDataContext db;

        public CinemaDatabase(DbCinemaDataContext Database) {
            this.db = Database;
        }

        public bool SubmitChanges() {
            try {
                this.db.SubmitChanges();

                return true;
            }
            catch (Exception e) {
                return false;
            }
        }
    }
}
