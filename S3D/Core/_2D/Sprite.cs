using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace S3D.Core._2D
{
    class Sprite
    {
        private Vector2 location;
        private Rectangle area;
        private Rectangle frame;
        private Color color;
        private SpriteEffects flipped;
        private float layer;
        private Texture2D texture;


        public Sprite(Texture2D texture)
        {
            this.location = new Vector2(0, 0);
            this.area = new Rectangle();
            this.frame = new Rectangle();
            this.color = Color.White;
            this.flipped = SpriteEffects.None;
            this.layer = 0;
            this.texture = texture;
        }

        public Vector2 Location { 
            get {
                return this.location;
            }
            set
            {
                this.location = value;
            }
        
        }

        public Rectangle Area { 
            get {
                return this.area;
            } set {
                this.area = value;
            } 
        }

        public Rectangle Frame
        {
            get
            {
                return this.frame;
            }
            set
            {
                this.frame = value;
            }
        }

        public Color Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        public SpriteEffects Flipped
        {
            get
            {
                return this.flipped;
            }
            set
            {
                this.flipped = value;
            }
        }

        public float Layer
        {
            get
            {
                return this.layer;
            }
            set
            {
                this.layer = value;
            }
        }

        public Texture2D Texture2D
        {
            get
            {
                return this.texture;
            }
            set
            {
                this.texture = value;
            }
        }



        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, null, area, frame, null, 0, null, color, flipped, 0);
        }
     
    }
}
