using System;
using System.Collections.Generic;
using System.Reflection;

namespace super_duper_lamp.core
{
    public static class Objects
    {
        public static List<Entity> Entities { get; } = new List<Entity>();

        private static readonly Dictionary<string, Type> Types = new Dictionary<string, Type>()
        {
            {"player", typeof(Player)},
        };

        public static Entity New(string type)
        {
            var ctors = Types[type].GetConstructors();

            if (ctors.Length != 0)
            {
                var NewEnt = (Entity) ctors[0].Invoke(new object[] {Entities.Count});
                Entities.Add(NewEnt);

                return NewEnt;
            }
            else
            {
                return null;
            }
        }

        public static Entity New(string type, object[] args)
        {
            var ctors = Types[type].GetConstructors(BindingFlags.Public);
            var NewEnt = (Entity)ctors[0].Invoke(args);

            Entities.Add(NewEnt);

            return NewEnt;
        }
    }
}
