using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcanoid_2021_v001.Model;

namespace Arcanoid_2021_v001
{
    /// <summary>
    /// Уровень игры
    /// </summary>
    public class Level
    {
        //Поля
        public Brick[,] Cells { get; set; }
        //Методы
        public static Level Parse(string inputStr)
        {
            var result = new Level();
            var lines = inputStr.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            result.Cells = new Brick[lines[0].Length, lines.Length];
            for (int i = 0; i < lines.Length; i++)
                for (int j = 0; j < lines[0].Length; j++)
                    switch (lines[i][j])
                    {
                        case '1':
                            result.Cells[j, i] = new Brick();
                            break;
                        case '2':
                            //Золотой блок
                            result.Cells[j, i] = new GoldBrick();
                            break;
                    }
            return result;
        }
    }
}
