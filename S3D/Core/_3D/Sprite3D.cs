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

        public Sprite3D(Texture2D texture) {
            this.position = new Vector3(0,0,0);
            this.location = new Vector2(0,0);
            this.area = new Rectangle();
            this.frame = new Rectangle();
            this.volume = new BoundingBox();
            this.color = Color.White;
            this.flipped = SpriteEffects.None;
            this.texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, null, area, frame, null, 0, null, color, flipped, 0);
        }
      
    }
}
