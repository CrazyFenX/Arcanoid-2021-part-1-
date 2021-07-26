using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid_2021_v001.Model
{
    /// <summary>
    /// Неразрушаемый золотой блок
    /// </summary>
    class GoldBrick : Brick
    {
        public GoldBrick()
        {
            IsBreackable = false;
        }

        public override void Draw(Graphics g, Rectangle rect)
        {
            g.FillRectangle(Brushes.Gold, rect);
            g.DrawRectangle(Pens.Black, rect);
        }
    }
}
