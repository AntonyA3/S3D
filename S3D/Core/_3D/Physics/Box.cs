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

        public Box() {
            this.centre = new Vector3(0, 0, 0);
            this.halfWidth = 0;
            this.halfHeight = 0;
            this.halfDepth = 0;

            this.upVector = new Vector3(0, 0, 0);
            this.forwardVector = new Vector3(0, 0, 0);
            this.rightVector = new Vector3(0, 0, 0);
           
        }

        public Box(Vector3 centre, float width, float height, float depth) { 
            
        }
    }
}
