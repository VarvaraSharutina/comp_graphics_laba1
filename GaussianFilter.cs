using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltersLab
{
    class GaussianFilter : MatrixFilter // размытие по Гауссу
    {
        public void createGaussianKernel(int radius, int sigma) //создам Гауссво ядро и нормализуем его
        {
            int size = 2 * radius + 1; // размер ядра
            kernel = new float[size, size]; //ядро фильтра
            float norm = 0; // коэффициент нрмировки ядра
            // расчитываем ядро фильтра
            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    kernel[i + radius, j + radius] = (float)Math.Exp(-(i * i + j * j) / (2 * sigma * sigma)); // для каждой позиции вычисляем значение двумерной ф-ии Гаусса
                    // это даёт веса, которые максимльны в центре и уменьшаются к краям
                    norm += kernel[i + radius, j + radius]; // все значения суммируем для последующей нормализации
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    kernel[i, j] /= norm; // делим все эл-ты матрицы на сумму (чтобя не измени общую яркость изображения после фильтрации)
                }
            }
        }

        public GaussianFilter()
        {
            createGaussianKernel(3, 2);
        }
    }
}
