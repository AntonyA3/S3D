using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace S3D.Core._3D.Physics
{
    public struct Sphere
    {
        public Vector3 centre;
        public float radius;


        public Sphere(Vector3 centre, float radius) {
            this.centre = centre; 
            this.radius = radius;
        }

        
        public bool Contains(Vector3 point) {
            return Vector3.DistanceSquared(this.centre, point) < this.radius * this.radius;
        }

        public bool Intersects(Line line) {
            return line.Intersects(this);
        }

        public bool Intersects(Sphere sphere)
        {
            return Vector3.DistanceSquared(this.centre, sphere.centre) < this.radius * this.radius;
        }
        public bool Intersects(Plane plane) {

            return plane.Intersects(this);
        }
        
        public bool Intersects(Box box) {
            return box.Intersects(this);
        }

    }
}
