using System;
using super_duper_lamp.core.objects;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace super_duper_lamp.core
{
    public static class Core
    {
        private static void Think(Time dt)
        {
            foreach (var e in Objects.Entities)
            {
                e.Think(dt);
            }
        }

        private static void Draw(RenderWindow window)
        {
            foreach (var e in Objects.Entities)
            {
                try // prob slow to use a try catch but whatever
                {
                    objects.Drawable ent = (objects.Drawable) e;

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
            foreach (var e in Objects.Entities)
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
            foreach (var e in Objects.Entities)
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
            // Create the main window
            RenderWindow window = new RenderWindow(new VideoMode(1600, 900), "SFML Works!");
			window.Closed += OnClose;
            window.KeyPressed += OnKeyPressed;
            window.KeyReleased += OnKeyReleased;

            Color windowColor = new Color(0, 0, 0);

            /////////////playground

		    //var ply = Objects.New("player");
            /*
		    var ent = Objects.New("static", new object[]
		    {
		        1,
               "textures/penios.png",
                new Vector2f(200,200),
		    });
            */
		    var ply = new Player();

            /////////////

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