using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form, IApplication
    {
        Scene scene = new Scene();
        ICommand activeCommand = null;

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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStrip2.Visible = true;

            activeCommand = new RectCommand(this, scene);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OutLineC.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FillColor.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            activeCommand = new MoveCommand(this, scene, 4);
        }
    }
}
