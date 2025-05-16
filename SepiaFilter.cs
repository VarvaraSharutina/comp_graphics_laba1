using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltersLab
{
    class SepiaFilter: Filters // сепия
    {
        int k = 50;
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y); // получаем цвет исходного пикселя
            int intensity = (int)(0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B); // вычисляем яркость пикселя по формуле
            // это стандартный способ перевода цветого изображения в оттенки серого
            return Color.FromArgb(
                Clamp((int)(intensity + 2*k), 0, 255), // усиливаем 
                Clamp((int)(intensity + 0.5*k), 0, 255), // усиливаем 
                Clamp((int)(intensity-k), 0, 255) // уменьшаем
                );
        }
    }
}
