using System.Collections.Generic;
using super_duper_lamp.core.objects;
using SFML.System;

namespace super_duper_lamp.game.objects
{
    public class Ship : Player
    {
        private Engine Eng1;
        private Engine Eng2;
        private Steering Steer;

        public Ship(string name, string pathToTexture) : base(name, pathToTexture)
        {
            Eng1 = new Engine("textures/penios.png", this);
            Eng1.Position = new Vector2f(50, 50);
            Eng2 = new Engine("textures/penios.png", this);
            Eng2.Position = new Vector2f(-50, 50);

            Steer = new Steering("textures/penios.png", this);
            Sprite.Scale = new Vector2f(0.5f, 0.5f);
        }

        public override void Think(Time dt)
        {
            Eng1.Think(dt);
            Eng2.Think(dt);

            base.Think(dt);
        }
    }
}
