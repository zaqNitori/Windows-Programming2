using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Command
{
    public class DrawCommandManager
    {
        private Stack<ICommand> _redoCommand;
        private Stack<ICommand> _undoCommand;

        public DrawCommandManager()
        {
            _redoCommand = new Stack<ICommand>();
            _undoCommand = new Stack<ICommand>();
        }

        //Save Command And Execute Operation
        public void Execute(DrawCommand drawCommand)
        {
            drawCommand.Execute();
            _undoCommand.Push(drawCommand);
            _redoCommand.Clear();
        }

        //Redo
        public void Redo()
        {
            if (_redoCommand.Count <= 0)
            {
                throw new Exception("No Redo Command!!");
            }
            _undoCommand.Push(_redoCommand.Peek());
            _redoCommand.Pop().Execute();
        }

        //Undo
        public void Undo()
        {
            if (_undoCommand.Count <= 0)
            {
                throw new Exception("No Undo Command!!");
            }
            _redoCommand.Push(_undoCommand.Peek());
            _undoCommand.Pop().UnExecute();
        }

    }
}
