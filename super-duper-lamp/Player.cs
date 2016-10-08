using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;

namespace super_duper_lamp
{
    public class Player : Drawable
    {
        private bool _wDown;
        private bool _sDown;
        private bool _aDown;
        private bool _dDown;

        private int _moveSpeed = 500;

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
            Vector2f MoveVector = new Vector2f(0,0);

            if (_wDown)
            {
                MoveVector.Y += -_moveSpeed * dt.AsSeconds();
            }

            if (_sDown)
            {
                MoveVector.Y += _moveSpeed * dt.AsSeconds();
            }

            if (_aDown)
            {
                MoveVector.X += -_moveSpeed * dt.AsSeconds();
            }

            if (_dDown)
            {
                MoveVector.X += _moveSpeed * dt.AsSeconds();
            }

            sprite.Position += MoveVector;
        }
    }
}
