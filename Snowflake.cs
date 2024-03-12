using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ScreanSave
{
    internal class Snowflake
    {
        private readonly int size;
        private readonly int speed;
        private Point position;
        private double time;
        public Snowflake(int x, int y, int size)
        {
            this.size = size;
            speed = 105 - size;
            position = new Point(x, y);
            time = 0;
        }
        public Size GetSize()
        {
            var size = new Size(this.size, this.size);
            return size;
        }
        public Point GetPoint()
        {
            return position;
        }

        /// <summary>
        /// Падение снежинок
        /// </summary>
        /// <param name="Width">Ширина фона для рисования</param>
        /// <param name="Height">Высота фона для рисования</param>
        public void fallingSnowflakes(int Width, int Height)
        {
            time += 0.1;
            position.Y += speed;
            position.X += (int)(50 * Math.Sin(0.1 * time));
            if (position.Y >= Height || position.X >= Width)
            {
                position.Y = 0 - size;
                time = 0;
                position.X = new Random().Next(0, Width);
            }
        }
    }
}
