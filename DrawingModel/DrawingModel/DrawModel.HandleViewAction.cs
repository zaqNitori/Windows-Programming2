using DrawingModel.Command;
using DrawingModel.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    partial class DrawModel
    {
        // 按下滑鼠
        public void HandlePointerPressed(double pointX, double pointY)
        {
            if (pointX > 0 && pointY > 0)
            {
                if (_shapeFactory.DrawShapeType != ShapeType.None)
                {
                    SetShapeAttribute(pointX, pointY);
                }
                else
                {
                    if ((_isSelected = SelectShape(pointX, pointY, ref _selectedShape)) == true)
                        NotifyModelChanged();
                }
            }
        }

        // 暫存 Shape 所需變數
        private void SetShapeAttribute(double pointX, double pointY)
        {
            _firstPointX = pointX;
            _firstPointY = pointY;
            _isPressed = true;
            if (_shapeFactory.DrawShapeType.Equals(ShapeType.Line))
            {
                _isPressed = SelectShape(pointX, pointY, ref _selectedShape);
            }
            _hint = _shapeFactory.BuildShape(pointX, pointY);
        }

        // 判斷是否有選到圖形
        private bool SelectShape(double pointX, double pointY, ref IShape shape)
        {
            for (var i = _shapes.Count - 1; i >= 0; i--)
            {
                if (_shapes[i].IsPointCoverd(pointX, pointY))
                {
                    shape = _shapes[i];
                    return true;
                }
            }
            return false;
        }

        // 滑鼠移動
        public void HandlePointerMoved(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _hint.SetBottomRight(pointX, pointY);
                NotifyModelChanged();
            }
        }

        // 滑鼠放開
        public void HandlePointerReleased(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _isPressed = false;
                ExecuteShape(pointX, pointY);
                SetShapeType(ShapeType.None);
                NotifyModelChanged();
            }
        }

        // 將 Shape 加入 繪製List
        private void ExecuteShape(double pointX, double pointY)
        {
            IShape shape = _shapeFactory.BuildShape(_firstPointX, _firstPointY, pointX, pointY);
            if (_shapeFactory.DrawShapeType.Equals(ShapeType.Line))
            {
                IShape selectShape2 = null;
                if (SelectShape(pointX, pointY, ref selectShape2))
                {
                    if (_selectedShape.Equals(selectShape2)) 
                        return;
                    shape.SetConnectedShape(_selectedShape, selectShape2);
                }
                else
                    return;
            }
            _commandManager.Execute(new DrawCommand(this, shape));
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

    }
}
