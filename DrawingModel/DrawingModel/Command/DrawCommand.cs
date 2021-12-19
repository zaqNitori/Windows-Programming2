using DrawingModel.Shape;

namespace DrawingModel.Command
{
    public class DrawCommand : ICommand
    {
        DrawModel _drawModel;
        IShape _shape;

        public DrawCommand(DrawModel drawModel, IShape shape)
        {
            _drawModel = drawModel;
            _shape = shape;
        }

        //Execute
        public void Execute()
        {
            _drawModel.InsertShape(_shape);
        }

        //UnExecute
        public void UnExecute()
        {
            _drawModel.DeleteShape();
        }

    }
}
