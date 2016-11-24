using SFML.System;

namespace super_duper_lamp
{
    public abstract class Entity
    {
        public Entity(int id, string name)
        {
            ID = id;
            _name = name;
        }

        private string _name;

        // ReSharper disable once InconsistentNaming
        public int ID { get; }

        public virtual void Think(Time dt)
        {
            //Console.WriteLine("Default think");
        }
    }
}
