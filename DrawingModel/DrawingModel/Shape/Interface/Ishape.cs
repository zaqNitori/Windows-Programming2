using System.Drawing;

namespace DrawingModel.Shape
{
    public interface IShape
    {
        // 繪製圖形 - 外框
        void Draw(IGraphics graphics);

        // 繪製圖形 - 填滿
        void Fill(IGraphics graphics);

        // 判斷是否選到圖片
        bool IsPointCoverd(double x1, double y1);

        // 設定底部
        void SetBottom(double y2);

        // 設定右邊
        void SetRight(double x2);

    }
}
