using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltersLab
{
    class BlurFilter: MatrixFilter // размытие
    {
        public BlurFilter()
        {
            int sizeX = 5; // задаем значения ядра свертки: 5х5 (это означает, что при обработке каждого пикселя будет учитываться его окрестность 5х5 пикселей)
            int sizeY = 5;

            kernel = new float[sizeX, sizeY]; // создаем матрицу ядра свертки 5х5, заполняя её одинаковыми значениями 0.04
            for(int i = 0; i < sizeX; ++i)
            {
                for(int j = 0; j < sizeY; ++j)
                {
                    kernel[i, j] = 1.0f / (float)(sizeX * sizeY);
                }
                // при вычислении цвета каждого пикселя используем среднее значение его соседей
            }
        }
    }
}
