using DrawingModel.Shape;
using System.Collections.Generic;

namespace DrawingModel
{
    public class DrawModel
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        double _firstPointX;
        double _firstPointY;
        bool _isPressed = false;
        List<IShape> _shapes = new List<IShape>();
        IShape _hint;

        public DrawModel()
        {
            DrawShapeType = ShapeType.None;
        }

        public ShapeType DrawShapeType
        {
            get; set;
        }

        // 按下滑鼠
        public void HandlePointerPressed(double pointX, double pointY)
        {
            if (pointX > 0 && pointY > 0 && DrawShapeType != ShapeType.None)
            {
                _firstPointX = pointX;
                _firstPointY = pointY;
                _hint = BuildShape(pointX, pointY);
                _isPressed = true;
            }
        }

        // 滑鼠移動
        public void HandlePointerMoved(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _hint.SetRight(pointX);
                _hint.SetBottom(pointY);
                NotifyModelChanged();
            }
        }

        // 滑鼠放開
        public void HandlePointerReleased(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _isPressed = false;
                IShape shape = BuildShape(pointX, pointY);
                _shapes.Add(shape);
                NotifyModelChanged();
            }
        }

        // 根據選取項目，建立圖形
        private IShape BuildShape(double pointX, double pointY)
        {
            IShape shape = null;
            switch (DrawShapeType)
            {
                case ShapeType.Rectangle:
                    shape = new Rectangle(_firstPointX, _firstPointY, pointX, pointY);
                    break;
                case ShapeType.Ellipse:
                    shape = new Ellipse(_firstPointX, _firstPointY, pointX, pointY);
                    break;
            }
            return shape;
        }

        // 清空畫面
        public void Clear()
        {
            _isPressed = false;
            DrawShapeType = ShapeType.None;
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
