using System;
using super_duper_lamp.core.objects;
using SFML.System;
using SFML.Window;


namespace super_duper_lamp.game.objects
{
    class Steering : Part
    {
        public Steering(string pathToTexture, Ship Parent) : base("steering", pathToTexture, Parent)
        {
            Sprite.Scale =new Vector2f(0.1f, 0.1f);
        }

        public override void Think(Time dt)
        {
            //tween angular velocity so that the movement is smooth and more difficult to 360, takes a time for vel to catch up

            var ship = ((Ship) Parent);

            if (ship.MouseLDown)
            {
                var mousePos = Mouse.GetPosition(core.G.Window) - new Vector2i((int)core.G.Window.Size.X / 2, (int)core.G.Window.Size.Y / 2);
                var targetRad = (float) (Math.Atan2(mousePos.Y, mousePos.X));// + (Math.PI/2));
                var currentRad = ship.Body.Rotation;// / (Math.PI * 2));
               
                //find the required rotation as a fraction of 1
                var targetRadRatio = (currentRad - targetRad) - (float)(Math.PI / 2);
                if (targetRadRatio < -Math.PI)
                {
                    targetRadRatio = targetRadRatio + (float)Math.PI*2;
                }

                //ask the ship to rotate
                ship.Body.ApplyTorque(ship.MaxAngularAcceleration * -targetRadRatio);

                //Parent.Rotation = (float)(angleRad * (180 / Math.PI));
                //ship.Body.Rotation = angleRad;
            }

            base.Think(dt);
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
