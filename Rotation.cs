using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltersLab
{
    internal class Rotation : Filters // поворот
    {
        private int x0, y0; // центр поворота
        private float angle; // угол поворота в радианах

        public Rotation(float angle, Image image)
        {
            this.x0 = image.Width / 2; // центр по горизонтали
            this.y0 = image.Height / 2; // центр по вертикали
            this.angle = angle * (float)Math.PI / 180; // преобразуем угол из градусов в радианы
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int k, int l)
        {
            // применяем формулы поворота
            int x = (int)((k - x0) * Math.Cos(angle) - (l - y0) * Math.Sin(angle) + x0);
            int y = (int)((k - x0) * Math.Sin(angle) + (l - y0) * Math.Cos(angle) + y0);

            if (x >= sourceImage.Width || x < 0 || y >= sourceImage.Height || y < 0) // провереям, попадают ли новые координаты в пределы изображения
            {
                return Color.Black; // если нет, то возвращаем черный цвет для областей за границами
            }
            return sourceImage.GetPixel(x, y);
        }
    }

}
