using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Rect
    {
        public float X, Y, Width, Height;
        public Color OutLineColor, FillColor;

        public void DrawOn(Graphics t)
        {
            using (var p = new Pen(OutLineColor))
                t.DrawRectangle(p, X, Y, Width, Height);
            using (var b = new SolidBrush(FillColor))
                t.FillRectangle(b, X + 1, Y + 1, Width - 1, Height - 1);
        }

        public bool Intersects(float x, float y, float eps)
        {
            return x + eps >= X
                && y + eps >= Y
                && x - eps <= X + Width
                && y - eps <= Y + Height;

        }

        public void MoveBy(float dx, float dy)
        {
            X += dx;
            Y += dy;
        }

    }
}
