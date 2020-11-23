using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace S3D.Core._2D.Physics
{
    class Circle
    {
        float radius;
        Vector2 centre;

        public bool Intersects(Circle circle) {
            return Vector2.DistanceSquared(this.centre, circle.centre) < this.radius * this.radius + circle.radius * circle.radius;
        }

        public bool Intersects(Rect rect) {
            Vector2[] corner = rect.GetCorners();
            bool r = false;
            for (int i = 0; i < 4; i++) {
                r = r || this.Contains(corner[i]);
            }
            return r;
        }

        public bool Contains(Vector2 point)
        {
            return Vector2.DistanceSquared(this.centre, point) < this.radius * this.radius;
        }

    }
}
