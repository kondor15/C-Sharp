using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class MoveCommand:ICommand
    {
        Scene scene;
        IApplication application;
        Rect r;
        float eps;
        float LastX, LastY;

        public MoveCommand(IApplication app, Scene s, float eps)
        {
            this.eps = eps;
            scene = s;
            application = app;
            r = null;
        }
        public void MouseDownHandler(float x, float y)
        {
            var shapes = scene.FindShapes(x, y, eps);
            if (shapes.Count > 0)
            {
                LastX = x;
                LastY = y;
                r = shapes[shapes.Count];
            }
        }

        public void MouseMoveHandler(float x, float y)
        {
            if (r != null)
            {
                r.MoveBy(x - LastX, y - LastY);
                LastX = x;
                LastY = y;
                application.Invalidate();
            }
        }

        public void MouseUpHandler(float x, float y)
        {
            r.MoveBy(x - LastX, y - LastY);
            LastX = x;
            LastY = y;
            r = null;
            application.Invalidate();
        }
    }
}
