using BordF;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Game15_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Game game;
        const int size = 8;

        public MainWindow()
        {
            InitializeComponent();
            game = new Game(size);
            btStart.Click += BtStart_Click;
            gridStart(size);
            HideButton();
        }

        private void gridStart(int size)
        {
            for (int i = 0; i < size; i++)
            {
                grGane.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < size; i++)
            {
                grGane.RowDefinitions.Add(new RowDefinition());
            }

        }

        private void BtStart_Click(object sender, RoutedEventArgs e)
        {
             game.Start(10 + DateTime.Now.Millisecond);
            game.Start(1);
            ShowButton();
        }

        void HideButton()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    ShowDigitAt(0, i, j);
                }
            }

            lbMain.Content  = "Добро  пожаловать  в  игру";
        }

        void ShowButton()
        {
            grGane.Children.Clear();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    ShowDigitAt(game.GetDigitAt(i, j), i, j);
                }
            }

            lbMain.Content = game.moves + " ходов";
        }

        private void ShowDigitAt(int digit, int x, int y)
        {
            Button button = new Button();
           
            button.Content = DecTohex(digit).ToString();

            if (digit == 0) { button.Visibility = Visibility.Collapsed; }

            button.Name = $"_{x}{y}";
            button.SetValue(Grid.RowProperty, y);
            button.SetValue(Grid.ColumnProperty, x);
            button.Click += b00_Click;
            grGane.Children.Add(button);
        }

        private string DecTohex(int digit)
        {
            if (digit == 0) return "";
            if (digit < 10) return digit.ToString();
            return ((char)('A' + digit - 10)).ToString();

        }



        private void b00_Click(object sender, EventArgs e)
        {
            if (game.Solved()) lbMain.Content = "Победа";
            Button button = (Button)sender;
            int x = int.Parse(button.Name.Substring(1, 1));
            int y = int.Parse(button.Name.Substring(2, 1));
            game.PresAt(x, y);
            ShowButton();

            if (game.Solved()) lbMain.Content = "Победа";
        }
    }
}
