﻿using System;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get => this.width;
            set => this.width = value;
        }

        public int Height
        {
            get => this.height;
            set => this.height = value;
        }

        public void Draw()
        {
            var symbol = '*';

            this.DrawLine(this.width, symbol, symbol);

            for (int i = 1; i < this.height - 1; ++i)
            {
                this.DrawLine(this.width, symbol, ' ');
            }

            this.DrawLine(this.width, symbol, symbol);
        }

        private void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);

            for (int i = 1; i < width - 1; ++i)
            {
                Console.Write(mid);
            }

            Console.WriteLine(end);
        }
    }
}