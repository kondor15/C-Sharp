using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    class MoveCirle:ICommand
    {
        Scene scene;
        IApplication application;
        Circle c;
        float eps;
        float LastX, LastY;

        public MoveCirle(IApplication app, Scene s, float eps)
        {
            this.eps = eps;
            scene = s;
            application = app;
             c = null;
        }
        public void MouseDownHandler(float x, float y)
        {
            var shape = scene.FindShape(x, y, eps);
            if (shape.Count > 0)
            {
                LastX = x;
                LastY = y;
                c = shape[shape.Count - 1];
            }
        }

        public void MouseMoveHandler(float x, float y)
        {

            if (c != null)
            {
                c.MoveBy(x - LastX, y - LastY);
                LastX = x;
                LastY = y;
                application.Invalidate();
            }
        }

        public void MouseUpHandler(float x, float y)
        {

            if (c != null)
            {
                c.MoveBy(x - LastX, y - LastY);
                LastX = x;
                LastY = y;
                c = null;
                application.Invalidate();
            }

        }
    }
}
