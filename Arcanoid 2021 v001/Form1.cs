using System;
using Arcanoid_2021_v001.Model;
using System.Windows.Forms;

namespace Arcanoid_2021_v001
{
    public partial class Form1 : Form
    {
        private Game game;
        public Form1()
        {
            InitializeComponent();

            game = new Game();
            game.Bounds = pnGame.ClientRectangle;
            game.InitLevel();

            pnGame.Game = game;

            var tm = new Timer { Enabled = true, Interval = 20 };
            tm.Tick += delegate
            {
                var dt = 0.1f;
                game.Update(dt);
                pnGame.Invalidate();

                if (game.IsGameOver()) //Мяч потерян
                {
                    tm.Stop();
                    MessageBox.Show("Game over!");
                    tm.Start();
                }
            };
        }
    }
}
