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

// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x404

namespace DrawingApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DrawingModel.DrawModel _model;
        PresentationModel.DrawingAppPresentationModel _drawingAppPresentationModel;


        public MainPage()
        {
            this.InitializeComponent();
            _model = new DrawingModel.DrawModel();
            _drawingAppPresentationModel = new PresentationModel.DrawingAppPresentationModel(_model, _canvas);
            _canvas.Background = new SolidColorBrush(Colors.White);
            _canvas.PointerPressed += HandleCanvasPointerPressed;
            _canvas.PointerReleased += HandleCanvasPointerReleased;
            _canvas.PointerMoved += HandleCanvasPointerMoved;
            _buttonClear.Click += HandleClearButtonClick;
            _model._modelChanged += HandleModelChanged;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached. 
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        /// <summary>
        /// 處理畫面清除事件
        /// </summary>
        private void HandleClearButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Clear();
        }

        /// <summary>
        /// 處理畫布 滑鼠點擊事件
        /// </summary>
        public void HandleCanvasPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _model.PointerPressed(e.GetCurrentPoint(_canvas).Position.X,
           e.GetCurrentPoint(_canvas).Position.Y);
        }

        /// <summary>
        /// 處理畫布 滑鼠放開事件
        /// </summary>
        public void HandleCanvasPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            _model.PointerReleased(e.GetCurrentPoint(_canvas).Position.X,
           e.GetCurrentPoint(_canvas).Position.Y);
        }

        /// <summary>
        /// 處理畫布 滑鼠移動事件
        /// </summary>
        public void HandleCanvasPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            _model.PointerMoved(e.GetCurrentPoint(_canvas).Position.X,
           e.GetCurrentPoint(_canvas).Position.Y);
        }

        /// <summary>
        /// 處理 同步通知
        /// </summary>
        public void HandleModelChanged()
        {
            _drawingAppPresentationModel.Draw();
        }

    }
}
