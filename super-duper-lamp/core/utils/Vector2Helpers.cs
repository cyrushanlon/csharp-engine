
using System;
using SFML.Graphics;
using SFML.System;

namespace super_duper_lamp
{
    public static class Vector2Extended
    {
        public static Vector2f Rotate(Vector2f vec, float rotation)
        {
            var radians = (Math.PI / 180) * rotation;

            var ca = Math.Cos(radians);
            var sa = Math.Sin(radians);

            return new Vector2f(Convert.ToSingle(ca * vec.X - sa * vec.Y), Convert.ToSingle(sa * vec.X + ca * vec.Y));
        }

        public static double LengthSquared(Vector2f vec)
        {
            return (vec.X*vec.X) + (vec.Y*vec.Y);
        }

        public static double Length(Vector2f vec)
        {
            return Math.Sqrt((vec.X * vec.X) + (vec.Y * vec.Y));
        }

        public static Vector2f Normalize(Vector2f vec)
        {
            var length = Convert.ToSingle(Math.Sqrt((vec.X*vec.X) + (vec.Y*vec.Y)));
            return length != 0 ? new Vector2f(vec.X / length, vec.Y / length) : vec;
        }
    }
}
