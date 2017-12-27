using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Scene
    {
        protected List<Rect> shapes = new List<Rect>();
        
        public void DrawOn(Graphics t)
        {
            foreach (var s in shapes)
                s.DrawOn(t);
        }

        public List<Rect> FindShapes(float x, float y, float eps)
        {
            var result = new List<Rect>();
            foreach (var s in shapes)
                if (s.Intersects(x, y, eps))
                    result.Add(s);
            return result;
        }

        public void Add(Rect s)
        {
            shapes.Add(s);
        }
    }
}
