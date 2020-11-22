using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using S3D.Core._3D.Physics;

namespace S3D.Core._3D
{

    /// <summary>
    /// A stub class to represent the humanoid skeleton
    /// </summary>
    class Humanoid
    {
        Joint leftLegJoint;
        Joint rightLegJoint;
        Joint leftKneeJoint;
        Joint rightKneeJoint;

        Joint pelvicCentreJoint;

        Box upperLeftLegBox;
        Box upperRightLegBox;
        Box lowerLeftLegBox;
        Box lowerRightLegBox;
        public Humanoid() {

        }

        public void setPelvicPosition(Vector3 position) {
            Vector3 deltaPosition = position - this.pelvicCentreJoint.Position;
            this.pelvicCentreJoint.Position = position;

            this.rightKneeJoint.Position += deltaPosition;
            this.leftKneeJoint.Position += deltaPosition;
            this.leftLegJoint.Position += deltaPosition;
            this.rightLegJoint.Position += deltaPosition;
            this.upperLeftLegBox.Centre += position;
            this.upperRightLegBox.Centre += position;
            this.lowerLeftLegBox.Centre += position;
            this.lowerRightLegBox.Centre += position;
        }

        public void setLeftKneeJointRotation() { 
        
        }
    }
}
