using System;
using System.Collections.Generic;
using super_duper_lamp.core;
using super_duper_lamp.core.objects;
using super_duper_lamp.core.utils;
using SFML.Graphics;
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
            Eng1.Position = new Vector2f(150, 50);
            Eng2 = new Engine("textures/penios.png", this);
            Eng2.Position = new Vector2f(-150, 50);

            Steer = new Steering("textures/penios.png", this);
            Sprite.Scale = new Vector2f(0.5f, 0.5f);
        }

        public override void Think(Time dt)
        {
            Eng1.Think(dt);
            Eng2.Think(dt);

            base.Think(dt);
        }

        public override void Draw()
        {
            base.Draw();           

            var line = new Vertex[2];
            line[0] = new Vertex(Position, Color.Red);
            line[1] = new Vertex(Position + (Vector2Extended.XNAToSFML(Body.LinearVelocity) * 5), Color.Cyan);

            G.Window.Draw(line, 0, 2, PrimitiveType.Lines);
        }
    }
}
