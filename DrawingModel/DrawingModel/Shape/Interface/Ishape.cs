using System.Drawing;

namespace DrawingModel.Shape
{
    interface Ishape
    {
        // 繪製圖形
        void Draw(IGraphics graphics);

        // 設定底部
        void SetBottom(double y2);

        // 設定右邊
        void SetRight(double x2);
    }
}
