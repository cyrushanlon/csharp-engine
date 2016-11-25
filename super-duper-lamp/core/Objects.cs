using System;
using System.Collections.Generic;
using System.Reflection;
using super_duper_lamp.core.objects;

namespace super_duper_lamp.core
{
    public static class Objects
    {
        public static List<Entity> Entities { get; } = new List<Entity>();

        private static readonly Dictionary<string, Type> Types = new Dictionary<string, Type>()
        {
            {"player", typeof(Player)},
            {"static", typeof(Static)},
        };
/*
        public static Entity New(string type)
        {
            if (Types.ContainsKey(type))
            {
                var ctors = Types[type].GetConstructors();
                if (ctors.Length != 0)
                {
                    var NewEnt = (Entity) ctors[0].Invoke(new object[] {Entities.Count});
                    Entities.Add(NewEnt);

                    return NewEnt;
                }
            }

            Console.Out.WriteLine("Type " + type + " not supported by Objects.");

            return null;
        }

        public static Entity New(string type, object[] args)
        {
            var ctors = Types[type].GetConstructors();
            var NewEnt = (Entity)ctors[0].Invoke(args);

            Entities.Add(NewEnt);

            return NewEnt;
        }
*/
        public static int NextID()
        {
            return Entities.Count;
        }

        public static void Add(Entity newEnt)
        {
            newEnt.ID = NextID();
            Entities.Add(newEnt);
        }
    }
}
