using System;

namespace FacadeUI.Utility
{
    public struct Point : IEquatable<Point>
    {
        public float X;
        public float Y;

        public Point(float x, float y)
        {
            X = x ;
            Y = y ;
        }

        public bool Equals(Point other) => X.Equals(other.X) && Y.Equals(other.Y);
        public override bool Equals(object obj) => obj is Point p && Equals(p);
        public override string ToString() => $"({X}, {Y})";
        public override int GetHashCode() => Tuple.Create(X, Y).GetHashCode();
        public static bool operator == (Point lhs, Point rhs) => lhs.Equals(rhs);
        public static bool operator != (Point lhs, Point rhs) => !lhs.Equals(rhs);
        public static Point operator + (Point lhs, Point rhs) => new Point(lhs.X + rhs.X, lhs.Y + rhs.Y) ;
        public static Point operator - (Point lhs, Point rhs) => new Point(lhs.X - rhs.X, lhs.Y - rhs.Y) ;
        public static Point operator - (Point rhs) => new Point(-rhs.X, -rhs.Y) ;
 
    }
}