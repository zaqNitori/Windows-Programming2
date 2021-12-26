using DrawingModel.Shape;
using System.Collections.Generic;
using DrawingModel.Command;

namespace DrawingModel
{
    public partial class DrawModel
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

        // 圖形選取資訊
        public string GetSelectedString()
        {
            return _isSelected ? CommonString.SELECTED_INFO + _selectedShape.ToString() : string.Empty;
        }

        //設定繪製圖形
        public void SetShapeType(ShapeType shapeType)
        {
            _shapeFactory.DrawShapeType = shapeType;
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
