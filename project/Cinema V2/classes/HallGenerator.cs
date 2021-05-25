using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Cinema_V2.classes
{
    class HallGenerator
    {
        private List<models.SeatList> SeatLists;

        public HallGenerator(List<models.SeatList> sl) {
            SeatLists = sl;
        }

        public Button GenerateButton(string content, string name, StackPanel stackPnl) {
            Button btn = new Button();
            btn.Content = content;
            btn.Name = name;
            btn.Content = stackPnl;
            btn.BorderThickness = new Thickness(0);
            btn.Click += new RoutedEventHandler(btnSeat_Clicked);
           
            return btn;
        }

        public static Image GenerateImage(BitmapImage source)
        {
            Image img = new Image();
            img.Stretch = Stretch.Uniform;
            img.Source = source;

            return img;
        }

        public static StackPanel GenerateStackPanel(Image img)
        {
            StackPanel stackPnl = new StackPanel();
            stackPnl.Children.Add(img);

            return stackPnl;
        }

        public static void GenerateHall(Grid gdSeats, int colAmount, int rowAmount) {
            for (int i = 0; i < colAmount; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();

                gdSeats.ColumnDefinitions.Add(colDef);
            }

            for (int i = 0; i < rowAmount; i++)
            {
                RowDefinition rowDef = new RowDefinition();

                gdSeats.RowDefinitions.Add(rowDef);
            }
        }

        public static void GenerateGridButton(Button btn, Grid grid, int y, int x) {
            Grid.SetColumn(btn, y);
            Grid.SetRow(btn, x);
            grid.Children.Add(btn);
        }

        public static void GenerateGridImage(Image img, Grid grid, int y, int x) {
            Grid.SetColumn(img, y);
            Grid.SetRow(img, x);
            grid.Children.Add(img);
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

                Image img = GenerateImage(source);

                StackPanel stackPnl = GenerateStackPanel(img);

                clicked.Content = stackPnl;
            }
            else
            {
                MessageBox.Show("This seat is reserved!");
            }
        }

    }
}
