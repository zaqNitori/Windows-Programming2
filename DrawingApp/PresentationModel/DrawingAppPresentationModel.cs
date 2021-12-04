﻿using System;
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
        IGraphics _igraphics;

        public DrawingAppPresentationModel(DrawModel model, Canvas canvas)
        {
            this._model = model;
            _igraphics = new DrawingAppGraphicsAdaptor(canvas);
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
            _model.Draw(_igraphics);
        }

        // 清除畫布
        public void Clear()
        {
            _model.Clear();
        }

        // 設定 要繪製的圖形
        public void DrawShpaeType(ShapeType shapeType)
        {
            _model.DrawShapeType = shapeType;
        }

        // 滑鼠點擊
        public void PointerPressed(double x, double y)
        {
            _model.PointerPressed(x, y);
        }

        // 滑鼠放開
        public void PointerReleased(double x, double y)
        {
            _model.PointerReleased(x, y);
        }

        // 滑鼠移動
        public void PointerMoved(double x, double y)
        {
            _model.PointerMoved(x, y);
        }

        // 同步通知
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

    }
}
