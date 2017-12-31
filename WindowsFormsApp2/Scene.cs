using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    class Scene
    {
        protected List<Rect> shapes = new List<Rect>();
        protected List<Circle> shape = new List<Circle>();
        protected List<Line> shap = new List<Line>();
         
        
        public void DrawOn(Graphics t)
        {
           
            foreach (var s in shapes)
                s.DrawOn(t);
            foreach (var p in shape)
                p.DrawOn(t);
            foreach (var s in shap)
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
        public List<Circle> FindShape(float x, float y, float eps)
        {
            var result = new List<Circle>();
            foreach (var s in shape)
                if (s.Intersects(x, y, eps))
                    result.Add(s);
            return result;
        }
        public List<Line> FindShap(float x, float y, float eps)
        {
            var result = new List<Line>();
            foreach (var s in shap)
                if (s.Intersects(x, y, eps))
                    result.Add(s);
            return result;
        }

        public void Add(Rect s)
        {
            shapes.Add(s);
        }

        public void Add(Circle c)
        {
            shape.Add(c);
        }
        public void Add(Line l)
        {
            shap.Add(l);
        }

        public void RemoveR(Rect s)
        {
            shapes.RemoveRange(0, shapes.Count);
        }

        public void RemoveC(Circle c)
        {
            shape.RemoveRange(0, shape.Count);
            
        }
        public void RemoveL (Line e)
        {
            shap.RemoveRange(0, shap.Count);

        }
    }
}
