using System.Drawing;

namespace DrawingModel.Shape
{
    public class Rectangle : IShape
    {

        public Rectangle(double x1, double y1, double x2, double y2)
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

        // 繪圖
        public void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(X1, Y1, X2, Y2);
        }

        // 設定底部
        public void SetBottom(double y2)
        {
            Y2 = y2;
        }

        // 設定右邊
        public void SetRight(double x2)
        {
            X2 = x2;
        }

    }
}
