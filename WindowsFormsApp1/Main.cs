using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        float startX,startY,x,y,H,W,yMin , xMin;
        
        bool fla,fl;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Double clicked!");
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            using (var p = new Pen(Color.Red, 10 ))
            {
                e.Graphics.DrawLine(p, 0, Height/2, Width, Height/2);
            }
               
        }

        private void Main_ResizeBegin(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New file");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = openPaintFile.ShowDialog();
            if(result == DialogResult.OK )
            {
               var filename = openPaintFile.FileName;
                using (var f = File.Open(filename, FileMode.OpenOrCreate))
                {
                    MessageBox.Show("Opend File" + filename, "Result from OpenFileDialog");
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            fl = true;
            toolStripButton4.Visible= true;
            toolStripButton5.Visible = true;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            outLineColor.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            FillColor.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //outLineColor.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //FillColor.ShowDialog();
        }

        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            using (var p = new Pen(outLineColor.Color, 5))
            {
                
                e.Graphics.DrawRectangle(p, xMin, yMin, W, H);
                using (var b = new SolidBrush(FillColor.Color))
                {
                    e.Graphics.FillRectangle(b, xMin + 3, yMin + 3, W - 5, H - 5);
                }
            }
        }

        private void drawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            fla = false;
            //x = e.X;
            //y = e.Y;
            drawPanel.Invalidate();
        }

        private void toolStripContainer1_ContentPanel_Paint(object sender, PaintEventArgs e)
        {
            //using (var p = new Pen(outLineColor.Color, 10))
            //{
            //    var h = toolStripContainer1.ContentPanel.Height;
            //    var w = toolStripContainer1.ContentPanel.Width;
            //    e.Graphics.DrawLine(p, 0, h / 2, w, h / 2);
            //}
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (fl != false)
            {
                if (fla != false)
                {

                    xMin = Math.Min(startX, e.X);
                    yMin = Math.Min(startY, e.Y);
                    var xMax = Math.Max(startX, e.X);
                    var yMax = Math.Max(startY, e.Y);
                    W = xMax - xMin;
                    H = yMax - yMin;


                    drawPanel.Invalidate();

                }
            }
        }

        

        private void drawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            fla = true;
            startX = e.X;
            startY = e.Y;
            drawPanel.Invalidate();
        }
    }
}
