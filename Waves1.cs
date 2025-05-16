using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltersLab
{// каждый пискель сдвигается по горизонтали на величину, пропорциональную sin(y)
    class Waves1: Filters // волны 1
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int k, int l)
        {
            int newX = Clamp(k + (int)(20 * Math.Sin(2 * Math.PI * l / 60)), 0, sourceImage.Width - 1); // каждый пиксель (k, l) получает новую координат Х (получаем смещение по горизонтали)
            int newY = l; // У остается неизменным

            Color pixelColor=sourceImage.GetPixel(k, l); // получаем цвет исходного пикселя
            if ((newX >= 0 && newX <= sourceImage.Width) && (newY >= 0 && newY <= sourceImage.Height)) // проверяем, находится ли newX и newY внутри изображения
            {
                pixelColor = sourceImage.GetPixel(newX, newY); // если newX и newY находятся в пределах изображения, то цвет берется из нового места 
            }
            return pixelColor;
        }
        
    }
}
