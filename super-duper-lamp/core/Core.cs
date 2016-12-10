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
            foreach (var e in ObjectManager.Entities)
            {
                e.Think(dt);
            }
        }

        //need to remove type cast
        private static void Draw()
        {
            foreach (var e in ObjectManager.Entities)
            {
                try
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

        public static void Run()
		{
            // Create the main window
            //RenderWindow window = new RenderWindow(new VideoMode(1600, 900), "SFML Works!");
            G.Create(new VideoMode(1600, 900), "SFML Works!");

			G.Window.Closed += OnClose;
            G.Window.KeyPressed += InputManager.OnKeyPressed;
            G.Window.KeyReleased += InputManager.OnKeyReleased;

		    G.Window.MouseButtonPressed += InputManager.OnMousePressed;
            G.Window.MouseButtonReleased += InputManager.OnMouseReleased;

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
            while (G.Window.IsOpen)
            {
                Time dt = clock.ElapsedTime;

				// Process events
				G.Window.DispatchEvents();

                //lock FPS to 144
                //dt related stuff
                if (dt.AsSeconds() > 1/144f) {
                    G.World.Step(1/144f);
                    Think(dt);
                    camera.Think(dt);
                    clock.Restart();
                }

                //draw
                // Clear screen
                G.Window.Clear(windowColor);
                //draw on all entities
                camera.UseCamera();
                Draw();
                // Update the window
                G.Window.Display();

                G.Window.SetTitle(Convert.ToString(1/dt.AsSeconds()));
            }
		}
	}
}