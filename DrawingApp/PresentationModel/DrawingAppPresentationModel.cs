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
            IsButtonClearEnabled = IsButtonDrawEllipseEnabled = IsButtonDrawRectangleEnabled = true;
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
            _model.DrawShapeType = shapeType;
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

        // 同步通知
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

    }
}
