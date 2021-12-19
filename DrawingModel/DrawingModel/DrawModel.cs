using DrawingModel.Shape;
using System.Collections.Generic;
using DrawingModel.Command;

namespace DrawingModel
{
    public class DrawModel
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();

        double _firstPointX;
        double _firstPointY;
        bool _isPressed = false;

        DrawCommandManager _commandManager;
        ShapeFactory _shapeFactory;
        List<IShape> _shapes;
        IShape _hint;

        public DrawModel()
        {
            _shapeFactory = new ShapeFactory(ShapeType.None);
            _commandManager = new DrawCommandManager();
            _shapes = new List<IShape>();
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
                _commandManager.Execute(new DrawCommand(this, shape));
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

        //Handle Redo Event
        public void HandleRedo()
        {
            _commandManager.Redo();
        }

        //Handle Undo Event
        public void HandleUndo()
        {
            _commandManager.Undo();
        }

        //Insert shape
        public void InsertShape(IShape shape)
        {
            _shapes.Add(shape);
        }

        //Delete Last insert shape
        public void DeleteShape()
        {
            _shapes.RemoveAt(_shapes.Count - 1);
        }

        // 同步通知
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }

}
