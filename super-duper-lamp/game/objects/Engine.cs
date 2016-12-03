using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using super_duper_lamp.core.objects;
using SFML.System;

namespace super_duper_lamp.game.objects
{
    public class Engine:Part
    {
        public Engine(string pathToTexture, Ship Parent) : base("engine", pathToTexture, Parent)
        {
        }

        private float _acceleration = -50; //pixels/s
        private float _restingRotation = 0;
        private bool _vectoringOn = true;
        private Vector2f _vectoringMinMax = new Vector2f(-30, 30);

        public override void Think(Time dt)
        {
            if (_vectoringOn)
            {
                if (((Player)Parent).ADown)
                {// -
                    Rotation = _vectoringMinMax.X;
                }
                else if (((Player) Parent).DDown)
                {// +
                    Rotation = _vectoringMinMax.Y;
                }
                else
                {
                    Rotation = _restingRotation;
                }
            }

            ((Ship)Parent).Velocity += Vector2Extended.Rotate(new Vector2f(0, -_acceleration), Rotation) * dt.AsSeconds();
            base.Think(dt);
        }
    }
}
