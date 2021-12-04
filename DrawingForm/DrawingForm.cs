using System;
using System.Windows.Forms;
using DrawingModel;
using DrawingForm.PresentationModel;
using DrawingModel.Shape;

namespace DrawingForm
{
    public partial class DrawingForm : Form
    {
        DrawModel _model;
        DrawingFormPresentationModel _presentationModel;
        Panel _canvas;

        public DrawingForm()
        {
            InitializeComponent();
            InitializeCanvas();
            InitializeButton();
            InitializePresentationModel();
        }

        // 初始化 畫布
        private void InitializeCanvas()
        {
            _canvas = new DoubleBufferedPanel();
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = System.Drawing.Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPointerPressed;
            _canvas.MouseUp += HandleCanvasPointerReleased;
            _canvas.MouseMove += HandleCanvasPointerMoved;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);
        }

        // 初始化 Button
        private void InitializeButton()
        {
            _buttonClear.Top = _buttonDrawEllipse.Top = _buttonDrawRectangle.Top = 0;
            _buttonClear.Click += HandleClearButtonClick;
            _buttonDrawEllipse.Click += HandleDrawEllipseButtonClick;
            _buttonDrawRectangle.Click += HandleDrawRectangleButtonClick;
        }

        // 初始化 PresentationModel
        private void InitializePresentationModel()
        {
            _model = new DrawModel();
            _presentationModel = new DrawingFormPresentationModel(_model, _canvas);
            _presentationModel._modelChanged += HandleModelChanged;
        }

        // 重置畫面按鈕狀態
        private void RefreshButtonStatus()
        {
            _buttonClear.Enabled = _presentationModel.IsButtonClearEnabled;
            _buttonDrawEllipse.Enabled = _presentationModel.IsButtonDrawEllipseEnabled;
            _buttonDrawRectangle.Enabled = _presentationModel.IsButtonDrawRectangleEnabled;
        }

        // 處理 清除按鈕點擊 事件
        public void HandleClearButtonClick(object sender, EventArgs e)
        {
            _presentationModel.Clear();
            _presentationModel.IsButtonDrawEllipseEnabled = true;
            _presentationModel.IsButtonDrawRectangleEnabled = true;
            RefreshButtonStatus();
        }

        // 處理 清除按鈕點擊 事件
        public void HandleDrawRectangleButtonClick(object sender, EventArgs e)
        {
            _presentationModel.DrawShpaeType(ShapeType.Rectangle);
            _presentationModel.IsButtonDrawRectangleEnabled = false;
            _presentationModel.IsButtonDrawEllipseEnabled = true;
            RefreshButtonStatus();
        }

        // 處理 清除按鈕點擊 事件
        public void HandleDrawEllipseButtonClick(object sender, EventArgs e)
        {
            _presentationModel.DrawShpaeType(ShapeType.Ellipse);
            _presentationModel.IsButtonDrawEllipseEnabled = false;
            _presentationModel.IsButtonDrawRectangleEnabled = true;
            RefreshButtonStatus();
        }

        // 處理畫布 滑鼠點擊事件
        public void HandleCanvasPointerPressed(object sender, MouseEventArgs e)
        {
            _presentationModel.PointerPressed(e.X, e.Y);
        }

        // 處理畫布 滑鼠放開事件
        public void HandleCanvasPointerReleased(object sender, MouseEventArgs e)
        {
            _presentationModel.PointerReleased(e.X, e.Y);
        }

        // 處理畫布 滑鼠移動事件
        public void HandleCanvasPointerMoved(object sender, MouseEventArgs e)
        {
            _presentationModel.PointerMoved(e.X, e.Y);
        }

        // 處理畫布繪製事件
        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        // 處理 同步通知
        public void HandleModelChanged()
        {
            Invalidate(true);
        }

    }
}
