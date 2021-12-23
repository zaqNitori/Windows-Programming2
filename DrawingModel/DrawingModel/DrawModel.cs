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
        bool _isSelected = false;

        DrawCommandManager _commandManager;
        ShapeFactory _shapeFactory;
        List<IShape> _shapes;
        IShape _selectedShape;
        IShape _hint;

        public DrawModel()
        {
            _shapeFactory = new ShapeFactory(ShapeType.None);
            _commandManager = new DrawCommandManager();
            _shapes = new List<IShape>();
        }

        public bool IsButtonUndoEnabled
        {
            get
            {
                return _commandManager.IsButtonUndoEnabled;
            }
        }

        public bool IsButtonRedoEnabled
        {
            get
            {
                return _commandManager.IsButtonRedoEnabled;
            }
        }

        //設定繪製圖形
        public void SetShapeType(ShapeType shapeType)
        {
            _shapeFactory.DrawShapeType = shapeType;
        }

        // 按下滑鼠
        public void HandlePointerPressed(double pointX, double pointY)
        {
            if (pointX > 0 && pointY > 0)
            {
                if (_shapeFactory.DrawShapeType != ShapeType.None) 
                {
                    _firstPointX = pointX;
                    _firstPointY = pointY;
                    _hint = _shapeFactory.BuildShape(pointX, pointY);
                    _isPressed = true;
                }
                else
                {
                    _selectedShape = SelectShape(pointX, pointY);
                    if (_isSelected)
                        NotifyModelChanged();
                }
            }
        }

        // 判斷是否有選到圖形
        private IShape SelectShape(double pointX, double pointY)
        {
            for (var i = _shapes.Count - 1; i >= 0; i--)
            {
                if (_shapes[i].IsPointCoverd(pointX, pointY))
                {
                    _isSelected = true;
                    return _shapes[i];
                }
            }
            _isSelected = false;
            return null;
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
            _isSelected = _isPressed = false;
            _shapeFactory.DrawShapeType = ShapeType.None;
            _shapes.Clear();
            _commandManager.Clear();
            NotifyModelChanged();
        }

        // 繪圖
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (var shape in _shapes)
                shape.Fill(graphics);
            if (_isPressed)
                _hint.Draw(graphics);
            if (_isSelected)
                _selectedShape.Draw(graphics);
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
            int last = _shapes.Count - 1;
            if (_shapes.LastIndexOf(_selectedShape) == last)
            {
                _isSelected = false;
                _selectedShape = null;
            }
            _shapes.RemoveAt(last);
        }

        // 同步通知
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }

}
