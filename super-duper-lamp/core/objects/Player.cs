using SFML.System;
using SFML.Window;

namespace super_duper_lamp.core.objects
{
    public class Player : Drawable
    {
        private bool _wDown;
        private bool _sDown;
        private bool _aDown;
        private bool _dDown;

        private const int MoveSpeed = 500; //per second
        private const float RotSpeed = 90f;//per second

        public Player(int id) : base(id, "player", @"E:\+ 00 + Projects\VS 2013\C#\super-duper-lamp\super-duper-lamp\textures\penios.png")
        {
            _wDown = false;
        }

        public void Input(object sender, KeyEventArgs e, bool up)
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
            var moveVector = new Vector2f(0,0);

            if (_wDown)
            {
                moveVector.Y += -MoveSpeed * dt.AsSeconds();
            }

            if (_sDown)
            {
                moveVector.Y += MoveSpeed * dt.AsSeconds();
            }

            if (_aDown)
            {
                //moveVector.X += -MoveSpeed * dt.AsSeconds();
                Rotation = Rotation - (RotSpeed * dt.AsSeconds());
            }

            if (_dDown)
            {
                Rotation = Rotation + (RotSpeed * dt.AsSeconds());
            }

            Position += Vector2Extended.Rotate(moveVector, Rotation);
        }
    }
}
