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
        const float DASH_PATTERN = 2f;

        public DrawingAppGraphicsAdaptor(Canvas canvas)
        {
            this._canvas = canvas;
        }

        // 清除畫布
        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        // 畫線
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

        // 畫矩形
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            Rectangle rectangle = new Rectangle();
            InitializeShape(rectangle, x1, y1, x2, y2);
            InitialShapeBorderStyle(rectangle);
            _canvas.Children.Add(rectangle);
        }

        // 畫圓
        public void DrawEllipse(double x1, double y1, double x2, double y2)
        {
            Ellipse ellipse = new Ellipse();
            InitializeShape(ellipse, x1, y1, x2, y2);
            InitialShapeBorderStyle(ellipse);
            _canvas.Children.Add(ellipse);
        }

        // 畫矩形
        public void FillRectangle(double x1, double y1, double x2, double y2)
        {
            Rectangle rectangle = new Rectangle();
            InitializeShape(rectangle, x1, y1, x2, y2);
            rectangle.Fill = new SolidColorBrush(Colors.Blue);
            _canvas.Children.Add(rectangle);
        }

        // 畫圓
        public void FillEllipse(double x1, double y1, double x2, double y2)
        {
            Ellipse ellipse = new Ellipse();
            InitializeShape(ellipse, x1, y1, x2, y2);
            ellipse.Fill = new SolidColorBrush(Colors.Blue);
            _canvas.Children.Add(ellipse);
        }

        // 初始化圖形
        private Shape InitializeShape(Shape shape, double x1, double y1, double x2, double y2)
        {
            Common.ResetMarginPoint(ref x1, ref y1, ref x2, ref y2);
            shape.Margin = new Thickness(x1, y1, x2, y2);
            shape.Width = x2 - x1;
            shape.Height = y2 - y1;
            return shape;
        }
        
        //設定圖形外框
        private void InitialShapeBorderStyle(Shape shape)
        {
            shape.Stroke = new SolidColorBrush(Colors.Black);
            shape.StrokeDashArray = new DoubleCollection() 
            { 
                DASH_PATTERN 
            };
        }

    }
}
