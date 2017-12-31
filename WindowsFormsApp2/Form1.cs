using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form1 : Form, IApplication
    {
        Scene scene = new Scene();
        ICommand activeCommand = null;
        Rect r;
        Circle c;
        Line l;

        public Form1()
        {
            InitializeComponent();

            Type t = typeof(Control);

            var p = t.GetProperty("DoubleBuffered",
                BindingFlags.NonPublic
                | BindingFlags.Instance);
            p.SetValue(drawPanel, true);
        }

        Color IApplication.MainColor
        {
            get
            {
                return OutLineC.Color;
            }
        }

        Color IApplication.SecondaryColor
        {
            get
            {
                return FillColor.Color;
            }
        }


        private void Main_ResizeBegin(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void toolStripContainer1_ContentPanel_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            scene.DrawOn(e.Graphics);
        }

        void IApplication.Invalidate()
        {
            drawPanel.Invalidate();
        }

        private void drawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if(activeCommand != null)
            {
                activeCommand.MouseDownHandler(e.X, e.Y);
            }
        }

        private void drawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (activeCommand != null)
            {
                activeCommand.MouseUpHandler(e.X, e.Y);
            }

        }

        private void drawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (activeCommand != null)
            {
                activeCommand.MouseMoveHandler(e.X, e.Y);
            }
        }
        private void RecButton_Click(object sender, EventArgs e)
        {
            activeCommand = new RectCommand(this, scene);
            FillColor.Color = Color.Transparent;
        }

        private void CircleButton_Click(object sender, EventArgs e)
        {
            activeCommand = new CircleCommand(this, scene);
            FillColor.Color = Color.Transparent;
        }



        private void OutLineColorButton_Click(object sender, EventArgs e)
        {
            OutLineC.ShowDialog();
        }

        private void FillColorButton_Click(object sender, EventArgs e)
        {
            FillColor.ShowDialog();
        }

        private void RecMover_Click(object sender, EventArgs e)
        {
            activeCommand = new MoveCommand(this, scene, 4);
        }



        private void CircleMover_Click(object sender, EventArgs e)
        {
            activeCommand = new MoveCirle(this, scene, 4);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(drawPanel.Width);
                int height = Convert.ToInt32(drawPanel.Height);

                Bitmap bmp = new Bitmap(width, height);
                drawPanel.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bmp.Save(saveFileDialog1.FileName);
            }

        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            scene.RemoveC(c);
            scene.RemoveR(r);
            scene.RemoveL(l);
            drawPanel.Refresh();
        }

        private void LineCreator_Click(object sender, EventArgs e)
        {
            activeCommand = new LineCommand(this, scene);
            
        }

        private void LineMover_Click(object sender, EventArgs e)
        {
            activeCommand = new LineMove(this, scene,4);
        }
    }
}
