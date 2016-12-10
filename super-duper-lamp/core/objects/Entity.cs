using SFML.System;

namespace super_duper_lamp.core.objects
{
    public abstract class Entity
    {
        public Entity(string name)
        {
            _name = name;

            ObjectManager.Add(this);
        }

        private string _name;

        // ReSharper disable once InconsistentNaming
        private int id;
        public int ID
        {
            get { return id; }
            set
            {
                if (id != default(int))
                {
                    id = value;
                }
            }
        }

        public virtual void Think(Time dt)
        {
            //Console.WriteLine("Default think");
        }
    }
}
