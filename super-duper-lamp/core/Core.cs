using System;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using super_duper_lamp.core.objects;
using super_duper_lamp.game.objects;
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

        private static void Draw()
        {
            foreach (var e in Objects.Entities)
            {
                try // prob slow to use a try catch but whatever
                {
                    objects.Drawable ent = (objects.Drawable) e;

                    ent.Draw();
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

                    ent.KeyInput(sender, (KeyEventArgs)ev, true);
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

                    ent.KeyInput(sender, (KeyEventArgs)ev, false);
                }
                catch (Exception)
                {
                    //shouldnt matter whats in here
                }
            }
        }

        private static void OnMousePressed(object sender, EventArgs ev)
        {
            foreach (var e in Objects.Entities)
            {
                try
                {
                    Player ent = (Player)e;

                    ent.MouseBtnInput(sender, (MouseButtonEventArgs)ev, true);
                }
                catch (Exception)
                {
                    //shouldnt matter whats in here
                }
            }
        }
        private static void OnMouseReleased(object sender, EventArgs ev)
        {
            foreach (var e in Objects.Entities)
            {
                try
                {
                    Player ent = (Player)e;

                    ent.MouseBtnInput(sender, (MouseButtonEventArgs)ev, false);
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
            //RenderWindow window = new RenderWindow(new VideoMode(1600, 900), "SFML Works!");
            Global.Create(new VideoMode(1600, 900), "SFML Works!");

			Global.W.Closed += OnClose;
            Global.W.KeyPressed += OnKeyPressed;
            Global.W.KeyReleased += OnKeyReleased;

		    Global.W.MouseButtonPressed += OnMousePressed;
            Global.W.MouseButtonReleased += OnMouseReleased;

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
            new Static("textures/penios.png", new Vector2f(0, 0));

		    var ply = new Ship("good ship", "textures/penios.png");

            /////////////

            Camera camera = new Camera();
		    camera.Target = ply;

            Clock clock = new Clock();

            // Start the game loop
            while (Global.W.IsOpen)
            {

                Time dt = clock.Restart();

				// Process events
				Global.W.DispatchEvents();

                //Physics Update
                //"This should not vary"
                Global.World.Step(dt.AsSeconds());

                //think on all entities
			    Think(dt);
                camera.Think(dt);

				// Clear screen
				Global.W.Clear(windowColor);

                //draw on all entities
                camera.UseCamera();
                Draw();

				// Update the window
				Global.W.Display();

                Global.W.SetTitle(Convert.ToString(1/dt.AsSeconds()));
            }
		}
	}
}