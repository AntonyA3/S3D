using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace S3D.Core._2D.Physics
{
    public class Circle
    {
        float radius;
        Vector2 centre;


        public Vector2 Centre { 
            get {
                return this.centre;
            }
            set {
                this.centre = value;
            }
        }

        public float Radius { get {
                return this.radius;
            } set {
                this.radius = value;
            } 
        }

        public Circle() {
            this.radius = 0;
            this.centre = new Vector2(0, 0);
        }

        public Circle(Vector2 centre, float radius) {
            this.centre = centre;
            this.radius = radius;
        }

        public bool Intersects(Circle circle) {
            return Vector2.DistanceSquared(this.centre, circle.centre) < this.radius * this.radius + circle.radius * circle.radius;
        }


        public bool Intersects(Rect rect) {
            
            Vector2 d = (rect.Centre - this.centre);
            d.Normalize();
            return rect.Contains(d * this.radius) || rect.Contains(this.centre);
        }

        public bool Contains(Vector2 point)
        {
            return Vector2.DistanceSquared(this.centre, point) < this.radius * this.radius;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
