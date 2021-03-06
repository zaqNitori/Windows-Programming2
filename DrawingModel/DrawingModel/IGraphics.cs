namespace DrawingModel
{
    public interface IGraphics
    {
        /// <summary>
        /// 清除畫布
        /// </summary>
        void ClearAll();

        /// <summary>
        /// 畫線
        /// </summary>
        void DrawLine(double x1, double y1, double x2, double y2);

        /// <summary>
        /// 畫矩形
        /// </summary>
        void DrawRectangle(double x1, double y1, double x2, double y2);

        /// <summary>
        /// 畫圓
        /// </summary>
        void DrawEllipse(double x1, double y1, double x2, double y2);

        // 畫矩形
        void FillRectangle(double x1, double y1, double x2, double y2);

        // 畫圓
        void FillEllipse(double x1, double y1, double x2, double y2);
    }
}
