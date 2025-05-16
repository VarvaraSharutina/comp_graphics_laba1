using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltersLab
{
    class InvertFilter: Filters // инверсия
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y); // получаем цвет исходного пикселя (color хранит значение цвета в формате RGB, каждое от 0 до 255)
            return Color.FromArgb(255 - sourceColor.R,
                                  255 - sourceColor.G,
                                  255 - sourceColor.B); // вычисляем инверсию и возвращаем результат                                   
        }
    }
}
