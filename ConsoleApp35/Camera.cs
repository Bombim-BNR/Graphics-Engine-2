using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;


namespace ConsoleApp35
{
    public class Camera
    {
        public Vector2 position;
        public double rotation, zoom;
        private float width, height, ratio;
        private Matrix4 sizeProjection = Matrix4.Identity;
        public Camera(Vector2 position, double rotation, double zoom, float width, float height)
        {
            this.position = position;
            this.rotation = rotation;
            this.zoom = zoom;
            this.width = width;
            this.height = height;
            ratio = width / height;
            sizeProjection = Matrix4.CreateOrthographic(width , height , 0f, 0f);
        }

        
        public Camera(Camera other)
        {
            this.position = new Vector2(other.position.X, other.position.Y);
            this.rotation = other.rotation;
            this.zoom = other.zoom;
            this.width = other.width;
            this.height = other.height;
            ratio = width / height;
            sizeProjection = Matrix4.CreateOrthographicOffCenter(-0.99f, 1, -0.99f, 1, -1, 1);


        }

        public void UpdateSize(float width, float height)
        {
            this.width = width;
            this.height = height;
            ratio = width / height;
            sizeProjection = Matrix4.CreateOrthographic(width * ratio, height * ratio, 0f, 0f);

        }

        public Matrix4 GetTransform()
        {

            Matrix4 transform = Matrix4.Identity;
            transform = Matrix4.Mult(transform, Matrix4.CreateTranslation(-position.X, -position.Y, 0));
            transform = Matrix4.Mult(transform, Matrix4.CreateRotationZ(-(float)rotation));
            transform = Matrix4.Mult(transform, Matrix4.CreateScale((float)zoom, (float)zoom, 1.0f));


            return transform;
        }
    }
}
