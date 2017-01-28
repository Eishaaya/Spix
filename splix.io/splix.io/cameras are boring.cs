using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace splix.io
{
    public class cameras_are_boring
    {
        public BasicEffect Effect;
        private Player player;

        public cameras_are_boring()
        {

        }
        public cameras_are_boring(Player bob)
        {
            player = bob;
            var viewport = bob.Image.GraphicsDevice.Viewport;

            Effect = new BasicEffect(bob.Image.GraphicsDevice);
            Effect.TextureEnabled = true;
            Effect.VertexColorEnabled = true;
            Effect.Projection = Matrix.CreateOrthographic(viewport.Width, viewport.Height, 1, 10);
            Effect.World = Matrix.Identity;

            Update();
        }

       

        public void Update()
        {
            var viewport = player.Image.GraphicsDevice.Viewport;
            Effect.View = Matrix.CreateLookAt(new Vector3(player.Location, -9), new Vector3(player.Location, 0), Vector3.Down);
        }
    }
}
