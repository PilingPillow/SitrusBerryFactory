using System;
using System.Collections.Generic;

namespace SitrusBerryFactory._managers._historyManager
{
    public sealed class HistoryManager
    {
        public EventHandler StateChanged { get; set; }
        public List<ICommand> History { get; }
        public int CurrentIndex { get; private set; }

        public HistoryManager()
        {
            History = new List<ICommand>();
        }

        // Checks whether Undo or Redo is available
        public bool CanUndo => CurrentIndex > 0;
        public bool CanRedo => CurrentIndex < History.Count;

        public void PushCommand(ICommand command)
        {
            ExecuteAndNotify(() =>
            {
                // Remove Redo history when a new command is added after Undo
                if (CurrentIndex < History.Count)
                {
                    History.RemoveRange(
                        CurrentIndex,
                        History.Count - CurrentIndex);
                }

                History.Add(command);
                CurrentIndex++;
            });
        }

        public void Undo()
        {
            if (!CanUndo) return;

            ExecuteAndNotify(() =>
            {
                CurrentIndex--;
                History[CurrentIndex].Undo();
            });
        }

        public void Redo()
        {
            if (!CanRedo) return;

            ExecuteAndNotify(() =>
            {
                History[CurrentIndex].Redo();
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
                History.Clear();
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