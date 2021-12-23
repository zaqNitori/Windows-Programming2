using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DrawingModel.Shape;

// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x404

namespace DrawingApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DrawingModel.DrawModel _model;
        PresentationModel.DrawingAppPresentationModel _presentationModel;

        public MainPage()
        {
            InitializeComponent();
            InitializeCanvas();
            InitializeButton();
            InitializePresentationModel();
            RefreshButtonStatus();
        }

        // 初始化 畫布
        private void InitializeCanvas()
        {
            _canvas.PointerPressed += HandleCanvasPointerPressed;
            _canvas.PointerReleased += HandleCanvasPointerReleased;
            _canvas.PointerMoved += HandleCanvasPointerMoved;
        }

        // 初始化 Button
        private void InitializeButton()
        {
            _buttonClear.Click += HandleClearButtonClick;
            _buttonDrawEllipse.Click += HandleDrawEllipseButtonClick;
            _buttonDrawRectangle.Click += HandleDrawRectangleButtonClick;
            _buttonChoose.Click += HandleChooseButtonClick;
            _buttonRedo.Click += HandleRedo;
            _buttonUndo.Click += HandleUndo;
        }

        // 初始化 PresentationModel
        private void InitializePresentationModel()
        {
            _model = new DrawingModel.DrawModel();
            _presentationModel = new PresentationModel.DrawingAppPresentationModel(_model, _canvas);
            _presentationModel._modelChanged += HandleModelChanged;
        }

        // 重置畫面按鈕狀態
        private void RefreshButtonStatus()
        {
            _buttonClear.IsEnabled = _presentationModel.IsButtonClearEnabled;
            _buttonDrawEllipse.IsEnabled = _presentationModel.IsButtonDrawEllipseEnabled;
            _buttonDrawRectangle.IsEnabled = _presentationModel.IsButtonDrawRectangleEnabled;
            _buttonRedo.IsEnabled = _presentationModel.IsButtonRedoEnabled;
            _buttonUndo.IsEnabled = _presentationModel.IsButtonUndoEnabled;
            _buttonChoose.IsEnabled = _presentationModel.IsButtonChooseEnabled;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached. 
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        // 處理畫面清除事件
        private void HandleClearButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Clear();
            _presentationModel.IsButtonDrawRectangleEnabled = true;
            _presentationModel.IsButtonDrawEllipseEnabled = true;
            _presentationModel.IsButtonChooseEnabled = true;
            RefreshButtonStatus();
        }

        // 處理 Chooses按鈕點擊 事件
        public void HandleChooseButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.SetDrawShapeType(ShapeType.None);
            _presentationModel.IsButtonDrawEllipseEnabled = true;
            _presentationModel.IsButtonDrawRectangleEnabled = true;
            _presentationModel.IsButtonChooseEnabled = false;
            RefreshButtonStatus();
        }

        // 處理 清除按鈕點擊 事件
        public void HandleDrawRectangleButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.SetDrawShapeType(ShapeType.Rectangle);
            _presentationModel.IsButtonDrawRectangleEnabled = false;
            _presentationModel.IsButtonDrawEllipseEnabled = true;
            _presentationModel.IsButtonChooseEnabled = true;
            RefreshButtonStatus();
        }

        // 處理 清除按鈕點擊 事件
        public void HandleDrawEllipseButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.SetDrawShapeType(ShapeType.Ellipse);
            _presentationModel.IsButtonDrawEllipseEnabled = false;
            _presentationModel.IsButtonDrawRectangleEnabled = true;
            _presentationModel.IsButtonChooseEnabled = true;
            RefreshButtonStatus();
        }

        // 處理畫布 滑鼠點擊事件
        public void HandleCanvasPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _presentationModel.HandlePointerPressed(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // 處理畫布 滑鼠放開事件
        public void HandleCanvasPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            _presentationModel.HandlePointerReleased(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // 處理畫布 滑鼠移動事件
        public void HandleCanvasPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            _presentationModel.HandlePointerMoved(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // 處理 Redo 事件
        public void HandleRedo(object sender, RoutedEventArgs e)
        {
            _presentationModel.HandleRedo();
            HandleModelChanged();
        }

        // 處理 Undo 事件
        public void HandleUndo(object sender, RoutedEventArgs e)
        {
            _presentationModel.HandleUndo();
            HandleModelChanged();
        }

        // 處理 同步通知
        public void HandleModelChanged()
        {
            _presentationModel.Draw();
            RefreshButtonStatus();
        }

    }
}
