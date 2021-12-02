using System.Windows.Forms;
using System.Drawing;
using DrawingModel;

namespace DrawingForm.PresentationModel
{
    class DrawingFormGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;

        public DrawingFormGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        /// <summary>
        /// 清除畫布
        /// </summary>
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        /// <summary>
        /// 畫線
        /// </summary>
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        /// <summary>
        /// 畫矩形
        /// </summary>
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawRectangle(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);

        }
    }
}
