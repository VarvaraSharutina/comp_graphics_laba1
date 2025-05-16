using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace FiltersLab
{
    class GlassFilter: Filters // эффект стекла (добавляет случайный шум в изображение)
    {
        Random rand = new Random(); // создаем объект класса Random для генерации случайных чисел
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            // rand.NextDouble() возвращает число от 0 д 1
            // получаем сдвиг по х и у на +-5
            int newX = (int)(x + (rand.NextDouble() - 0.5) * 10);
            int newY = (int)(y + (rand.NextDouble() - 0.5) * 10);

            Color pixelColor = sourceImage.GetPixel(x, y); // получаем цвет пикселя из исходного изображения
            if ((newX >= 0 && newX < sourceImage.Width) && (newY >= 0 && newY < sourceImage.Height)) // проверка, не вышла ли случайная точка за пределы изображения 
            {
                pixelColor = sourceImage.GetPixel(newX, newY);
            }
            return pixelColor;
        }
    }
}
