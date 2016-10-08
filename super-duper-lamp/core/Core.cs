using System;
using System.Collections;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace super_duper_lamp.core
{
    public static class Core
    {
        private static List<Entity> Entities;

        private static void Think(Time dt)
        {
            foreach (var e in Entities)
            {
                e.Think(dt);
            }
        }

        private static void Draw(RenderWindow window)
        {
            foreach (var e in Entities)
            {
                try // prob slow to use a try catch but whatever
                {
                    Drawable Ent = (Drawable) e;

                    Ent.Draw(window);
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
            foreach (var e in Entities)
            {
                try // prob slow to use a try catch but whatever
                {
                    Player Ent = (Player)e;

                    Ent.Input(sender, (KeyEventArgs)ev, true);
                }
                catch (Exception)
                {
                    Console.WriteLine("Not a player.");
                }
            } 
        }

        private static void OnKeyReleased(object sender, EventArgs ev)
        {
            foreach (var e in Entities)
            {
                try // prob slow to use a try catch but whatever
                {
                    Player Ent = (Player)e;

                    Ent.Input(sender, (KeyEventArgs)ev, false);
                }
                catch (Exception)
                {
                    Console.WriteLine("Not a player.");
                }
            }
        }

        public static void Run()
		{
            Entities = new List<Entity>();

            // Create the main window
            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "SFML Works!");
			window.Closed += OnClose;
            window.KeyPressed += OnKeyPressed;
            window.KeyReleased += OnKeyReleased;

            Color windowColor = new Color(0, 0, 0);

		    Entities.Add(new Drawable(0, "meme",
		        @"E:\+ 00 + Projects\VS 2013\C#\super-duper-lamp\super-duper-lamp\textures\penios.png"));

            Entities.Add(new Entity(1, "meme"));
            Entities.Add(new Player(2));

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
			}
		}
	}
}