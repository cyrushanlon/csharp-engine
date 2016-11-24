using System;
using SFML.System;

namespace super_duper_lamp.core.objects
{
    public class Static : Drawable
    {
        public Static(int id, string pathToTexture, Vector2f Pos) : base(id, "static", pathToTexture)
        {
            Position = Pos;
        }
    }
}
