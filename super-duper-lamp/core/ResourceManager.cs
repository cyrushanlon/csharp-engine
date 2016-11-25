using System;
using System.Collections.Generic;

using SFML.Graphics;

namespace super_duper_lamp.core
{
	public static class ResourceManager
	{
	    private const string ResourcePath = @"E:\+ 00 + Projects\VS 2013\C#\super-duper-lamp\super-duper-lamp";
		private static Dictionary<string,Tuple<Texture, int> > resources = new Dictionary<string, Tuple<Texture, int>>();

 /*
	    public ResourceManager(Dictionary<string, Tuple<Texture, int>> resources)
	    {
	        this.resources = resources;
	    }
*/
	    public static Texture GetResource(string path)
		{
			if (resources.ContainsKey(path))
			{
				var item = resources[path];

				resources[path] = new Tuple<Texture, int>(item.Item1, item.Item2 + 1);

				return item.Item1;
			} 
			else 
			{
				var tex = new Texture(ResourcePath + @"\" + path);
				resources.Add(path, new Tuple<Texture, int>(tex, 1));
				return tex;
			}
		}

		public static void RemoveResource(string path)
		{
			if (resources.ContainsKey(path))
			{
				var item = resources[path];

				if (item.Item2 - 1 <= 0)
				{
					resources.Remove(path);
				}
				else
				{
					resources[path] = new Tuple<Texture, int>(item.Item1, item.Item2 - 1);
				}
			}
		}
	}
}
