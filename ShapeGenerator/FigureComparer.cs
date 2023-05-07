using ShapeGenerator.Shapes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeGenerator
{
    public class FigureComparer : IComparer<Shape>
    {
        public int Compare(Shape x, Shape y)
        {
            string textX = x.ToString();
            string textY = y.ToString();

            // Разделение названия фигуры и номера
            string[] partsX = textX.Split(' ');
            string[] partsY = textY.Split(' ');

            string figureX = partsX[0];
            string figureY = partsY[0];

            int numberX = int.Parse(partsX[1]);
            int numberY = int.Parse(partsY[1]);

            // Сравнение названия фигуры
            int compareFigure = string.Compare(figureX, figureY, StringComparison.Ordinal);
            if (compareFigure != 0)
                return compareFigure;

            // Сравнение номера фигуры
            return numberX.CompareTo(numberY);
        }
    }
}
