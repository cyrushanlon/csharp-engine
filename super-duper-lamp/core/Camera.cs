using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace super_duper_lamp.core
{
    class Camera
    {
        private View _view;
        private bool _qDown = false;
        private bool _eDown = false;
        private int _rotSpeed = 45;

        public objects.Drawable Target { get; set; }

        public Camera()
        {
            _view = new View(new Vector2f(0, 0), new Vector2f(1920, 1080));
            _view.Zoom(2f);
        }

        public void UseCamera()
        {
            Global.W.SetView(_view);
        }

        public void Input(object sender, KeyEventArgs e, bool up)
        {
            if (e.Code.Equals(Keyboard.Key.Q))
            {
                _qDown = up;
            }
            else if (e.Code.Equals(Keyboard.Key.Q))
            {
                _eDown = up;
            }
        }

        public void Think(Time dt)
        {
            if (Target != null)
            {
                _view.Center = Target.Position;
            }

            if (_qDown && !_eDown)
            {
                _view.Rotation = _view.Rotation - (_rotSpeed*dt.AsSeconds());
            }
            else if (_eDown && !_qDown)
            {
                _view.Rotation = _view.Rotation + (_rotSpeed*dt.AsSeconds());
            }
        }
    }
}
