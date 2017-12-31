using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    class LineCommand : ICommand
    {
        bool active;
        Scene scene;
        IApplication application;
        Line e;
        float StartX, StartY;

        public LineCommand(IApplication app, Scene s)
        {
            scene = s;
            application = app;

        }

        public void MouseDownHandler(float x, float y)
        {
            StartX = x;
            StartY = y;
            active = true;
            e = new Line()
            {
                X = x,
                Y = y,
                X1 = x,
                Y1 = y,
                OutLineColor = application.MainColor
            };
            scene.Add(e);
        }

        public void MouseMoveHandler(float x, float y)
        {

            if (active != false)
            {
                //float xMin = Math.Min(StartX, x);
                //float yMin = Math.Min(StartY, y);
                //float xMax = Math.Max(StartX, x);
                //float yMax = Math.Max(StartY, y);

                e.X1 = x;
                e.Y1 = y;
                application.Invalidate();
            }
        }

        public void MouseUpHandler(float x, float y)
        {
            active = false;
            application.Invalidate();
        }
    }
}
