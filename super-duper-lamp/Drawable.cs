using System;
using SFML.Graphics;
using SFML.System;

namespace super_duper_lamp
{
    public class Drawable : Entity
	{
		protected Sprite Sprite { get; set; }
        public Drawable Parent { get; set; }
        public bool RotateWithParent { get; set; }

        public Vector2f Position { get; set; }

	    private Texture texture;

        public Drawable(int id, string name, string pathToTexture) : base(id, name)
		{
			texture = new Texture(pathToTexture);
            Sprite = new Sprite {Texture = texture};
		}

		public virtual void Draw(RenderWindow window) 
		{
            //sets the parent transform if there is a requirement for one
		    if (Parent != null)
		    {
		        if (RotateWithParent)
		        {
		            var radians = (Math.PI/180)*Parent.Sprite.Rotation;

		            var ca = Math.Cos(radians);
		            var sa = Math.Sin(radians);

                    Sprite.Position = Parent.Position + new Vector2f(Convert.ToSingle(ca*Position.X - sa*Position.Y), Convert.ToSingle(sa *Position.X + ca*Position.Y));
		            Sprite.Rotation = Parent.Sprite.Rotation;

                    Console.WriteLine(radians);
		        }
		        else
		            Sprite.Position = Parent.Position + Position;
		    }
		    else
		    {
		        Sprite.Position = Position;
		    }

		    window.Draw(Sprite);
		}

	}
}
