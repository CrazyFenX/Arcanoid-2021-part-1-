using System;
using Arcanoid_2021_v001.Model;
using System.Windows.Forms;

namespace Arcanoid_2021_v001.Control
{
    public partial class GamePanel : UserControl
    {
        public Game Game { get; set; }
        public GamePanel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Game == null) return;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Game.Bounds = ClientRectangle;
            Game.Draw(e.Graphics);
        }
    }
}
