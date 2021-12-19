using DrawingModel;
using System.Windows.Forms;
using DrawingModel.Shape;

namespace DrawingForm.PresentationModel
{
    public class DrawingFormPresentationModel
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        DrawModel _model;

        public DrawingFormPresentationModel(DrawModel model)
        {
            this._model = model;
            _model._modelChanged += NotifyModelChanged;
            IsButtonClearEnabled = IsButtonDrawEllipseEnabled = IsButtonDrawRectangleEnabled = true;
            IsButtonUndoEnabled = IsButtonRedoEnabled = false;
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
            get; set;
        }

        public bool IsButtonRedoEnabled
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
        public void SetDrawShapeType(ShapeType shapeType)
        {
            _model.SetShapeType(shapeType);
        }

        // 滑鼠點擊
        public void HandlePointerPressed(int x1, int y1)
        {
            _model.HandlePointerPressed(x1, y1);
        }

        // 滑鼠放開
        public void HandlePointerReleased(int x1, int y1)
        {
            _model.HandlePointerReleased(x1, y1);
        }

        // 滑鼠移動
        public void HandlePointerMoved(int x1, int y1)
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

    }
}
