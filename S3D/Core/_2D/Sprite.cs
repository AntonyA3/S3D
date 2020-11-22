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


        public Sprite(Texture2D texture) { 
        
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, null, area, frame, null, 0, null, color, flipped, 0);
        }
     
    }
}
