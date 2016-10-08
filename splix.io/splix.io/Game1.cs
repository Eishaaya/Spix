using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace splix.io
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        Random random;

        public int colorselect;
        List<Color> colors;
        Grid grid;

        KeyboardState prevKs;
        KeyboardState ks;
        bool menu = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.ApplyChanges();

            base.Initialize();
        }
        protected override void LoadContent()
        {
            random = new Random();
            colorselect = random.Next(0, 18);
            colors = new List<Color>()
            {
                Color.Maroon,
                Color.Navy,
                Color.Gold,
                Color.OrangeRed,
                Color.Violet,
                Color.Wheat,
                Color.DarkOliveGreen,
                Color.SaddleBrown,
                Color.DarkSalmon,
                Color.Yellow,
                Color.Pink,
                Color.BlueViolet,
                Color.BlanchedAlmond,
                Color.Khaki,
                Color.Turquoise,
                Color.Crimson,
                Color.White,
                Color.White,
                Color.White
            };


            spriteBatch = new SpriteBatch(GraphicsDevice);
            grid = new Grid(GraphicsDevice.Viewport.Width / 30, GraphicsDevice.Viewport.Height / 30, Content.Load<Texture2D>("CellBlock"));
            player = new Player(Content.Load<Texture2D>("soldier"), new Vector2(random.Next(0, 64) * 30, random.Next(0, 36) * 30), colors[colorselect], 5, Content.Load<Texture2D>("tail"), Content.Load<Texture2D>("capturedcell"), Content.Load<Texture2D>("pixel"));

        }
        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            prevKs = ks;
            ks = Keyboard.GetState();
            if (menu)
            {
                if (ks.IsKeyDown(Keys.Enter))
                {
                    menu = false;
                }
            }
            else
            {
                player.Update(gameTime, ks, prevKs);
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (menu)
            {
                GraphicsDevice.Clear(colors[colorselect]);
            }
            else
            {
                grid.Draw(spriteBatch);
                player.draw(spriteBatch);
                //player.debugDraw(spriteBatch, Content.Load<Texture2D>("pixel"));
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
