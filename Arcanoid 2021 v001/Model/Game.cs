using System;
using System.Drawing;
using Arcanoid_2021_v001.Model;

namespace Arcanoid_2021_v001.Model
{
    public class Game
    {
        public Paddle Paddle { get; set; }
        public Ball Ball { get; set; }
        public Rectangle Bounds { get; set; }

        public void InitLevel()
        {
            Ball = new Ball();
            Ball.Bounds = new Rectangle(Bounds.Width / 2, (int)(Bounds.Height * 0.9f), 10, 10);
            Ball.Velocity = new Point(0, -5);
            Ball.Speed = 5;

            Paddle = new Paddle();
            Paddle.Bounds = new Rectangle(Bounds.Width / 2, (int)(Bounds.Height * 0.95f), 80, 15);
            Paddle.Speed = 6;
        }

        public bool IsGameOver()
        {
            return Ball.Bounds.Bottom > Bounds.Bottom + 2;
        }

        public void Update(float dt)
        {
            Ball.Update(dt, this);
            Paddle.Update(dt, this);
        }

        public virtual void Draw(Graphics g)
        {
            //Рисуем мяч и ракетку
            Ball.Draw(g);
            Paddle.Draw(g);
        }
    }
}