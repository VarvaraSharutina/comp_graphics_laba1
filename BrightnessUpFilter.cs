using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltersLab
{
    class BrightnessUpFilter: Filters // увеличение яркости
    {
        int k = 40; // значение, определяющее, насколько мы увеличим яркость
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y); // получаем цвет исходного пикселя
            return Color.FromArgb( // к каждому цветовому каналу прибавляем одно и то же значение k, тем самым увеличивая яркость
                Clamp(sourceColor.R + k, 0, 255),
                Clamp(sourceColor.G + k, 0, 255),
                Clamp(sourceColor.B + k, 0, 255)
                );
        }
    }
}
