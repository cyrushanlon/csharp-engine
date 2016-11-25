using System;
using SFML.System;

namespace super_duper_lamp.core.objects
{
    public class Static : Drawable
    {
        public Static(string pathToTexture, Vector2f pos) : base("static", pathToTexture)
        {
            Position = pos;
        }
    }
}
