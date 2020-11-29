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
            Vector2[] corner = rect.GetCorners();
            Vector2 v0 = rect.XVector;
            Vector2 v1 = rect.XVector;
            Vector2 p;
            v1.Y *= -1;
            bool b = false;
            for (int i = 0; i < 4; i++) {
                b = b || this.Contains(corner[i]);
            }
            if (b) return b;
            b = this.Contains(Geometry2D.GetIntersectionPoint(corner[0], v0, this.centre, v1));
            p = Geometry2D.GetIntersectionPoint(corner[0], v0, this.centre, v1);
            b = this.Contains(p) && Geometry2D.isPointOnLine(corner[0], corner[3], p);
            if (b) return b;
            p = Geometry2D.GetIntersectionPoint(corner[1], v0, this.centre, v1);
            b = this.Contains(p) && Geometry2D.isPointOnLine(corner[1], corner[2], p);

            if (b) return b;
            v0 = rect.YVector;
            v1 = rect.YVector;
            v1.Y *= -1;
            p = Geometry2D.GetIntersectionPoint(corner[0], v0, this.centre, v1);
            b = this.Contains(p) && Geometry2D.isPointOnLine(corner[0], corner[1], p);
            if (b) return b;
            p = Geometry2D.GetIntersectionPoint(corner[2], v0, this.centre, v1);
            b = this.Contains(p) && Geometry2D.isPointOnLine(corner[2], corner[3], p);
            return b;

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
