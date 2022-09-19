using System;

namespace ShapesLib
{
    public abstract class Shape
    {
        public Vertex[] Vertices { get; protected set; }
        public string Type { get; protected set; } = "Default";

        public Shape(Vertex[] vertices)
        {
            Vertices = vertices;
        }

        public abstract double GetArea(); // Получить площадь фигуры
    }

    public class Circle : Shape
    {
        protected double radius;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertices">Первая([0]) вершина - центр окружности. Растояние между первой([0]) и второй([1]) вершинами массива есть радиус окружности</param>
        public Circle(Vertex[] vertices) : base(vertices)
        {
            Vertices = new Vertex[] { vertices[0], vertices[1] };
            radius = Tools.Distance(Vertices[0], Vertices[1]);
            Type = "Circle";
        }

        public override double GetArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }
    }

    public class Triangle : Shape
    {
        protected double[] sides;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertices">Используются только первые три вершины массива ([0],[1],[2])</param>
        public Triangle(Vertex[] vertices) : base(vertices)
        {
            Vertices = new Vertex[] { vertices[0], vertices[1], vertices[2] };
            sides = new double[] { Tools.Distance(Vertices[0], Vertices[1]), Tools.Distance(Vertices[1], Vertices[2]), Tools.Distance(Vertices[2], Vertices[0]) };
            SetType();
        }

        public override double GetArea()
        {
            double p = (sides[0] + sides[1] + sides[2]) / 2; // полупериметр
            return Math.Sqrt(p * (p - sides[0]) * (p - sides[1]) * (p - sides[2]));
        }

        protected void SetType()
        {
            int c = 0; // индекс гипотенузы по умолчанию
            int a = 1, b = 2;  // индексы катетов по умолчанию

            double max = Math.Max(sides[c], Math.Max(sides[a], sides[b])); // Поиск саммой длинной стороны

            if (max == sides[1])
            {
                c = 1;
                a = 0;
            }

            if (max == sides[2])
            {
                c = 2;
                b = 0;
            }

            if ((int)Math.Floor(Math.Pow(sides[c], 2) * 10000) == (int)Math.Floor(Math.Pow(sides[a], 2) * 10000) + (int)Math.Floor(Math.Pow(sides[b], 2) * 10000))
                Type = "Right triangle";
            else
                Type = "Triangle";

        }
    }
}
