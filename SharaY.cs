using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltersLab
{
    class SharaY: MatrixFilter // выделение границ по У
    {
        public SharaY()
        {
            kernel = new float[,] {
                // оператор Щарра
                {3.0f, 10.0f, 3.0f},
                {0.0f, 0.0f, 0.0f},
                {-3.0f, -10.0f, -3.0f}
            };
        }
    }
}
// фильтр обнаруживает горизонтальные границы (перепады яркости сверху вниз)
// матрица усиливает резкие изменения яркости
// если сверху темнее, снизу светлее - получится положительное значение, яркий пиксель
// если наоборот - отрицательное значение, темный пиксель
// слабый отклик на вертикальные/однородные области