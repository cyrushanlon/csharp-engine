
using System;
using SFML.System;

namespace super_duper_lamp.core.objects
{
    public abstract class Dynamic : Drawable
    {
        public Dynamic(string name, string pathToTexture) : base(name, pathToTexture)
        {
            MaxSpeedSqrd = MaxSpeed*MaxSpeed;
        }

        public Vector2f Velocity;
        public float AngVelocity;

        private const int MaxAngVelocity = 180;
        private const int MaxSpeed = 0;
        private int MaxSpeedSqrd;

        public override void Think(Time dt)
        {
            base.Think(dt);

            //limit angvel to maxangvel
            if (MaxAngVelocity != 0)
            {
                if (AngVelocity > MaxAngVelocity)
                {
                    AngVelocity = MaxAngVelocity;
                }
                else if (AngVelocity < -MaxAngVelocity)
                {
                    AngVelocity = -MaxAngVelocity;
                }
            }

            //limit vel to maxvel
            if (MaxSpeed != 0)
            {
                var speedSquared = Vector2Extended.LengthSquared(Velocity);
                if (speedSquared > MaxSpeedSqrd)
                {
                    var Ratio = Convert.ToSingle(MaxSpeed/Math.Sqrt(speedSquared));

                    Velocity.X *= Ratio;
                    Velocity.Y *= Ratio;
                }
            }

            Rotation += AngVelocity * dt.AsSeconds();

            Position += Velocity * dt.AsSeconds();
        }
    }
}
