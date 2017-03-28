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

            var ship = (Ship) Parent;

            if (ship.MouseLDown)
            {
                var mousePos = Mouse.GetPosition(core.G.Window) -
                               new Vector2i((int) core.G.Window.Size.X/2, (int) core.G.Window.Size.Y/2);
                var targetRad = (float) (Math.Atan2(mousePos.Y, mousePos.X)); // + (Math.PI/2));
                var currentRad = ship.Body.Rotation; // / (Math.PI * 2));
                var currentAngVel = ship.Body.AngularVelocity;

                //find the required rotation as a fraction of 1
                //var targetRadRatio = (currentRad - targetRad) - (float)(Math.PI / 2);
                //if (targetRadRatio < -Math.PI)
                //{
                //    targetRadRatio = targetRadRatio + (float)Math.PI*2;
                //}

                //check if we add the new vel we will overshoot
                //then slam on reverse and we should nicely level out at target
                Console.WriteLine(targetRad - currentRad);
                if (Math.Abs(targetRad - currentRad) < 0.0005 && currentAngVel < 0.05)
                {
                    ship.Body.AngularVelocity = 0;
                    ship.Body.Rotation = targetRad;
                }
                else
                {
                    var timeToTarget = Math.Abs((targetRad - currentRad)/currentAngVel);
                    var timeToDecelerate = Math.Abs(currentAngVel/ship.MaxAngularAcceleration);

                    //Console.WriteLine(timeToTarget);

                    //find if angle is to the left or the right of the currentangle (needs to account for -180 to 180)
                    bool isLeft = targetRad < currentRad;
                    var dirMult = -1;
                    if (isLeft)
                        dirMult = 1;

                    //ship rotate
                    //will we overshoot?
                    if (timeToTarget >= timeToDecelerate)
                    {
                        //check if we can add a tiny bit more acceleration this tick and if so do so then deccelerate if we cant then just do nothing
                        ship.Body.AngularVelocity -= (ship.MaxAngularAcceleration*dt.AsSeconds()*dirMult);
                    }
                    else // we will not overshoot if we add the full acceleration
                    {
                        ship.Body.AngularVelocity += (ship.MaxAngularAcceleration*dt.AsSeconds()*dirMult);
                    }

                    //ship.Body.ApplyAngularImpulse(ship.MaxAngularAcceleration * -targetRadRatio * dt.AsSeconds());

                    //Parent.Rotation = (float)(angleRad * (180 / Math.PI));
                    //ship.Body.Rotation = angleRad;
                }
            }
            base.Think(dt);
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
