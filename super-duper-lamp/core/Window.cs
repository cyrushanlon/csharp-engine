using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace super_duper_lamp.core
{
    public static class Window
    {
        public static RenderWindow W { get; set; }

        public static void Create(VideoMode VidMode, string Title)
        {
               W = new RenderWindow(VidMode, Title);
        }
    }
}
