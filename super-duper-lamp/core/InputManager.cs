using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using super_duper_lamp.core.objects;
using SFML.Window;

namespace super_duper_lamp.core
{
    public static class InputManager
    {
        public static void OnKeyPressed(object sender, EventArgs ev)
        {
            //need to remove this type cast
            foreach (var e in ObjectManager.Entities)
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
        public static void OnKeyReleased(object sender, EventArgs ev)
        {
            //need to remove this type cast
            foreach (var e in ObjectManager.Entities)
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

        public static void OnMousePressed(object sender, EventArgs ev)
        {
            foreach (var e in ObjectManager.Entities)
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
        public static void OnMouseReleased(object sender, EventArgs ev)
        {
            foreach (var e in ObjectManager.Entities)
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
    }
}
