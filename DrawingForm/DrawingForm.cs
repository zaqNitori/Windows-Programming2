﻿using System;
using System.Windows.Forms;
using DrawingModel;
using DrawingForm.PresentationModel;
using DrawingModel.Shape;
using System.Reflection;

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
            InitializePresentationModel();
            InitializeCanvas();
            InitializeControl();
            RefreshControlStatus();
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

        // 初始化 控制向
        private void InitializeControl()
        {
            _selectedLabel.DataBindings.Add(CommonString.ATTRIBUTE_TEXT, _presentationModel, nameof(_presentationModel.SelectedLabelText));
            InitializeButton();
        }

        // 初始化 Button
        private void InitializeButton()
        {
            _buttonDrawLine.Top = _buttonClear.Top = _buttonDrawEllipse.Top = _buttonDrawRectangle.Top = _buttonChoose.Top = _toolStrip.Bottom;
            _buttonClear.Click += HandleClearButtonClick;
            _buttonDrawEllipse.Click += HandleDrawEllipseButtonClick;
            _buttonDrawRectangle.Click += HandleDrawRectangleButtonClick;
            _buttonChoose.Click += HandleChooseButtonClick;
            _buttonDrawLine.Click += HandleDrawLineButtonClick;
            _buttonRedo.Click += HandleRedo;
            _buttonUndo.Click += HandleUndo;
        }

        // 初始化 PresentationModel
        private void InitializePresentationModel()
        {
            _model = new DrawModel();
            _presentationModel = new DrawingFormPresentationModel(_model);
            _presentationModel._modelChanged += HandleModelChanged;
        }

        // 重置畫面控制向狀態
        private void RefreshControlStatus()
        {
            RefreshButtonStatus();
            _selectedLabel.DataBindings[0].ReadValue();
        }

        // 重置畫面按鈕狀態
        private void RefreshButtonStatus()
        {
            _buttonClear.Enabled = _presentationModel.IsButtonClearEnabled;
            _buttonDrawEllipse.Enabled = _presentationModel.IsButtonDrawEllipseEnabled;
            _buttonDrawRectangle.Enabled = _presentationModel.IsButtonDrawRectangleEnabled;
            _buttonRedo.Enabled = _presentationModel.IsButtonRedoEnabled;
            _buttonUndo.Enabled = _presentationModel.IsButtonUndoEnabled;
            _buttonChoose.Enabled = _presentationModel.IsButtonChooseEnabled;
            _buttonDrawLine.Enabled = _presentationModel.IsButtonDrawLineEnabled;
        }

        // 處理 Clear按鈕點擊 事件
        public void HandleClearButtonClick(object sender, EventArgs e)
        {
            _presentationModel.Clear();
            _presentationModel.IsButtonDrawEllipseEnabled = true;
            _presentationModel.IsButtonDrawRectangleEnabled = true;
            _presentationModel.IsButtonChooseEnabled = true;
            RefreshControlStatus();
        }

        // 處理 Line按鈕點擊 事件
        public void HandleDrawLineButtonClick(object sender, EventArgs e)
        {
            _presentationModel.SetDrawShapeType(ShapeType.Line);
            _presentationModel.IsButtonDrawLineEnabled = false;
            _presentationModel.IsButtonDrawRectangleEnabled = true;
            _presentationModel.IsButtonDrawEllipseEnabled = true;
            _presentationModel.IsButtonChooseEnabled = true;
            RefreshControlStatus();
        }

        // 處理 Chooses按鈕點擊 事件
        public void HandleChooseButtonClick(object sender, EventArgs e)
        {
            _presentationModel.SetDrawShapeType(ShapeType.None);
            _presentationModel.IsButtonDrawLineEnabled = true;
            _presentationModel.IsButtonDrawEllipseEnabled = true;
            _presentationModel.IsButtonDrawRectangleEnabled = true;
            _presentationModel.IsButtonChooseEnabled = false;
            RefreshControlStatus();
        }

        // 處理 Rectangle按鈕點擊 事件
        public void HandleDrawRectangleButtonClick(object sender, EventArgs e)
        {
            _presentationModel.SetDrawShapeType(ShapeType.Rectangle);
            _presentationModel.IsButtonDrawLineEnabled = true;
            _presentationModel.IsButtonDrawRectangleEnabled = false;
            _presentationModel.IsButtonDrawEllipseEnabled = true;
            _presentationModel.IsButtonChooseEnabled = true;
            RefreshControlStatus();
        }

        // 處理 Ellipse按鈕點擊 事件
        public void HandleDrawEllipseButtonClick(object sender, EventArgs e)
        {
            _presentationModel.SetDrawShapeType(ShapeType.Ellipse);
            _presentationModel.IsButtonDrawLineEnabled = true;
            _presentationModel.IsButtonDrawEllipseEnabled = false;
            _presentationModel.IsButtonDrawRectangleEnabled = true;
            _presentationModel.IsButtonChooseEnabled = true;
            RefreshControlStatus();
        }

        // 處理畫布 滑鼠點擊事件
        public void HandleCanvasPointerPressed(object sender, MouseEventArgs e)
        {
            _presentationModel.HandlePointerPressed(e.X, e.Y);
        }

        // 處理畫布 滑鼠放開事件
        public void HandleCanvasPointerReleased(object sender, MouseEventArgs e)
        {
            _presentationModel.HandlePointerReleased(e.X, e.Y);
        }

        // 處理畫布 滑鼠移動事件
        public void HandleCanvasPointerMoved(object sender, MouseEventArgs e)
        {
            _presentationModel.HandlePointerMoved(e.X, e.Y);
        }

        // 處理畫布繪製事件
        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        //Handle Redo Event
        public void HandleRedo(object sender, EventArgs e)
        {
            _presentationModel.HandleRedo();
            HandleModelChanged();
        }

        //Handle Undo Event
        public void HandleUndo(object sender, EventArgs e)
        {
            _presentationModel.HandleUndo();
            HandleModelChanged();
        }

        // 處理 同步通知
        public void HandleModelChanged()
        {
            Invalidate(true);
            RefreshControlStatus();
        }

    }
}
