using System;
using System.Windows.Forms;

namespace DrawingForm
{
    public partial class DrawingForm : Form
    {
        DrawingModel.DrawModel _model;
        PresentationModel.DrawingFormPresentationModel _presentationModel;
        Panel _canvas;

        public DrawingForm()
        {
            // prepare canvas
            _canvas = new DoubleBufferedPanel();
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = System.Drawing.Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPointerPressed;
            _canvas.MouseUp += HandleCanvasPointerReleased;
            _canvas.MouseMove += HandleCanvasPointerMoved;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);

            // prepare clear button
            Button clear = new Button();
            clear.Text = "Clear";
            clear.Dock = DockStyle.Top;
            clear.AutoSize = true;
            clear.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            clear.Click += HandleClearButtonClick;
            Controls.Add(clear);

            // prepare presentation model and model
            _model = new DrawingModel.DrawModel();
            _presentationModel = new PresentationModel.DrawingFormPresentationModel(_model, _canvas);
            _model._modelChanged += HandleModelChanged;
        }

        /// <summary>
        /// 處理畫面清除事件
        /// </summary>
        public void HandleClearButtonClick(object sender, EventArgs e)
        {
            _model.Clear();
        }

        /// <summary>
        /// 處理畫布 滑鼠點擊事件
        /// </summary>
        public void HandleCanvasPointerPressed(object sender, MouseEventArgs e)
        {
            _model.PointerPressed(e.X, e.Y);
        }

        /// <summary>
        /// 處理畫布 滑鼠放開事件
        /// </summary>
        public void HandleCanvasPointerReleased(object sender, MouseEventArgs e)
        {
            _model.PointerReleased(e.X, e.Y);
        }

        /// <summary>
        /// 處理畫布 滑鼠移動事件
        /// </summary>
        public void HandleCanvasPointerMoved(object sender, MouseEventArgs e)
        {
            _model.PointerMoved(e.X, e.Y);
        }

        /// <summary>
        /// 處理畫布繪製事件
        /// </summary>
        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        /// <summary>
        /// 處理 同步通知
        /// </summary>
        public void HandleModelChanged()
        {
            Invalidate(true);
        }

    }
}
