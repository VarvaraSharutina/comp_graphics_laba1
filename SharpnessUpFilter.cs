using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltersLab
{
    class SharpnessUpFilter: MatrixFilter // увеличение резкости
    {
        public SharpnessUpFilter()
        {
            kernel = new float[,] {

                { 0.0f, -1.0f, 0.0f}, // центральный пиксель умножаем на 5.0 (усиление своего собственного значения)
                { -1.0f, 5.0f, -1.0f}, // 4 ближайших соседа умножаем на -1.0 (вычитается их влияние)
                { 0.0f, -1.0f, 0.0f} // диагональняе пиксели игнорируем
                // общая яркость изображения сохраняется, но контраст между центром и краями усиливается
            };
        }
    }
}
// для каждого пикселя вычисляем новое значение = 5.0 * текущий_пиксель -1.0 * верхний_сосед- 1.0 * нижний_сосед- 1.0 * левый_сосед- 1.0 * правый_сосед
