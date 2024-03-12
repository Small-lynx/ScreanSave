using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreanSave
{
    public partial class ScreanSaveForm : Form
    {
        public ScreanSaveForm()
        {
            InitializeComponent();
            graphics = CreateGraphics();
            graphicsContext = BufferedGraphicsManager.Current;
            buffered = graphicsContext.Allocate(graphics, DisplayRectangle);
        }

        private Graphics graphics;
        private List<Snowflake> snowflakes;
        private BufferedGraphicsContext graphicsContext;
        private BufferedGraphics buffered;

        private void ScreanSaveForm_Load(object sender, EventArgs e)
        {
            var count = 20;
            snowflakes = new List<Snowflake>();
            var rnd = new Random();
            for (var i = 0; i <= count; i++)
            {
                var snow = new Snowflake(rnd.Next(0, Width), rnd.Next(0, Height), rnd.Next(50, 101));
                snowflakes.Add(snow);
            }
        }

        /// <summary>
        /// Перерисовка снежинок
        /// </summary>
        private void SnowRedraw()
        {
            buffered.Graphics.Clear(BackColor);
            buffered.Graphics.DrawImage(new Bitmap(Properties.Resources.forest, Width, Height), 0, 0);
            for (var i = 0; i < snowflakes.Count; i++)
            {
                buffered.Graphics.DrawImage(new Bitmap(Properties.Resources.snow, snowflakes[i].GetSize()), snowflakes[i].GetPoint());
            }
            buffered.Render();
        }


        /// <summary>
        /// Действия при тике таймера
        /// </summary>
        private void timerSnow_Tick(object sender, EventArgs e)
        {
            timerSnow.Enabled = false;
            SnowRedraw();
            for (var i = 0; i < snowflakes.Count; i++)
            {
                snowflakes[i].fallingSnowflakes(Width, Height);
            }
            timerSnow.Enabled = true;
        }
    }
}
