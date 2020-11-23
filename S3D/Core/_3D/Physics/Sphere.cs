using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace S3D.Core._3D.Physics
{
    class Sphere
    {
        private Vector3 centre;
        private float radius;

        public Vector3 Centre { 
            get {
                return this.centre;
            }
            set {
                this.centre = value;
            }
        }

        public float Radius {
            get {
                return this.radius;
            }
            set {
                this.radius = value;
            }
        }

        public bool Intersects(Sphere sphere) {
            return Vector3.DistanceSquared(this.centre, sphere.centre) < 
                this.radius * this.radius + sphere.radius * sphere.radius;
        }

        public bool Intersects(Box box) {
            Vector3[] corner = box.GetCorners();
            bool r = false;

            for (int i = 0; i < 8; i++) {
                r = r || this.Contains(corner[i]);
            }
            return r;
            
        }

        public bool Contains(Vector3 point) {
            return Vector3.DistanceSquared(this.centre, point) <
                this.radius * this.radius;
        }

    }
}
