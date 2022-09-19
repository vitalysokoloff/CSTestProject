using System;

namespace ShapesLib
{
    public static class Tools
    {
        public static double Distance(Vertex a, Vertex b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }

    }
}
