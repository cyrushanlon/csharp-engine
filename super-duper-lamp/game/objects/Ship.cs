using System.Collections.Generic;
using super_duper_lamp.core.objects;
using SFML.System;

namespace super_duper_lamp.game.objects
{
    public class Ship : Player
    {
        private Engine Eng;

        public Ship(string name, string pathToTexture) : base(name, pathToTexture)
        {
            Eng = new Engine("textures/penios.png", this);
        }

        public override void Think(Time dt)
        {
            Eng.Think(dt);

            base.Think(dt);
        }
    }
}
