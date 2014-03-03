using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Fantasy_Farm
{
    enum PlayerTool
    {
        None,
        Axe,
        Water,
        Hammer,
        Hoe,
        SeedBag
    }
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Sprite screens;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            // SaveGame("test.ffarm");
            LoadGame("test.ffarm");

            base.Initialize();
        }

        public void SaveGame(string fileName)
        {
            SaveData savedata = new SaveData();
            Stream stream = null;

            try { stream = File.OpenWrite(fileName); }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return;
            }
            BinaryFormatter bf = new BinaryFormatter();
            try { bf.Serialize(stream, savedata); }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                stream.Close();
                return;
            }

            if (stream != null) { stream.Close(); }
        }

        public void LoadGame(string fileName)
        {
            Stream stream = null;
            BinaryFormatter bf = new BinaryFormatter();

            try { stream = File.OpenWrite(fileName); }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return;
            }

            try { SaveData savedata = (SaveData)bf.Deserialize(stream); }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                stream.Close();
                return;
            }

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            GameStateManager.Services = this.Services;
            GameStateManager.SwitchToPlay();
            screens = new Sprite(Content.Load<Texture2D>("screens"), new Vector2(800, 480));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            GameStateManager.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            GameStateManager.Draw(spriteBatch);

            spriteBatch.Begin();
            screens.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
