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

        public Button generateButton(string content, string name, StackPanel stackPnl, RoutedEventHandler btnSeat_Clicked) {
            Button btn = new Button();
            btn.Content = content;
            btn.Name = name;
            btn.Content = stackPnl;
            btn.BorderThickness = new Thickness(0);
            btn.Click += new RoutedEventHandler(btnSeat_Clicked);
           
            return btn;
        }

        public static Image generateImage(BitmapImage source)
        {
            Image img = new Image();
            img.Stretch = Stretch.Uniform;
            img.Source = source;

            return img;
        }

        public static StackPanel generateStackPanel(Image img)
        {
            StackPanel stackPnl = new StackPanel();
            stackPnl.Children.Add(img);

            return stackPnl;
        }

        public static void generateHall(Grid gdSeats, int colAmount, int rowAmount) {
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

        public static void generateGridButton(Button btn, Grid grid, int y, int x) {
            Grid.SetColumn(btn, y);
            Grid.SetRow(btn, x);
            grid.Children.Add(btn);
        }

        public static void generateGridImage(Image img, Grid grid, int y, int x) {
            Grid.SetColumn(img, y);
            Grid.SetRow(img, x);
            grid.Children.Add(img);
        }
    }
}
