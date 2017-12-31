using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    class Line
    {
        public float X, Y, X1, Y1;
        public Color OutLineColor;

        public void DrawOn(Graphics t)
        {
            using (var p = new Pen(OutLineColor))
                t.DrawLine(p, X, Y, X1, Y1);
        }

        public bool Intersects(float x, float y, float eps)
        {
            return x + eps >= X
                && y + eps >= Y
                && x - eps <= X + X1
                && y - eps <= Y + Y1;

        }

        public void MoveBy(float dx, float dy)
        {
            X += dx;
            Y += dy;
            X1 += dx;
            Y1 += dy;
        }

    }
}
