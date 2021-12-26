using System;
using System.Drawing;

namespace DrawingModel.Shape
{
    public class Rectangle : IShape
    {

        public Rectangle(double x1, double y1, double x2, double y2)
        {
            Common.ResetMarginPoint(ref x1, ref y1, ref x2, ref y2);
            Y1 = y1;
            X1 = x1;
            Y2 = y2;
            X2 = x2;
            IsChecked = false;
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

        public bool IsChecked
        {
            get; set;
        }

        // 繪圖 - 外框
        public void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(X1, Y1, X2, Y2);
        }

        // 繪圖 - 外框
        public void Draw(IGraphics graphics, ShapeType shapeType)
        {
            if (shapeType.Equals(ShapeType.Rectangle))
                this.Draw(graphics);
        }

        // 繪圖 - 填滿
        public void Fill(IGraphics graphics)
        {
            graphics.FillRectangle(X1, Y1, X2, Y2);
        }

        // 判斷是否 覆蓋 點
        public bool IsPointCoverd(double x1, double y1)
        {
            if (x1 >= X1 && x1 <= X2
                && y1 >= Y1 && y1 <= Y2)
            {
                IsChecked = true;
                return true;
            }
            return false;
        }

        // 格式化字串
        public override string ToString()
        {
            return nameof(Rectangle) + CommonString.FRONT_BRACKET_SMALL
                + ((int)X1).ToString() + CommonString.COMMA + CommonString.SPACE
                + ((int)Y1).ToString() + CommonString.COMMA + CommonString.SPACE
                + ((int)X2).ToString() + CommonString.COMMA + CommonString.SPACE
                + ((int)Y2).ToString() + CommonString.BACK_BRACKET_SMALL;
        }

        //取得 X軸 中心點
        public double GetCenterPointX()
        {
            return Common.GetAverage(X1, X2);
        }

        //取得 Y軸 中心點
        public double GetCenterPointY()
        {
            return Common.GetAverage(Y1, Y2);
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
            throw new NotImplementedException(nameof(Rectangle) + CommonString.SET_CONNECTED_SHAPE_NOT_IMPLEMENT);
        }

    }
}
