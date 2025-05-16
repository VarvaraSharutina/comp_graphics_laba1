using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltersLab
{
    class GrayScaleFilter: Filters // чб
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y); // получаем цвет исходного пикселя
            int intensity = (int)(0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B); // вычисляем яркость пикселя по формуле
            // это стандартный способ перевода цветого изображения в оттенки серого
            return Color.FromArgb( 
                Clamp(intensity, 0, 255), // функция clamp приводит значение к допустимому диапозону
                Clamp(intensity, 0, 255),
                Clamp(intensity, 0, 255)
                ); // создаем новый цвет с одинаковыми значениями R, G, B (оттенок серого)
        }
    }
}
