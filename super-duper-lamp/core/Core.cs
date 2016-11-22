using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace super_duper_lamp.core
{
    public static class Core
    {
        private static List<Entity> _entities;

        private static void Think(Time dt)
        {
            foreach (var e in _entities)
            {
                e.Think(dt);
            }
        }

        private static void Draw(RenderWindow window)
        {
            foreach (var e in _entities)
            {
                try // prob slow to use a try catch but whatever
                {
                    Drawable ent = (Drawable) e;

                    ent.Draw(window);
                }
                catch (Exception)
                {
                    //Console.WriteLine("Not a drawable.");
                }
            }
        }

        private static void OnClose(object sender, EventArgs e)
		{
			// Close the window when OnClose event is received
			RenderWindow window = (RenderWindow)sender;
			window.Close();
		}

        private static void OnKeyPressed(object sender, EventArgs ev)
        {
            foreach (var e in _entities)
            {
                try
                {
                    Player ent = (Player)e;

                    ent.Input(sender, (KeyEventArgs)ev, true);
                }
                catch (Exception)
                {
                    //shouldnt matter whats in here
                }
            } 
        }

        private static void OnKeyReleased(object sender, EventArgs ev)
        {
            foreach (var e in _entities)
            {
                try
                {
                    Player ent = (Player)e;

                    ent.Input(sender, (KeyEventArgs)ev, false);
                }
                catch (Exception)
                {
                    //shouldnt matter whats in here
                }
            }
        }

        public static void Run()
		{
            _entities = new List<Entity>();

            // Create the main window
            RenderWindow window = new RenderWindow(new VideoMode(1600, 900), "SFML Works!");
			window.Closed += OnClose;
            window.KeyPressed += OnKeyPressed;
            window.KeyReleased += OnKeyReleased;

            Color windowColor = new Color(0, 0, 0);

            var Ent = new Drawable(0, "meme",
                @"E:\+ 00 + Projects\VS 2013\C#\super-duper-lamp\super-duper-lamp\textures\penios.png");

            var ply = new Player(1);

		    Ent.Parent = ply;
            ply.Position = new Vector2f(100,100);

		    _entities.Add(Ent);
		    Ent.RotateWithParent = true;

		    Ent.Position = new Vector2f(75, 75);
            _entities.Add(ply);

	        Clock clock = new Clock();

            // Start the game loop
            while (window.IsOpen)
            {

                Time dt = clock.Restart();

				// Process events
				window.DispatchEvents();

                //think on all entities
			    Think(dt);

				// Clear screen
				window.Clear(windowColor);

                //draw on all entities
				Draw(window);

				// Update the window
				window.Display();

                window.SetTitle(Convert.ToString(1/dt.AsSeconds()));
            }
		}
	}
}