using SFML.Graphics;

namespace super_duper_lamp
{
    public class Drawable : Entity
	{
		protected Sprite sprite { get; set; }
		private Texture texture;


		public Drawable(int id, string name, string pathToTexture) : base(id, name)
		{
			texture = new Texture(pathToTexture);
		    sprite = new Sprite {Texture = texture};
		}

		public virtual void Draw(RenderWindow window) 
		{
			window.Draw(sprite);
		}

	}
}
