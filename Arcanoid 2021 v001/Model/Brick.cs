using System;
using System.Drawing;
using Arcanoid_2021_v001.Model;

namespace Arcanoid_2021_v001
{
    /// <summary>
    /// Блок
    /// </summary>
    public class Brick
    {
        //Поля
        /// <summary>
        /// Разрушаем ли блок?
        /// </summary>
        public virtual bool IsBreackable { get; set; }

        //Конструкторы
        public Brick()
        {
            IsBreackable = true;
        }

        //Методы
        public virtual void Draw(Graphics g, Rectangle rect)
        {
            g.FillRectangle(Brushes.Brown, rect);
            g.DrawRectangle(Pens.Black, rect);
        }

        public virtual void OnHit(int x, int y, Game game)
        {
            if (IsBreackable)
            {
                game.Level.Cells[x, y] = null; //удаляем разбитый блок
            }
        }
    }
}
