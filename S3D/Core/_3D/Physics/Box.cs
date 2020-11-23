using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace S3D.Core._3D.Physics
{
    /// <summary>
    /// Represent a Movable and Rotatable cuboid that is useful for collision detection
    /// </summary>
    class Box
    {
        /// <summary>
        /// The centre of the cuboid
        /// </summary>
        private Vector3 centre;
        /// <summary>
        /// Half the width of the cuboid
        /// </summary>
        private float halfWidth;
        /// <summary>
        /// Half the height of the cuboid
        /// </summary>
        private float halfHeight;
        /// <summary>
        /// Half the depth of the cuboid
        /// </summary>
        private float halfDepth;
        /// <summary>
        /// The up vector of the cuboid
        /// where the magnitude is the halfHeight
        /// </summary>
        private Vector3 upVector;
        /// <summary>
        /// The right vector where the magnitude is the
        /// half width
        /// </summary>
        private Vector3 rightVector;
        /// <summary>
        /// The forward vector where the magnitude is the
        /// half depth
        /// </summary>
        private Vector3 forwardVector;

        /// <summary>
        /// Initialises the default bounding box.
        /// </summary>
        public Box() {
            this.centre = new Vector3(0, 0, 0);

            this.upVector = new Vector3(0, 0, 0);
            this.forwardVector = new Vector3(0, 0, 0);
            this.rightVector = new Vector3(0, 0, 0);

        }

        /// <summary>
        /// Creates a new Box with no orientation
        /// </summary>
        /// <param name="centre">The centre of the box</param>
        /// <param name="halfWidth">Half of the width of the box and it's direction</param>
        /// <param name="halfHeight">Half of the height of the box and its direction</param>
        /// <param name="halfDepth">Half the depth of the box and it's direction</param>
        public Box(Vector3 centre, Vector3 rightVector, Vector3 upVector, Vector3 forwardVector) {
            this.centre = centre;

            this.rightVector = rightVector;
            this.upVector = upVector;
            this.forwardVector = forwardVector;

        }
        public Vector3 Centre {
            get {
                return this.centre;
            }
            set {
                this.centre = value;
            }
        }
        public Vector3 UpVector{
            get{
                return this.upVector;
            }
            set {
                this.upVector = value;
            }
        }

        public Vector3 RightVector { 
            get {
                return this.rightVector;
            }
            set {
                this.rightVector = value;
            }
        }

        public Vector3 ForwardVector { 
            get {
                return this.forwardVector;
            }
            set {
                this.forwardVector = value;
            }
        }

        public bool Intersects(Sphere sphere) {
            return sphere.Intersects(this);
        }

        /// <summary>
        /// Because the intersection function uses the contains function
        /// it also presumes that each vector of the box is at 90 degrees of each other
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public bool Intersects(Box box) {
            bool r = false;
            Vector3[] corner = box.GetCorners();
            for (int i = 0; i < 8; i++) {
                r = r || this.Contains(corner[i]);
            }
            return r;
        }
        /// <summary>
        /// The contains function presumes that eah vector in the box is 90 degree.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool Contains(Vector3 point) {
            bool r = false;
            Vector3[] corner = this.GetCorners();

            for (int i = 0; i < 8; i++) {
                //corner to point
                Vector3 ctp = point - corner[i];
                //corner to centre;
                Vector3 ceTp = this.centre - corner[i];
                r = r ||Vector3.Dot(ctp, ceTp) > 0;
            }
            return r;
            
        }

        public Vector3[] GetCorners() {
            Vector3[] corner = {
                this.centre - this.rightVector - this.upVector - this.forwardVector,
                this.centre - this.rightVector + this.upVector - this.forwardVector,
                this.centre + this.rightVector + this.upVector - this.forwardVector,
                this.centre + this.rightVector - this.upVector - this.forwardVector,
                this.centre - this.rightVector - this.upVector + this.forwardVector,
                this.centre - this.rightVector + this.upVector + this.forwardVector,
                this.centre + this.rightVector + this.upVector + this.forwardVector,
                this.centre + this.rightVector - this.upVector + this.forwardVector
            };
            return corner;
        }
        /// <summary>
        /// this returns true if it is a box,
        /// this returns false if it is a parallelpipe
        /// </summary>
        public bool isBox() {
            return Vector3.Dot(upVector, rightVector) *
                   Vector3.Dot(rightVector, forwardVector) *
                   Vector3.Dot(upVector, forwardVector) == 0;
            
        }
     
    }
}
