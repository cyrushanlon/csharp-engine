using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace super_duper_lamp.game.objects
{
    public class Gyroscope : Part
    {
        private float maxRotationForce = 0.2f; //rad/second
        private float desiredAngle = 0; //the target angle in radians as should be set by the ship steering controller?

        public Gyroscope(string name, string pathToTexture, Ship parent) : base(name, pathToTexture, parent)
        {

        }

        public override void Think(Time dt)
        {
            //Apply force to set the current angle to the desired angle
            var physBody = ((Ship) Parent).Body;      
            var currentAngle = physBody.Rotation;
            var deltaAngle = desiredAngle - currentAngle;
            var angularVelocity = physBody.AngularVelocity;

            //physBody.ApplyTorque();

            base.Think(dt);
        }
    }
}
