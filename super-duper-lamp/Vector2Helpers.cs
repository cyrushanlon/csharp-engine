
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
    }
}
