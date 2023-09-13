using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hours
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics g;
        Timer timer;
        Pen pen;
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black, 9);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(new Rectangle(30, 52, 240, 240));
            Region region = new Region(path);
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image =  bitmap);
            timer = new Timer();
            timer.Interval = 1000;
            timer.Start();
            timer.Tick += Timer_Tick;
            g.TranslateTransform(ClientSize.Width / 2, ClientSize.Height / 2);
            this.Region = region;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            g.Clear(BackColor);
            string time = now.Hour.ToString() + ":"+ now.Minute.ToString() + ":"+ now.Second.ToString();
            g.DrawString(time, new Font("Calibri", 11), Brushes.Black, -25, 50);
            g.DrawEllipse(pen, -100, -100, 200, 200);
            g.DrawLine(new Pen(Color.Black, 5), 0, 0, (float)(60 * Math.Cos((now.Hour * 30 - 90) * Math.PI / 180)), (float)(60 * Math.Sin((now.Hour * 30 - 90) * Math.PI / 180)));;
            g.DrawLine(new Pen(Color.Red, 3), 0, 0, (float)(75 * Math.Cos((now.Minute * 6 - 90) * Math.PI / 180)), (float)(75 * Math.Sin((now.Minute * 6 - 90) * Math.PI / 180)));;
            g.DrawLine(new Pen(Color.Green, 1), 0, 0, (float)(90 * Math.Cos((now.Second * 6 - 90) * Math.PI / 180)), (float)(90 * Math.Sin((now.Second * 6 - 90) * Math.PI / 180)));
            pictureBox1.Invalidate();
        }
    }

}
