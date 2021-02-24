using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BordF;

namespace WindowsFormsApp1
{
    public partial class Game15 : Form
    {
        Game game;
        const int size = 4;

        public Game15()
        {
            InitializeComponent();
            game = new Game(size);
            HideButton();
        }

        private void b00_Click(object sender, EventArgs e)
        {
            if (game.Solved()) label1.Text = "Победа";
            Button button = (Button)sender;
            int x = int.Parse(button.Name.Substring(1, 1));
            int y = int.Parse(button.Name.Substring(2, 1));
            game.PresAt(x, y);
            ShowButton();
            if (game.Solved()) label1.Text = "Победа";
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            game.Start(10 + DateTime.Now.Millisecond);
           // game.Start(1);
            ShowButton();
        }

        void  HideButton ()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    ShowDigitAt(0, i, j);
                }
            }
            label1.Text = "Добро  пожаловать  в  игру";
        }
        void  ShowButton ()
        {
            for (int i = 0; i<size; i++)
            {
                for (int j = 0; j<size; j++)
                {
                    ShowDigitAt( game.GetDigitAt (i ,j ), i, j);
                }
            }
            label1.Text = game.moves + " ходов";
        }

        private void ShowDigitAt(int digit, int x, int y)
        {
            Button button = (Button) Controls["b" + x + y];
            button.Text = DecTohex (digit);
            button.Visible = digit > 0;
            
        }

        private string DecTohex(int digit)
        {
            if (digit == 0) return "";
            if (digit < 10) return digit.ToString();
            return ((char)('A' + digit - 10)).ToString();

        }
    }
}
