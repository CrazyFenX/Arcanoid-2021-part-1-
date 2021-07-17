using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arcanoid_2021_v001.Model
{
    /// <summary>
    /// Ракетка
    /// </summary>
    public class Paddle
    {
        public Rectangle Bounds { get; set; }
        public int Speed { get; set; }
        public Point Velocity { get; set; }

        public Paddle()
        {
            Speed = 1;
        }

        public void Update(float dt, Game game)
        {
            //Обрабатываем клавиатуру
            Velocity = new Point();
            if (Keyboard.IsKeyDown(Keys.Left) || Keyboard.IsKeyDown(Keys.A))
                Velocity = new Point(-Speed, 0);
            if (Keyboard.IsKeyDown(Keys.Right) || Keyboard.IsKeyDown(Keys.D))
                Velocity = new Point(Speed, 0);
            //Сдвигаем ракетку
            var bounds = Bounds;
            bounds.Offset(Velocity.X, Velocity.Y);

            //Проверяем, остаемся ли в игровом поле
            if (bounds.Left >= game.Bounds.Left && bounds.Right <= game.Bounds.Right)
            {
                Bounds = bounds;
            }
        }

        public virtual void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Green, Bounds);
            g.DrawRectangle(Pens.Lime, Bounds);
        }

    }
}
