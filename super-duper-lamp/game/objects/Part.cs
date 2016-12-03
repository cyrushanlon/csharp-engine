using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using super_duper_lamp.core.objects;
using SFML.System;

namespace super_duper_lamp.game.objects
{
    public class Part : Drawable
    {
        public Part(string name, string pathToTexture, Ship Parent) : base(name, pathToTexture)
        {
            this.Parent = Parent;
            Parent.RotateWithParent = true;
            Sprite.Scale = new Vector2f(0.3f, 0.3f);
        }
    }
}
