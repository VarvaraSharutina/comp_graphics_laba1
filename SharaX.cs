using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltersLab
{
    class SharaX: MatrixFilter // выделение границ по Х
    {
        public SharaX()
        {
            kernel = new float[,] {
                // оператор Щарра
                {3.0f, 0.0f, -3.0f},
                {10.0f, 0.0f, -10.0f},
                {3.0f, 0.0f, -3.0f}
            };
        }
    }
}
// фильтр обнаруживает вертикальные границы (перепады яркости слева направо)
// матрица усиливает резкие изменения яркости
// если слева темнее, справа светлее - получится положительное значение, яркий пиксель
// если наоборот - отрицательное значение, темный пиксель
// слабый отклик на горизонтальные/однородные области
