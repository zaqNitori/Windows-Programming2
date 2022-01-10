using System.Drawing;

namespace DrawingModel.Shape
{
    public interface IShape
    {
        // 繪製圖形 - 外框
        void Draw(IGraphics graphics);

        // 繪製圖形 - 外框
        void Draw(IGraphics graphics, ShapeType shapeType);

        // 繪製圖形 - 填滿
        void Fill(IGraphics graphics);

        // 判斷是否選到圖片
        bool IsPointCoverd(double x1, double y1);

        // 設定底部 右邊
        void SetBottomRight(double x2, double y2);

        // 設定top left
        void SetTopLeft(double x1, double y1);

        // 設定 shift point
        void SetShiftAmount(double pointX, double pointY);

        // 設定連接的圖形
        void SetConnectedShape(IShape shape1, IShape shape2);

        //取得 X軸 中心點
        double GetCenterPointX();

        //取得 Y軸 中心點
        double GetCenterPointY();
    }
}
