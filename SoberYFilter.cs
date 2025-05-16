using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltersLab
{
    class SobelYFilter : MatrixFilter // фильтр Собеля У (выделяет горизонтальные границы на изображении)
    {
        public SobelYFilter()
        {
            kernel = new float[,] {
                // оператор Собеля (вычисчляем градиент по оси Х)
                {-1.0f, -2.0f, 1.0f},
                {0.0f, 0.0f, 0.0f},
                {1.0f, 2.0f, 1.0f}
            };
        }
    }
}
// фильтр "чувствует" перепады яркости сверху вниз
// чем резче переход, тем сильнее отклик