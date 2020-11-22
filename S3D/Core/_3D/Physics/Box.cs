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
        /// <param name="halfWidth">Half of the width of the box</param>
        /// <param name="halfHeight">Half of the height of the box</param>
        /// <param name="halfDepth">Half the depth of the box</param>
        public Box(Vector3 centre, float halfWidth, float halfHeight, float halfDepth) {
            this.centre = centre;

            this.halfWidth = halfWidth;
            this.halfHeight = halfHeight;
            this.halfDepth = halfDepth;

            this.rightVector = new Vector3(halfWidth, 0, 0);
            this.upVector = new Vector3(0, halfHeight, 0);
            this.forwardVector = new Vector3(0, 0, halfDepth);

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

        public Vector3[] GetCorners() {
            return null;
        }
     
    }
}
