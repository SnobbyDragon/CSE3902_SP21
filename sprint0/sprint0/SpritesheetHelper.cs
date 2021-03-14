﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public static class SpritesheetHelper
    {
        /*
         * GetFramesH gets sprites in a horizontal line
         */
        public static List<Rectangle> GetFramesH(int xOffset, int yOffset, int width, int height, int numFrames)
        {
            List<Rectangle> sources = new List<Rectangle>();
            for (int i = 0; i < numFrames; i++)
            {
                sources.Add(new Rectangle(xOffset, yOffset, width, height));
                xOffset += width + 1;
            }
            return sources;
        }

        /*
         * GetFramesV gets sprites in a vertical line
         */
        public static List<Rectangle> GetFramesV(int xOffset, int yOffset, int width, int height, int numFrames)
        {
            List<Rectangle> sources = new List<Rectangle>();
            for (int i = 0; i < numFrames; i++)
            {
                sources.Add(new Rectangle(xOffset, yOffset, width, height));
                xOffset += width + 1;
            }
            return sources;
        }
    }
}
