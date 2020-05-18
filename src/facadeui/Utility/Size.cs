using System ;

namespace FacadeUI.Utility
{
    public struct Size : IEquatable<Size>
    {
        public float Width ;
        public float Height ;

        public Size(float w, float h)
        {
            Width = w ;
            Height = h ;
        }

    
        public bool Equals(Size other) => Width.Equals(other.Width) && Height.Equals(other.Height);
        public override bool Equals(object obj) => obj is Size p && Equals(p);
        public override string ToString() => $"({Width}, {Height})";
        public override int GetHashCode() => Tuple.Create(Width, Height).GetHashCode();
        public static bool operator == (Size lhs, Size rhs) => lhs.Equals(rhs);
        public static bool operator != (Size lhs, Size rhs) => !lhs.Equals(rhs);
        public static Size operator + (Size lhs, Size rhs) => new Size(lhs.Width + rhs.Width, lhs.Height + rhs.Height) ;
        public static Size operator - (Size lhs, Size rhs) => new Size(lhs.Width - rhs.Width, lhs.Height - rhs.Height) ;
        public static Size operator - (Size rhs) => new Size(-rhs.Width, -rhs.Height) ;
    }
}