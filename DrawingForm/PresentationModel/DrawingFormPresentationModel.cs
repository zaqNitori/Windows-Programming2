using DrawingModel;
using System.Windows.Forms;
using DrawingModel.Shape;

namespace DrawingForm.PresentationModel
{
    class DrawingFormPresentationModel
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        DrawModel _model;

        public DrawingFormPresentationModel(DrawModel model, Control canvas)
        {
            this._model = model;
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
        public void Draw(System.Drawing.Graphics graphics)
        {
            // graphics物件是Paint事件帶進來的，只能在當次Paint使用
            // 而Adaptor又直接使用graphics，這樣DoubleBuffer才能正確運作
            // 因此，Adaptor不能重複使用，每次都要重新new
            _model.Draw(new DrawingFormGraphicsAdaptor(graphics));
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
        public void PointerPressed(int x, int y)
        {
            _model.PointerPressed(x, y);
        }

        // 滑鼠放開
        public void PointerReleased(int x, int y)
        {
            _model.PointerReleased(x, y);
        }

        // 滑鼠移動
        public void PointerMoved(int x, int y)
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
