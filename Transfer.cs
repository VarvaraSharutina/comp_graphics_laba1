using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltersLab
{
    internal class Transfer : Filters // перенос
    {
        

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int newX = x + 50; // сдвиг вправо на 50 пикселей
            int newY = y; // вертикаль без изменений

            if (newX >= sourceImage.Width || newX < 0 || newY >= sourceImage.Height || newY < 0) // провереям, попадают ли новые координаты в пределы изображения
            {
                return Color.Black; // если нет, то возвращаем черный цвет для областей за границами
            }
            return sourceImage.GetPixel(newX, newY); // получаем цвет из новых координат
        }
    }
}
