using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Shape
{
    public class Line : IShape
    {
        public Line(double x1, double y1, double x2, double y2)
        {
            Y1 = y1;
            X1 = x1;
            Y2 = y2;
            X2 = x2;
        }

        public double X1
        {
            get; set;
        }

        public double Y1
        {
            get; set;
        }

        public double X2
        {
            get; set;
        }

        public double Y2
        {
            get; set;
        }

        public IShape Shape1
        {
            get; set;
        }

        public IShape Shape2
        {
            get; set;
        }

        // 繪圖 - 外框
        public void Draw(IGraphics graphics)
        {
            graphics.DrawLine(X1, Y1, X2, Y2);
        }

        // 繪圖 - 填滿
        public void Fill(IGraphics graphics)
        {
            double shapeX1 = Shape1.GetCenterPointX();
            double shapeY1 = Shape1.GetCenterPointY();
            double shapeX2 = Shape2.GetCenterPointX();
            double shapeY2 = Shape2.GetCenterPointY();
            graphics.DrawLine(shapeX1, shapeY1, shapeX2, shapeY2);
            //throw new NotImplementedException(nameof(Line) + CommonString.LINE_EXCEPTION);
        }

        // 判斷是否 覆蓋 點
        public bool IsPointCoverd(double x1, double y1)
        {
            return false;
            //throw new NotImplementedException(nameof(Line) + CommonString.IS_POINT_COVERD_NOT_IMPLEMENT);
        }

        //取得 X軸 中心點
        public double GetCenterPointX()
        {
            return (X1 + X2) / 2;
        }

        //取得 Y軸 中心點
        public double GetCenterPointY() 
        {
            return (Y1 + Y2) / 2;
        }

        // 設定底部右邊
        public void SetBottomRight(double x2, double y2)
        {
            X2 = x2;
            Y2 = y2;
        }

        // 設定連接的圖形
        public void SetConnectedShape(IShape shape1, IShape shape2)
        {
            Shape1 = shape1;
            Shape2 = shape2;
        }

    }
}
