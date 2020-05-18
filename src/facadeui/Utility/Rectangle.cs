using System;

namespace FacadeUI.Utility
{
    public struct Rectangle : IEquatable<Rectangle>
    {
        public float X ;
        public float Y ;
        public float Width;
        public float Height ;

        public Point Position => new Point(X, Y);
        public Size Size => new Size(Width, Height);
        public float Left => X ;
        public float Right => X + Width;
        public float Top => Y + Height;
        public float Bottom => Y;
        public Point Center => new Point(X+(Width/2.0f), Y+(Height/2.0f)) ;

        public override bool Equals(object obj) => obj is Rectangle r && Equals(r);
        public bool Equals(Rectangle r) => X == r.X && Y == r.Y && Width == r.Width && Height == r.Height;
        public static bool operator == (Rectangle lhs, Rectangle rhs) => lhs.Equals(rhs);
        public static bool operator != (Rectangle lhs, Rectangle rhs) => !lhs.Equals(rhs);

        public override int GetHashCode()
        {
            return Tuple.Create(X,Y,Width,Height).GetHashCode() ;
        }

        public bool Contains(Point pt)
        {
            Point test = pt - Position ;

            return (test.X >= 0.0f) && (test.X < Width)
                && (test.Y >= 0.0f) && (test.Y < Height);
        }

        public bool Intersects(Rectangle r)
        {
            bool x_check = Left > r.Right || r.Left > Right ;
            bool y_check = Bottom > r.Top || r.Top > Bottom ;

            return !(x_check && y_check) ;
        }
    }
}