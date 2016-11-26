using System;
using SFML.System;
using SFML.Window;

namespace super_duper_lamp.core.objects
{
    public class Player : Dynamic
    {
        private bool _wDown;
        private bool _sDown;
        private bool _aDown;
        private bool _dDown;

        private const int Acceleration = 200; //per second per second
        private const float AngAcceleration = 90;//per second per second

        public Player(string name, string pathToTexture) : base(name, pathToTexture)
        {
            _wDown = false;
        }

        public virtual void Input(object sender, KeyEventArgs e, bool up)
        {
            if (e.Code.Equals(Keyboard.Key.W))
            {
                _wDown = up;
            }
            else if (e.Code.Equals(Keyboard.Key.S))
            {
                _sDown = up;
            }
            else if (e.Code.Equals(Keyboard.Key.A))
            {
                _aDown = up;
            }
            else if (e.Code.Equals(Keyboard.Key.D))
            {
                _dDown = up;
            }
        }

        public override void Think(Time dt)
        {
            if (_aDown && !_dDown)
            {
                //moveVector.X += -MoveSpeed * dt.AsSeconds();
                AngVelocity -= (AngAcceleration * dt.AsSeconds());
            }

            if (_dDown && !_aDown)
            {
                AngVelocity += (AngAcceleration * dt.AsSeconds());
            }

            if (_wDown)
            {
                Velocity += Vector2Extended.Rotate(new Vector2f(0, -Acceleration), Rotation) * dt.AsSeconds();
            }
            else if (_sDown)
            {
                Velocity += Vector2Extended.Rotate(new Vector2f(0, Acceleration), Rotation) * dt.AsSeconds();
            }

            base.Think(dt);
        }
    }
}
