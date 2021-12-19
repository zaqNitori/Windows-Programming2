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
        private const string NO_REDO_COMMAND_EXCEPTION = "No Redo Command!!";
        private const string NO_UNDO_COMMAND_EXCEPTION = "No Undo Command!!";

        public DrawCommandManager()
        {
            _redoCommand = new Stack<ICommand>();
            _undoCommand = new Stack<ICommand>();
        }

        public bool IsButtonUndoEnabled
        {
            get
            {
                return _undoCommand.Count > 0;
            }
        }

        public bool IsButtonRedoEnabled
        {
            get
            {
                return _redoCommand.Count > 0;
            }
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
                throw new Exception(NO_REDO_COMMAND_EXCEPTION);
            }
            _undoCommand.Push(_redoCommand.Peek());
            _redoCommand.Pop().Execute();
        }

        //Undo
        public void Undo()
        {
            if (_undoCommand.Count <= 0)
            {
                throw new Exception(NO_UNDO_COMMAND_EXCEPTION);
            }
            _redoCommand.Push(_undoCommand.Peek());
            _undoCommand.Pop().ReverseExecute();
        }

        //Clear All stack
        public void Clear()
        {
            _redoCommand.Clear();
            _undoCommand.Clear();
        }

    }
}
