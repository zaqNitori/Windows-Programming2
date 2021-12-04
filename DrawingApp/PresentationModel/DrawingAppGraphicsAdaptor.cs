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
            InitializeShape(rectangle, (int)x1, (int)y1, (int)x2, (int)y2, new SolidColorBrush(Colors.Blue));
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(rectangle);

        }

        // <summary>
        /// 畫圓
        /// </summary>
        public void DrawEllipse(double x1, double y1, double x2, double y2)
        {
            Rectangle rectangle = new Rectangle();
            InitializeShape(rectangle, (int)x1, (int)y1, (int)x2, (int)y2, new SolidColorBrush(Colors.Blue));
        }

        /// <summary>
        /// 初始化圖形
        /// </summary>
        private Shape InitializeShape(Shape shape, int left, int top, int right, int bottom, SolidColorBrush fillColorBrush)
        {
            shape.Margin = new Thickness(left, top, right, bottom);
            shape.Width = right - left;
            shape.Height = bottom - top;
            shape.Fill = fillColorBrush;
            return shape;
        }

    }
}
