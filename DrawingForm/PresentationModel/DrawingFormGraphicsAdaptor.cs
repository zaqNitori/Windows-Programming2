using System.Windows.Forms;
using System.Drawing;
using DrawingModel;
using System.Drawing.Drawing2D;

namespace DrawingForm.PresentationModel
{
    public class DrawingFormGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;
        SolidBrush _brush;
        Pen _dashPen;
        const float DASH_PATTERN = 2f;

        public DrawingFormGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
            _brush = new SolidBrush(Color.YellowGreen);
            _dashPen = new Pen(Color.Black);
            _dashPen.DashStyle = DashStyle.Custom;
            _dashPen.DashPattern = new float[] { DASH_PATTERN, DASH_PATTERN };
        }

        // 清除畫布
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        // 畫線
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        // 畫矩形
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            Common.ResetMarginPoint(ref x1, ref y1, ref x2, ref y2);
            _graphics.DrawRectangle(_dashPen, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
        }

        // 畫圓
        public void DrawEllipse(double x1, double y1, double x2, double y2)
        {
            Common.ResetMarginPoint(ref x1, ref y1, ref x2, ref y2);
            _graphics.DrawEllipse(_dashPen, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
        }

        // 畫矩形
        public void FillRectangle(double x1, double y1, double x2, double y2)
        {
            Common.ResetMarginPoint(ref x1, ref y1, ref x2, ref y2);
            _graphics.FillRectangle(_brush, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
        }

        // 畫圓
        public void FillEllipse(double x1, double y1, double x2, double y2)
        {
            Common.ResetMarginPoint(ref x1, ref y1, ref x2, ref y2);
            _graphics.FillEllipse(_brush, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
        }

    }
}
