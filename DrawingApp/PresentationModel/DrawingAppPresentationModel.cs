using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using DrawingModel;
using DrawingModel.Shape;

namespace DrawingApp.PresentationModel
{
    class DrawingAppPresentationModel
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        DrawModel _model;
        IGraphics _iGraphics;

        public DrawingAppPresentationModel(DrawModel model, Canvas canvas)
        {
            this._model = model;
            _iGraphics = new DrawingAppGraphicsAdaptor(canvas);
            _model._modelChanged += NotifyModelChanged;
            _model._stateChanged += HandleStateChanged;
            IsButtonDrawLineEnabled = IsButtonClearEnabled = IsButtonDrawEllipseEnabled = IsButtonDrawRectangleEnabled = true;
        }

        public string SelectedLabelText
        {
            get
            {
                return _model.GetSelectedString();
            }
        }

        public bool IsButtonDrawLineEnabled
        {
            get; set;
        }

        public bool IsButtonClearEnabled
        {
            get; set;
        }

        public bool IsButtonDrawRectangleEnabled
        {
            get; set;
        }

        public bool IsButtonDrawEllipseEnabled
        {
            get; set;
        }

        public bool IsButtonUndoEnabled
        {
            get
            {
                return _model.IsButtonUndoEnabled;
            }
        }

        public bool IsButtonRedoEnabled
        {
            get
            {
                return _model.IsButtonRedoEnabled;
            }
        }

        // 繪製
        public void Draw()
        {
            // 重複使用igraphics物件
            _model.Draw(_iGraphics);
        }

        // 清除畫布
        public void Clear()
        {
            _model.Clear();
        }

        // 設定 要繪製的圖形
        public void SetDrawShapeType(ShapeType shapeType)
        {
            _model.SetShapeType(shapeType);
        }

        // 滑鼠點擊
        public void HandlePointerPressed(double x1, double y1)
        {
            _model.HandlePointerPressed(x1, y1);
        }

        // 滑鼠放開
        public void HandlePointerReleased(double x1, double y1)
        {
            _model.HandlePointerReleased(x1, y1);
        }

        // 滑鼠移動
        public void HandlePointerMoved(double x1, double y1)
        {
            _model.HandlePointerMoved(x1, y1);
        }

        //Handle Redo Event
        public void HandleRedo()
        {
            _model.HandleRedo();
        }

        //Handle Undo Event
        public void HandleUndo()
        {
            _model.HandleUndo();
        }

        // 同步通知
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        // 動作狀態改變
        void HandleStateChanged()
        {
            IsButtonDrawEllipseEnabled = IsButtonDrawRectangleEnabled = IsButtonDrawLineEnabled = true;
        }

    }
}
