using System;
using System.Drawing;
using Arcanoid_2021_v001.Model;

namespace Arcanoid_2021_v001.Model
{
    public class Game
    {
        //Поля
        public Level Level { get; set; }
        public Paddle Paddle { get; set; }
        public Ball Ball { get; set; }
        public Rectangle Bounds { get; set; }

        public int NextLevelNumber { get; set; }

        //Методы
        public void InitLevel()
        {
            //Инициализация мяча
            Ball = new Ball();
            Ball.Bounds = new Rectangle(Bounds.Width / 2, (int)(Bounds.Height * 0.9f), 10, 10);
            Ball.Velocity = new Point(0, -5);
            Ball.Speed = 5;

            //Инициализация ракетки
            Paddle = new Paddle();
            Paddle.Bounds = new Rectangle(Bounds.Width / 2, (int)(Bounds.Height * 0.95f), 80, 15);
            Paddle.Speed = 6;

            //Инициализация уровня
            switch(NextLevelNumber)
            {
                case 0:
                    Level = Level.Parse(
                        @"
0000000000000000000
0000111111111111000
0020111111111111020");
                    break;

                case 1:
                    Level = Level.Parse(
                        @"
0000000000000000000
0000000000000000000
1111111111111111111
1010101010101010101
1010101020201010101
1110111011101110111");
                    break;
                default:
                    NextLevelNumber = 0;
                    goto case 0;
            }
        }
        /// <summary>
        /// Все ли блоки уничтожены?
        /// </summary>
        public bool IsLevelCompleted()
        {
            foreach (Brick item in Level.Cells)
                if (item != null && item.IsBreackable) return false;
            return true;
        }

        /// <summary>
        /// Вышел ли мяч за пределы поля?
        /// </summary>
        public bool IsGameOver()
        {
            return Ball.Bounds.Bottom > Bounds.Bottom + 2;
        }

        /// <summary>
        /// Обновление состояния объектов и уровня
        /// </summary>
        public void Update(float dt)
        {
            Ball.Update(dt, this);
            Paddle.Update(dt, this);
        }

        /// <summary>
        /// Отрисовка объектов и уровня
        /// </summary>
        public virtual void Draw(Graphics g)
        {
            //Рисуем блоки
            for (int i = 0; i < Level.Cells.GetLength(1); i++)
                for (int j = 0; j < Level.Cells.GetLength(0); j++)
                    if (Level.Cells[j, i] != null)
                        Level.Cells[j, i].Draw(g, GetBlockRect(j, i));
            //Рисуем мяч и ракетку
            Ball.Draw(g);
            Paddle.Draw(g);
        }

        public Rectangle GetBlockRect(int x, int y)
        {
            var width = (int)(1f * Bounds.Width / Level.Cells.GetLength(0));
            var height = 15;
            return new Rectangle(x * width, y * height, width, height);
        }
    }
}