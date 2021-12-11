using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel.Shape;

namespace DrawingModel
{
    public class ShapeFactory
    {

        public ShapeFactory(ShapeType shapeType)
        {
            DrawShapeType = shapeType;
        }

        public ShapeType DrawShapeType
        {
            get; set;
        }

        // 根據選取項目，建立圖形
        public IShape BuildShape(double x1, double y1)
        {
            string shape = DrawShapeType.ToString();
            var type = typeof(IShape).Assembly
                                    .GetTypes()
                                    .Single(child => child.Name == shape);
            var instance = (IShape)Activator.CreateInstance(type, new object[] { x1, y1, x1, y1 });
            return instance;
        }

        // 根據選取項目，建立圖形
        public IShape BuildShape(double x1, double y1, double x2, double y2)
        {
            string shape = DrawShapeType.ToString();
            var type = typeof(IShape).Assembly
                                    .GetTypes()
                                    .Single(child => child.Name == shape);
            var instance = (IShape)Activator.CreateInstance(type, new object[] { x1, y1, x2, y2});
            return instance;
        }

    }
}
