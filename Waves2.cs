using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltersLab
{// каждый пискель сдвигается по вертикали на величину, пропорциональную sin(y)
    class Waves2 : Filters // волны 2
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int k, int l)
        {
            int newX = k; // Х остается неизменным
            int newY = Clamp(l + (int)(20 * Math.Sin(Math.PI * k /30)), 0, sourceImage.Height - 1); // каждый пиксель (k, l) получает новую координат У (получаем смещение по вертикали)

            Color pixelColor = sourceImage.GetPixel(k, l); // получаем цвет исходного пикселя
            if ((newX >= 0 && newX <= sourceImage.Width) && (newY >= 0 && newY <= sourceImage.Height)) // проверяем, находится ли newX и newY внутри изображения
            {
                pixelColor = sourceImage.GetPixel(newX, newY); // если newX и newY находятся в пределах изображения, то цвет берется из нового места 
            }
            return pixelColor;
        }

    }
}
