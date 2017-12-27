using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class RectCommand:ICommand
    {
        bool active;
        Scene scene;
        IApplication application;
        Rect r;
        float StartX, StartY;

        public RectCommand(IApplication app, Scene s)
        {
            scene = s;
            application = app;

        }

        public void MouseDownHandler(float x, float y)
        {
            StartX = x;
            StartY = y;
            active = true;
            r = new Rect()
            {
                X = x,
                Y = y,
                Width = 0,
                Height = 0,
                FillColor = application.SecondaryColor,
                OutLineColor = application.MainColor
            };
            scene.Add(r);
        }

        public void MouseMoveHandler(float x, float y)
        {
            if (active != false)
            {
                

                float xMin = Math.Min(StartX, x);
                float yMin = Math.Min(StartY, y);
                float xMax = Math.Max(StartX, x);
                float yMax = Math.Max(StartY, y);
                r = new Rect()
                {
                    X = xMin,
                    Y = yMin,
                    Width = xMax-xMin,
                    Height = yMax-yMin,
                    FillColor = application.SecondaryColor,
                    OutLineColor = application.MainColor
                };
                scene.Add(r);
                
                
            }
           
        }

        public void MouseUpHandler(float x, float y)
        {
            active = false;
        }
    }
}
