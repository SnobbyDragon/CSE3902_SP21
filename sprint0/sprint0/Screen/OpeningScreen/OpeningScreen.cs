using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//Author: Stuti Shah
namespace sprint0
{
    public class OpeningScreen
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private List<int> waveDists;
        private Rectangle source, splashLoc;
        private List<Rectangle> sourceSplash, sourceWaves, locationWaves;
        private readonly int waterEffectWidth = 32, waterEffectHeight = 16, splashFrames = 2, waveFrames = 3, xoffset = 1, yoffset = 11;
        private readonly int repeatedFramesSplash = 20, repframesWave = 12, maxWaveDist = 45, waveNum = 3, waveMinY = 180;
        private int currWaveFrame, currSplashFrame, timer = 0;
        private readonly Game1 game;
        public OpeningScreen(Game1 game, Texture2D texture)
        {
            this.game = game;
            Texture = texture;
            SetSources();
            splashLoc = WaterLocRec(80, 168);
            locationWaves = new List<Rectangle>() { WaterLocRec(80, 183), WaterLocRec(80, 201), WaterLocRec(80, 217) };
            currWaveFrame = currSplashFrame = 0;
            waveDists = new List<int>() { 0, 15, 30 };
        }
        public void Update()
        {
            timer = (timer + 1) % 2;
            currSplashFrame = (currSplashFrame + 1) % (splashFrames * repeatedFramesSplash);
            currWaveFrame = (currWaveFrame + 1) % (waveFrames * repframesWave);
            if (timer == 0)
            {
                for (int i = 0; i < waveNum; i++)
                {
                    waveDists[i] = (waveDists[i] + 1) % maxWaveDist;
                    Rectangle temp = locationWaves[i];
                    temp.Y = (int)(waveMinY * Game1.Scale) + (int)(waveDists[i] * Game1.Scale);
                    locationWaves[i] = temp;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
            foreach (Rectangle waveLoc in locationWaves)
                spriteBatch.Draw(Texture, waveLoc, sourceWaves[currWaveFrame / repframesWave], Color.White);
            spriteBatch.Draw(Texture, splashLoc, sourceSplash[currSplashFrame / repeatedFramesSplash], Color.White);
        }
        private void SetSources()
        {
            Location = new Rectangle(0, 0, (int)(Game1.Width * Game1.Scale), (int)((Game1.MapHeight + Game1.HUDHeight) * Game1.Scale));
            source = new Rectangle(xoffset, yoffset, 256, 224);
            sourceSplash = SpritesheetHelper.GetFramesH(846, 11, waterEffectWidth, waterEffectHeight, splashFrames);
            sourceWaves = SpritesheetHelper.GetFramesH(776, 28, waterEffectWidth, waterEffectHeight, waveFrames);
        }

        private Rectangle WaterLocRec(int offsetX, int offsetY)
            => new Rectangle((int)(offsetX * Game1.Scale), (int)(offsetY * Game1.Scale), (int)(waterEffectWidth * Game1.Scale), (int)(waterEffectHeight * Game1.Scale));
    }
}
