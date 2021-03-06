﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace S3D.Core._3D.Physics
{

    public struct Box
    {


        Vector3 centre;
        Vector3 axis0;
        Vector3 axis1;
        Vector3 axis2;
        
        public Box(Vector3 centre, Vector3 axis0, Vector3 axis1, Vector3 axis2)
        {
            this.centre = centre;
            this.axis0 = axis0;
            this.axis1 = axis1;
            this.axis2 = axis2;

        }

        public Vector3[] GetCorners() {

            return new Vector3[] {
                this.centre - axis0 - axis1 - axis2,
                this.centre - axis0 + axis1 - axis2,
                this.centre + axis0 + axis1 - axis2,
                this.centre + axis0 - axis1 - axis2,
                this.centre - axis0 - axis1 + axis2,
                this.centre - axis0 + axis1 + axis2,
                this.centre + axis0 + axis1 + axis2,
                this.centre + axis0 - axis1 + axis2
            };
        }
        public BoundingBox GetBoundingBox() {
            return BoundingBox.CreateFromPoints(this.GetCorners());
        }
        public bool Contains(Vector3 point) {
           
            Plane[] plane = this.GetPlanes();
            bool b = true;
            /*for the this to return true the inner normal of all box planes must be
             * closer than the outer normal
             */
            for (int i = 0; i < 6; i++) {
                Vector3 topNormal = plane[i].GetNormal();
                b = b && (plane[i].centre + topNormal - point).LengthSquared() > (plane[i].centre - topNormal - point).LengthSquared();
            }

            return b;
            
        }

        public bool Intersects(Line line) {
            if (line.GetRay().Intersects(this.GetBoundingBox())!= null) { 
                if (this.Contains(line.p0))
                {
                    return true;
                }
                if (this.Contains(line.p1))
                {
                    return true;
                }
            
                //either the box contains each point in a line
            

                //or this line intersects one of the planes of the box
                Plane[] plane = this.GetPlanes();
                for (int i = 0; i < 6; i++)
                {
                    bool r = line.Intersects(plane[i]);
                    if (r)
                    {
                        return r;
                    }
                }
            }
            
            //if not there is no intersectiom
            return false;
        }
        
        public bool Intersects(Sphere sphere) {
            if (this.GetBoundingBox().Intersects(sphere.GetBoundingBox())) { 
                Plane[] plane = this.GetPlanes();
                //the sphere intersects with at least 1 plane of the box
                for (int i = 0; i < 6; i++) {
                    if (sphere.Intersects(plane[i])) {
                        return true;
                    }
                }
            }
            
            //otherwise there is no intersection
            return false;
        }

        public bool Intersects(Plane plane) {
            if (this.GetBoundingBox().Intersects(plane.GetBounding())) { 
                Plane[] boxPlanes = this.GetPlanes();
                //at least 1 of the planes of the box, must intersect with the plane
                for (int i = 0; i < 6; i++) {
                    if (boxPlanes[i].Intersects(plane)) {
                        return true;
                    }
                }
            }
            
            return false;
        }

        public bool Intersects(Box box) {
            if (this.GetBoundingBox().Intersects(box.GetBoundingBox())) { 
                Plane[] ourPlanes = this.GetPlanes();
                Plane[] otherPlanes = box.GetPlanes();

                //at least 1 of the planes of this box must intersect with another plane of another box
                for (int i = 0; i < 6; i++) {
                    for (int j = 0; j < 6; j++)
                    {
                        if (ourPlanes[i].Intersects(otherPlanes[j])) {
                            return true;
                        }
                    }
                }
            }
            
            return false;
        }
        private Plane[] GetPlanes() {
            Vector3[] c = this.GetCorners();
            //left
            //right
            //bottom
            //top
            //front
            //back
            return new Plane[] {
                new Plane(c[0] + 0.5f * (c[5] - c[0]),axis2, -axis1),
                new Plane(c[3] + 0.5f *(c[6] - c[3]), axis2, axis1),
                new Plane(c[0] + 0.5f *(c[7] - c[0]), -axis0, axis2),
                new Plane(c[1] + 0.5f *(c[6] - c[1]), -axis0, -axis2 ),
                new Plane(c[0] + 0.5f *(c[2] - c[0]), -axis0, -axis1 ),
                new Plane(c[4] + 0.5f *(c[6] - c[4]), -axis0, axis1 )
            };

           

        }
        

    }
}
