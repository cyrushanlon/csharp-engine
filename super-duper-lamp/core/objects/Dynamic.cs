
using System;
using FarseerPhysics;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using SFML.System;

namespace super_duper_lamp.core.objects
{
    public abstract class Dynamic : Drawable
    {
        public Dynamic(string name, string pathToTexture) : base(name, pathToTexture)
        {
            _maxSpeedSqrd = MaxSpeed*MaxSpeed;

            Body = new Body(G.World, new Vector2(0f,0f));
            Body.BodyType = BodyType.Dynamic;
            Body.Friction = 0;
            //Body.Rotation = (float)Math.PI/2;

            Shape = new CircleShape(1, 1);

            Fixture = Body.CreateFixture(Shape);
        }

        public Vector2f Velocity;
        public float AngVelocity;

        private const int MaxAngVelocity = 180;
        private const int MaxSpeed = 0;
        private readonly int _maxSpeedSqrd;

        public Body Body;
        public Shape Shape;
        public Fixture Fixture;

        public override void Think(Time dt)
        {
            base.Think(dt);
            /*
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
                if (speedSquared > _maxSpeedSqrd)
                {
                    var Ratio = Convert.ToSingle(MaxSpeed/Math.Sqrt(speedSquared));

                    Velocity.X *= Ratio;
                    Velocity.Y *= Ratio;
                }
            }

            Rotation += AngVelocity * dt.AsSeconds();

            Position += Velocity * dt.AsSeconds();

            */

            Rotation = (float) (Body.Rotation*(180.0/Math.PI)) + 90;
            Position = new Vector2f(ConvertUnits.ToDisplayUnits(Body.Position.X), ConvertUnits.ToDisplayUnits(Body.Position.Y));
        }
    }
}
