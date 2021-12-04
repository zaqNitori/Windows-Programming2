using DrawingModel.Shape;
using System.Collections.Generic;

namespace DrawingModel
{
    class DrawModel
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        double _firstPointX;
        double _firstPointY;
        bool _isPressed = false;
        List<Ishape> _shapes = new List<Ishape>();
        Ishape _hint;

        public ShapeType DrawShapeType
        {
            get; set;
        }

        // 按下滑鼠
        public void PointerPressed(double x, double y)
        {
            if (x > 0 && y > 0)
            {
                _firstPointX = x;
                _firstPointY = y;
                _hint = BuildShape(x, y);
                _isPressed = true;
            }
        }

        // 滑鼠移動
        public void PointerMoved(double x, double y)
        {
            if (_isPressed)
            {
                _hint.SetRight(x);
                _hint.SetBottom(y);
                NotifyModelChanged();
            }
        }

        // 滑鼠放開
        public void PointerReleased(double x, double y)
        {
            if (_isPressed)
            {
                _isPressed = false;
                Ishape shape = BuildShape(x, y);
                _shapes.Add(shape);
                NotifyModelChanged();
            }
        }

        // 根據選取項目，建立圖形
        private Ishape BuildShape(double x, double y)
        {
            if (DrawShapeType.Equals(ShapeType.Rectangle))
            {
                return new Rectangle(_firstPointX, _firstPointY, x, y);
            }
            else
            {
                return new Ellipse(_firstPointX, _firstPointY, x, y);
            }
        }

        // 清空畫面
        public void Clear()
        {
            _isPressed = false;
            _shapes.Clear();
            NotifyModelChanged();
        }

        // 繪圖
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (var shape in _shapes)
                shape.Draw(graphics);
            if (_isPressed)
                _hint.Draw(graphics);
        }

        // 同步通知
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }

}
