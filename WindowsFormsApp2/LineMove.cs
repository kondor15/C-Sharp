using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    class LineMove : ICommand
    {
        Scene scene;
        IApplication application;
        Line e;
        float eps;
        float LastX, LastY;

        public LineMove(IApplication app, Scene s, float eps)
        {
            this.eps = eps;
            scene = s;
            application = app;
            e = null;
        }
        public void MouseDownHandler(float x, float y)
        {
            var shape = scene.FindShap(x, y, eps);
            if (shape.Count > 0)
            {
                LastX = x;
                LastY = y;
                e = shape[shape.Count - 1];
            }
        }

        public void MouseMoveHandler(float x, float y)
        {

            if (e != null)
            {
                e.MoveBy(x - LastX, y - LastY);
                LastX = x;
                LastY = y;
                application.Invalidate();
            }
        }

        public void MouseUpHandler(float x, float y)
        {

            if (e != null)
            {
                e.MoveBy(x - LastX, y - LastY);
                LastX = x;
                LastY = y;
                e = null;
                application.Invalidate();
            }

        }
    }
}
