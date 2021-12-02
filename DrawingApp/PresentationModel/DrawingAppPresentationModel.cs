using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using DrawingModel;

namespace DrawingApp.PresentationModel
{
    class DrawingAppPresentationModel
    {
        DrawModel _model;
        IGraphics _igraphics;

        public DrawingAppPresentationModel(DrawModel model, Canvas canvas)
        {
            this._model = model;
            _igraphics = new DrawingAppGraphicsAdaptor(canvas);
        }

        /// <summary>
        /// 繪製
        /// </summary>
        public void Draw()
        {
            // 重複使用igraphics物件
            _model.Draw(_igraphics);
        }
    }
}
