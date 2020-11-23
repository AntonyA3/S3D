using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace S3D.Core._3D
{
    class Sprite3D
    {
        private Vector3 position;
        private Vector2 location;
        private Rectangle area;
        private Rectangle frame;
        private BoundingBox volume;
        private Color color;
        private SpriteEffects flipped;

        private Texture2D texture;
        private Func<Vector3, Vector2> projection;

        public Sprite3D(Texture2D texture) {
            this.position = new Vector3(0, 0, 0);
            this.location = new Vector2(0, 0);
            this.area = new Rectangle();
            this.frame = new Rectangle();
            this.volume = new BoundingBox();
            this.color = Color.White;
            this.flipped = SpriteEffects.None;
            this.texture = texture;

        }

        public Vector3 Position {
            get {
                return this.position;
            }
            set {
                this.position = value;
                this.location = this.projection(this.position);

            }
        }
        /// <summary>
        /// Get the area based on the sprites location
        /// Sets the area if the sprite was at position 0,0,0
        /// </summary>
        public Rectangle Area {
            get {
                Rectangle a = this.area;
                a.Offset(this.location);
                return a;
            }

            set {
                this.area = value;
            }
        }

        public BoundingBox Volume {
            get {
                BoundingBox v = this.volume;
                v.Min += position;
                v.Max += position;
                return v;
            }
            set {
                this.volume = value;
            }
        }

        public Rectangle Frame
        {
            get {
                return this.frame;
            }
            set {
                this.frame = value;
            }

        }

        public Color Color {
            get {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        public SpriteEffects Flipped{
            get {
                return this.flipped;
            }
            set {
                this.flipped = value;
            }
        }


        public Texture2D Texture {
            get {
                return this.texture;
            }
            set {
                this.texture = value;
            }
        }
      

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, null, area, frame, null, 0, null, color, flipped, 0);
        }
      
    }
}
