using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screen_Saver
{
    public partial class Form1 : Form
    {
        //Lists for ball traits
        List<Size> ballSize = new List<Size>();
        List<Rectangle> ballRectangle = new List<Rectangle>();
        List<Color> ballColor = new List<Color>();
        List<int> ballxSpeed = new List<int>();
        List<int> ballySpeed = new List<int>();

        //Graphics Objects
        SolidBrush ballbrush; 


        public Form1()
        {
            InitializeComponent();
            InitBallValues();
        }

        public void InitBallValues()
        {

            ballRectangle.Add(new Rectangle(100, 100, 25, 25));
            ballRectangle.Add(new Rectangle(450, 150, 25, 25));
            ballRectangle.Add(new Rectangle(350, 350, 25, 25));

            ballColor.Add(Color.FromArgb(255, 0, 0));
            ballColor.Add(Color.FromArgb(0, 255, 0));
            ballColor.Add(Color.FromArgb(0, 0, 255));

            ballxSpeed.Add(5);
            ballxSpeed.Add(-5);
            ballxSpeed.Add(5);

            ballySpeed.Add(5);
            ballySpeed.Add(-5);
            ballySpeed.Add(5);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
         //   foreach(int i in ballxSpeed)
                //move all the balls
            for(int i = 0; i < ballxSpeed.Count(); i++)
            {
                ballRectangle[i] = new Rectangle (ballRectangle[i].X + ballxSpeed[i], ballRectangle[i].X + ballySpeed[i], 25, 25);
            }

            //check for collision
            for (int i = 0; i < ballxSpeed.Count(); i++)
            {
                if (ballRectangle[i].X < 0)
                {
                    ballxSpeed[i] = 5;
                }

                else if (ballRectangle[i].X > this.Width - 25)
                {
                    ballxSpeed[i] = -5;
                }

                if (ballRectangle[i].Y < 0)
                {
                    ballySpeed[i] = 5;
                }

                else if (ballRectangle[i].X > this.Width - 25)
                {
                    ballySpeed[i] = -5;
                }
            }


                Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < ballxSpeed.Count(); i++)
            {
               ballbrush = new SolidBrush(ballColor[i]);
               e.Graphics.FillEllipse(ballbrush, ballRectangle[i]);
            }
        }
    }
}
