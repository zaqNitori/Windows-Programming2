namespace DrawingModel
{
    class Line
    {
        public double x1;
        public double y1;
        public double x2;
        public double y2;

        /// <summary>
        /// 繪製
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(IGraphics graphics)
        {
            graphics.DrawLine(x1, y1, x2, y2);
        }
    }
}
