using System;
using FarseerPhysics;
using Microsoft.Xna.Framework;
using super_duper_lamp.core.objects;
using super_duper_lamp.core.utils;
using SFML.System;

namespace super_duper_lamp.game.objects
{
    public class Engine:Part
    {
        public Engine(string pathToTexture, Ship Parent) : base("engine", pathToTexture, Parent)
        {
        }

        private float _acceleration = 2000; //pixels/s/s
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
            
            if (((Player) Parent).WDown)
            {
                var force = new Vector2f(0, -_acceleration * dt.AsSeconds());
                force = Vector2Extended.Rotate(force, Parent.Rotation + Rotation);

                ((Dynamic) Parent).Body.ApplyForce(Vector2Extended.SFMLToXNA(force), ConvertUnits.ToSimUnits(Vector2Extended.SFMLToXNA(Sprite.Position)));
            }
            //((Ship)Parent).Velocity -= Vector2Extended.Rotate(new Vector2f(0, _acceleration), Rotation + Parent.Rotation) * dt.AsSeconds();

            base.Think(dt);
        }
    }
}
