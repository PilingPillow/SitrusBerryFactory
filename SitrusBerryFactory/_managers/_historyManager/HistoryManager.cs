using System;
using System.Collections.Generic;

namespace SitrusBerryFactory._managers._historyManager
{
    public sealed class HistoryManager
    {
        public event EventHandler StateChanged = null;
        public readonly List<ICommand> CommandList = null;
        public int CurrentIndex = 0;

        // Checks whether Undo or Redo is available
        public bool CanUndo => CurrentIndex > 0;
        public bool CanRedo => CurrentIndex < CommandList.Count;

        public HistoryManager()
        {
            CommandList = new List<ICommand>();
        }

        public void PushCommand(ICommand command)
        {
            ExecuteAndNotify(() =>
            {
                // Remove Redo history when a new command is added after Undo
                if (CurrentIndex < CommandList.Count)
                {
                    CommandList.RemoveRange(
                        CurrentIndex,
                        CommandList.Count - CurrentIndex);
                }

                CommandList.Add(command);
                CurrentIndex++;
            });
        }

        public void Undo()
        {
            if (!CanUndo) return;

            ExecuteAndNotify(() =>
            {
                CurrentIndex--;
                CommandList[CurrentIndex].Undo();
            });
        }

        public void Redo()
        {
            if (!CanRedo) return;

            ExecuteAndNotify(() =>
            {
                CommandList[CurrentIndex].Redo();
                CurrentIndex++;
            });
        }

        private void ExecuteAndNotify(Action action)
        {
            action();
            StateChanged?.Invoke(this, EventArgs.Empty);
        }

        public void MoveTo(int targetIndex)
        {
            while (CurrentIndex > targetIndex)
            {
                Undo();
            }

            while (CurrentIndex < targetIndex)
            {
                Redo();
            }
        }

        public void Clear()
        {
            ExecuteAndNotify(() =>
            {
                CommandList.Clear();
                CurrentIndex = 0;
            });
        }
    }

    public interface ICommand
    {
        string Desc { get; }

        void Undo();
        void Redo();
    }
}
