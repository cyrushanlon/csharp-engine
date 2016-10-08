using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace super_duper_lamp
{
    public class Entity
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
