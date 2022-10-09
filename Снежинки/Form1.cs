using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Снежинки
{
    public partial class Form1 : Form
    {
        private readonly IList<Snowflake1> snowflakes;
        private readonly Timer timer;

        public Form1()
        {
            InitializeComponent();
            snowflakes = new List<Snowflake1>();
            AddSnowflakes();
            timer = new Timer();
            timer.Interval = 250;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var snowflake in snowflakes)
            {
                timer.Stop();
                snowflake.Y += snowflake.Size;
                if (snowflake.Y > Screen.PrimaryScreen.WorkingArea.Height)
                {
                    snowflake.Y = -snowflake.Size;
                }
            }
            Refresh();
            timer.Start();
        }

        private void AddSnowflakes()
        {
            var rnd = new Random();
            for (int i = 0; i < 60; i++)
            {
                snowflakes.Add(new Snowflake1
                {
                    X = rnd.Next(Screen.PrimaryScreen.WorkingArea.Width),
                    Y = rnd.Next(Screen.PrimaryScreen.WorkingArea.Height),
                    Size = rnd.Next(20, 50)
                });
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        Bitmap snezhinka = Properties.Resources.снежинка;
        private void Form1_Paint_1(object sender, PaintEventArgs e)
        { 
            foreach (var item in snowflakes)
            {
                e.Graphics.DrawImage(snezhinka,
                    item.X,
                    item.Y,
                    item.Size,
                    item.Size);
            }

        }

    }
}
