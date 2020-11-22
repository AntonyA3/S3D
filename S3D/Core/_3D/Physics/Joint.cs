using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace S3D.Core._3D.Physics
{
    class Joint
    {
        Matrix m;
        Vector3 position;
        public Joint() {
           
        }

        public Vector3 Position { get {
                return this.position;
            }set {
                this.position = value;
            } 
           
        }

        public void SetOrientation(float yaw, float pitch, float roll) {
            this.m = Matrix.CreateFromYawPitchRoll(yaw, pitch, roll);
        }

        public Vector3 Forward { 
            get { 
                return m.Forward; 
            }
        }

        public Vector3 Right
        {
            get
            {
                return m.Right;
            }
        }

        public Vector3 Up
        {
            get
            {
                return m.Up;
            }
        }


    }
}
