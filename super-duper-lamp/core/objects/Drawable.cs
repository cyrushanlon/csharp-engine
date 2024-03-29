﻿using System;
using super_duper_lamp.core.utils;
using SFML.Graphics;
using SFML.System;

namespace super_duper_lamp.core.objects
{
    public abstract class Drawable : Entity
	{
		protected Sprite Sprite { get; set; }
        public Drawable Parent { get; set; }
        public bool RotateWithParent { get; set; }

        public Vector2f Origin { get; set; }
        public Vector2f Position { get; set; }
        public float Rotation { get; set; }

	    private Texture texture;

        public Drawable(string name, string pathToTexture) : base(name)
        {
            texture = ResourceManager.GetResource(pathToTexture);
            Sprite = new Sprite {Texture = texture};

            Origin = new Vector2f(Sprite.GetLocalBounds().Width/2, Sprite.GetLocalBounds().Height / 2);

		    RotateWithParent = true;
		}

		public virtual void Draw()
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

            G.Window.Draw(Sprite);
		}

	}
}
