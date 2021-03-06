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
    /// Interaction logic for cinemaHall.xaml
    /// </summary>
    public partial class cinemaHall : Window
    {
        private List<models.SeatList> SeatLists;
        private classes.HallGenerator HallGeneratorHelper;
        private classes.CinemaReservation ReservationHelper;
        private int sId;
        public cinemaHall(int sId, Hall h, DbCinemaDataContext db)
        {
            InitializeComponent();

            SeatLists = new List<models.SeatList>();
            HallGeneratorHelper = new classes.HallGenerator(SeatLists);
            ReservationHelper = new classes.CinemaReservation(db);
            this.sId = sId;


            int count = 1;
            int amountRows = 0;
            int row;
            BitmapImage source;

            classes.HallGenerator.generateHall(
                gdSeats,
                Convert.ToInt32(h.hAmountRows),
                Convert.ToInt32((h.hAmoutSeats / h.hAmountRows + 1))
            );

            for (int i = 0; i < (h.hAmoutSeats / h.hAmountRows); i++){
                for (int j = 0; j < h.hAmountRows; j++){
                    row = j + 1;

                    if (row != h.hStairs1 && row != h.hStairs2 && row != h.hStairs3 && row != h.hStairs4){
                        bool reserved = ReservationHelper.CheckReservationSeat(sId, count);

                        classes.SeatListHelper.create(SeatLists, Convert.ToInt32(count), reserved);

                        if (reserved) {
                            source = new BitmapImage(new Uri(@"C:\Users\Thijs\source\repos\ThijsVerkade\cinema\project\Cinema V2\images\seats-red.jpg"));
                        }
                        else {
                            source = new BitmapImage(new Uri(@"C:\Users\Thijs\source\repos\ThijsVerkade\cinema\project\Cinema V2\images\seats.jpg"));
                        }

                        Image img = classes.HallGenerator.generateImage(source);

                        StackPanel stackPnl = classes.HallGenerator.generateStackPanel(img);

                        Button btn = HallGeneratorHelper.generateButton(count.ToString(), "Button" + count.ToString(), stackPnl, btnSeat_Clicked);

                        classes.HallGenerator.generateGridButton(btn, gdSeats, j, i);

                        count++;
                    } else {
                        source = new BitmapImage(new Uri(@"C:\Users\Thijs\source\repos\ThijsVerkade\cinema\project\Cinema V2\images\stairs.jpg"));

                        Image img = classes.HallGenerator.generateImage(source);

                        classes.HallGenerator.generateGridImage(img, gdSeats, j, i);
                    }
                    amountRows++;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (models.SeatList sl in this.SeatLists)
            {
                if (sl.Reserved == false && sl.Selected == true)
                {
                    ReservationHelper.Create(sl.Id, this.sId);
                }
            }
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            mainWindow.updateSeatsLabel();
            MessageBox.Show("Your tickets has been reserverd");
            this.Close();
        }

        private void btnSeat_Clicked(object sender, EventArgs e)
        {
            BitmapImage source;
            Button clicked = (Button)sender;
            int name = Convert.ToInt32(clicked.Name.Replace("Button", ""));

            models.SeatList res = SeatLists.Find(x => x.Id == name);
            if (res.Reserved == false)
            {
                if (res.Selected == false)
                {
                    source = new BitmapImage(new Uri(@"C:\Users\Thijs\source\repos\ThijsVerkade\cinema\project\Cinema V2\images\seats-green.jpg"));
                    res.Selected = true;
                }
                else
                {
                    source = new BitmapImage(new Uri(@"C:\Users\Thijs\source\repos\ThijsVerkade\cinema\project\Cinema V2\images\seats.jpg"));
                    res.Selected = false;
                }

                Image img = classes.HallGenerator.generateImage(source);

                StackPanel stackPnl = classes.HallGenerator.generateStackPanel(img);

                clicked.Content = stackPnl;
            }
            else
            {
                MessageBox.Show("This seat is reserved!");
            }
        }

    }
}
