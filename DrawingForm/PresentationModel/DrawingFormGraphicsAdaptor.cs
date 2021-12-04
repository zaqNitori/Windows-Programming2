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
            RefactorMarginPoint(ref x1, ref y1, ref x2, ref y2);
            _graphics.DrawRectangle(Pens.Black, (float)x1, (float)y1, (float)(x2-x1), (float)(y2-y1));
        }

        /// <summary>
        /// 畫圓
        /// </summary>
        public void DrawEllipse(double x1, double y1, double x2, double y2)
        {
            RefactorMarginPoint(ref x1, ref y1, ref x2, ref y2);
            _graphics.DrawEllipse(Pens.Black, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
        }

        // 判斷座標是否需要轉換
        private void RefactorMarginPoint(ref double x1, ref double y1, ref double x2, ref double y2)
        {
            if (x1 > x2)
            {
                Common.Swap<double>(ref x1, ref x2);
            }

            if (y1 > y2)
            {
                Common.Swap<double>(ref y1, ref y2);
            }
        }

    }
}
