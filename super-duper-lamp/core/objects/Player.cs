using System;
using SFML.System;
using SFML.Window;

namespace super_duper_lamp.core.objects
{
    public class Player : Dynamic
    {
        public bool WDown;
        public bool SDown;
        public bool ADown;
        public bool DDown;

        private const int Acceleration = 200; //per second per second
        private const float AngAcceleration = 90;//per second per second

        public Player(string name, string pathToTexture) : base(name, pathToTexture)
        {
            WDown = false;
        }

        public virtual void Input(object sender, KeyEventArgs e, bool up)
        {
            if (e.Code.Equals(Keyboard.Key.W))
            {
                WDown = up;
            }
            else if (e.Code.Equals(Keyboard.Key.S))
            {
                SDown = up;
            }
            else if (e.Code.Equals(Keyboard.Key.A))
            {
                ADown = up;
            }
            else if (e.Code.Equals(Keyboard.Key.D))
            {
                DDown = up;
            }
        }

        public override void Think(Time dt)
        {
            /*
            if (_aDown && !_dDown)
            {
                //moveVector.X += -MoveSpeed * dt.AsSeconds();
                AngVelocity -= AngAcceleration * dt.AsSeconds();
            }

            if (_dDown && !_aDown)
            {
                AngVelocity += AngAcceleration * dt.AsSeconds();
            }

            if (_wDown)
            {
                Velocity += Vector2Extended.Rotate(new Vector2f(0, -Acceleration), Rotation) * dt.AsSeconds();
            }
            else if (_sDown)
            {
                Velocity += Vector2Extended.Rotate(new Vector2f(0, Acceleration), Rotation) * dt.AsSeconds();
            }

            */

            base.Think(dt);
        }
    }
}