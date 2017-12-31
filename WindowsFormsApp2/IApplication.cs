using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    interface IApplication
    {
        Color MainColor { get; }
        Color SecondaryColor { get; }

        void Invalidate();
    }
}
