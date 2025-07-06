using System.Collections.Generic;
using taskt.Core.Script;

namespace taskt.UI.Forms
{
    /// <summary>
    /// Undo, Redo manager for frmScriptBuilder
    /// </summary>
    public class UndoRedoManager4frmScriptBuilder
    {
        /// <summary>
        /// undo stack
        /// </summary>
        private readonly Stack<Script> undo = new Stack<Script>();
        /// <summary>
        /// redo stack
        /// </summary>
        private readonly Stack<Script> redo = new Stack<Script>();
        
        /// <summary>
        /// can undo?
        /// </summary>
        public bool CanUndo { get => (this.undo.Count > 0); }
        /// <summary>
        /// can redo?
        /// </summary>
        public bool CanRedo { get => (this.redo.Count > 0); }

        public UndoRedoManager4frmScriptBuilder() { }

        /// <summary>
        /// add snapshot
        /// </summary>
        /// <param name="script"></param>
        public void AddSnapshot(Script script)
        {
            undo.Push(script);
        }

        /// <summary>
        /// undo
        /// </summary>
        /// <returns></returns>
        public Script Undo()
        {
            if (CanUndo)
            {
                var ret = undo.Pop();
                redo.Push(ret);
                return ret;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// redo
        /// </summary>
        /// <returns></returns>
        public Script Redo()
        {
            if (CanRedo)
            {
                var ret = redo.Pop();
                undo.Push(ret);
                return ret;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// clear undo, redo data
        /// </summary>
        public void Clear() 
        { 
            undo.Clear();
            redo.Clear(); 
        } 
    }
}
