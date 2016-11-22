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

        public Vector2f Origin { get; set; }
        public Vector2f Position { get; set; }
        public float Rotation { get; set; }

	    private Texture texture;

        public Drawable(int id, string name, string pathToTexture) : base(id, name)
		{
			texture = new Texture(pathToTexture);
            Sprite = new Sprite {Texture = texture};

            Origin = new Vector2f(Sprite.GetLocalBounds().Width/2, Sprite.GetLocalBounds().Height / 2);
		}

		public virtual void Draw(RenderWindow window)
		{
		    Sprite.Origin = Origin;

            //sets the parent transform if there is a requirement for one
		    if (Parent != null)
		    {
		        if (RotateWithParent)
		        {
                    Sprite.Position = Parent.Position + Vector2Extended.Rotate(Position, Parent.Rotation);
                    Sprite.Rotation = Parent.Rotation + Rotation;
		        }
		        else
		        {
		            Sprite.Position = Parent.Position + Position;
		        }

		    }
		    else
		    {
		        Sprite.Position = Position;
                Sprite.Rotation = Rotation;
            }

            window.Draw(Sprite);
		}

	}
}
