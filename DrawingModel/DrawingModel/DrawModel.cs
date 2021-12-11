using DrawingModel.Shape;
using System.Collections.Generic;

namespace DrawingModel
{
    public class DrawModel
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        ShapeFactory _shapeFactory;
        double _firstPointX;
        double _firstPointY;
        bool _isPressed = false;
        List<IShape> _shapes = new List<IShape>();
        IShape _hint;

        public DrawModel()
        {
            _shapeFactory = new ShapeFactory(ShapeType.None);
        }

        //設定繪製圖形
        public void SetShapeType(ShapeType shapeType)
        {
            _shapeFactory.DrawShapeType = shapeType;
        }

        // 按下滑鼠
        public void HandlePointerPressed(double pointX, double pointY)
        {
            bool isShape = _shapeFactory.DrawShapeType != ShapeType.None;
            if (pointX > 0 && pointY > 0 && isShape)
            {
                _firstPointX = pointX;
                _firstPointY = pointY;
                _hint = _shapeFactory.BuildShape(pointX, pointY);
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
                IShape shape = _shapeFactory.BuildShape(_firstPointX, _firstPointY, pointX, pointY);
                _shapes.Add(shape);
                NotifyModelChanged();
            }
        }

        // 清空畫面
        public void Clear()
        {
            _isPressed = false;
            _shapeFactory.DrawShapeType = ShapeType.None;
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
