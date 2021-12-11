using System.Drawing;

namespace DrawingModel.Shape
{
    public interface IShape
    {
        // 繪製圖形
        void Draw(IGraphics graphics);

        // 設定底部
        void SetBottom(double y2);

        // 設定右邊
        void SetRight(double x2);
    }
}
