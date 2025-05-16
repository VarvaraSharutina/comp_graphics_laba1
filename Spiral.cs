using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

using System.ComponentModel;

namespace FiltersLab
{
    class Spiral : Filters
    {
        private int centerX;
        private int centerY;
        private int spiralRadius;
        private int spiralTurns;
        private int thickness;

        public Spiral() : this(0, 0, 100, 5, 3) { }

        public Spiral(int centerX, int centerY, int spiralRadius, int spiralTurns, int thickness)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.spiralRadius = spiralRadius;
            this.spiralTurns = spiralTurns;
            this.thickness = thickness;
        }

        public Bitmap SpiralProcessImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            // Если центр не установлен, устанавливаем в середину изображения
            if (centerX == 0) centerX = sourceImage.Width / 2;
            if (centerY == 0) centerY = sourceImage.Height / 2;
            if (spiralRadius == 100) spiralRadius = Math.Min(sourceImage.Width, sourceImage.Height) / 2;

            int totalPixels = sourceImage.Width * sourceImage.Height;
            int pixelsProcessed = 0;
            int updateInterval = totalPixels / 100;

            for (int y = 0; y < sourceImage.Height; y++)
            {
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    if (worker != null && worker.CancellationPending)
                    {
                        return null;
                    }

                    resultImage.SetPixel(x, y, calculateNewPixelColor(sourceImage, x, y));

                    pixelsProcessed++;
                    if (worker != null && pixelsProcessed % updateInterval == 0)
                    {
                        int progressPercentage = pixelsProcessed * 100 / totalPixels;
                        worker.ReportProgress(progressPercentage);
                    }
                }
            }

            if (worker != null)
            {
                worker.ReportProgress(100);
            }

            return resultImage;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            // Вычисляем полярные координаты
            double dx = x - centerX;
            double dy = y - centerY;
            double distance = Math.Sqrt(dx * dx + dy * dy);
            double angle = Math.Atan2(dy, dx);

            // Нормализуем угол
            if (angle < 0) angle += 2 * Math.PI;

            // Проверяем принадлежность к спирали
            if (IsPixelOnSpiral(distance, angle))
            {
                return Color.Red;
            }

            return sourceImage.GetPixel(x, y);
        }

        private bool IsPixelOnSpiral(double distance, double angle)
        {
            // Основной виток спирали
            double spiralDistance = spiralRadius * angle / (2 * Math.PI * spiralTurns);
            if (Math.Abs(distance - spiralDistance) <= thickness)
                return true;

            // Следующий виток спирали (угол + 2π)
            spiralDistance = spiralRadius * (angle + 2 * Math.PI) / (2 * Math.PI * spiralTurns);
            if (Math.Abs(distance - spiralDistance) <= thickness)
                return true;

            // Предыдущий виток спирали (угол - 2π)
            spiralDistance = spiralRadius * (angle - 2 * Math.PI) / (2 * Math.PI * spiralTurns);
            if (Math.Abs(distance - spiralDistance) <= thickness)
                return true;

            return false;
        }
    }
}
