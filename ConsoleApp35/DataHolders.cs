using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace ConsoleApp34
{
    public class Sprite
    {
        private Texture texture;
        private int positionX;
        private int positionY;
        private int width;
        private int height; 
        
        public Sprite(Texture texture, int positionX, int positionY, int width, int height)
        {
            this.texture = texture;
            this.positionX = positionX;
            this.positionY = positionY;
            this.width = width;
            this.height = height;
        }

        
        public Sprite(Sprite sprite)
        {
            this.texture = new Texture(sprite.Texture);
            this.positionX = sprite.PositionX;
            this.positionY = sprite.PositionY;
            this.width = sprite.Width;
            this.height = sprite.Height;
        }

        
        public Sprite(Texture texture, (int, int) position, (int, int) size)
            : this(texture, position.Item1, position.Item2, size.Item1, size.Item2) { }

        
        public Texture Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public int PositionX
        {
            get { return positionX; }
            set { positionX = value; }
        }

        public int PositionY
        {
            get { return positionY; }
            set { positionY = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }
    }


    public struct Texture
    {
        private int id;
        private int width, height;
        public int Id
        {
            get { return id; }
        }
        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }
        public Texture(int id, int width, int height)
        {
            this.id = id;
            this.width = width;
            this.height = height;
        }
        public Texture(Texture texture)
        {
            this.id = texture.Id;
            this.width = texture.Width;
            this.height = texture.Height;
        }
        public Texture((int, int, int) data)
        {
            this.id = data.Item1;
            this.width = data.Item2;
            this.height = data.Item3;
        }


        public void Use(TextureUnit unit)
        {
            GL.ActiveTexture(unit);
            GL.BindTexture(TextureTarget.Texture2D, id);
        }

    }
}
