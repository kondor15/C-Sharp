using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    interface ICommand
    {
        void MouseDownHandler(float x, float y);
        void MouseUpHandler(float x, float y);
        void MouseMoveHandler(float x, float y);
    }
}
