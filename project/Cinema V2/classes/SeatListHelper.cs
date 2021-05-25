using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_V2.classes
{
    class SeatListHelper
    {
        public static void create(List<models.SeatList> SeatLists, int id, bool reserved) {
            models.SeatList sl = new models.SeatList();
            sl.Id = id;
            sl.Reserved = reserved;
            sl.Selected = false;
            SeatLists.Add(sl);
        }
    }
}
