using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltersLab
{
    class SobelXFilter: MatrixFilter // фильтр Собеля Х (выделяет вертикальные границы на изображении)
    {
        public SobelXFilter()
        {
            kernel = new float[,] {
                // оператор Собеля (вычисчляем градиент по оси Х)
                {-1.0f, 0.0f, 1.0f},
                {-2.0f, 0.0f, 2.0f},
                {-1.0f, 0.0f, 1.0f}
            };
        }
    }
}
// фильтр "чувствует" перепады яркости слева направо
// чем резче переход, тем сильнее отклик
