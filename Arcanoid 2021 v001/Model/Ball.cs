using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Arcanoid_2021_v001.Model
{
    /// <summary>
    /// Мяч
    /// </summary>
    public class Ball
    {
        public Rectangle Bounds; //Границы мяча
        public Point Velocity; //Вектор скорости (направление)
        public int Speed = 5; //Скорость

        public void Update(float dt, Game game)
        {
            var b = Bounds;
            b.Offset(Velocity.X, Velocity.Y);

            var cp = new Point(Bounds.X + Bounds.Width / 2, Bounds.Y + Bounds.Height / 2); //Центр мяча

            //обработка столкновения с ракеткой
            var rect = game.Paddle.Bounds;
            if (Bounds.IntersectsWith(rect)) //Если происходит столкновение
            {
                //Вычисляем направление отскока
                var padding = 7; //Отскок

                Velocity.Y = -Speed;
                Velocity.X -= Math.Sign(game.Paddle.Velocity.X);

                if (cp.X < rect.Left + padding) Velocity.X = -Speed;
                if (cp.X > rect.Right - padding) Velocity.X = Speed;

            }

            //обработка столкновения со стенками
            if (b.Left < game.Bounds.Left || b.Right > game.Bounds.Right) Velocity.X *= -1;
            if (b.Top < game.Bounds.Top) Velocity.Y *= -1;

            //Двигаем мяч
            Bounds.Offset(Velocity.X, Velocity.Y);
        }

        public virtual void Draw(Graphics g)
        {
            var path = new GraphicsPath();

            path.AddEllipse(Bounds);
            var brush = new PathGradientBrush(path){
                CenterColor =Color.White, SurroundColors = new Color[] { Color.Red }};

            g.FillPath(brush, path);
            g.DrawPath(Pens.Black, path);
        }
    }
}