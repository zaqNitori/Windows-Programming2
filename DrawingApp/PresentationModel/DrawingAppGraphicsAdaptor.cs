using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using DrawingModel;
using Windows.UI.Xaml;

namespace DrawingApp.PresentationModel
{
    class DrawingAppGraphicsAdaptor : IGraphics
    {
        Canvas _canvas;
        public DrawingAppGraphicsAdaptor(Canvas canvas)
        {
            this._canvas = canvas;
        }

        /// <summary>
        /// 清除畫布
        /// </summary>
        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        /// <summary>
        /// 畫線
        /// </summary>
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(line);
        }

        /// <summary>
        /// 畫矩形
        /// </summary>
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            Rectangle rectangle = new Rectangle();
            InitializeShape(rectangle, x1, y1, x2, y2, new SolidColorBrush(Colors.Blue));
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(rectangle);

        }

        // <summary>
        /// 畫圓
        /// </summary>
        public void DrawEllipse(double x1, double y1, double x2, double y2)
        {
            Ellipse ellipse = new Ellipse();
            InitializeShape(ellipse, x1, y1, x2, y2, new SolidColorBrush(Colors.Blue));
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(ellipse);
        }

        /// <summary>
        /// 初始化圖形
        /// </summary>
        private Shape InitializeShape(Shape shape, double x1, double y1, double x2, double y2, SolidColorBrush fillColorBrush)
        {
            RefactorMarginPoint(ref x1, ref y1, ref x2, ref y2);
            shape.Margin = new Thickness(x1, y1, x2, y2);
            shape.Width = x2 - x1;
            shape.Height = y2 - y1;
            shape.Fill = fillColorBrush;
            return shape;
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
