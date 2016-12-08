using FarseerPhysics;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using SFML.Graphics;
using SFML.Window;

namespace super_duper_lamp.core
{
    public static class Global
    {
        public static RenderWindow W { get; set; }
        public static World World { get; set; }

        public static void Create(VideoMode VidMode, string Title)
        {
                W = new RenderWindow(VidMode, Title);
                World = new World(new Vector2(0f,0f));
                ConvertUnits.SetDisplayUnitToSimUnitRatio(64f);
        }
    }
}
